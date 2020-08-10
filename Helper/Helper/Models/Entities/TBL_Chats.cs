using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_Chats : BaseEntity<int>
    {

        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "متن کامنت")]
        [MaxLength(1500, ErrorMessage = "حداکثر 1500 کاراکتر وارد کنید")]
        [MinLength(1, ErrorMessage = "حداقل 1 کاراکتر وارد کنید")]
        public string Text { get; set; }


        public DateTime CreateDate { get; set; }




        #region   relation
        public string SenderId { get; set; }

        [ForeignKey("SenderId")]
        public ApplicationUser Sender { get; set; }


        public string GetterId { get; set; }

        [ForeignKey("GetterId")]
        public ApplicationUser Getter { get; set; }

        #endregion

    }
}
