using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class AccountSettingsVM
    {

        public string Id { get; set; }


        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }


        [EmailAddress(ErrorMessage = "به فرمت  ایمیل وارد کنید")]
        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MaxLength(30, ErrorMessage = "حداکثر 30 کاراکتر وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [MinLength(8, ErrorMessage = "از 8 تا 11 کاراکتر وارد کنید")]
        [MaxLength(11, ErrorMessage = "از 8 تا 11 کاراکتر وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره موبایل ")]
        public string Phone { get; set; }






        /// <summary>
        /// زبان سایت
        /// </summary>
        public SiteLanguage SiteLanguage { get; set; }


        /// <summary>
        ///نام بانک
        /// </summary>
        [MaxLength(150, ErrorMessage = "حداکثر 150 کاراکتر ")]
        public string BankName { get; set; }


        /// <summary>
        /// نام صاحب حساب بانک
        /// </summary>
        [MaxLength(60, ErrorMessage = "حداکثر 60 کاراکتر ")]
        [Display(Name = " نام صاحب حساب بانک")]
        public string AccountOwner { get; set; }


        /// <summary>
        /// شماره کارت
        /// </summary>
        //[StringLength(16, MinimumLength = 16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        [MaxLength(16,ErrorMessage ="فقط 16 کاراکتر وارد کنید")]
        [MinLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        [Display(Name = " شماره کارت")]
        public string CardNumber { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        [MaxLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        [MinLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        [Display(Name = "شماره شبا")]
        public string ShabaNumber { get; set; }


        /// <summary>
        /// شماره ویزا یا مسترکارد
        /// </summary>
        [MaxLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        [MinLength(16, ErrorMessage = "فقط 16 کاراکتر وارد کنید")]
        [Display(Name = "شماره ویزا یا مسترکارد")]
        public string VisaNumber { get; set; }



    }
}
