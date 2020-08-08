using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Enums
{
    public enum SiteLanguage
    {
        [Description("انگلیسی")]
        [Display(Name = "انگلیسی")]
        English,
        [Description("فارسی")]
        [Display(Name = "فارسی")]
        Persian
    }
}
