using Helper.Models.Entities;
using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.NewFolder
{
    public class NewsListViewModel
    {

        public int Id { get; set; }

        [Display(Name ="عنوان")]
        public string Title { get; set; }

        [Display(Name = "تعداد لایک")]
        public int LikesCount { get; set; }

        [Display(Name = "تعداد کامنت")]
        public int CommentsCount { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int SeenCount { get; set; }

        [Display(Name = "نوع")]
        public NewsType NewsType { get; set; }
    }
}
