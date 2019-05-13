using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class UserRestrictedIp
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public bool IsActive { get; set; }
    }
}
