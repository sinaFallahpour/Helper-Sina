﻿using System;
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
using Microsoft.AspNetCore.Http.Features;
using AutoMapper;
using Helper.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

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
            services.AddLocalization(options => options.ResourcesPath = "Resources");




            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlServer(
                  Configuration.GetConnectionString("DefaultConnection")));

            //cors origin
            services.AddCors(opt =>
            {
                
                opt.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://helperlanding.niknet.co",
                               "http://localhost:3000",
                                "https://helperadmin.niknet.co")
                    .AllowCredentials();
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
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789@#+-اآبپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیئيك";
            })
            .AddRoleManager<RoleManager<IdentityRole>>()
            //این توکن میسازه   باید باشه برا چنج پسورد و.کانفیرم ایمیل
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<ApplicationDbContext>();



            //setting of cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Error/AccesDenied";
                options.Cookie.Name = "YourAppCookieName";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(1);
                options.LoginPath = "/account/login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });


            //file size checking
            services.Configure<FormOptions>(options =>
            {
                //options.MultipartBodyLengthLimit = 60000000;

                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
            });



            //jwt seeting 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(PublicHelper.SECREKEY));

            //JwtBearerDefaults.AuthenticationScheme
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


            services.AddMvc(options => options.EnableEndpointRouting = false)
                 .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix,
                    options => { options.ResourcesPath = "Resources"; })
                .AddDataAnnotationsLocalization(options =>
                {
                    options.DataAnnotationLocalizerProvider = (type, factory) =>
                        factory.Create(typeof(ShareResource));
                });


            //Add MailKit
            services.AddMailKit(optionBuilder =>
            {
                optionBuilder.UseMailKit(new MailKitOptions()
                {
                    //get options from sercets.json
                    Server = "Server",

                    Port = Convert.ToInt32(587),
                    SenderName = "Helper",
                    SenderEmail = "fallahpour.sina77@gmail.com",

                    // can be optional with no authentication 
                    //Account = Configuration["Account"],
                    //Password = Configuration["Password"],
                    // enable ssl or tls
                    Security = true
                });
            });



            //inject autoMapper
            services.AddAutoMapper(typeof(TBL_NewsArticleVideo).Assembly);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<JwtGenerator>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHttpContextAccessor accesor)
        {

            app.UseMiddleware<ErrorHandlingMiddleware>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {

                //app.UseStatusCodePagesWithRedirects("/Error/{0}");

                app.UseExceptionHandler("/Home/Error");
                
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithRedirects("/Error/{0}");



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

           

            //2 زبانه
            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo(PublicHelper.persianCultureName),
                new CultureInfo(PublicHelper.EngCultureName)
            };
            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(PublicHelper.persianCultureName),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures,
                RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
            };
            app.UseRequestLocalization(options);




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
