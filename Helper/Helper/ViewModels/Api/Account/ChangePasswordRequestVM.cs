using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Account
{
    public class ChangePasswordRequestVM
    {

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(6, ErrorMessage = "حداقل 6 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(6, ErrorMessage = "حداقل 6 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string NewPassword { get; set; }

    }
}
