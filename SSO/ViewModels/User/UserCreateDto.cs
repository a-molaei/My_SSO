using SSO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class UserCreateDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int? PersonId { get; set; }

        public User LoadFrom()
        {
            var user = new User
            {
                UserName = this.UserName,
                Password = this.Password,
                PersonId = this.PersonId,
                LastPasswordChangeDateTime = DateTime.Now,
                CreationDateTime = DateTime.Now
            };
            return user;
        }
    }
}
