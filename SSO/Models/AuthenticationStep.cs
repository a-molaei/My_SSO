using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class AuthenticationStep
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int SecurityLevelId { get; set; }
        public SecurityLevel SecurityLevel { get; set; }
        public DateTime CreationDateTime { get; set; }
    }
}
