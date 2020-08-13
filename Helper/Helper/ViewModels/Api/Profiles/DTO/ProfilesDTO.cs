using Helper.Models.Enums;
using Helper.ViewModels.Api.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Profiles.DTO
{
    public class ProfilesDTO
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


        [MaxLength(200, ErrorMessage = "حداکثر 200 کاراکتر وارد کنید")]
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [Display(Name = "نام")]
        public string Nickname { get; set; }


        [StringLength(11, MinimumLength = 1, ErrorMessage = "فقط 11 کاراکتر وارد کنید")]
        [Display(Name = "شماره تماس ")]
        public string Phone { get; set; }


        [MaxLength(300, ErrorMessage = "حداکثر 300 کاراکتر وارد کنید")]
        public string Descriptions { get; set; }


        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ تولد ")]
        public string Birthdate { get; set; }


        [StringLength(maximumLength: 300, ErrorMessage = "حداکثر 300 کاراکتر وارد کنید")]
        public string LanguageKnowing { get; set; }


        public UserGender Gender { get; set; }

        public UserMarriedType MarriedType { get; set; }
        
        
        public string   City { get; set; }

        public UserVM CurrentUser { get; set; }


        public  EducationHistoryDTO EducationHistryDTO { get; set; }


        //رابطه کاربر با  سابقه کار
        //public int WorkExperienceId { get; set; }
        //[ForeignKey("WorkExperienceId")]
        public  WorkExperienceDTO WorkExperienceDTO { get; set; }



    }
}
