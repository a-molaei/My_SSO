using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels.IbToken
{
    public class IbTokenAuthenticate
    {
        public int[] RandomKeys { get; set; }
        public string TokenResult { get; set; }
        public string UserName { get; set; }
        public string DeviceId { get; set; }
        public int RequestedSecurityLevel { get; set; }
        public int ApplicationId { get; set; }
        public int PageId { get; set; }
    }
}
