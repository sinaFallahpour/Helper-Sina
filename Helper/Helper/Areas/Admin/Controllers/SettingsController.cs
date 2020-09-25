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

namespace Helper.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = Static.ADMINROLE)]
    public class SettingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SettingsController(ApplicationDbContext context)
        {
            _context = context;
        }




        // GET: Admin/Settings
        public IActionResult Index()
        {
            var context = _context.TBL_Settings.AsQueryable();

            var model = new SettingsViewModel()
            {
                ContactUs = context.Where(c => c.Key == PublicHelper.ContactKeyName).SingleOrDefault().Value,
                EnglishContactUs = context.Where(c => c.Key == PublicHelper.ContactKeyName).SingleOrDefault().EnglishValue,
                Aboutus = context.Where(c => c.Key == PublicHelper.AboutUsKeyName).SingleOrDefault().Value,
                EnglishAboutus = context.Where(c => c.Key == PublicHelper.AboutUsKeyName).SingleOrDefault().EnglishValue,
                SiteRules = context.Where(c => c.Key == PublicHelper.SiteRulesKeyName).SingleOrDefault().Value,
                EnglishSiteRules = context.Where(c => c.Key == PublicHelper.SiteRulesKeyName).SingleOrDefault().EnglishValue,

                LandingHelperText = context.Where(c => c.Key == PublicHelper.landingHelperText).SingleOrDefault().Value,
                EnglishlandingHelperText = context.Where(c => c.Key == PublicHelper.landingHelperText).SingleOrDefault().EnglishValue,


                ForUserText = context.Where(c => c.Key == PublicHelper.ForUserText).SingleOrDefault().Value,
                EnglishForUserText = context.Where(c => c.Key == PublicHelper.ForUserText).SingleOrDefault().EnglishValue,

                ForProfessionalText = context.Where(c => c.Key == PublicHelper.ForProfessionalText).SingleOrDefault().Value,
                EnglishForProfessionalText = context.Where(c => c.Key == PublicHelper.ForProfessionalText).SingleOrDefault().EnglishValue,

                CreateServiceText = context.Where(c => c.Key == PublicHelper.CreateServiceText).SingleOrDefault().Value,
                EnglishCreateServiceText = context.Where(c => c.Key == PublicHelper.CreateServiceText).SingleOrDefault().EnglishValue,

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
                    var contactUs = _context.TBL_Settings.SingleOrDefault(c => c.Key == PublicHelper.ContactKeyName);
                    if (contactUs != null)
                    {
                        contactUs.Value = model.ContactUs;
                        contactUs.EnglishValue = model.EnglishContactUs;
                        contactUs.UpdatedAt = DateTime.Now;
                    }

                    var aboutUs = _context.TBL_Settings.SingleOrDefault(c => c.Key == PublicHelper.AboutUsKeyName);
                    if (aboutUs != null)
                    {
                        aboutUs.Value = model.Aboutus;
                        aboutUs.EnglishValue = model.EnglishAboutus;

                        aboutUs.UpdatedAt = DateTime.Now;
                    }

                    var siteRules = _context.TBL_Settings.SingleOrDefault(c => c.Key == PublicHelper.SiteRulesKeyName);
                    if (siteRules != null)
                    {
                        siteRules.Value = model.SiteRules;
                        siteRules.EnglishValue = model.EnglishSiteRules;

                        siteRules.UpdatedAt = DateTime.Now;
                    }


                    var landingHelperText = _context.TBL_Settings.SingleOrDefault(c => c.Key == PublicHelper.landingHelperText);
                    if (landingHelperText != null)
                    {
                        landingHelperText.Value = model.LandingHelperText;
                        landingHelperText.EnglishValue = model.EnglishlandingHelperText;

                        landingHelperText.UpdatedAt = DateTime.Now;
                    }


                    var ForUser = _context.TBL_Settings.SingleOrDefault(c => c.Key == PublicHelper.ForUserText);
                    if (ForUser != null)
                    {
                        ForUser.Value = model.ForUserText;
                        ForUser.EnglishValue = model.EnglishForUserText;

                        ForUser.UpdatedAt = DateTime.Now;
                    }


                    var ForUserProfesional = _context.TBL_Settings.SingleOrDefault(c => c.Key == PublicHelper.ForProfessionalText);
                    if (ForUserProfesional != null)
                    {
                        ForUserProfesional.Value = model.ForProfessionalText;
                        ForUserProfesional.EnglishValue = model.EnglishForProfessionalText;

                        ForUserProfesional.UpdatedAt = DateTime.Now;
                    }


                    var CreateServiceText = _context.TBL_Settings.SingleOrDefault(c => c.Key == PublicHelper.CreateServiceText);
                    if (CreateServiceText != null)
                    {
                        CreateServiceText.Value = model.CreateServiceText;
                        CreateServiceText.EnglishValue = model.EnglishCreateServiceText;

                        CreateServiceText.UpdatedAt = DateTime.Now;
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



        #region Fucking category Create


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


        #endregion
        #region Fucking category Edit 

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
