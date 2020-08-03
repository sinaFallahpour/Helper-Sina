using Helper.Extention;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.News
{
    public class CreateArticleViewModel : CreateBaseViewModel
    {
        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = " عکس مقاله")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".svg", ".gif" })]
        [MaxFileSize(10 * 1024 * 1024)]
        [NotMapped]
        public IFormFile ArticlePhoto { get; set; }

        public string ArticlePhotoAddress { get; set; }
    }
}
