using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_MonyUnit : BaseEntity<int>
    {
        [Required(ErrorMessage = "نام واحد پول الزامیست")]
        [Display(Name = "نام واحد پول")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام انگلیسی واحد پول الزامیست")]
        [Display(Name = "نام انگلیسی واحد پول")]
        public string EnglishName { get; set; }

        /// <summary>
        /// آیا این  واحد پول فعال است
        /// </summary>
        /// 
        [Display(Name = "  آیا فعال است؟")]
        public bool IsEnabled { get; set; }



        #region Relation
        /// <summary>
        /// لیست واحد های پولی پلن
        /// </summary>
        public virtual ICollection<TBL_Plane_MonyUnit> PlansMonyUnit { get; set; }

        #endregion







    }
}
