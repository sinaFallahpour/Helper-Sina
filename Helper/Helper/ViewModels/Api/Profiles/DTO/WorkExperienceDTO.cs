using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Profiles.DTO
{
    public class WorkExperienceDTO
    {
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
        public string EnterDate { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ خروج ")]
        public string ExitDate { get; set; }


        [MaxLength(300, ErrorMessage = "حداکثر 300 کاراکتر وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Descriptions { get; set; }

    }
}
