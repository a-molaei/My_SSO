using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSO.Models.ModelConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRoles", "SSO");
            builder.Property(b => b.UserId).HasMaxLength(128);
            builder.Property(b => b.RoleId).HasMaxLength(128);
            builder.HasOne(b => b.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.Role)
                .WithMany()
                .HasForeignKey(b => b.RoleId);
        }
    }
}
