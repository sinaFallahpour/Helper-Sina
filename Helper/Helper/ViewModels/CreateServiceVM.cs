using Helper.Extention;
using Helper.Models.Enums;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class CreateServiceVM
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(30, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "عنوان خدمت")]
        public string Title { get; set; }



        [Required(ErrorMessage = "Required")]
        [MinLength(3, ErrorMessage = "Minimum length is {1} characters")]
        [MaxLength(500, ErrorMessage = "Maximum length is {1} characters")]
        [Display(Name = "توضیحات خدمت")]
        public string Description { get; set; }


        public DateTime CreateDate { get; set; }


        /// <summary>
        /// ليست مهارت هايش
        /// </summary>
        [Required(ErrorMessage = "{0} Is required.")]
        [MaxLength(600, ErrorMessage = "Maximum length is {1} characters")]


        [Display(Name = "Skills")]
        public string Skills { get; set; }

        /// <summary>
        /// سرويس گيرنده يادهنده
        /// </summary>
        public ServiceType ServiceType { get; set; }





        /// <summary>
        /// آيا توافقيست
        /// </summary>
        public bool IsAgreement { get; set; }



        /// <summary>
        /// تعداد لايك
        /// </summary>
        public int LikeCount { get; set; }


        /// <summary>
        /// تعداد كامنت
        /// </summary>
        public int CommentCount { get; set; }


        /// <summary>
        /// تعداد سين
        /// </summary>
        public int SeenCount { get; set; }



        /// <summary>
        /// ایا با ایمیل به خدمت دهتده فرستاده شود
        /// </summary>
        public bool IsSendByEmail { get; set; }


        /// <summary>
        /// ایا با نوتیفیکیشن به خدمت دهتده فرستاده شود
        /// </summary>
        public bool IsSendByNOtification { get; set; }


        /// <summary>
        /// ایا با اس ام اس به خدمت دهتده فرستاده شود
        /// </summary>
        public bool IsSendBySms { get; set; }


        /// <summary>
        /// حداقل فيمت
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "حداقل قیمت")]
        public double MinpRice { get; set; }


        /// <summary>
        /// حداكثر قيمت
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "حداقل قیمت")]
        public double MaxPrice { get; set; } = 9999999999999999999;



        #region relatoin

        //public string UserId { get; set; }


        public int? CityId { get; set; }

        //[ForeignKey("CityId")]
        //public virtual TBL_City City { get; set; }


        public int? CategoryId { get; set; }

        //[ForeignKey("CategoryId")]
        //public virtual TBL_Category Category { get; set; }


        public int? MonyUnitId { get; set; }

        //[ForeignKey("MonyUnitId")]
        //public virtual TBL_MonyUnit MonyUnit { get; set; }
        #endregion

    }
}
