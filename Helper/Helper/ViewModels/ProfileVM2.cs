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

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(20, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [EmailAddress(ErrorMessage = "InValidEmail")]
        [Required(ErrorMessage = "Required")]
        [MaxLength(30, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [MaxLength(200, ErrorMessage = "Maximum length is {1} characters")]
        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [Display(Name = "نام")]
        public string Nickname { get; set; }


        //[StringLength(8, MinimumLength = 1, ErrorMessage = "فقط 11 کاراکتر وارد کنید")]
        [MinLength(8, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(11, ErrorMessage = "Maximum length is {1} characters")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "شماره تماس ")]
        public string Phone { get; set; }


        [MaxLength(300, ErrorMessage = "Maximum length is {1} characters")]
        public string Descriptions { get; set; }


        [StringLength(maximumLength: 50, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = " تاریخ تولد ")]
        public string Birthdate { get; set; }


        [StringLength(maximumLength: 600, ErrorMessage = "Maximum length is {1} characters")]
        public string LanguageKnowing { get; set; }


        [Display(Name = "جنسیت")]
        public UserGender Gender { get; set; } = UserGender.Man;

        [Display(Name = "وضعیت ")]
        public UserMarriedType MarriedType { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "Maximum length is {1} characters")]
        public string City { get; set; }

        //public UserVM CurrentUser { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "مقطع ")]
        public string MaghTa { get; set; }

        [MaxLength(200, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "نام دانشگاه")]
        public string UnivercityName { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "  از تاریخ ")]
        public string EduEnterDate { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "تا تاریخ")]
        public string EduExitDate { get; set; }
        //public EducationHistoryDTO EducationHistryDTO { get; set; }





        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(50, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = " شرکت")]
        public string CompanyName { get; set; }

        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(50, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "سمت")]
        public string Semat { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = " تاریخ ورود ")]
        public string WorkEnterDate { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = " تاریخ خروج ")]
        public string WorkExitDate { get; set; }


        [MaxLength(300, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "توضیحات")]
      
        public string WorkDescriptions { get; set; }
        //public WorkExperienceDTO WorkExperienceDTO { get; set; }
    }
}
