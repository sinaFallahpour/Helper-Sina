using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Helper.Models.Entities;
using Helper.Areas.Admin.Models.ViewModels.Sttings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[RequestSizeLimit(long.MaxValue)]
    [Authorize(Roles = Static.ADMINROLE)]
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public SettingsController(ApplicationDbContext context,
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Admin/Settings
        public IActionResult Index()
        {
            var context = _context.TBL_Settings.AsQueryable();

            var model = new SettingsViewModel()
            {
                ContactUs = context.Where(c => c.Key == "Contactus").SingleOrDefault().Value,
                Aboutus = context.Where(c => c.Key == "AboutUs").SingleOrDefault().Value,
            };
            //var slidersImagesAddress = context.Where(c => c.Key == "Slider").SingleOrDefault().Value.Split("###");

            //model.ImagesAddresses = new List<string>();
            //foreach (var item in slidersImagesAddress)
            //{
            //    model.ImagesAddresses.Add(item);
            //}

            return View(model);
        }





        /// <summary>
        /// edit AboutUs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(SettingsViewModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {

                    var contactUs = _context.TBL_Settings.SingleOrDefault(c => c.Key == "Contactus");
                    if (contactUs != null)
                    {
                        contactUs.Value = model.ContactUs;
                        contactUs.UpdatedAt = DateTime.Now;
                    }

                    var aboutUs = _context.TBL_Settings.SingleOrDefault(c => c.Key == "AboutUs");
                    if (aboutUs != null)
                    {
                        aboutUs.Value = model.Aboutus;
                        aboutUs.UpdatedAt = DateTime.Now;
                    }

                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        ViewBag.Success = "ثبت موفقیت آمیز";
                        return View(model);
                    }
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
            }
            return View(model);
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }





    }
}
