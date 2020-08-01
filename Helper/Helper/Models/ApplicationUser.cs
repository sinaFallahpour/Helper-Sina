using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models
{
    public class ApplicationUser : IdentityUser
    {


        [StringLength(maximumLength: 100,ErrorMessage ="حداکثر 100 کاراکتر وارد کنید")]
        [Display(Name = "نام ")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        [Display(Name ="نام خانوادگی")]
        public string LastName { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "حداکثر 200 کاراکتر وارد کنید")]
        [Display(Name = "نام  ")]
        public string Nickname { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ تولد ")]
        public string Birthdate { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = "حداکثر 10 کاراکتر وارد کنید")]
        [Display(Name = "  کد ملی ")]
        public string NationalCode { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = "حداکثر 10 کاراکتر وارد کنید")]
        [Display(Name = "  جنسیت  ")]
        public string Gender { get; set; }

        [StringLength(maximumLength: 20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [Display(Name = "   شماره تماس ")]
        public string Phone { get; set; }

        public DateTime RegistrationDateTime { get; set; }

        [StringLength(maximumLength: 10, ErrorMessage = "حداکثر 10 کاراکتر وارد کنید")]
        public string VerificationCode { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "حداکثر 200 کاراکتر وارد کنید")]
        public string AvatarUrl { get; set; }

        [Display(Name = "  آدرس ")]
        public string Address { get; set; }


        /// <summary>
        /// قوانین را مپذیرم؟
        /// </summary>
        public bool AcceptRules { get; set; }


        /// <summary>
        /// آدرس عکس
        /// </summary>
        public string PhotoAddress { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }

       
        #region Relation


        /// <summary>
        /// ادمین که این ادمین راخلق کرد
        /// </summary>
        [ForeignKey("CreatedAdminId")]
        public virtual ApplicationUser CreatedAdmin { get; set; }
        public string CreatedAdminId { get; set; }



        //public virtual ICollection<IdentityUserRole<int>> Roles { get; } = new List<IdentityUserRole<int>>();


        public ICollection<IdentityUserRole<string>> UserRole { get; set; }


        #endregion  Relation


    }
}
