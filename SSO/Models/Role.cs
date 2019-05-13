using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class Role
    {
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        public string Title { get; set; }
        public int RoleGroupId { get; set; }
        public virtual RoleGroup RoleGroup { get; set; }
        public virtual ICollection<RoleAction> RoleActions { get; set; }
        public virtual ICollection<RoleApplication> RoleApplications { get; set; }
    }
}
