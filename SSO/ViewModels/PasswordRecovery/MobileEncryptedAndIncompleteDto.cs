using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels.PasswordRecovery
{
    public class MobileEncryptedAndIncompleteDto
    {
        public string IncompleteMobileNumber { get; set; }
        public string EncryptedMobileNumber { get; set; }
    }
}
