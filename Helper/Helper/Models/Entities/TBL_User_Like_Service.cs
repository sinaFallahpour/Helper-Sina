using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_User_Like_Service : BaseEntity<int>
    {


        public DateTime CrateDate { get; set; }

        #region   relation

        public string UserName { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }



        public int? ServiceId { get; set; }

        [ForeignKey("ServiceId")]
        public TBL_Service Service { get; set; }

        #endregion
    }
}
