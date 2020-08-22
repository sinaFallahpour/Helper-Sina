using DNTPersianUtils.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Helper.ViewModels
{
    public class RegisterViewModel
    {
        public string ReturnUrl { get; set; }

        [Required]
        [ShouldContainOnlyPersianLetters(ErrorMessage = "فقط از حروف فارسی استفاده کنید")]
        public string Nickname { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "ایمیل را به درستی وارد کنید")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور همخوانی ندارد")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression("([1-9][0-9]*)")]
        public string Captcha { get; set; }
    }
}
