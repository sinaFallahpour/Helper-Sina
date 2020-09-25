using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class ForgetPasswordVM
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(30, ErrorMessage = "Maximum length is {1} characters")]
        [EmailAddress(ErrorMessage = "InValidEmail")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
    }

}
