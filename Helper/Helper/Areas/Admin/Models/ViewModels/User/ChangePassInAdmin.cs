using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.User
{
    public class ChangePassInAdmin
    {

        [Required(ErrorMessage = "{0} الزامیست")]
        [MinLength(6, ErrorMessage = "حداقل طول پسورد {1} کاراکتر میباشد")]
        [MaxLength(20, ErrorMessage = "حداقل طول پسورد {1} کاراکتر میباشد")]

        [DataType(DataType.Password)]
        [Display(Name = "پس.رد")]
        public string NewPassword { get; set; }



        [Required(ErrorMessage = "{0} الزامیست")]
        [MinLength(6, ErrorMessage = "حداقل  نام کاربری {1} کاراکتر میباشد")]
        [MaxLength(20, ErrorMessage = "حداقل طول نام کاربری {1} کاراکتر میباشد")]
        [Display(Name = "نام کاربری")]
        public string  Username { get; set; }
    }
}
