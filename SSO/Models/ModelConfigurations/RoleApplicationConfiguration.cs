using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models.ModelConfigurations
{
    public class RoleApplicationConfiguration : IEntityTypeConfiguration<RoleApplication>
    {
        public void Configure(EntityTypeBuilder<RoleApplication> builder)
        {
            builder.ToTable("RoleApplications", "SSO");
            builder.Property(b => b.RoleId).HasMaxLength(128);
            builder.HasOne(b => b.Role)
                .WithMany(b => b.RoleApplications)
                .HasForeignKey(b => b.RoleId);

            builder.HasOne(b => b.Application)
                .WithMany()
                .HasForeignKey(b => b.ApplicationId);
        }
    }
}
