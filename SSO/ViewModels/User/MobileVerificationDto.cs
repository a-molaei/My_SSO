using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class MobileVerificationDto
    {
        public string MobileNumber { get; set; }
        public string Code { get; set; }
        public int SecurityLevel { get; set; }
    }
}
