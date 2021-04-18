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

                foreach (var prop in type.GetProperties().Where(x => x.DeclaringType?.FullName != "OzerNet.Commands.Infrastructure.Command").ToList())
                {
                    if (prop.PropertyType.Name == "List`1")
                    {
                        var listType = prop.PropertyType.GenericTypeArguments.FirstOrDefault()?.Name;
                        if (!string.IsNullOrEmpty(listType))
                        {
                            inputs[prop.Name] = $"List<{listType}>";
                        }
                        else
                        {
                            inputs[prop.Name] = prop.PropertyType.Name;
                        }
                    }
                    else
                    {
                        inputs[prop.Name] = prop.PropertyType.Name;
                    }

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
                    Name = $"{type.Name} {needToken}",
                    Process = describeAttribute?.Process.ToString(),
                    Description = description,
                    Post = inputs
                });
            }
            return documents;
        }
    }
}
