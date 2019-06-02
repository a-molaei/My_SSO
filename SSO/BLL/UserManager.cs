using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSO.ViewModels;
using SSO.UoW;
using SSO.Models;
using Microsoft.AspNetCore.Identity;
using SSO.Helper;
using SSO.Helper.Sms;
using SSO.Helper.CommonData;

namespace SSO.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _UnitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
        }

        public bool ChangePassword(User user, string newPassword)
        {
            try
            {
                user.Password = new PasswordHasher<User>().HashPassword(user, newPassword);
                if (ChangeSecurityStamp(user))
                    return true;
                return false;
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool ChangeSecurityStamp(User user)
        {
            try
            {
                user.SecurityStamp = Guid.NewGuid().ToString();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CreateUser(UserCreateDto userDto)
        {
            var user = userDto.LoadFrom();
            user.Password = new PasswordHasher<User>().HashPassword(user,userDto.Password);
            _UnitOfWork.UserRepository.Add(user);
            var result = _UnitOfWork.Complete();
            _UnitOfWork.Dispose();
            return result > 0;
        }

        public bool SendVerificationCodeSms(User user)
        {
            MobileVerificationCode vCode = new MobileVerificationCode
            {
                MobileNumber = user.MobileNumber,
                IsVerified = false,
                CreationDateTime = DateTime.Now,
                CreatedByUserId = user.Id
            };
            RandomNumber myrand = new RandomNumber();
            vCode.Code = myrand.GenerateRandomNumber(4);
            _UnitOfWork.MobileVerificationCodeRepository.Add(vCode);
            int count = _UnitOfWork.Complete();
            if (count == 1)
            {
                SmsService sms = new SmsService();
                var smsSent = true; // sms.SendVerificationCode(user.MobileNumber, vCode.Code);
                if (smsSent) 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string VerifyPassword(string username, string password)
        {
            var user = _UnitOfWork.UserRepository.Find(u => u.UserName == username).FirstOrDefault();
            PasswordVerificationResult result = PasswordVerificationResult.Failed;
            if (user != null)
            {
                result = new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, password);
            }
            return result.ToString();
        }

        public bool VerifyVerificationCodeSms(User user, string code)
        {
            var lastCode = _UnitOfWork.MobileVerificationCodeRepository.Find(v => v.MobileNumber == user.MobileNumber).OrderByDescending(v => v.CreationDateTime).FirstOrDefault();
            if (lastCode.IsVerified == true)
                return false;
            else if (lastCode.Code == code)
            {
                lastCode.IsVerified = true;
                ChangeSecurityStamp(user);
                _UnitOfWork.Complete();
                return true;
            }
            else
                return false;
        }

        public string GetNextAuthenticationStep(string userName, string userId, int currentSecurityLevel, int requestedSecurityLevel)
        {
            if (requestedSecurityLevel == 0)
                requestedSecurityLevel = 1;
            var requestedModes = _UnitOfWork.SecurityLevelModelRepository
                .Find(s => s.SecurityLevelId == requestedSecurityLevel)
                .Select(s => s.SecurityModeId)
                .ToList();

            var validatedModes = _UnitOfWork.SecurityLevelModelRepository
                .Find(s => s.SecurityLevelId == currentSecurityLevel)
                .Select(s => s.SecurityModeId)
                .ToList();

            var datetime = DateTime.Now.AddMinutes(-5);
            var newlyAuthenticatedSteps = _UnitOfWork.AuthenticationStepRepository
                .Find(a => a.UserId == userId && a.CreationDateTime >= datetime)
                .Select(a => a.SecurityModeId)
                .ToList();

            var remainingModes = requestedModes
                .Except(validatedModes)
                .Except(newlyAuthenticatedSteps)
                .ToList();

            if (remainingModes.Any())
                return GetAuthenticationStepNameByIndex(remainingModes.FirstOrDefault());
            else
                return AuthenticationSteps.Done.ToString();
        }
        public string GetAuthenticationStepNameByIndex(int index)
        {
            AuthenticationSteps a = (AuthenticationSteps)index;
            return a.ToString();
        }
        public string GetNextAuthenticationStep(User user,int currentSecurityLevel, int requestedSecurityLevel, AuthenticationSteps step)
        {
            AuthenticationStep auth = new AuthenticationStep()
            {
                SecurityModeId = (int)step,
                UserId = user.Id,
                CreationDateTime = DateTime.Now
            };
            _UnitOfWork.AuthenticationStepRepository.Add(auth);
            _UnitOfWork.Complete();
            var nextStep = GetNextAuthenticationStep(user.UserName, user.Id, currentSecurityLevel, requestedSecurityLevel);
            return nextStep;
        }

        public bool IsUserLocked(User user)
        {
            if (user.LockOutEnabled && DateTime.Now <= user.LockOutEndDate)
                return true;
            else if(user.LockOutEnabled && DateTime.Now > user.LockOutEndDate)
            {
                UnlockUser(user);
                return false;
            }
            return false;
        }

        public void IncreaseUserFailedPasswordCount(User user)
        {
            user.AccessFailedCount = user.AccessFailedCount + 1;
        }

        public bool HasUserPassedMaxFailedPasswordCount(User user, Setting setting)
        {
            if (user.AccessFailedCount >= setting.MaxFailedPasswordCount)
                return true;
            else
                return false;
        }

        public void LockUser(User user, Setting setting)
        {
            user.LockOutEndDate = DateTime.Now.AddMinutes(setting.LockOutDuration);
            user.LockOutEnabled = true;
        }

        public void UnlockUser(User user)
        {
            user.LockOutEnabled = false;
            user.LockOutEndDate = null;
            user.AccessFailedCount = 0;
        }
    }
}
