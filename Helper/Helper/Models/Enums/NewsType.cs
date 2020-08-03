using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Enums
{
    public enum NewsType
    {
        [Description("خبر")]
        [Display(Name = "خبر")]
        News,
        [Description("مقاله")]
        [Display(Name = "مقاله")]
        Arrticle,
        [Description("فیلم")]
        [Display(Name = "فیلم")]
        Videos,

    }
}
