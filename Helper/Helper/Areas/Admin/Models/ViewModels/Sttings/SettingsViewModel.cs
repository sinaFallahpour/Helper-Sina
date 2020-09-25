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

        [Required(ErrorMessage = "  متن درباره  ما الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "درباره ما")]
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



        [Required(ErrorMessage = " متن هلپر بستری مناسب (فارسی) الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "  هلپر بستری مناسب")]
        [AllowHtml]
        public string LandingHelperText { get; set; }




        [Required(ErrorMessage = " متن هلپر بستری مناسب (انگلیسی) الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "  (english)هلپر بستری مناسب")]
        [AllowHtml]
        public string EnglishlandingHelperText { get; set; }





      

        [Required(ErrorMessage = " متن برای کاربران (فارسی) الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "برای کاربران")]
        [AllowHtml]
        public string ForUserText { get; set; }




        [Required(ErrorMessage = " متن برای کاربران (انگلیسی) الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "برای کاربران(english)")]
        [AllowHtml]
        public string EnglishForUserText { get; set; }





        [Required(ErrorMessage = " متن برای متخصصین (فارسی) الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "برای متخصصین")]
        [AllowHtml]
        public string ForProfessionalText { get; set; }




        [Required(ErrorMessage = " متن برای متخصصین (انگلیسی) الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "(english)برای متخصصین")]
        [AllowHtml]
        public string EnglishForProfessionalText { get; set; }






        [Required(ErrorMessage = " متن ایجاد سرویس الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = " ایجاد سرویس")]
        [AllowHtml]
        public string CreateServiceText { get; set; }




        [Required(ErrorMessage = " متن برای متخصصین (انگلیسی) الزامیست")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        [Display(Name = "ایجاد سرویس (english)")]
        [AllowHtml]
        public string EnglishCreateServiceText { get; set; }







        //public List<string> ImagesAddresses { get; set; }

        //[NotMapped]
        //public IFormFile Photo { get; set; }


    }
}
