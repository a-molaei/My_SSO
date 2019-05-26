using SSO.Models;
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
        string VerifyPassword(string username, string password);
        bool ChangePassword(User user, string newPassword);
        bool ChangeSecurityStamp(User user);
        bool SendVerificationCodeSms(User user);
        bool VerifyVerificationCodeSms(User user, string code);
    }
}
