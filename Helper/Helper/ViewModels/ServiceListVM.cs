﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class ServiceListVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }


        public DateTime CreateDate { get; set; }
        /// <summary>
        /// تعداد لايك
        /// </summary>
        public int LikeCount { get; set; }

        /// <summary>
        /// تعداد كامنت
        /// </summary>
        public int CommentCount { get; set; }

        /// <summary>
        /// تعداد سين
        /// </summary>
        public int SeenCount { get; set; }


        /// <summary>
        /// آیا این سرویس توسط کاربر فعلی لایک شده یا خیر
        /// </summary>
        public bool IsLiked { get; set; }





         /// <summary>
         /// نام  دسته بندی 
         /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// نام انگکلیسی دسته بندی
        /// </summary>
        public string CategoryEnglishEnglishName { get; set; }
        
        /// <summary>
        /// عکس دسته بندی
        /// </summary>
        public string CategoryImageAddres { get; set; }

    }
}
