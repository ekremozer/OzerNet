using OzerNet.Entities;
using Microsoft.EntityFrameworkCore;
using OzerNet.Entities.Users;
using OzerNet.Utility.Infrastructure;

namespace OzerNet.Dal.EntityFrameWork.Base
{
    public class EfContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleAuthority> ModuleAuthorities { get; set; }
        public DbSet<RoleAuthority> RoleAuthorities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(AppParameters.ConnectionString);
            //optionsBuilder.UseNpgsql(AppParameters.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilderHelper.OnModelCreating(modelBuilder);
        }
    }
}