using DNTPersianUtils.Core;
using System;
using System.ComponentModel.DataAnnotations;

namespace Helper.ViewModels
{
    public class RegisterViewModel
    {

        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        //[ShouldContainOnlyPersianLetters(ErrorMessage = "فقط از حروف فارسی استفاده کنید")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [EmailAddress(ErrorMessage = "ایمیل را به درستی وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور همخوانی ندارد")]
        [Display(Name = "تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [RegularExpression("([1-9][0-9]*)")]
        [Display(Name = "کذ امنیتی")]
        public string Captcha { get; set; }

        [Display(Name = "قوانین را میپذیرم")]
        public bool AcceptRules { get; set; }

    }
}
