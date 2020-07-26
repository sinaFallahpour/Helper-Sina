using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_AboutUs : BaseEntity<int>
    {
        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(2, ErrorMessage = "حداقل 20 کاراکتر ")]
        [Display(Name = " عنوان ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [MinLength(20, ErrorMessage = "حداقل 20 کاراکتر ")]
        [Display(Name = "متن درباره ما")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required(ErrorMessage = "این فیلد الزامیست")]
        [Display(Name = "آیا متن اصلیست")]
        public bool IsMain { get; set; }

    }
}
