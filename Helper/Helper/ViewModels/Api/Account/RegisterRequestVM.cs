using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Account
{
    public class RegisterRequestVM
    {
        [Required(ErrorMessage = "این فیلد الزامیست")]
        [Display(Name = "نام کاربری")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "این فیلد الزامیست")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }




        [Required(ErrorMessage ="")]
        [EmailAddress(ErrorMessage ="به فرمت  ایمیل وارد کنید")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

    }
}
