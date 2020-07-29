using Helper.Models.Enums;
using Helper.Models.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.User
{
    public class AdminCreateViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        [MinLength(3,ErrorMessage ="حدافل 3 کاراکتر وارد شود")]
        [Display(Name = "نام ")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        [MinLength(3, ErrorMessage = "حدافل 3 کاراکتر وارد شود")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "این فیلد الزامیست")]
        //[ShouldContainOnlyPersianLetters(ErrorMessage = "فقط از حروف فارسی استفاده کنید")]
        [MinLength(3, ErrorMessage = "حدافل 3 کاراکتر وارد شود")]
        [Display(Name = "نام مستعار ")]
        public string Nickname { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        //[EmailAddress(ErrorMessage = "نام کاربری  را به درستی وارد کنید")]
        [MinLength(3, ErrorMessage = "حدافل 3 کاراکتر وارد شود")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [DataType(DataType.Password)]
        [Display(Name = "رمز عبور")]
        [StringLength(100, ErrorMessage = "   پسورد حداقل 6 کاراکتر ", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "کلمه عبور همخوانی ندارد")]
        [Display(Name = "تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }


        [EnumDataType(typeof(UserGender))]
        [Display(Name = "جنسیت")]
        public UserGender Gender { get; set; } 



    }
}
