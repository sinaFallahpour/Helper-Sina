using Helper.Models.Enums;
using Helper.ViewModels.Api.Profiles.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class ProfileVM2
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


        [MaxLength(200, ErrorMessage = "حداکثر 200 کاراکتر وارد کنید")]
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [Display(Name = "نام")]
        public string Nickname { get; set; }


        //[StringLength(8, MinimumLength = 1, ErrorMessage = "فقط 11 کاراکتر وارد کنید")]
        [MinLength(8, ErrorMessage = "از 8 تا 11 کاراکتر وارد کنید")]
        [MaxLength(11, ErrorMessage = "از 8 تا 11 کاراکتر وارد کنید")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره تماس ")]
        public string Phone { get; set; }


        [MaxLength(300, ErrorMessage = "حداکثر 300 کاراکتر وارد کنید")]
        public string Descriptions { get; set; }


        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ تولد ")]
        public string Birthdate { get; set; }


        [StringLength(maximumLength: 600, ErrorMessage = "حداکثر 600 کاراکتر وارد کنید")]
        public string LanguageKnowing { get; set; }


        [Display(Name = "جنسیت")]
        public UserGender Gender { get; set; } = UserGender.Man;

        [Display(Name = "وضعیت ")]
        public UserMarriedType MarriedType { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        public string City { get; set; }

        //public UserVM CurrentUser { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        [Display(Name = "مقطع ")]
        public string MaghTa { get; set; }

        [MaxLength(200, ErrorMessage = "حداکثر 200 کاراکتر وارد کنیید")]
        [Display(Name = "نام دانشگاه")]
        public string UnivercityName { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = "  از تاریخ ")]
        public string EduEnterDate { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = "تا تاریخ")]
        public string EduExitDate { get; set; }
        //public EducationHistoryDTO EducationHistryDTO { get; set; }







        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " شرکت")]
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
        public string WorkDescriptions { get; set; }
        //public WorkExperienceDTO WorkExperienceDTO { get; set; }
    }
}
