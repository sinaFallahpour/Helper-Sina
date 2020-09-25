using Helper.Data;
using Helper.Models.Entities;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Identity;
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
                       Key = PublicHelper.AboutUsKeyName,
                       CreatedAt = DateTime.Now,
                       Value = "",
                       EnglishValue = ""
                   },
                   new TBL_Setting()
                   {
                       Id = 2,
                       Key = PublicHelper.ContactKeyName,
                       CreatedAt = DateTime.Now,
                       Value = "",
                       EnglishValue = ""
                   },
                    new TBL_Setting()
                    {
                        Id = 3,
                        Key = PublicHelper.SiteRulesKeyName,
                        CreatedAt = DateTime.Now,
                        Value = "",
                        EnglishValue = ""
                    },
                    new TBL_Setting()
                    {
                        Id = 4,
                        Key = PublicHelper.landingHelperText,
                        CreatedAt = DateTime.Now,
                        Value = "",
                        EnglishValue = ""
                    },
                    new TBL_Setting()
                    {
                        Id = 5,
                        Key = PublicHelper.ForUserText,
                        CreatedAt = DateTime.Now,
                        Value = "",
                        EnglishValue = ""
                    },
                    new TBL_Setting()
                    {
                        Id = 6,
                        Key = PublicHelper.ForProfessionalText,
                        CreatedAt = DateTime.Now,
                        Value = "",
                        EnglishValue = ""
                    },
                       new TBL_Setting()
                       {
                           Id = 7,
                           Key = PublicHelper.CreateServiceText,
                           CreatedAt = DateTime.Now,
                           Value = "",
                           EnglishValue = ""
                       }


                 );


            //builder.Entity<IdentityRole>().HasData(
            //    new IdentityRole()
            //    {
            //        Name = PublicHelper.ADMINROLE,
            //        NormalizedName = PublicHelper.ADMINROLE.Normalize(),
            //        Id = Guid.NewGuid().ToString(),
            //    },
            //     new IdentityRole()
            //     {
            //         Name = PublicHelper.USERROLE,
            //         NormalizedName = PublicHelper.USERROLE.Normalize(),
            //         Id = Guid.NewGuid().ToString(),
            //     }

            //     );


        }






    }
}
