using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DNTPersianUtils.Core;

namespace Helper.ViewModels
{
    public class AccountSettingsVM
    {

        public string Id { get; set; }


        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(20, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }


        [EmailAddress(ErrorMessage = "InValidEmail")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(30, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        //[MinLength(8, ErrorMessage = "Minimum length is {1} characters ")]
        //[MaxLength(11, ErrorMessage = "Maximum length is {1} characters")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره موبایل ")]
        [ValidIranianMobileNumber(ErrorMessage = "ysatsytatsautsattsaysu")]
        public string Phone { get; set; }






        /// <summary>
        /// زبان سایت
        /// </summary>
        public SiteLanguage SiteLanguage { get; set; }


        /// <summary>
        ///نام بانک
        /// </summary>
        [MaxLength(150, ErrorMessage = "Maximum length is {1} characters")]
        public string BankName { get; set; }


        /// <summary>
        /// نام صاحب حساب بانک
        /// </summary>
        [MaxLength(60, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = " نام صاحب حساب بانک")]
        public string AccountOwner { get; set; }


        /// <summary>
        /// شماره کارت
        /// </summary>
        //[StringLength(16, MinimumLength = 16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        //[MaxLength(16, ErrorMessage = "Maximum length is {1} characters")]
        [MaxLength(16, ErrorMessage = "Enter just {1} character")]
        [MinLength(16, ErrorMessage = "Enter just {1} character")]
       
        [Display(Name = " شماره کارت")]
        public string CardNumber { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        //[MaxLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        //[MinLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        [Required(ErrorMessage = "Required")]
        [ValidIranShebaNumber(ErrorMessage = "sdssdsd")]
        [Display(Name = "شماره شبا" )]
        public string ShabaNumber { get; set; }


        /// <summary>
        /// شماره ویزا یا مسترکارد
        /// </summary>
        //[MaxLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        //[MinLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        [Display(Name = "شماره ویزا یا مسترکارد")]
        public string VisaNumber { get; set; }









        

        [Required(ErrorMessage = "Required")]
        [MinLength(6, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(20, ErrorMessage = "Maximum length is {1} characters")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string OldPassword { get; set; }




        [Required(ErrorMessage = "Required")]
        [MinLength(6, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(20, ErrorMessage = "Maximum length is {1} characters")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string NewPassword { get; set; }



        [Required(ErrorMessage = "Required")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "ComparePassWordErrorMessage")]
        [Display(Name = "تکرار رمز عبور")]
        public string NewPasswordConfirm { get; set; }
    }
}
