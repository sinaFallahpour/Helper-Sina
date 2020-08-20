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

namespace Helper.Controllers
{

    //[Authorize(Roles = Static.ADMINROLE)]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }



        public async Task<IActionResult> Index()
        {
            var slides = await _context.TBL_Sliders.Where(c => c.IsActive == true).ToListAsync();
            var model = new HomePageVM
            {
                Slides = slides,
            };
            return View(model);
        }




        public async Task<IActionResult> AboutUs()
        {
            var AboutUs = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.AboutUsKeyName).FirstOrDefaultAsync();
            return View(AboutUs);
        }




        public async Task<IActionResult> ContactUs()
        {
            var ContactUs = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.ContactKeyName).FirstOrDefaultAsync();
            return View(ContactUs);
        }





        public async Task<IActionResult> SiteRules()
        {
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
    }
}
