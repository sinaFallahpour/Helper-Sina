using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.User
{
    public class AdminLoginViewModel
    {
        [Key]
        public string Id { get; set; }

        public string returnUrl { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [Display(Name ="نام کاربری")]
        public string Username { get; set; }



        [Required(ErrorMessage = "این فیلد الزامیست")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

       
        /// <summary>
        /// مرا بخاطر سپار
        /// </summary>
        public bool RememberMe { get; set; }


    }
}
