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


        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(20, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }


        [Required(ErrorMessage = "Required")]
        [EmailAddress(ErrorMessage = "InValidEmail")]
        [MaxLength(30, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required")]
        [MinLength(6, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(20, ErrorMessage = "Maximum length is {1} characters")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }


        /// <summary>
        /// قوانین را مپذیرم؟
        /// </summary>
        public bool AcceptRules { get; set; }
    }
}
