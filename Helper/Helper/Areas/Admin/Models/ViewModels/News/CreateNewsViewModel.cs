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
    public class CreateNewsViewModel : CreateBaseViewModel
    {
        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = " فیلم ")]
        [AllowedExtensions(new string[] { ".mp4", ".avi", ".hd", ".mpg", ".gif", ".vtt", ".mov", ".mkv", ".wmv" })]
        [MaxFileSize(30 * 1024 * 1024)]
        [NotMapped]
        public IFormFile Video { get; set; }

        public string VideoAddress { get; set; }

    }
}
