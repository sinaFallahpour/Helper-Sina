using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DNTPersianUtils.Core;

namespace Helper.Models.Entities
{
    public class TBL_BankInfo    /* : BaseEntity<int>*/
    {

        /// <summary>
        ///نام بانک
        /// </summary>
        public string BankName { get; set; }


        /// <summary>
        /// نام صاحب حساب بانک
        /// </summary>
        public string AccountOwner { get; set; }


        /// <summary>
        /// شماره کارت
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string ShabaNumber { get; set; }


        /// <summary>
        /// شماره ویزا یا مسترکارد
        /// </summary>
        public string VisaNumber { get; set; }




        #region Relations
        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }



        #endregion

    }
}
