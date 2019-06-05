using SSO.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class UserCreateDto
    {
        [Required(ErrorMessage = "وارد کردن نام کاربری اجباری است")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "وارد کردن رمز جدید اجباری است")]
        public string Password { get; set; }
        [Required(ErrorMessage = "وارد کردن تکرار رمز اجباری است")]
        [Compare("Password", ErrorMessage = "تکرار رمز معتبر صحیح نمی باشد")]
        public string ConfirmPassword { get; set; }
        public int? PersonId { get; set; }
        public string CaptchaKey { get; set; }
        public string UserCaptchaInput { get; set; }
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
