using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Helper.Models;
using Microsoft.AspNetCore.Authorization;
using Helper.Models.Utilities;
using Helper.Data;
using Helper.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using Microsoft.Extensions.Localization;
using Helper.Models.Enums;
using Helper.Models.Entities;
using DNTPersianUtils.Core;

namespace Helper.Controllers
{

    //[Authorize(Roles = Static.ADMINROLE)]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IStringLocalizer<HomeController> _localizer;

        public HomeController(
            ApplicationDbContext context,
             IStringLocalizer<HomeController> localizer)
        {
            _context = context;
            _localizer = localizer;
        }



        public async Task<IActionResult> Index()
        {
            ViewData["WhyHelper"] = _localizer["WhyHelper"];
            ViewData["HowHelperWork"] = _localizer["HowHelperWork"];

            ViewData["StartNow"] = _localizer["StartNow"];
            ViewData["ForProfessionals"] = _localizer["ForProfessionals"];
            ViewData["ForProfessionalsText"] = _localizer["ForProfessionalsText"];

            ViewData["NumberOfServiceProviders"] = _localizer["NumberOfServiceProviders"];
            ViewData["ServicesProvided"] = _localizer["ServicesProvided"];
            ViewData["citiesOfCovered"] = _localizer["citiesOfCovered"];


            ViewData["ForUsers"] = _localizer["ForUsers"];

            ViewData["ForUsersText"] = _localizer["ForUsersText"];

            ViewData["ViewCategories"] = _localizer["ViewCategories"];
            ViewData["SeeAll"] = _localizer["SeeAll"];
            ViewData["Service"] = _localizer["Service"];



            ViewData["Title1"] = _localizer["Title1"];
            ViewData["Text2"] = _localizer["Text2"];



            var citiesCount = await _context.TBL_City.CountAsync(c => c.IsEnabled == true);

            var ServiceProviderCount = await _context.Users.CountAsync(c => c.HasProviderService);

            var doneServiceCount = 0;

            var categories = await _context.TBL_Category.Where(c => c.IsEnabled == true)
                     .OrderByDescending(c => c.CreateDate).Take(7).ToListAsync();



            List<TBL_Slide> slides;
            string LandingHelperText;
            string ForUserText;
            string ForProfessionalText;
            string CreateServiceText;
            if (CultureInfo.CurrentCulture.Name == PublicHelper.persianCultureName)
            {
                slides = await _context.TBL_Sliders
                    .Where(c => c.IsActive == true && c.LanguageType == LanguageType.Persian)
                    .ToListAsync();

                LandingHelperText = _context.TBL_Settings.AsNoTracking().Where(c => c.Key == PublicHelper.landingHelperText).SingleOrDefault().Value;
                ForUserText = _context.TBL_Settings.AsNoTracking().Where(c => c.Key == PublicHelper.ForUserText).SingleOrDefault().Value;
                ForProfessionalText = _context.TBL_Settings.AsNoTracking().Where(c => c.Key == PublicHelper.ForProfessionalText).SingleOrDefault().Value;
                CreateServiceText = _context.TBL_Settings.AsNoTracking().Where(c => c.Key == PublicHelper.CreateServiceText).SingleOrDefault().Value;
            }
            else
            {
                slides = await _context.TBL_Sliders
                    .Where(c => c.IsActive == true && c.LanguageType == LanguageType.English)
                    .ToListAsync();

                LandingHelperText = _context.TBL_Settings.AsNoTracking().Where(c => c.Key == PublicHelper.landingHelperText).SingleOrDefault().EnglishValue;
                ForUserText = _context.TBL_Settings.AsNoTracking().Where(c => c.Key == PublicHelper.ForUserText).SingleOrDefault().EnglishValue;
                ForProfessionalText = _context.TBL_Settings.AsNoTracking().Where(c => c.Key == PublicHelper.ForProfessionalText).SingleOrDefault().EnglishValue;
                //CreateServiceText = _context.TBL_Settings.AsNoTracking().Where(c => c.Key == PublicHelper.CreateServiceText).SingleOrDefault().EnglishValue;
            }

            var model = new HomePageVM
            {
                Slides = slides,
                ServiceProviderCount = ServiceProviderCount,
                DoneServiceCount = doneServiceCount,
                CityCount = citiesCount,
                Categories = categories,
                LandingHelperText = LandingHelperText,
                ForUserText = ForUserText,
                ForProfessionalText = ForProfessionalText,
               
            };
            return View(model);
        }




        public async Task<IActionResult> AboutUs()
        {
            ViewData["AbouUs"] = _localizer["AbouUs"];

            var AboutUs = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.AboutUsKeyName).FirstOrDefaultAsync();
            return View(AboutUs);
        }




        public async Task<IActionResult> ContactUs()
        {
            ViewData["ContactUs"] = _localizer["ContactUs"];

            var ContactUs = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.ContactKeyName).FirstOrDefaultAsync();
            return View(ContactUs);
        }





        public async Task<IActionResult> SiteRules()
        {
            ViewData["SiteRoles"] = _localizer["SiteRoles"];

            var SiteRules = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.SiteRulesKeyName).FirstOrDefaultAsync();
            return View(SiteRules);
        }








        public IActionResult Table()
        {
            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [AllowAnonymous]
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }




    }
}
