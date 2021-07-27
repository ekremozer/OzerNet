using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OzerNet.Dal.EntityFrameWork.Base;
using OzerNet.Utility.Infrastructure;

namespace OzerNet.Dal.EntityFrameWork.MsSql
{
    public class MsSqlContext : EfContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppParameters.ConnectionString);
        }
    }
}
