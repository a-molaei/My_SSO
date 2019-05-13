using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class HardwareTokenCode
    {
        public int Id { get; set; }
        public string OTP { get; set; }
        public bool IsVerified { get; set; }
        public DateTime CreationDateTime { get; set; }
        public string CreatedByUserId { get; set; }
        public virtual User CreatedByUser { get; set; }
    }
}
