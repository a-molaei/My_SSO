using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models.ModelConfigurations
{
    public class AuthenticationStepConfiguration : IEntityTypeConfiguration<AuthenticationStep>
    {
        public void Configure(EntityTypeBuilder<AuthenticationStep> builder)
        {
            builder.ToTable("AuthenticationSteps", "SSO");
            builder.HasOne(b => b.User)
                .WithMany()
                .HasForeignKey(b => b.UserId);

            builder.HasOne(b => b.SecurityMode)
                .WithMany()
                .HasForeignKey(b => b.SecurityModeId);
        }
    }
}
