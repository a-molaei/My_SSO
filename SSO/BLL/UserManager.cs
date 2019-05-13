using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SSO.ViewModels;
using SSO.UoW;
using SSO.Models;
using Microsoft.AspNetCore.Identity;

namespace SSO.BLL
{
    public class UserManager : IUserManager
    {
        private readonly IUnitOfWork _UnitOfWork;

        public UserManager(IUnitOfWork unitOfWork)
        {
            _UnitOfWork = unitOfWork;
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
        public string Authenticate(string username, string password)
        {
            var user = _UnitOfWork.UserRepository.Find(u => u.UserName == username).FirstOrDefault();
            PasswordVerificationResult result = PasswordVerificationResult.Failed;
            if (user != null)
            {
                result = new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, password);
            }
            return result.ToString();
        }
    }
}
