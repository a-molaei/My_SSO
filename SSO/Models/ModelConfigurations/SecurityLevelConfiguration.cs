using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSO.Models.ModelConfigurations
{
    public class SecurityLevelConfiguration : IEntityTypeConfiguration<SecurityLevel>
    {
        public void Configure(EntityTypeBuilder<SecurityLevel> builder)
        {
            builder.ToTable("SecurityLevels", "SSO");
            builder.Property(b => b.Title).HasMaxLength(50);
        }
    }
}
