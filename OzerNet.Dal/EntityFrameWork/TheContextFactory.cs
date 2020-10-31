using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Options;

namespace OzerNet.Dal.EntityFrameWork
{
    public class TheContextFactory : IContextFactory
    {
        public string ConnectionString { get; set; }
        public TheContextFactory(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public EfContext Create()
        {
            return new EfContext(ConnectionString);
        }
    }
}
