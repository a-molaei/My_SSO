using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models.ModelConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "SSO");
            builder.Property(b => b.Id).HasMaxLength(128);
            builder.Property(b => b.Title).HasMaxLength(50);
            builder.HasOne(b => b.RoleGroup)
                .WithMany(b => b.Roles)
                .HasForeignKey(b => b.RoleGroupId);
        }
    }
}
