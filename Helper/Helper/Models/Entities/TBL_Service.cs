using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_Service : BaseEntity<int>
    {

        [Display(Name = "عنوان خدمت")]
        public string Title { get; set; }

        [Display(Name = "توضیحات خدمت")]
        public string Description { get; set; }



        [Display(Name = "تاریخ ثبت خدمت")]
        public DateTime CreateDate { get; set; }




        /// <summary>
        /// ليست مهارت هايش
        /// </summary>
        [Display(Name = " مهارت های ثبت شده")]
        public string Skills { get; set; }




        /// <summary>
        /// سرويس گيرنده يادهنده
        /// </summary>
        [Display(Name = "نوع سرویس")]
        public ServiceType ServiceType { get; set; }




        /// <summary>
        /// آيا توافقيست
        /// </summary>
        [Display(Name = "آيا توافقيست؟")]
        public bool IsAgreement { get; set; }



        /// <summary>
        /// تعداد لايك
        /// </summary>
        [Display(Name = "تعداد لایک")]
        public int LikeCount { get; set; }

        /// <summary>
        /// تعداد كامنت
        /// </summary>
        [Display(Name = "تعداد  کامنت")]
        public int CommentCount { get; set; }

        /// <summary>
        /// تعداد سين
        /// </summary>
        [Display(Name = "تعداد بازدید")]
        public int SeenCount { get; set; }



        /// <summary>
        /// ایا با ایمیل به خدمت دهتده فرستاده شود
        /// </summary>
        [Display(Name ="وضعیت ارسال با ایمیل")]
        public bool IsSendByEmail { get; set; }


        /// <summary>
        /// ایا با نوتیفیکیشن به خدمت دهتده فرستاده شود
        /// </summary>
        [Display(Name = "وضعیت ارسال با   نوتیفیکیشن")]
        public bool IsSendByNOtification { get; set; }


        /// <summary>
        /// ایا با اس ام اس به خدمت دهتده فرستاده شود
        /// </summary>

        [Display(Name = "وضعیت ارسال با اس ام اس")]
        public bool IsSendBySms { get; set; }


        /// <summary>
        /// حداقل فيمت
        /// </summary>
        [Display(Name = "حداقل قيمت")]
        public double MinpRice { get; set; }


        /// <summary>
        /// حداكثر قيمت
        /// </summary>
        [Display(Name = "حداكثر قيمت")]
        public double MaxPrice { get; set; }

        [Display(Name ="وضعیت تایید ادمین")]
        public ConfirmServiceType ConfirmServiceType { get; set; }

        #region relatoin

        [Display(Name = "نام کاربر")]
        public string Username { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }


        public int? CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual TBL_City City { get; set; }


        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual TBL_Category Category { get; set; }


        public int? MonyUnitId { get; set; }

        [ForeignKey("MonyUnitId")]
        public virtual TBL_MonyUnit MonyUnit { get; set; }

        public ICollection<TBL_User_Like_Service> UserLikeServices { get; set; }

        #endregion

    }
}
