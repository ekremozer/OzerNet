using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OzerNet.Dal.EntityFrameWork.Base;
using OzerNet.Entities.Users;
using OzerNet.Utility.Infrastructure;

namespace OzerNet.Dal.EntityFrameWork.MsSql
{
    public class PostgreSqlContext : EfContext
    {
        public DbSet<PostgreTemp> PostgreUsers { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(AppParameters.ConnectionString);
        }
    }
}
