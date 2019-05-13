using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models.ModelConfigurations
{
    public class HardwareTokenCodeConfiguration : IEntityTypeConfiguration<HardwareTokenCode>
    {
        public void Configure(EntityTypeBuilder<HardwareTokenCode> builder)
        {
            builder.ToTable("HardwareTokenCodes", "SSO");
            builder.Property(b => b.OTP).HasMaxLength(4);
            builder.HasOne(b => b.CreatedByUser)
                .WithMany(b => b.HardwareTokenCodes)
                .HasForeignKey(b => b.CreatedByUserId);
        }
    }
}
