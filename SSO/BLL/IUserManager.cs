using SSO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.BLL
{
    public interface IUserManager
    {
        bool CreateUser(UserCreateDto userDto);
        string Authenticate(string username, string password);
    }
}
