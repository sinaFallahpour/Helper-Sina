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

        [Required(ErrorMessage ="  متن درباره  ما الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name ="درباره ما")]
        [AllowHtml]
        public string Aboutus { get; set; }

        [Required(ErrorMessage = "  متن درباره  ما الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "EnglishAboutus")]
        [AllowHtml]
        public string EnglishAboutus { get; set; }

        [Required(ErrorMessage = " متن ارتبط با ما الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "ارتبط با ما")]
        [AllowHtml]
        public string ContactUs { get; set; }



        [Required(ErrorMessage = " متن ارتبط با ما الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "EnglishContactUs")]
        [AllowHtml]
        public string EnglishContactUs { get; set; }



        [Required(ErrorMessage = " متن قوانین سایت الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "قوانین سایت")]
        [AllowHtml]
        public string SiteRules { get; set; }




        [Required(ErrorMessage = " متن قوانین سایت الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "EnglishSiteRules")]
        [AllowHtml]
        public string EnglishSiteRules { get; set; }



        //public List<string> ImagesAddresses { get; set; }

        //[NotMapped]
        //public IFormFile Photo { get; set; }


    }
}
