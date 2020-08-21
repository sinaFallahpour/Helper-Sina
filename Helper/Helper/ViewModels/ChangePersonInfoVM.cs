using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class ChangePersonInfoVM
    {
        public string Id { get; set; }


        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "این فیلد الزامیست")]
        [EmailAddress(ErrorMessage = "به فرمت  ایمیل وارد کنید")]
        [MaxLength(30, ErrorMessage = "حداکثر 30 کاراکتر وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        //[StringLength(11, MinimumLength = 8, ErrorMessage = "شماره تماس بین 8 تا 11 کاراکتر وارد کنید")]
        [MinLength(8,ErrorMessage = "شماره تماس بین 8 تا 11 کاراکتر وارد کنید")]
        [MaxLength(11, ErrorMessage = "شماره تماس بین 8 تا 11 کاراکتر وارد کنید")]
        [Display(Name = "شماره تماس ")]
        public string Phone { get; set; }
        
        /// <summary>
        /// زبان سایت
        /// </summary>
        public SiteLanguage SiteLanguage { get; set; }

    }
}
