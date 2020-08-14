using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Plan.DTO
{
    public class PlanDTO
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





        /// <summary>
        /// لیست واحد های پولی پلن
        /// </summary>
        public virtual ICollection<PlanMonyUnitDTO> PlanMonyUnitDTO { get; set; }




    }
}
