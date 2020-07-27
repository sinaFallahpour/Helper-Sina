using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Entities
{
    public class TBL_Slide : BaseEntity<int>
    {
        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "عنوان")]
        public string Title { get; set; }

        [Required(ErrorMessage = "الزامیست")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        public string PhotoAddress { get; set; }

        [Required(ErrorMessage = "الزامیست")]
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
