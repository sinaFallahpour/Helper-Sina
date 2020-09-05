using Helper.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.Category
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "نام دسته بندی الزامیست ")]
        [Display(Name = "نام دسته بندی")]
        public string Name { get; set; }

        [Required(ErrorMessage = " نام    انگلیسی دسته بندی الزامیست")]
        [Display(Name = "نام انگلیسی    دسته بندی")]
        public string EnglishName { get; set; }

        public DateTime CreateDate { get; set; }

        /// <summary>
        /// آیا این دسته بندی فعال است
        /// </summary>
        [Display(Name = "  آیا فعال است؟")]
        public bool IsEnabled { get; set; }


        public string PhotoAddress { get; set; }


        [Display(Name = "عکس")]
        [NotMapped]
        public IFormFile Photo { get; set; }



    }
}
