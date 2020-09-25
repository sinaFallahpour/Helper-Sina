using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class ProfileWithDashboardVM
    {
        public ProfileVM2 Profile { get; set; }
        public List<ServiceListVM> Services { get; set; }
    }
}
