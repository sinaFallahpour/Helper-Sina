using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_Plane_MonyUnit : BaseEntity<int>
    {

        #region   relation
        public int? PlanId { get; set; }

        [ForeignKey("PlanId")]
        public TBL_Plans Plan { get; set; }


        public int? MonyUnitId { get; set; }

        [ForeignKey("MonyUnitId")]
        public TBL_MonyUnit MonyUnit { get; set; }
       
        [Display(Name = "نام واحد پول")]
        public string MonyName { get; set; }


        [Display(Name = "نام واحد پول")]
        public string MonyEnglishName { get; set; }

        /// <summary>
        /// آیا این  واحد پول فعال است
        /// </summary>
        [Display(Name = "  آیا فعال است؟")]
        public bool IsEnabled { get; set; }



        public string Price { get; set; }


        #endregion

    }
}
