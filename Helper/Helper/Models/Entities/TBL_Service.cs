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

        public string Name { get; set; }

        public string Description { get; set; }


        /// <summary>
        /// شهر
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// دسته بندي
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// ليست مهارت هايش
        /// </summary>
        public string Skills { get; set; }

        /// <summary>
        /// سرويس گيرنده يادهنده
        /// </summary>
        public ServiceType ServiceType { get; set; }


        /// <summary>
        /// نحوه فرستادتن به خدمت گيرنده
        /// </summary>
        public SendType SendType { get; set; }

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
        
        #endregion

    }
}
