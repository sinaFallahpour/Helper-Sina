using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Enums
{
    public enum SendType
    {
        [Description("اس ام اس")]
        [Display(Name = "اس ام اس"  )]
        SMS,
        [Description("ايميل")]
        [Display(Name = "ايميل")]
        Email,
        [Description("نوتيفيكيشن")]
        [Display(Name = "نوتيفيكيشن")]
        Notification,
    }
}
