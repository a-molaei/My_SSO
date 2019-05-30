using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class GetAuthRouteDto
    {
        public int RequestedSecurityLevel { get; set; }
        public string UserName { get; set; }
    }
}
