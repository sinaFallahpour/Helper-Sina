using Helper.Models.Enums;
using Helper.ViewModels.Api.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Profiles
{
    public class UpdateProfileVM
    {


        public string Id { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "به فرمت  ایمیل وارد کنید")]
        [MaxLength(30, ErrorMessage = "حداکثر 30 کاراکتر وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }



        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        public string City { get; set; }


        [StringLength(11, MinimumLength = 1, ErrorMessage = "فقط 11 کاراکتر وارد کنید")]
        [Display(Name = "شماره تماس ")]
        public string Phone { get; set; }




        /*  كارنت يوزر  */
        public UserVM CurrentUser { get; set; }




        /* اطلاعات شخصی  */

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ تولد ")]
        public string Birthdate { get; set; }

        [Display(Name = "  جنسیت  ")]
        public UserGender Gender { get; set; }

        [Display(Name = "وضعیت")]
        public UserMarriedType MarriedType { get; set; }

        [StringLength(maximumLength: 600, ErrorMessage = "حداکثر 600 کاراکتر وارد کنید")]
        public string LanguageKnowing { get; set; }

       


        /*  سوابق کاری  */
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string CompanyName { get; set; }

        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = "سمت")]
        public string Semat { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ ورود ")]
        public string WorkEnterDate { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ خروج ")]
        public string WorkExitDate { get; set; }


        [MaxLength(300, ErrorMessage = "حداکثر 300 کاراکتر وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Descriptions { get; set; }






        /* سوابق تحصیلی */
        /// <summary>
        /// مقطع
        /// </summary>
        /// 
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        public string MaghTa { get; set; }

        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string UnivercityName { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ ورود ")]
        public string EduEnterDate { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ ورود ")]
        public string EduExitDate { get; set; }



    }
}
