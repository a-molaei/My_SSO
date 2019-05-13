using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class RoleGroup
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
