using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_NewsLike : BaseEntity<int>
    {


        public DateTime CrateDate { get; set; }


        #region relation

        //relation with news
        [ForeignKey("NewsId")]
        public virtual TBL_NewsArticleVideo NewsArticleVideo { get; set; }

        public int? NewsId { get; set; }


        //relation with user
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        public string UserId { get; set; }


        #endregion   relation
    }
}
