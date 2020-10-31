using System;

namespace OzerNet.Commands.Infrastructure
{
    public class DescribeAttribute : Attribute
    {
        public string Description { get; }
        public Module Module { get; }
        public Process Process { get; }
        public DescribeAttribute(Module module, Process process, string description)
        {
            Description = description;
            Module = module;
            Process = process;
        }
    }
    public enum Module
    {
        User = 1,
        Common = 2
    }
    public enum Process
    {
        None = 0,
        Create = 1,
        Read = 2,
        Update = 3,
        Delete = 4
    }
}
