using SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class SettingDto
    {
        public int Id { get; set; }
        public int MaxFailedPasswordCount { get; set; }
        public int LockOutDuration { get; set; }
        public int TokenExpirationDuration { get; set; }
        public int PasswordExpirationDuration { get; set; }
        public void SaveTo(Setting obj)
        {
            this.Id = obj.Id;
            this.MaxFailedPasswordCount = obj.MaxFailedPasswordCount;
            this.LockOutDuration = obj.LockOutDuration;
            this.TokenExpirationDuration = obj.TokenExpirationDuration;
            this.PasswordExpirationDuration = obj.PasswordExpirationDuration;
        }
        public Setting LoadFrom()
        {
            var obj = new Setting()
            {
                MaxFailedPasswordCount = this.MaxFailedPasswordCount,
                LockOutDuration = this.LockOutDuration,
                TokenExpirationDuration = this.TokenExpirationDuration,
                PasswordExpirationDuration = this.PasswordExpirationDuration
            };
            return obj;
        }
        public Setting CheckChanges(Setting obj)
        {

            obj.MaxFailedPasswordCount = this.MaxFailedPasswordCount;
            obj.LockOutDuration = this.LockOutDuration;
            obj.TokenExpirationDuration = this.TokenExpirationDuration;
            obj.PasswordExpirationDuration = this.PasswordExpirationDuration;
            return obj;
        }
    }
}
