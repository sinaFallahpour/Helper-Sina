using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Helper.Areas.Admin.Models;
using Helper.Models.Entities;
using Helper.Areas.Admin.Models.ViewModels;
using Helper.Models;

namespace Helper.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Helper.Areas.Admin.Models.Class> Class { get; set; }
        //public DbSet<AppUser> ApplicationUser { get; set; }
        public DbSet<Helper.Areas.Admin.Models.ViewModels.LoginAdminViewModel> LoginAdminViewModel { get; set; }

    }
}
