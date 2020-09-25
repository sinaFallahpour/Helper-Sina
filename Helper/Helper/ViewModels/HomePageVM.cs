using Helper.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.ViewModels
{
    public class HomePageVM
    {
        public List<TBL_Slide> Slides { get; set; }


        public int CityCount { get; set; }

        public int ServiceProviderCount { get; set; }

        public int DoneServiceCount { get; set; }

        public List<TBL_Category> Categories { get; set; }



        public string LandingHelperText { get; set; }

        public string ForUserText { get; set; }

        public string ForProfessionalText { get; set; }
        //public string CreateServiceText { get; set; }

    }
}
