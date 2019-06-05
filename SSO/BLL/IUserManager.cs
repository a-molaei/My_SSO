using SSO.Helper.CommonData;
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
        string GetNextAuthenticationStep(string userName, string userId, int currentSecurityLevel, int requestedSecurityLeve);
        string GetNextAuthenticationStep(User user, int currentSecurityLevel, int requestedSecurityLevel, AuthenticationSteps step);
        string GetAuthenticationStepNameByIndex(int index);
        bool IsUserLocked(User user);
        void IncreaseUserFailedPasswordCount(User user);
        bool HasUserPassedMaxFailedPasswordCount(User user, Setting setting);
        void LockUser(User user, Setting setting);
        void UnlockUser(User user);
        bool IsForcedToChangePassword(User user, Setting setting);
    }
}
