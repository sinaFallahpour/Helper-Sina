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

namespace Helper.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        //public DbSet<LoginAdminViewModel> LoginAdminViewModel { get; set; }
        public DbSet<TBL_AboutUs> TBL_AboutUs { get; set; }
        public DbSet<Setting> Settings { get; set; }


        //public DbSet<LoginAdminViewModel> LoginAdminViewModel { get; set; }
        //public DbSet<Helper.ViewModels.RegisterViewModel> RegisterViewModel { get; set; }


        //public DbSet<LoginAdminViewModel> LoginAdminViewModel { get; set; }
        //public DbSet<Helper.ViewModels.RegisterViewModel> RegisterViewModel { get; set; }

    }
}
