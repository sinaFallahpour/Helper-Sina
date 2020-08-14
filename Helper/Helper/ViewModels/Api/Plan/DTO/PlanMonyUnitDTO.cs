using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels.Api.Plan.DTO
{
    public class PlanMonyUnitDTO
    {

        /// <summary>
        /// قیمت پنل
        /// </summary>
        [Display(Name = "قیت")]
        public int Price { get; set; }




        [Display(Name = "نام واحد پول")]
        public string MonyName { get; set; }
    }
}
