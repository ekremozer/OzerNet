using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzerNet.Utility.Infrastructure
{
    public class AppSettings
    {
        public List<ConnectionStrings> ConnectionStrings { get; set; }
        public string DbCreatePassword { get; set; }
        public string DefaultDbConnection { get; set; }
    }
}

public class ConnectionStrings
{
    public string Name { get; set; }
    public string Value { get; set; }
}