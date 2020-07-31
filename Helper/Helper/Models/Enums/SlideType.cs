using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Enums
{
    public enum SlideType
    {
     
        [Description("غیر فعال ")]
        NotActive,
        [Description("فعال")]
        IsActive,
        [Description("همه")]
        All
    }
}
