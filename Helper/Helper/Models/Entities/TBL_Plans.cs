using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_Plans
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "نام")]
        public string Name { get; set; }




        /// <summary>
        /// تعداد سرویس های این پلن
        /// </summary>
        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = " تعداد سرویس قابل استفاده")]
        public int ServiceCount { get; set; }



        /// <summary>
        ///تعداد ماه اعتبار این پلن
        /// </summary>
        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "تعداد ماه  اعتبار")]
        public int Duration { get; set; }



        ///// <summary>
        ///// قیمت پنل
        ///// </summary>
        ///// 
        //[Required(ErrorMessage = "قیمت الزامیست")]
        //[Display(Name = "قیت")]
        //public int Price { get; set; }




        /// <summary>
        /// توضیحات
        /// </summary>
        [MaxLength(220, ErrorMessage = "حداکثر 220 کاراکتر وارد کنید")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }






        #region  Realtion
        
        
        /// <summary>
        /// لیست واحد های پولی پلن
        /// </summary>
        public virtual ICollection<TBL_Plane_MonyUnit> PlansMonyUnit { get; set; }



        #endregion Realtion

    }
}
