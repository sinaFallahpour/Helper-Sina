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

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    [RequestSizeLimit(long.MaxValue)]
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
            var slidersImagesAddress = context.Where(c => c.Key == "Slider").SingleOrDefault().Value.Split("###");

            model.ImagesAddresses = new List<string>();
            foreach (var item in slidersImagesAddress)
            {
                model.ImagesAddresses.Add(item);
            }

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

                    string uniqueFileName = null;
                    if (!model.Photo.IsImage())
                    {
                        ModelState.AddModelError("", "به فرمت عکس وارد کنید");
                        return View(model);
                    }
                    if (model.Photo.Length > 5000000)
                    {
                        ModelState.AddModelError("", "حجم فایل زیاد است");
                        return View(model);
                    }
                    if (model.Photo != null && model.Photo.Length > 0 && model.Photo.IsImage())
                    {
                        var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ReactPages/assets/uploads/slider");
                        uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + model.Photo.FileName);
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                        //update database
                        var sliderImageAddress = _context.TBL_Settings.SingleOrDefault(c => c.Key == "Slider");
                        sliderImageAddress.Value = uniqueFileName;
                    }


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























        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(SettingsViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(model);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tBL_Setting);
        //}

        // GET: Admin/Settings/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tBL_Setting = await _context.TBL_Settings.FindAsync(id);
        //    if (tBL_Setting == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tBL_Setting);
        //}





















        private bool TBL_SettingExists(int id)
        {
            return _context.TBL_Settings.Any(e => e.Id == id);
        }
    }
}
