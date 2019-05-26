using Microsoft.EntityFrameworkCore;
using SSO.Models.ModelConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models.SsoDbContext
{
    public class SsoDbContext : DbContext
    {
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<RoleAction> RoleAction { get; set; }
        public virtual DbSet<RoleApplication> RoleApplication { get; set; }
        public virtual DbSet<UserRestrictedIp> UserRestrictedIp { get; set; }
        public virtual DbSet<MobileVerificationCode> MobileVerificationCode { get; set; }
        public virtual DbSet<HardwareTokenCode> HardwareTokenCode { get; set; }
        public virtual DbSet<SecurityLevel> SecurityLevel { get; set; }
        public virtual DbSet<SecurityMode> SecurityMode { get; set; }
        public virtual DbSet<SecurityLevelMode> SecurityLevelMode { get; set; }
        public virtual DbSet<RoleGroup> RoleGroup { get; set; }
        public virtual DbSet<Session> Session { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }




        public SsoDbContext(DbContextOptions<SsoDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
            builder.ApplyConfiguration(new ActionConfiguration());
            builder.ApplyConfiguration(new ApplicationConfiguration());
            builder.ApplyConfiguration(new RoleActionConfiguration());
            builder.ApplyConfiguration(new RoleApplicationConfiguration());
            builder.ApplyConfiguration(new RoleGroupConfiguration());
            builder.ApplyConfiguration(new SecurityLevelConfiguration());
            builder.ApplyConfiguration(new SecurityModeConfiguration());
            builder.ApplyConfiguration(new SecurityLevelModeConfiguration());
            builder.ApplyConfiguration(new SettingConfiguration());
            builder.ApplyConfiguration(new SessionConfiguration());
            builder.ApplyConfiguration(new MobileVerificationCodeConfiguration());
            builder.ApplyConfiguration(new HardwareTokenCodeConfiguration());
            builder.ApplyConfiguration(new UserRestrictedIpConfiguration());




        }
    }
}
