using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.User
{
    public class LockedUserVM
    {
        [Required(ErrorMessage = "{0} is  Required")]
        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(20, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }
    }
}
