using OzerNet.Entities;
using Microsoft.EntityFrameworkCore;
using OzerNet.Entities.Users;

namespace OzerNet.Dal.EntityFrameWork
{
    public class EfContext : DbContext
    {
        private readonly string _connectionString;
        public EfContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<ModuleAuthority> ModuleAuthorities { get; set; }
        public DbSet<RoleAuthority> RoleAuthorities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelBuilderHelper.OnModelCreating(modelBuilder);
        }
    }
}