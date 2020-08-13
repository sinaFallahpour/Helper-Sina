using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Enums
{
    public enum UserMarriedType
    {
        [Display(Name = "مجرد ")]
        [Description("مجرد")]
        single,
        [Display(Name = "متاهل")]
        [Description("متاهل")]
        Married
    }
}