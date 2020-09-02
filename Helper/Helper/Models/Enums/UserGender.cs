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
        [Display(Name = "Man")]
        [Description("Man")]
        Man,
        [Display(Name = "Woman")]
        [Description("Woman")]
        Woman
    }
}
