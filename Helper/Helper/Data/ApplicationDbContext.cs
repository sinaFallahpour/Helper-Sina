using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Helper.Areas.Admin.Models;
using Helper.Models.Entities;
using Helper.Areas.Admin.Models.ViewModels;
using Helper.Models;
using Helper.ViewModels;
using Helper.Extention;
using Helper.Areas.Admin.Models.ViewModels.User;
using Helper.Controllers;
using Helper.Areas.Admin.Models.ViewModels.NewFolder;
using Helper.Areas.Admin.Models.ViewModels.News;
using Helper.ViewModels.Api.AccountSettings;
namespace Helper.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //1 to n news and comment
            builder.Entity<TBL_NewsArticleVideo>().HasMany(b => b.NewsComments)
                 .WithOne(p => p.NewsArticleVideo)
                  .HasForeignKey(p => p.NewsId)
                      .OnDelete(DeleteBehavior.Cascade);


            //1 to n bew and like
            builder.Entity<TBL_NewsArticleVideo>().HasMany(b => b.NewsLike)
                 .WithOne(p => p.NewsArticleVideo)
                  .HasForeignKey(p => p.NewsId)
                      .OnDelete(DeleteBehavior.Cascade);




            //adding database value for Setting
            builder.Seed();
        }

        public DbSet<TBL_Setting> TBL_Settings { get; set; }

        public DbSet<TBL_Slide> TBL_Sliders { get; set; }



        public DbSet<TBL_NewsArticleVideo> TBL_NewsArticleVideo { get; set; }

        public DbSet<TBL_NewsComment> TBL_NewsComment { get; set; }

        public DbSet<TBL_NewsLike> TBL_NewsLike { get; set; }



        /// <summary>
        /// خدمت ها
        /// </summary>
        public DbSet<TBL_Service> TBL_Service { get; set; }


        /// <summary>
        ///  نوع هاي خدمت 
        /// </summary>
        public DbSet<TBL_ServiceLevel2> TBL_ServiceLevel2 { get; set; }



        /// <summary>
        /// لايك ها خدمت هايي از كاربر
        /// </summary>
        public DbSet<TBL_User_Like_Service> UserLikeSerive { get; set; }



        /// <summary>
        /// كامنت هاي كاربر روي خدمت هايي
        /// </summary>
        public DbSet<TBL_User_Comment_Service> UserCommentService { get; set; }






    }
}
