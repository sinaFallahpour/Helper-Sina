using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels
{
    [Area("Admin")]
    public class LoginAdminViewModel
    {

        [Key]
        public int Id { get; set; }


        public string ReturnUrl { get; set; }

        //[Required(ErrorMessage = "ایمیل الزامیست")]
        //[Display(Name = "ایمیل")]
        //[EmailAddress]
        //public string Email { get; set; }

        [Required(ErrorMessage = "نام کاربری الزامیست")]
        [Display(Name = "ایمیل")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "گذرواژه الزامیست")]
        [DataType(DataType.Password)]
        [Display(Name = "گذرواژه")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار؟")]
        public bool RememberMe { get; set; }



    }
}
