using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.News
{
    public class CreateBaseViewModel
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "توضیحات")]
        [MaxLength(550, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [MinLength(1, ErrorMessage = "حداقل 1 کاراکتر وارد کنید")]
        public string Title { get; set; }


        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "توضیحات")]
        [MaxLength(1500, ErrorMessage = "حداکثر 1500 کاراکتر وارد کنید")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر وارد کنید")]
        public string Description { get; set; }

        public string CreateDate { get; set; }

        
        public NewsType NewsType { get; set; }



    }
}
