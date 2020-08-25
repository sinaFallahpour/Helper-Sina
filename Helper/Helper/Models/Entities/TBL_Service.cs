using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_Service : BaseEntity<int>
    {


        public string Title { get; set; }

        public string Description { get; set; }


        public DateTime CreateDate { get; set; }




        /// <summary>
        /// ليست مهارت هايش
        /// </summary>
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
        public int MinpRice { get; set; }


        /// <summary>
        /// حداكثر قيمت
        /// </summary>
        public int MaxPrice { get; set; }



        #region relatoin

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
        #endregion

    }
}
