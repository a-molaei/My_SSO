using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.Models
{
    public class RoleAction
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public int ActionId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Action Action { get; set; }
    }
}
