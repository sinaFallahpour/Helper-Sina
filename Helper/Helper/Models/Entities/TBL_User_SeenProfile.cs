using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_User_SeenProfile : BaseEntity<int>
    {





        public DateTime CreateDate { get; set; }




        #region   relation
        public string CurrentUserId { get; set; }

        [ForeignKey("CurrentUserId")]
        public ApplicationUser CurrentUser { get; set; }


        public string SeenerId { get; set; }

        [ForeignKey("SeenerId")]
        public ApplicationUser Seener { get; set; }

        #endregion

    }
}
