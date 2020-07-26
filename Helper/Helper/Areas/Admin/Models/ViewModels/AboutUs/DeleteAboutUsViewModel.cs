using Helper.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Areas.Admin.Models.ViewModels.AboutUs
{
    public class DeleteAboutUsViewModel
    {
        public DeleteAboutUsViewModel(TBL_AboutUs AboutUs,bool IsSuccess )
        {
            this.AboutUs = AboutUs;
            this.IsSuccess = IsSuccess;
        }


        public TBL_AboutUs  AboutUs { get; set; }
        public  bool IsSuccess { get; set; }
    }
}
