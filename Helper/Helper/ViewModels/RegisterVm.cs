using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class RegisterVm
    {
        [Key]
        public int Id { get; set; }

        public string ReturnUrl { get; set; }


        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(3, ErrorMessage = "حداقل 3 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string _Username { get; set; }


        [Required(ErrorMessage = "این فیلد الزامیست")]
        [EmailAddress(ErrorMessage = "به فرمت  ایمیل وارد کنید")]
        [MaxLength(30, ErrorMessage = "حداکثر 30 کاراکتر وارد کنید")]
        [Display(Name = "ایمیل")]
        public string _Email { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(6, ErrorMessage = "حداقل 6 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string _Password { get; set; }


        /// <summary>
        /// قوانین را مپذیرم؟
        /// </summary>
        public bool AcceptRules { get; set; }
    }
}
