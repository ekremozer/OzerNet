using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using OzerNet.Commands.Infrastructure;

namespace OzerNet.WepApi.Infrastructure
{
    public static class DocumentHelper
    {
        public static List<Document> GenerateDocument(string commandName = "")
        {
            var documents = new List<Document>();
            var types = Assembly.GetAssembly(typeof(Command))?.DefinedTypes
                .Where(x => x.BaseType == typeof(Command) &&
                            (string.IsNullOrEmpty(commandName) ||
                             x.Name.ToLowerInvariant().Contains(commandName.ToLowerInvariant())));

            if (types == null) return documents;

            foreach (var type in types)
            {
                var authorizedAttribute = type.GetCustomAttribute<AuthorizedAttribute>();
                var describeAttribute = type.GetCustomAttribute<DescribeAttribute>();
                var description = string.Empty;

                if (describeAttribute != null) description = describeAttribute.Description;

                var inputs = new Dictionary<string, string>();

                var excludeProperty = new[] { "PostUrl", "HttpRequest" };
                foreach (var prop in type.GetProperties().ToList())
                {
                    if (excludeProperty.Contains(prop.Name)) continue;
                    inputs[prop.Name] = prop.PropertyType.Name;
                }

                var needToken = authorizedAttribute == null ? "(Needs_token)" : string.Empty;

                var document = documents.FirstOrDefault(h => h.Module == describeAttribute?.Module.ToString());

                if (document == null)
                {
                    if (describeAttribute != null)
                    {
                        document = new Document
                        {
                            Module = describeAttribute.Module.ToString(),
                            Commands = new List<dynamic>()
                        };
                        documents.Add(document);
                    }
                }

                document?.Commands.Add(new
                {
                    Process = describeAttribute?.Process.ToString(),
                    Description = description,
                    Name = $"{type.Name} {needToken}",
                    Post = inputs
                });
            }
            return documents;
        }
    }
}
