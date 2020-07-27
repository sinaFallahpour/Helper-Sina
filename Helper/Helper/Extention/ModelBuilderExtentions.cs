using Helper.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Extention
{
    public static class ModelBuilderExtentions
    {

        public static void Seed(this ModelBuilder builder)
        {
            builder.Entity<TBL_Setting>().HasData(
                   new TBL_Setting()
                   {
                       Id = 1,
                       Key = "AboutUs",
                       CreatedAt = DateTime.Now,
                       Value = ""
                   },
                   new TBL_Setting()
                   {
                       Id = 2,
                       Key = "Contactus",
                       CreatedAt = DateTime.Now,
                       Value = ""
                   }, new TBL_Setting()
                   {
                       Id = 3,
                       Key = "Slider",
                       CreatedAt = DateTime.Now,
                       Value = ""
                   }
                 );
        }
    }
}
