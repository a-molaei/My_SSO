using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSO.Models.ModelConfigurations
{
    public class UserRestrictedIpConfiguration : IEntityTypeConfiguration<UserRestrictedIp>
    {
        public void Configure(EntityTypeBuilder<UserRestrictedIp> builder)
        {
            builder.ToTable("UserRestrictedIps", "SSO");
            builder.Property(b => b.Ip).HasMaxLength(50);
            builder.HasOne(b => b.User)
                .WithMany(b => b.UserRestrictedIps)
                .HasForeignKey(b => b.UserId);
        }
    }
}
