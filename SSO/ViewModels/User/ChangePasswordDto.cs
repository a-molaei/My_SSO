using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SSO.ViewModels
{
    public class ChangePasswordDto
    {
        [Required(ErrorMessage = "وارد کردن رمز قدیم اجباری است")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز جدید اجباری است")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "وارد کردن تکرار رمز جدید اجباری است")]
        [Compare("NewPassword", ErrorMessage = "رمز جدید و تکرار آن یکسان نمی باشد")]
        public string ConfirmPassword { get; set; }
    }
}
