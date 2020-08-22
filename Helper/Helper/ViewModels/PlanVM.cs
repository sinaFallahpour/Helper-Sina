using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class PlanVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام")]
        public string Name { get; set; }


        /// <summary>
        /// تعداد سرویس های این پلن
        /// </summary>
        [Display(Name = " تعداد سرویس قابل استفاده")]
        public int ServiceCount { get; set; }



        /// <summary>
        /// توضیحات
        /// </summary>
        [Display(Name = "توضیحات")]
        public string Description { get; set; }




        /// <summary>
        ///تعداد ماه اعتبار این پلن
        /// </summary>
        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "تعداد ماه  اعتبار")]
        public int Duration { get; set; }





        public bool IsSelected { get; set; }



        public bool  IsFree { get; set; }
        
        
        /// <summary>
        /// لیست واحد های پولی پلن
        /// </summary>
        public virtual ICollection<MonyUnitTVM> PlanMonyUnits { get; set; }
    }



    public class MonyUnitTVM {
        /// <summary>
        /// قیمت پنل
        /// </summary>
        [Display(Name = "قیت")]
        public int Price { get; set; }




        [Display(Name = "نام واحد پول")]
        public string MonyName { get; set; }
    }
}
