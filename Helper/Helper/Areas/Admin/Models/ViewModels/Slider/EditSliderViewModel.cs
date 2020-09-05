using Helper.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.Slider
{
    public class EditCategoryViewModel
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "عنوان")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر")]
        public string Title { get; set; }

        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "توضیحات")]
        [MaxLength(550, ErrorMessage = "حداکثر 550 کاراکتر وارد کنید")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر وارد کنید")]
        public string Description { get; set; }


        [Display(Name = "زبان")]
        public LanguageType LanguageType { get; set; }

        public bool IsActive { get; set; }
        public string PhotoAddress { get; set; }

        [Display(Name = "عکس")]
        public IFormFile Photo { get; set; }
    }
}
