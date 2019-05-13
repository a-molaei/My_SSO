using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models.ModelConfigurations
{
    public class PhoneVerificationCodeConfiguration : IEntityTypeConfiguration<PhoneVerificationCode>
    {
        public void Configure(EntityTypeBuilder<PhoneVerificationCode> builder)
        {
            builder.ToTable("PhoneVerificationCodes", "SSO");
            builder.Property(b => b.MobileNumber).HasMaxLength(11);
            builder.HasOne(b => b.CreatedByUser)
                .WithMany(b => b.PhoneVerificationCodes)
                .HasForeignKey(b => b.CreatedByUserId);
        }
    }
}
