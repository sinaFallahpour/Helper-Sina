using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_City : BaseEntity<int>
    {
        [Required(ErrorMessage = "  نام شهر الزامیست ")]
        [Display(Name = "نام شهر")]
        public string Name { get; set; }


        [Required(ErrorMessage = "  نام  انگلیسی  شهر  الزامیست ")]
        [Display(Name = "نام  انگلیسی شهر")]
        public string EnglishName { get; set; }


        public DateTime CreateDate { get; set; }


        /// <summary>
        /// آیا این شهر فعال است
        /// </summary>
        /// 
        [Display(Name = "  آیا فعال است؟")]

        public bool IsEnabled { get; set; }


    }

}
