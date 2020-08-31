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
            builder.Entity<TBL_NewsArticleVideo>()
                .HasMany(b => b.NewsLike)
                 .WithOne(p => p.NewsArticleVideo)
                  .HasForeignKey(p => p.NewsId)
                      .OnDelete(DeleteBehavior.Cascade);


            //1 به 0 کاربر واطلاعات درسی
            builder.Entity<TBL_EducationalHistory>(entity =>
            {
                entity.HasKey(c => c.UserId);
                entity.HasOne(c => c.User)
                    .WithOne(c => c.EducationHistry)
                        .HasForeignKey<TBL_EducationalHistory>(c => c.UserId)
                            .OnDelete(DeleteBehavior.Cascade);
            });


            //1 به 0 کاربر واطلاعات کاری
            builder.Entity<TBL_WorkExperience>(entity =>
            {
                entity.HasKey(c => c.UserId);
                entity.HasOne(c => c.User)
                    .WithOne(c => c.WorkExperience)
                        .HasForeignKey<TBL_WorkExperience>(c => c.UserId)
                            .OnDelete(DeleteBehavior.Cascade);
            });


            //1 به 0 کاربر واطلاعات بانکی
            builder.Entity<TBL_WorkExperience>(entity =>
            {
                entity.HasKey(c => c.UserId);
                entity.HasOne(c => c.User)
                    .WithOne(c => c.WorkExperience)
                        .HasForeignKey<TBL_WorkExperience>(c => c.UserId)
                            .OnDelete(DeleteBehavior.Cascade);
            });



             //پول ورابطه ان  به  ان  با پول پلن
            builder.Entity<TBL_MonyUnit>(entity =>
            {
                entity.HasMany(c => c.PlansMonyUnit)
                  .WithOne(c => c.MonyUnit)
                  .OnDelete(DeleteBehavior.Cascade);
            });
           



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


        ///// <summary>
        /////  نوع هاي خدمت 
        ///// </summary>
        //public DbSet<TBL_ServiceLevel2> TBL_ServiceLevel2 { get; set; }


        /// <summary>
        /// لايك ها خدمت هايي از كاربر
        /// </summary>
        public DbSet<TBL_User_Like_Service> TBL_UserLikeSerive { get; set; }


        /// <summary>
        /// كامنت هاي كاربر روي خدمت هايي
        /// </summary>
        public DbSet<TBL_User_Comment_Service> TBL_UserCommentService { get; set; }


        public DbSet<TBL_User_SeenProfile> TBL_UserSeenProfile { get; set; }


        public DbSet<TBL_Category> TBL_Category { get; set; }


        public DbSet<TBL_City> TBL_City { get; set; }

       


        /// <summary>
        ///اطلاعات کاری کاربر
        /// </summary>
        public DbSet<TBL_WorkExperience> TBL_WorkExperience { get; set; }


        /// <summary>
        ///اطلاعات درسی کاربر
        /// </summary>
        public DbSet<TBL_EducationalHistory> TBL_EducationalHistory { get; set; }
        

        /// <summary>
        ///اطلاعات بانکی کاربر
        /// </summary>
        public DbSet<TBL_BankInfo> TBL_BankInfo { get; set; }


        /// <summary>
        ///پلن های موجود
        /// </summary>
        public DbSet<TBL_Plans> TBL_Plans { get; set; }


        /// <summary>
        /// واحد های پول
        /// </summary>
        public DbSet<TBL_MonyUnit> TBL_MonyUnit { get; set; }

        /// <summary>
        /// پنل و واحد پول
        /// </summary>
        public DbSet<TBL_Plane_MonyUnit> TBL_Plane_MonyUnit { get; set; }

        /// <summary>
        /// پنل و واحد پول
        /// </summary>
        public DbSet<Helper.ViewModels.CreateServiceVM> CreateServiceVM { get; set; }

        /// <summary>
        /// پنل و واحد پول
        /// </summary>
        public DbSet<Helper.ViewModels.OtherUserProfileVM> OtherUserProfile { get; set; }

        /// <summary>
        /// پنل و واحد پول
        /// </summary>
        public DbSet<Helper.ViewModels.ServiceListVM> ServiceListVM { get; set; }

       



    }
}
