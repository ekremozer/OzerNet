using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzerNet.WepApi.Infrastructure
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string DbCreatePassword { get; set; }
    }
}

public class ConnectionStrings
{
    public string Data { get; set; }
    public string Dev { get; set; }
    public string Test { get; set; }
    public string Prod { get; set; }
}