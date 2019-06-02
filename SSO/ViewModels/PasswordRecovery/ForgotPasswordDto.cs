using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels.PasswordRecovery
{
    public class ForgotPasswordDto
    {
        public string NationalCode { get; set; }
        public string EncryptedEmail { get; set; }
        public string EncryptedMobileNumber { get; set; }
        public string CaptchaKey { get; set; }
        public string UserCaptchaInput { get; set; }
    }
}
