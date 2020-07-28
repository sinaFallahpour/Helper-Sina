using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Helper.Areas.Admin.Models.ViewModels.Sttings
{
    public class SettingsViewModel
    {

        [Required(ErrorMessage ="الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name ="درباره ما")]
        [AllowHtml]
        public string Aboutus { get; set; }

        [Required(ErrorMessage = "الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "ارتبط با ما")]
        [AllowHtml]
        public string ContactUs { get; set; }

        //public List<string> ImagesAddresses { get; set; }

        //[NotMapped]
        //public IFormFile Photo { get; set; }


    }
}
