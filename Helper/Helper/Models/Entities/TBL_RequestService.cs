using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_RequestService : BaseEntity<int>
    {

        public DateTime CreateDate { get; set; }


        #region   relation
        public string GiverId { get; set; }

        [ForeignKey("GiverId")]
        public ApplicationUser Giver { get; set; }


        public string GetterId { get; set; }

        [ForeignKey("GetterId")]
        public ApplicationUser Getter { get; set; }

        #endregion

    }
}
