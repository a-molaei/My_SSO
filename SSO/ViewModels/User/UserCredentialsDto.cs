using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class UserCredentialsDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int RequestedSecurityLevel { get; set; }
        public string CaptchaKey { get; set; }
        public string UserCaptchaInput { get; set; }
    }
}
