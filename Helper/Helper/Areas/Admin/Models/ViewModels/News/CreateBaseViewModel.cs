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
        [Display(Name = "عنوان")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [MinLength(1, ErrorMessage = "حداقل 1 کاراکتر وارد کنید")]
        public string Title { get; set; }



        [Required(ErrorMessage = "این فیلد الزامیست")]
        [Display(Name = "EnglishTitle")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [MinLength(1, ErrorMessage = "حداقل 1 کاراکتر وارد کنید")]
        public string EnglishTitle { get; set; }






        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "توضیحات")]
        [MaxLength(2000, ErrorMessage = "حداکثر 2000 کاراکتر وارد کنید")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر وارد کنید")]
        public string Description { get; set; }




        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "EnglishDescription")]
        [MaxLength(2000, ErrorMessage = "حداکثر 2000 کاراکتر وارد کنید")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر وارد کنید")]
        public string EnglishDescription { get; set; }




        public string CreateDate { get; set; }

        [Display(Name = "دسته بندی")]
        public NewsType NewsType { get; set; }




    }
}
