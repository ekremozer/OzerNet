using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzerNet.Utility.Infrastructure
{
    public class AppSettings
    {
        public ConnectionStrings ConnectionStrings { get; set; }
        public string DbCreatePassword { get; set; }
        public string DefaultDbConnection { get; set; }
    }
}

public class ConnectionStrings
{
    public string MsSqlData { get; set; }
    public string MsSqlDev { get; set; }
    public string MsSqlTest { get; set; }
    public string MsSqlProd { get; set; }
    public string PostgreSqlData { get; set; }
    public string PostgreSqlDev { get; set; }
    public string PostgreSqlTest { get; set; }
    public string PostgreSqlProd { get; set; }
}