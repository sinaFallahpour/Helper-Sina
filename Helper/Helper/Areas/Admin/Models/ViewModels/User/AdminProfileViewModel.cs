using Helper.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.User
{
    public class AdminProfileViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(4, ErrorMessage = "حداقل 4 کاراکتر وارد کنید")]
        [MaxLength(20, ErrorMessage = "حداقل 20 کاراکتر وارد کنید")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }



        [EmailAddress(ErrorMessage = "ایمیل را به درستی وارد کنید")]
        [Display(Name = "ایمیل")]
        public string  Email{ get; set; }


     

        [StringLength(maximumLength: 200, ErrorMessage = "حداکثر 200 کاراکتر وارد کنید")]
        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(2, ErrorMessage = "حداقل 2 حرف وارد کنید")]
        [Display(Name = "نام  ")]
        public string Nickname { get; set; }



        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        [Display(Name = "نام ")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        [MinLength(2, ErrorMessage = "حداقل 2 حرف وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

      

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [MinLength(2, ErrorMessage = "حداقل 2 حرف وارد کنید")]
        [Display(Name = " تاریخ تولد ")]
        public string Birthdate { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = "حداکثر 10 کاراکتر وارد کنید")]
       [MinLength(10,ErrorMessage ="حداقل  10 کاراکتر وارد کنید")]
        [Display(Name = "  کد ملی ")]
        public string NationalCode { get; set; }

      

        [StringLength(maximumLength: 11, ErrorMessage = "حداکثر 11 کاراکتر وارد کنید")]
        [Display(Name = "   شماره تماس ")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

      

        [Display(Name = "  آدرس ")]
        public string Address { get; set; }



        /// <summary>
        /// آدرس عکس
        /// </summary>
        public string PhotoAddress { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }


    }
}
