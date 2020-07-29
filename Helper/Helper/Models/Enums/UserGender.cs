using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Enums
{
    public enum UserGender
    {
        [Display(Name = "مرد")]
        [Description("مرد")]
        Man,
        [Display(Name = "زن")]
        [Description("زن")]
        Woman
    }
}
