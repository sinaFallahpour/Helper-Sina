﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_Category : BaseEntity<int>
    {
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
        /// 
        [Display(Name = "  آیا فعال است؟")]
        public bool IsEnabled { get; set; }


        [Display(Name="عکس")]
        public string PhotoAddress { get; set; }

        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "عکس")]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }


}
