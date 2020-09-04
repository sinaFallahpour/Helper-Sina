using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Enums
{
    public enum ConfirmServiceType
    {
        [Description("تایید شده")]
        [Display(Name = "تایید شده")]
        Confirmed,
        [Description("رد شده")]
        [Display(Name = "رد شده")]
        Rejected,
        [Description("درحال بررسی")]
        [Display(Name = "درحال بررسی")]
        Pending

    }
}
