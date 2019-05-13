using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class RoleApplication
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int ApplicationId { get; set; }
        public bool IsDefaultRole { get; set; }
        public virtual Role Role { get; set; }
        public virtual Application Application { get; set; }
    }
}
