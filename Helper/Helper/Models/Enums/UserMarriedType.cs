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
        [Display(Name = "Single")]
        [Description("Single")]
        single,
        [Display(Name = "Married")]
        [Description("Married")]
        Married
    }
}

