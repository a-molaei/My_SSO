using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSO.Models.ModelConfigurations
{
    public class SecurityModeConfiguration : IEntityTypeConfiguration<SecurityMode>
    {
        public void Configure(EntityTypeBuilder<SecurityMode> builder)
        {
            builder.ToTable("SecurityModes", "SSO");
            builder.Property(b => b.Title).HasMaxLength(50);
        }
    }
}
