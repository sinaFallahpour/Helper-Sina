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
    public class EditNewsViewModel : CreateBaseViewModel
    {

     
        [Display(Name = " فیلم ")]
        [AllowedExtensions(new string[] { ".mp4", ".ogg", ".avi", ".hd", ".mpg", ".gif", ".vtt", ".mov", ".mkv", ".wmv" })]
        [MaxFileSize(100 * 1024 * 1024)]
        [NotMapped]
        public IFormFile Video { get; set; }

        public string VideoAddress { get; set; }




        [Display(Name = " English Video ")]
        [AllowedExtensions(new string[] { ".mp4", ".ogg", ".avi", ".hd", ".mpg", ".gif", ".vtt", ".mov", ".mkv", ".wmv" })]
        [MaxFileSize(100 * 1024 * 1024)]
        [NotMapped]
        public IFormFile EnglishVideo { get; set; }

        public string EnglishVideoAddress { get; set; }


    }
}
