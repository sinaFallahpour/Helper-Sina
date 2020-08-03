using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_NewsComment : BaseEntity<int>
    {


        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "متن کامنت")]
        [MaxLength(1500, ErrorMessage = "حداکثر 1500 کاراکتر وارد کنید")]
        [MinLength(1, ErrorMessage = "حداقل 1 کاراکتر وارد کنید")]
        public string Text { get; set; }


        public DateTime CreateDate { get; set; }


        #region relation

        //relation with news
        [ForeignKey("NewsId")]
        public virtual TBL_NewsArticleVideo NewsArticleVideo { get; set; }

        public int? NewsId { get; set; }



        //relation with user
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }


        #endregion relation


    }
}
