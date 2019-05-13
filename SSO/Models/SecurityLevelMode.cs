using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class SecurityLevelMode
    {
        public int Id { get; set; }
        public int SecurityLevelId { get; set; }
        public SecurityLevel SecurityLevel { get; set; }
        public int SecurityModeId { get; set; }
        public SecurityMode SecurityMode { get; set; }
    }
}
