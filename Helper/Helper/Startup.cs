using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using Helper.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Helper.Common;
using Helper.Models.Service;
using API.Middleware;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Helper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            //cors origin
            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000").AllowCredentials();
                });
            });

            services.AddControllersWithViews();
            services.AddRazorPages();


            //setting  of identity
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = false;
            })
            .AddRoleManager<RoleManager<IdentityRole>>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationDbContext>();



            //setting of cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/accessDenied";
                options.Cookie.Name = "YourAppCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(7);
                options.LoginPath = "/admin/admins/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });



            //jwt seeting 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PublicHelper.SECREKEY));


            services.AddAuthentication()
               .AddCookie(cfg => { cfg.SlidingExpiration = true; })
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false
                    };
                });




            services.AddSession();

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddRazorPages()
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/{0}.cshtml");
                });








            //add more claim to  cookie
            services.AddTransient<IUserClaimsPrincipalFactory<ApplicationUser>, MyClaimPrincipalFactory>();


            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            //AddDefaultTokenProviders  را اضافه نکردم
            //services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //   .AddEntityFrameworkStores<ApplicationDbContext>()
            //   .AddDefaultUI()
            //   .AddDefaultTokenProviders();




            //services.AddControllersWithViews();
            //services.AddRazorPages();


            services.AddMvc(options => options.EnableEndpointRouting = false);



            services.AddScoped<JwtGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{area:Admin}/{controller=Home}/{action=Index}/{id?}");
            //    endpoints.MapRazorPages();
            //});



            ///okkkkkkk
            app.UseMvc(routes =>
            {

                routes.MapRoute(
                 name: "areas",
                  template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                //                   namespaces:new[] { "Payroll_Sytem.Controllers" }
                );


                routes.MapRoute(
                  name: "Default",
                  template: "{controller}/{action}/{id?}",
                 defaults: new { Areas = "Admin", controller = "Home", action = "Index", id = UrlParameter.Optional }
                 //                   namespaces:new[] { "Payroll_Sytem.Controllers" }
                );

            });








        }
    }
}
