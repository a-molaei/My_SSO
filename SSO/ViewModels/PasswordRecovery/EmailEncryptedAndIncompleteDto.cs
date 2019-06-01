using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels.PasswordRecovery
{
    public class EmailEncryptedAndIncompleteDto
    {
        public string IncompleteEmail { get; set; }
        public string EncrypedEmail { get; set; }
    }
}
