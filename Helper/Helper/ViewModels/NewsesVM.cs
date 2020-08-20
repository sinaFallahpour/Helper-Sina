using Helper.Models.Entities;
using Helper.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class NewsesVM
    {
        [Key]
        public int Key { get; set; }
        public List<Newse> Newses { get; set; }
        public List<Newse> Videos { get; set; }
        public List<Newse> Articles { get; set; }
    }




    public class Newse
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
