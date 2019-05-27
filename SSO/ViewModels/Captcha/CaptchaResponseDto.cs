using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels.Captcha
{
    public class CaptchaResponseDto
    {
        public string CaptchaImage { get; set; }
        public string Key { get; set; }
    }
}
