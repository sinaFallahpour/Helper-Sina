using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Data;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Static.ADMINROLE)]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["citiesCount"] = await _context.TBL_City.CountAsync(c => c.IsEnabled == true);
            ViewData["ServiceProviderCount"] = await _context.Users.CountAsync(c => c.HasProviderService);
            ViewData["doneServiceCount"]  = 0;

            return View();
        }
    }
}