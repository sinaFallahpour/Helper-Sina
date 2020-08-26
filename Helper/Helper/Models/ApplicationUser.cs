using Helper.Models.Entities;
using Helper.Models.Enums;
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

        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        [Display(Name = "نام ")]
        public string FirstName { get; set; }

        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; }

        [StringLength(maximumLength: 200, ErrorMessage = "حداکثر 200 کاراکتر وارد کنید")]
        [Display(Name = "نام  ")]
        public string Nickname { get; set; }

        [StringLength(maximumLength: 50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [Display(Name = " تاریخ تولد ")]
        public string Birthdate { get; set; }


        [Display(Name = "  جنسیت  ")]
        public UserGender Gender { get; set; }


        [Display(Name = "وضعیت")]
        public UserMarriedType MarriedType { get; set; }

        /// <summary>
        /// زبان  های مسلط
        /// </summary>
        [StringLength(maximumLength: 600, ErrorMessage = "حداکثر 600 کاراکتر وارد کنید")]
        public string LanguageKnowing { get; set; }


        /// <summary>
        /// مهارت های کاربر
        /// </summary>
        [StringLength(maximumLength: 600, ErrorMessage = "حداکثر 600 کاراکتر وارد کنید")]
        public string Skils { get; set; }



        /// <summary>
        ///  مهارت هایی که لازم دارد دیگران انجام بدهند  کاربر
        /// </summary>
        [StringLength(maximumLength: 600, ErrorMessage = "حداکثر 600 کاراکتر وارد کنید")]
        public string SkilsRequest { get; set; }




        [StringLength(maximumLength: 20, ErrorMessage = "حداکثر 20 کاراکتر وارد کنید")]
        [Display(Name = "   شماره تماس ")]
        public string Phone { get; set; }

        public DateTime RegistrationDateTime { get; set; }




        /// <summary>
        /// توضیحات خود
        /// </summary>
        [StringLength(maximumLength: 1000, ErrorMessage = "حداکثر 1000 کاراکتر وارد کنید")]
        public string Descriptions { get; set; }


        [StringLength(maximumLength: 100, ErrorMessage = "حداکثر 100 کاراکتر وارد کنید")]
        public string City { get; set; }


        /// <summary>
        /// زبان سایت
        /// </summary>
        public SiteLanguage SiteLanguage { get; set; }





        /// <summary>
        /// این همان توکنی که در دیتا بیس ذخیره میکنیم
        /// </summary>
        public string SerialNumber { get; set; }



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


        //relation with likes
        public virtual ICollection<TBL_NewsLike> NewsLike { get; set; }

        //realtion with comments
        public virtual ICollection<TBL_NewsComment> NewsComments { get; set; }



        //رابطه کاربر با سابقه تحصیلی
        //public int EduHistoryId { get; set; }


        public virtual TBL_EducationalHistory EducationHistry { get; set; }


        //رابطه کاربر با  سابقه کار
        //public int WorkExperienceId { get; set; }
        //[ForeignKey("WorkExperienceId")]
        public virtual TBL_WorkExperience WorkExperience { get; set; }



        //رابطه کاربر با اطلاعات بانکی 
        //public int WorkExperienceId { get; set; }
        //[ForeignKey("WorkExperienceId")]
        public virtual TBL_BankInfo BankInfo { get; set; }




        //public virtual ICollection<IdentityUserRole<int>> Roles { get; } = new List<IdentityUserRole<int>>();


        //public ICollection<IdentityUserRole<string>> UserRole { get; set; }




        /// <summary>
        /// آیدی آخرین پلن رزرو شده
        /// </summary>
        public int PlanId { get; set; }


        /// <summary>
        /// تاریخ روزی که پلن اکسپایر میشه
        /// </summary>
        public DateTime PlanExpDate { get; set; }

        /// <summary>
        /// تعداد از خدمت که  میتونم ارایه بدم
        /// </summary>
        public int PlanCount { get; set; }


        /// <summary>
        /// آیا از پلن رایگان استفاده کرده است یا نه
        /// </summary>
        public bool IsUsedFree { get; set; }


        #endregion  Relation


    }
}
