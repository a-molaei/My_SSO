using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid().ToString();
            SecurityStamp = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string MobileNumber { get; set; }
        public int? PersonId { get; set; }
        public bool IsLocked { get; set; }
        public string SecurityStamp { get; set; }
        public int AccessFailedCount { get; set; }
        public bool LockOutEnabled { get; set; }
        public DateTime? LockOutEndDate { get; set; }
        public DateTime LastPasswordChangeDateTime { get; set; }
        public bool ForcePasswordChange { get; set; }
        public DateTime CreationDateTime { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<UserRestrictedIp> UserRestrictedIps { get; set; }
        public virtual ICollection<MobileVerificationCode> MobileVerificationCodes { get; set; }
        public virtual ICollection<HardwareTokenCode> HardwareTokenCodes { get; set; }

    }
}
