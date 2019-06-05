using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class MobileVerificationDto
    {
        public string EncryptedMobileNumber { get; set; }
        public string Code { get; set; }
        public int SecurityLevel { get; set; }
        public int RequestedSecurityLevel { get; set; }
        public int ApplicationId { get; set; }
        public int PageId { get; set; }
    }
}
