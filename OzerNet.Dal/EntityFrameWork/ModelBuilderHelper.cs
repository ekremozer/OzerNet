using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using OzerNet.Entities.Users;

namespace OzerNet.Dal.EntityFrameWork
{
    public static class ModelBuilderHelper
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(x => x.Uid).HasName("user_Uid").IsUnique(true);
                entity.HasOne(x => x.UserRole).WithMany(x => x.Users).HasForeignKey(x => x.UserRoleUid);
                entity.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedUsers).HasForeignKey(x => x.CreatedBy);
                entity.HasOne(x => x.UpdatedByUser).WithMany(x => x.UpdatedUsers).HasForeignKey(x => x.UpdatedBy);
                entity.HasOne(x => x.DeletedByUser).WithMany(x => x.DeletedUsers).HasForeignKey(x => x.DeletedBy);
                entity.HasQueryFilter(x => !x.Deleted);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(x => x.Uid).HasName("userRole_Uid").IsUnique(true);
                entity.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedUserRoles).HasForeignKey(x => x.CreatedBy);
                entity.HasOne(x => x.UpdatedByUser).WithMany(x => x.UpdatedUserRoles).HasForeignKey(x => x.UpdatedBy);
                entity.HasOne(x => x.DeletedByUser).WithMany(x => x.DeletedUserRoles).HasForeignKey(x => x.DeletedBy);
                entity.HasQueryFilter(x => !x.Deleted);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasIndex(x => x.Uid).HasName("module_Uid").IsUnique(true);
                entity.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedUserModules).HasForeignKey(x => x.CreatedBy);
                entity.HasOne(x => x.UpdatedByUser).WithMany(x => x.UpdatedUserModules).HasForeignKey(x => x.UpdatedBy);
                entity.HasOne(x => x.DeletedByUser).WithMany(x => x.DeletedUserModules).HasForeignKey(x => x.DeletedBy);
                entity.HasQueryFilter(x => !x.Deleted);
            });

            modelBuilder.Entity<ModuleAuthority>(entity =>
            {
                entity.HasIndex(x => x.Uid).HasName("moduleAuthority_Uid").IsUnique(true);
                entity.HasOne(x => x.Module).WithMany(x => x.ModuleAuthorities).HasForeignKey(x => x.ModuleUid);
                entity.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedUserModuleAuthorities).HasForeignKey(x => x.CreatedBy);
                entity.HasOne(x => x.UpdatedByUser).WithMany(x => x.UpdatedUserModuleAuthorities).HasForeignKey(x => x.UpdatedBy);
                entity.HasOne(x => x.DeletedByUser).WithMany(x => x.DeletedUserModuleAuthorities).HasForeignKey(x => x.DeletedBy);
                entity.HasQueryFilter(x => !x.Deleted);
            });

            modelBuilder.Entity<RoleAuthority>(entity =>
            {
                entity.HasIndex(x => x.Uid).HasName("roleAuthority_Uid").IsUnique(true);
                entity.HasOne(x => x.UserRole).WithMany(x => x.RoleAuthorities).HasForeignKey(x => x.UserRoleUid);
                entity.HasOne(x => x.ModuleAuthority).WithMany(x => x.RoleAuthorities).HasForeignKey(x => x.ModuleAuthorityUid);
                entity.HasOne(x => x.CreatedByUser).WithMany(x => x.CreatedUserRoleAuthorities).HasForeignKey(x => x.CreatedBy);
                entity.HasOne(x => x.UpdatedByUser).WithMany(x => x.UpdatedUserRoleAuthorities).HasForeignKey(x => x.UpdatedBy);
                entity.HasOne(x => x.DeletedByUser).WithMany(x => x.DeletedUserRoleAuthorities).HasForeignKey(x => x.DeletedBy);
                entity.HasQueryFilter(x => !x.Deleted);
            });
        }
    }
}
