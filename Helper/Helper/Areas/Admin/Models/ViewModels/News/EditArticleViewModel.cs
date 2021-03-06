﻿using Helper.Extention;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.News
{
    public class EditArticleViewModel:CreateBaseViewModel
    {
        
        [Display(Name = " عکس مقاله")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".svg", ".gif" })]
        [MaxFileSize(20 * 1024 * 1024)]
        [NotMapped]
        public IFormFile ArticlePhoto { get; set; }

        public string ArticlePhotoAddress { get; set; }



        [Display(Name = " عکس EnglishArticle")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".svg", ".gif" })]
        [MaxFileSize(20 * 1024 * 1024)]
        [NotMapped]
        public IFormFile englishArticlePhoto { get; set; }

        public string EnglishArticlePhotoAddress { get; set; }

    }
}
