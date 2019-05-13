using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public int MaxFailedPasswordCount { get; set; }
        public int LockOutDuration { get; set; }
        public int TokenExpirationDuration { get; set; }
        public int PasswordExpirationDuration { get; set; }

    }
}
