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

            //adding database vaku for Setting
            builder.Seed();
        }

        public DbSet<TBL_Setting> TBL_Settings { get; set; }

        public DbSet<TBL_Slide> TBL_Sliders { get; set; }



        public DbSet<TBL_NewsArticleVideo> TBL_NewsArticleVideo { get; set; }

        public DbSet<TBL_NewsComment> TBL_NewsComment { get; set; }

        public DbSet<TBL_NewsLike> TBL_NewsLike { get; set; }

        public DbSet<Helper.Areas.Admin.Models.ViewModels.NewFolder.NewsListViewModel> NewsListViewModel { get; set; }

        public DbSet<Helper.Areas.Admin.Models.ViewModels.News.CreateArticleViewModel> CreateArticleViewModel { get; set; }




    }
}
