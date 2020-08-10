using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Enums
{
    public enum ServiceType
    {
        [Description("سرويس دهنده")]
        [Display(Name = "سرويس دهنده")]
        GiverService,
        [Description("سرويس گيرنده")]
        [Display(Name = "سرويس گيرنده")]
        GetterService,
    }
}
