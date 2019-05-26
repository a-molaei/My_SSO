using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SSO.Models.ModelConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "SSO");
            builder.Property(b => b.Id).HasMaxLength(128);
            builder.Property(b => b.SecurityStamp).HasMaxLength(128);
            builder.Property(b => b.UserName).HasMaxLength(10);
            builder.Property(b => b.MobileNumber).HasMaxLength(11);
        }
    }
}
