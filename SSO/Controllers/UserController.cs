using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSO.ViewModels;
using SSO.UoW;
using SSO.BLL;
using Microsoft.AspNetCore.Authorization;

namespace SSO.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : BaseApiController
    {
        public UserController(IUnitOfWork unitOfWork, IUserManager userManager, IJwtHandler jwtHandler)
            :base(unitOfWork, userManager, jwtHandler)
        {

        }
        // GET api/values
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(UserCreateDto dto)
        {
            var result = UserManager.CreateUser(dto);
            return new ObjectResult(result);
        }
        [HttpPut]
        [Authorize]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto dto)
        {
            try
            {
                var user = UnitOfWork.UserRepository.Find(u => u.UserName == User.Identity.Name).FirstOrDefault();
                if (user == null)
                {
                    return Unauthorized();
                }
                var result = UserManager.VerifyPassword(user.UserName, dto.OldPassword);
                if (result == "Failed")
                {
                    return BadRequest(new { error = "رمز فعلی اشتباه می باشد" });
                }
                else
                {
                    UserManager.ChangePassword(user, dto.NewPassword);
                    UnitOfWork.Complete();
                }
                return Ok();
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UserCredentialsDto dto)
        {
            var result = UserManager.VerifyPassword(dto.UserName, dto.Password);
            if (result == "Failed")
            {
                return Unauthorized();
            }
            return new ObjectResult(JwtHandler.Create(dto.UserName));
        }

        [HttpPost]
        [Route("SendVerificationCodeSms")]
        public IActionResult SendVerificationCodeSms(MobileVerificationDto dto)
        {
            // Mobile Validator
            var user = UnitOfWork.UserRepository.Find(u => u.MobileNumber == dto.MobileNumber).FirstOrDefault();
            if (user == null)
                return NotFound();
            bool result = UserManager.SendVerificationCodeSms(user);
            if (result)
            {
                return Ok();
            }
            else
                return StatusCode(500, new { Error = "خطا در ارسال پیامک"});
        }

        [HttpPost]
        [Route("VerifyVerificationCodeSms")]
        public IActionResult VerifyVerificationCodeSms(MobileVerificationDto dto)
        {
            // Mobile Validator
            var user = UnitOfWork.UserRepository.Find(u => u.MobileNumber == dto.MobileNumber).FirstOrDefault();
            if (user == null)
                return NotFound();
            bool result = UserManager.VerifyVerificationCodeSms(user, dto.Code);
            if (result)
            {
                return new ObjectResult(JwtHandler.Create(user.UserName));
            }
            else
                return StatusCode(400, new { Error = "کد ارسالی مورد تأیید نمی باشد" });
        }

    }
}
