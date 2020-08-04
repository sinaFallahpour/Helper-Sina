using Helper.Extention;
using Helper.Models.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_NewsArticleVideo : BaseEntity<int>
    {
        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "توضیحات")]
        [MaxLength(50, ErrorMessage = "حداکثر 50 کاراکتر وارد کنید")]
        [MinLength(1, ErrorMessage = "حداقل 1 کاراکتر وارد کنید")]
        public string Title { get; set; }



        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "توضیحات")]
        [MaxLength(2000, ErrorMessage = "حداکثر 2000 کاراکتر وارد کنید")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر وارد کنید")]
        public string Description { get; set; }

        public string CreateDate { get; set; }

        [Display(Name = "تعداد لایک")]
        public int LikesCount { get; set; }
        
        [Display(Name = "تعدادکامنت")]
        public int CommentsCount { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int SeenCount { get; set; }

        [Display(Name = "  دسته بندی")]
        public NewsType NewsType { get; set; }


        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = " عکس مقاله")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".svg", ".gif" })]
        [MaxFileSize(20 * 1024 * 1024)]
        [NotMapped]
        public IFormFile ArticlePhoto { get; set; }

        public string ArticlePhotoAddress { get; set; }


        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = " فیلم ")]
        [AllowedExtensions(new string[] { ".mp4", ".avi", ".hd", ".mpg", ".gif", ".vtt", ".mov", ".mkv", ".wmv" })]
        [MaxFileSize(30 * 1024 * 1024)]
        [NotMapped]
        public IFormFile Video { get; set; }

        public string VideoAddress { get; set; }




        #region  Relation

       
        //relation with likes
        public virtual ICollection<TBL_NewsLike> NewsLike { get; set; }

        //realtion with comments
        public virtual ICollection<TBL_NewsComment> NewsComments { get; set; }


        #endregion  Relation


    }
}
