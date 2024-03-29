﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SSO.ViewModels;
using SSO.UoW;
using SSO.BLL;
using Microsoft.AspNetCore.Authorization;
using SSO.Helper.Captcha;
using SSO.ViewModels.Captcha;
using SSO.Helper.CommonData;
using SSO.Models;
using SSO.Helper.Converter;
using SSO.ViewModels.PasswordRecovery;
using SSO.ViewModels.JwtToken;
using SSO.Helper.Validators;

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
            try
            {
                var captchaValidated = CaptchaHelper.ValidateCaptcha(dto.CaptchaKey, dto.UserCaptchaInput);
                if (captchaValidated == true)
                {
                    //Create Person if not exists
                    var user = UnitOfWork.UserRepository.Find(u => u.UserName == dto.UserName).FirstOrDefault();
                    if (user == null)
                    {
                        if (!CustomValidator.CheckPasswordComplexity(dto.Password))
                            return BadRequest(new { Error = "رمز عبور باید حداقل 8 کاراکتر و ترکیبی از اعداد و حروف باشد" });
                        if (!CustomValidator.ValidateNationalCode(dto.UserName))
                            return BadRequest(new { Error = "کد ملی معتبر نمی باشد" });
                        var result = UserManager.CreateUser(dto);
                    }
                    else
                    {
                        //////////
                    }
                    return Ok();
                }
                else
                {
                    return StatusCode(400, new { Error = "کلید تصویر امنیتی معتبر نمی باشد" });
                }
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
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
            try
            {
                var captchaValidated = CaptchaHelper.ValidateCaptcha(dto.CaptchaKey, dto.UserCaptchaInput);
                if (captchaValidated == true)
                {
                    var setting = UnitOfWork.SettingRepository.GetAll().FirstOrDefault();
                    if(setting == null)
                    {
                        return StatusCode(500, new { Error = "تنظیمات سیستم تعریف نشده است" });
                    }

                    var user = UnitOfWork.UserRepository.Find(u => u.UserName == dto.UserName).FirstOrDefault();
                    if (user == null)
                        return Unauthorized(new { Error = "نام کاربری یا کلمه عبور اشتباه است"});
                    if(UserManager.IsUserLocked(user))
                    {
                        return Unauthorized(new { Error = "حساب کاربری شما به علت وارد کردن رمز عبور اشتباه بیش از حد مجاز برای دقایقی مسدود شده است." });
                    }
                    var result = UserManager.VerifyPassword(dto.UserName, dto.Password);
                    if (result == "Failed")
                    {
                        UserManager.IncreaseUserFailedPasswordCount(user);
                        if (UserManager.HasUserPassedMaxFailedPasswordCount(user, setting))
                        {
                            UserManager.LockUser(user, setting);
                            UnitOfWork.Complete();
                            return Unauthorized(new { Error = "حساب کاربری شما به علت وارد کردن رمز عبور اشتباه بیش از حد مجاز برای دقایقی مسدود شده است." });
                        }
                        UnitOfWork.Complete();
                        return Unauthorized(new { Error = "نام کاربری یا کلمه عبور اشتباه است" });
                    }
                    UserManager.UnlockUser(user);

                    var nextStep = UserManager.GetNextAuthenticationStep(user, SecurityLevel, dto.RequestedSecurityLevel, AuthenticationSteps.Login);
                    if (nextStep == AuthenticationSteps.Done.ToString())
                    {
                        return new ObjectResult(JwtHandler.Create(user.UserName, dto.RequestedSecurityLevel, dto.ApplicationId, dto.PageId));
                    }
                    else
                    {
                        return Ok(new { NextRoute = nextStep });
                    }
                }
                else
                {
                    return StatusCode(400, new { Error = "کلید تصویر امنیتی معتبر نمی باشد" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        [Route("GetAuthRoute")]
        public IActionResult GetAuthRoute(GetAuthRouteDto dto)
        {
            try
            {
                string userId = string.Empty;
                string userName = string.Empty;
                if (!string.IsNullOrEmpty(dto.UserName))
                {
                    userName = dto.UserName;
                    userId = UnitOfWork.UserRepository.Find(u => u.UserName == dto.UserName).FirstOrDefault()?.Id;
                }
                else if (User != null)
                {
                    userId = UnitOfWork.UserRepository.Find(u => u.UserName == User.Identity.Name).FirstOrDefault()?.Id;
                    userName = User.Identity.Name;
                }
                var nextStep = UserManager.GetNextAuthenticationStep(userName, userId, SecurityLevel, dto.RequestedSecurityLevel);
                return Ok(new { NextRoute = nextStep });

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [HttpPost]
        [Route("SendVerificationCodeSms")]
        public IActionResult SendVerificationCodeSms(MobileVerificationDto dto)
        {
            var mobileNumber = CryptographyHelper.Decrypt(dto.EncryptedMobileNumber);
            var user = UnitOfWork.UserRepository.Find(u => u.MobileNumber == mobileNumber).FirstOrDefault();
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
            var mobileNumber = CryptographyHelper.Decrypt(dto.EncryptedMobileNumber);
            var user = UnitOfWork.UserRepository.Find(u => u.MobileNumber == mobileNumber).FirstOrDefault();
            if (user == null)
                return NotFound();
            bool result = UserManager.VerifyVerificationCodeSms(user, dto.Code);
            if (result)
            {
                var nextStep = UserManager.GetNextAuthenticationStep(user, SecurityLevel, dto.RequestedSecurityLevel, AuthenticationSteps.Mobile);
                if (nextStep == AuthenticationSteps.Done.ToString())
                {
                    return new ObjectResult(JwtHandler.Create(user.UserName, dto.RequestedSecurityLevel, dto.ApplicationId, dto.PageId));
                }
                else
                {
                    return Ok(new { NextRoute = nextStep });
                }
            }
            else
                return StatusCode(400, new { Error = "کد ارسالی مورد تأیید نمی باشد" });
        }
        [HttpGet]
        [Route("GetCaptcha")]
        public IActionResult GetCaptcha()
        {
            CaptchaResponseDto dto = new CaptchaResponseDto();
            dto = CaptchaHelper.GenerateCaptcha();
            return Ok(dto);
        }

        [HttpGet]
        [Route("GetEmailByNationalCode/{nationalCode}")]
        public IActionResult GetEmailByNationalCode(string nationalCode)
        {
            // get email from person server
            var testEmail = "molaie.amir@gmail.com";
            var incompleteAddress = EmailHelper.ConvertToIncompleteAddress(testEmail);
            var encrypted = CryptographyHelper.Crypt(testEmail);
            EmailEncryptedAndIncompleteDto dto = new EmailEncryptedAndIncompleteDto()
            {
                IncompleteEmail = incompleteAddress,
                EncrypedEmail = encrypted
            };
            return Ok(dto);
        }

        [HttpGet]
        [Route("GetMobileNumbersByNationalCode/{nationalCode}")]
        public IActionResult GetMobileNumbersByNationalCode(string nationalCode)
        {
            // get mobile numbers from person server
            var testMobiles = new List<string>()
            {"09132920196",
            "09334567897",
            "09109396262"
            };
            var result = testMobiles.Select(MobileHelper.GetEncryptedAndIncompleteMobile);
            return Ok(result);
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ForgotPasswordDto dto)
        {
            try
            {
                var captchaValidated = CaptchaHelper.ValidateCaptcha(dto.CaptchaKey, dto.UserCaptchaInput);
                if (captchaValidated == true)
                {
                    var decryptedEmail = CryptographyHelper.Decrypt(dto.EncryptedEmail);
                    var decryptedMobileNumber = CryptographyHelper.Decrypt(dto.EncryptedMobileNumber);
                    // send to email
                    // send to mobile
                    return Ok();
                }
                else
                {
                    return StatusCode(400, new { Error = "کلید تصویر امنیتی معتبر نمی باشد" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        [Authorize]
        [HttpGet]
        [Route("RefreshToken")]
        public IActionResult RefreshToken(RefreshTokenDto dto)
        {
            if (User?.Identity?.Name == null)
                return Unauthorized();
            return new ObjectResult(JwtHandler.Create(User.Identity.Name, SecurityLevel, dto.ApplicationId, 0));
        }

        [Authorize]
        [HttpGet]
        [Route("HasMobileNumber")]
        public IActionResult HasMobileNumber()
        {
            // User token to find person

            // Check if person has mobile number

            return Ok(new { Result = true });
        }

        [Authorize]
        [HttpPost]
        [Route("SendCodeToCreateFirstMobileNumber")]
        public IActionResult SendCodeToCreateFirstMobileNumber(CreateFirstMobileNumberDto dto)
        {
            if (!CustomValidator.ValidateMobileNumber(dto.MobileNumber))
            {
                return StatusCode(400, new { Error = "شماره موبایل نامعتبر می باشد. نمونه صحیح: 09131234567" });
            }

            // Check if mobile number exists

            var user = UnitOfWork.UserRepository.Find(u => u.MobileNumber == dto.MobileNumber).FirstOrDefault();
            if (user == null)
                return NotFound();
            bool result = UserManager.SendVerificationCodeSms(user);
            if (result)
            {
                return Ok();
            }
            else
                return StatusCode(500, new { Error = "خطا در ارسال پیامک" });
        }

        [Authorize]
        [HttpPost]
        [Route("VerifyCodeToCreateFirstMobileNumber")]
        public IActionResult VerifyCodeToCreateFirstMobileNumber(CreateFirstMobileNumberDto dto)
        {
            var user = UnitOfWork.UserRepository.Find(u => u.MobileNumber == dto.MobileNumber).FirstOrDefault();
            if (user == null)
                return NotFound();
            bool result = UserManager.VerifyVerificationCodeSms(user, dto.Code);
            if (result)
            {

                // User token to find person

                // Create mobile number in person

                return Ok();

            }
            else
                return StatusCode(400, new { Error = "کد ارسالی مورد تأیید نمی باشد" });
        }
    }
}
