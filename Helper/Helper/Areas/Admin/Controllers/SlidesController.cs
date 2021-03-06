﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Helper.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Helper.Models.Utilities;
using System.IO;
using Helper.Areas.Admin.Models.ViewModels.Slider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace Helper.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Static.ADMINROLE)]
    public class SlidesController : Controller
    {

        #region  ctor
        private readonly ApplicationDbContext _context;

        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;
        private readonly IConfigurationSection _settings;

        public SlidesController(ApplicationDbContext context,
            IWebHostEnvironment hostingEnvironment, IConfiguration iConfig)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _configuration = iConfig;
            _settings = _configuration.GetSection("AppSettings");
        }


        #endregion

        #region List
        // GET: Admin/Slides
        public async Task<IActionResult> Index()
        {
            var slides = await _context.TBL_Sliders.OrderBy(c => c.IsActive == true).ToListAsync();
            return View(slides);
        }
        #endregion

        #region Create

        // GET: Admin/Slides/Create
        public IActionResult Create()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TBL_Slide model)
        {

            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo == null)
                {
                    ModelState.AddModelError("", "لطفا عکس را آپلود کنید");
                    return View(model);
                }
                if (!model.Photo.IsImage())
                {
                    ModelState.AddModelError("", "به فرمت عکس وارد کنید");
                    return View(model);
                }
                if (model.Photo.Length > 15000000)
                {
                    ModelState.AddModelError("", "حجم فایل زیاد است");
                    return View(model);
                }
                if (model.Photo != null && model.Photo.Length > 0 && model.Photo.IsImage())
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/Slider");
                    uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + model.Photo.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        model.Photo.CopyTo(stream);
                    }
                    model.PhotoAddress = "/Upload/Slider/" + uniqueFileName;
                }
                try
                {
                    _context.Add(model);
                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
                catch
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }

            }
            //List<string> errors = new List<string>();
            //foreach (var item in ModelState.ToList())
            //{
            //    if(item.)
            //}
            return View(model);
        }




        #endregion

        #region Edit
        // GET: Admin/Slides/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tBL_Slide = await _context.TBL_Sliders.FindAsync(id);
            if (tBL_Slide == null)
            {
                return NotFound();
            }
            var model = new EditCategoryViewModel()
            {
                Id = tBL_Slide.Id,
                Description = tBL_Slide.Description,
                PhotoAddress = tBL_Slide.PhotoAddress,
                Title = tBL_Slide.Title,
                IsActive = tBL_Slide.IsActive,
                LanguageType = tBL_Slide.LanguageType,
            };

            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var slideFromDb = _context.TBL_Sliders.SingleOrDefault(c => c.Id == model.Id);
                    slideFromDb.Description = model.Description;
                    slideFromDb.Title = model.Title;
                    slideFromDb.IsActive = model.IsActive;
                    slideFromDb.LanguageType = model.LanguageType;
                    #region file validation
                    if (model.Photo != null)
                    {
                        string uniqueFileName = null;
                        if (!model.Photo.IsImage())
                        {
                            ModelState.AddModelError("", "به فرمت عکس وارد کنید");
                            return View(model);
                        }
                        if (model.Photo.Length > 15000000)
                        {
                            ModelState.AddModelError("", "حجم فایل زیاد است");
                            return View(model);
                        }
                        if (model.Photo != null && model.Photo.Length > 0 && model.Photo.IsImage())
                        {
                            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/Slider");
                            uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + model.Photo.FileName);
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            //model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.Photo.CopyTo(stream);
                            }

                            if (!string.IsNullOrEmpty(slideFromDb.PhotoAddress))
                            {
                                var LastImagePath = slideFromDb.PhotoAddress.Substring(1);
                                LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                                if (System.IO.File.Exists(LastImagePath))
                                {
                                    System.IO.File.Delete(LastImagePath);
                                }

                                //System.IO.File.Delete(LastImagePath);
                            }

                            //update Newe Pic Address To database
                            slideFromDb.PhotoAddress = "/Upload/Slider/" + uniqueFileName;
                        }
                    }
                    #endregion file validation


                    var result = _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }

            }
            return View(model);
        }

        #endregion Edit

        #region Delete

        #region Delete

        // GET: Admin/Slides/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBL_Slide = await _context.TBL_Sliders
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_Slide == null)
            {
                return NotFound();
            }

            return View(tBL_Slide);
        }

        // POST: Admin/Slides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var slideFromDb = await _context.TBL_Sliders.FindAsync(id);
            if (slideFromDb != null)
            {
                //Delete LastImage Image
                var LastImagePath = slideFromDb.PhotoAddress.Substring(1);
                LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                if (!string.IsNullOrEmpty(slideFromDb.PhotoAddress) && System.IO.File.Exists(LastImagePath))
                {
                    System.IO.File.Delete(LastImagePath);
                }

                try
                {
                    _context.TBL_Sliders.Remove(slideFromDb);
                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(slideFromDb);
                }
                catch
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(slideFromDb);
                }


                //_context.TBL_Sliders.Remove(slideFromDb);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }


        #endregion

        #endregion


        private bool TBL_SlideExists(int id)
        {
            return _context.TBL_Sliders.Any(e => e.Id == id);
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




#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<IActionResult> AddImage(IFormFile image)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            if (image != null && image.Length > 0)
            {
                var host = _hostingEnvironment.WebRootPath;
                var url = _settings.GetSection("SliderImages").Value;
                var savePath = Path.Combine(host, url);
                var uploadResult = FileUploader.UploadImage(image, savePath, compression: 70, width: 512, height: 512);
                if (!uploadResult.succsseded)
                {
                    return Json(false);
                }
                else
                {
                    var img = uploadResult.result;
                    return Json("/Uploads/ProductImages/" + img);
                }
            }
            else
            {
                return Json(false);
            }
        }

    }
}
