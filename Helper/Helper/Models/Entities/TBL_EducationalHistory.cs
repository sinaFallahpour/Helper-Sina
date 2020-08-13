using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    /// <summary>
    /// سابقه تحصیلی کاربر
    /// </summary>
    public class TBL_EducationalHistory /*: BaseEntity<int>*/
    {


        /// <summary>
        /// مقطع
        /// </summary>
        public string MaghTa { get; set; }


        public string UnivercityName { get; set; }



        public string EnterDate { get; set; }


        public string ExitDate { get; set; }



        #region Relations

        [Key]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }



        #endregion
    }
}
