using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.DTO.News
{
    public class ListNewsDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string CreateDate { get; set; }

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }

        public int SeenCount { get; set; }

        public string ArticlePhotoAddress { get; set; }

        public string VideoAddress { get; set; }

        public bool isLiked { get; set; }


        public NewsType NewsType { get; set; }


    }
}
