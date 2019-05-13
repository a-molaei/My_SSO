using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models.ModelConfigurations
{
    public class RoleActionConfiguration : IEntityTypeConfiguration<RoleAction>
    {
        public void Configure(EntityTypeBuilder<RoleAction> builder)
        {
            builder.ToTable("RoleActions", "SSO");
            builder.Property(b => b.RoleId).HasMaxLength(128);
            builder.HasOne(b => b.Role)
                .WithMany(b => b.RoleActions)
                .HasForeignKey(b => b.RoleId);

            builder.HasOne(b => b.Action)
                .WithMany()
                .HasForeignKey(b => b.ActionId);
        }
    }
}
