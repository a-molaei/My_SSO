using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models.ModelConfigurations
{
    public class MobileVerificationCodeConfiguration : IEntityTypeConfiguration<MobileVerificationCode>
    {
        public void Configure(EntityTypeBuilder<MobileVerificationCode> builder)
        {
            builder.ToTable("MobileVerificationCodes", "SSO");
            builder.Property(b => b.MobileNumber).HasMaxLength(11);
            builder.HasOne(b => b.CreatedByUser)
                .WithMany(b => b.MobileVerificationCodes)
                .HasForeignKey(b => b.CreatedByUserId);
        }
    }
}
