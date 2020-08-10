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
            return View(model);
        }



        #region  Edit contacus and aboiutus

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

        #endregion



        // GET: Admin/Settings/Create
        public async Task<IActionResult> CategoryCreate()
        {
            var CategoryString = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.categoriesKeyName)
                    .Select(c => c.Value).FirstOrDefaultAsync();
            var cityList = CategoryString?.Replace("###***", "-").Split("-").ToList();
            return View(cityList);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryCreate(string CategoryName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryFromDB = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.categoriesKeyName).FirstOrDefaultAsync();
                    if (categoryFromDB == null)
                    {
                        var newCity = new TBL_Setting
                        {
                            Key = PublicHelper.categoriesKeyName,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Value = CategoryName + "###***",
                        };
                        _context.Add(newCity);
                    }
                    else
                    {
                        var allCategories = categoryFromDB.Value.Replace("###***", "-").Split("-");
                        if (allCategories.Contains(CategoryName))
                        {
                            //ModelState.AddModelError("", "اين دسته بندي موجود است");
                            //return View(CategoryName);
                            TempData["Success"] = "اين دسته بندي موجود است";

                            //ViewData["Success"] = "اين دسته بندي موجود است";

                            return RedirectToAction(nameof(CategoryCreate));
                        }

                        categoryFromDB.Value = categoryFromDB.Value + CategoryName + "###***";
                    }
                    _context.SaveChanges();

                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return RedirectToAction(nameof(CategoryCreate));

                }
                catch
                {


                    TempData["Error"] = "خطا در ثبت";

                    return RedirectToAction(nameof(CategoryCreate));

                }

            }
            return View(CategoryName);
        }






        #region

        // GET: Admin/TBL_NewsArticleVideo/Edit/5
        public async Task<IActionResult> CategoryEdit(string CategoryName)
        {
            if (string.IsNullOrEmpty(CategoryName))
            {
                return NotFound();
            }


            var categoryFromDB = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.categoriesKeyName).FirstOrDefaultAsync();

            if (categoryFromDB == null)
            {
                return NotFound();
            }
            var allCategories = categoryFromDB.Value.Replace("###***", "-").Split("-");
            if (!allCategories.Contains(CategoryName))
            {
                return NotFound();
            }
            return View(CategoryName);
        }



        // POST: Admin/TBL_NewsArticleVideo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CategoryEdit(string OldCategoryName, string NewCategoryName)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var categoryFromDB = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.categoriesKeyName).FirstOrDefaultAsync();
                    if (categoryFromDB == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        var allCategories = categoryFromDB.Value.Replace("###***", "-").Split("-");
                        if (OldCategoryName != NewCategoryName && allCategories.Contains(NewCategoryName))
                        {
                            TempData["Success"] = "اين دسته بندي موجود است";
                            return RedirectToAction(nameof(CategoryEdit));
                        }

                        int index = allCategories.ToList().IndexOf(OldCategoryName);
                        if (index != -1)
                            allCategories[index] = NewCategoryName;
                        categoryFromDB.Value = string.Join("###***", allCategories);

                    }
                    _context.SaveChanges();

                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return RedirectToAction(nameof(CategoryCreate));

                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Error"] = "خطا در ثبت";
                    return RedirectToAction(nameof(CategoryCreate));
                }
            }
            TempData["Error"] = "خطا در ثبت";
            return RedirectToAction(nameof(CategoryCreate));
        }

        #endregion  Edit Vide and news


















        // GET: Admin/Settings/Create
        public async Task<IActionResult> CityCreate()
        {
            var CitiesString = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.CitiesKeyName).Select(c => c.Value).FirstOrDefaultAsync();
            //string[] parts1 = input.Replace("][", "-").Split('-');
            var cityList = CitiesString.Replace("###***", "-").Split("-").ToList();
            return View(cityList);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CityCreate(string CityName)
        {


            if (ModelState.IsValid)
            {
                try
                {

                    //var result;
                    var CityFromDB = await _context.TBL_Settings.Where(c => c.Value == PublicHelper.CitiesKeyName).FirstOrDefaultAsync();

                    if (CityFromDB == null)
                    {
                        var newCity = new TBL_Setting
                        {
                            Key = PublicHelper.CitiesKeyName,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            Value = CityName + "###***",
                        };
                        _context.Add(newCity);

                    }
                    else
                    {
                        var allCities = CityFromDB.Value.Replace("###***", "-").Split("-");
                        if (allCities.Contains(CityName))
                        {
                            ModelState.AddModelError("", "اين شهر موجود است");
                            return View(CityName);
                        }

                        CityFromDB.Value = CityFromDB.Value + CityName + "###***";
                    }
                    //_context.Add(model);
                    _context.SaveChanges();
                    //if (result > 0)
                    //{
                    return RedirectToAction(nameof(Index));
                    //}
                    //ModelState.AddModelError("", "خطا در ثبت");
                    //return View(model);
                }
                catch
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(CityName);
                }

            }
            return View(CityName);
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
