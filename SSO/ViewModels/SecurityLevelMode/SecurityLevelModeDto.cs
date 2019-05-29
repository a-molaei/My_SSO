using SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class SecurityLevelModeDto
    {
        public int Id { get; set; }
        public SecurityLevelDto SecurityLevel { get; set; }
        public SecurityModeDto SecurityMode { get; set; }
        public void SaveTo(SecurityLevelMode obj)
        {
            this.Id = obj.Id;
            if(obj.SecurityMode != null)
            {
                this.SecurityMode = new SecurityModeDto();
                this.SecurityMode.SaveTo(obj.SecurityMode);
            }
            if (obj.SecurityLevel != null)
            {
                this.SecurityLevel = new SecurityLevelDto();
                this.SecurityLevel.SaveTo(obj.SecurityLevel);
            }
        }
    }
}
