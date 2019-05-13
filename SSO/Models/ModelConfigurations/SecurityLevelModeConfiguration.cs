using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSO.Models.ModelConfigurations
{
    public class SecurityLevelModeConfiguration : IEntityTypeConfiguration<SecurityLevelMode>
    {
        public void Configure(EntityTypeBuilder<SecurityLevelMode> builder)
        {
            builder.ToTable("SecurityLevelMode", "SSO");

            builder.HasOne(b => b.SecurityLevel)
                .WithMany(b => b.SecurityLevelModes)
                .HasForeignKey(b => b.SecurityLevelId);

            builder.HasOne(b => b.SecurityMode)
                .WithMany()
                .HasForeignKey(b => b.SecurityModeId);

        }
    }
}
