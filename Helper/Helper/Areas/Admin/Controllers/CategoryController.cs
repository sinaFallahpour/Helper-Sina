using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Helper.Models.Entities;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using AutoMapper.Configuration;
using Microsoft.Extensions.Configuration;
using Helper.Areas.Admin.Models.ViewModels.Category;

namespace Helper.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Static.ADMINROLE)]
    public class CategoryController : Controller
    {

        #region  Ctor
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly Microsoft.Extensions.Configuration.IConfiguration _configuration;
        private readonly IConfigurationSection _settings;

        public CategoryController(ApplicationDbContext context, IWebHostEnvironment hostingEnvironment
            , Microsoft.Extensions.Configuration.IConfiguration iConfig)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _configuration = iConfig;
            _settings = _configuration.GetSection("AppSettings");
        }

        #endregion




        //#region  ctor
        //private readonly ApplicationDbContext _context;

        //private readonly IWebHostEnvironment _hostingEnvironment;
        //private readonly IConfiguration _configuration;
        //private readonly IConfigurationSection _settings;

        //public SlidesController(ApplicationDbContext context,
        //    IWebHostEnvironment hostingEnvironment, IConfiguration iConfig)
        //{
        //    _context = context;
        //    _hostingEnvironment = hostingEnvironment;
        //    _configuration = iConfig;
        //    _settings = _configuration.GetSection("AppSettings");
        //}


        //#endregion





        #region  List
        // GET: Admin/TBL_Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBL_Category.ToListAsync());
        }
        #endregion

        #region  create category
        // GET: Admin/TBL_Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TBL_Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TBL_Category model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var host = _hostingEnvironment.WebRootPath;
                    var url = "Upload/Category";
                    var savePath = Path.Combine(host, url);
                    var uploadResult = FileUploader.UploadImage(file: model.Photo, maxLength: 20, height: 500, width: 500, path: savePath, compression: 70);
                    if (uploadResult.succsseded == false)
                    {
                        ModelState.AddModelError("", uploadResult.result);
                        return View(model);
                    }

                    var img = uploadResult.result;
                    model.PhotoAddress = "/Upload/Category/" + img;





                    var catFromDb = await _context.TBL_Category.Where(c => c.Name == model.Name || c.EnglishName == model.EnglishName).FirstOrDefaultAsync();
                    if (catFromDb != null)
                    {
                        ModelState.AddModelError("", "اين دسته بندي موجود است");
                        return View(model);
                    }
                    model.CreateDate = DateTime.Now;
                    _context.Add(model);
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    TempData["Error"] = "خطا در حذف";
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        #endregion

        #region Edit

        // GET: Admin/TBL_Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tbl_category = await _context.TBL_Category.FindAsync(id);
            if (tbl_category == null)
            {
                return NotFound();
            }
            var model = new EditCategoryViewModel()
            {
                Id = tbl_category.Id,
                Name = tbl_category.Name,
                EnglishName = tbl_category.EnglishName,
                CreateDate = tbl_category.CreateDate,
                IsEnabled = tbl_category.IsEnabled,
                Photo = tbl_category.Photo,
                PhotoAddress=tbl_category.PhotoAddress
            };

            return View(model);
        }



        // POST: Admin/TBL_Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditCategoryViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
           
            if (ModelState.IsValid)
            {
                try
                {
                    var catFromDb = _context.TBL_Category.Find(id);
                    if (catFromDb == null)
                    {
                        ModelState.AddModelError("", "این دسته بندی  یافت نشد");
                        return View(model);
                    }

                    if (model.Photo != null)
                    {

                        var host = _hostingEnvironment.WebRootPath;
                        var url = "Upload/Category";
                        var savePath = Path.Combine(host, url);
                        var uploadResult = FileUploader.UploadImage(file: model.Photo, maxLength: 20, height: 400, width: 400, path: savePath, compression: 70);
                        if (uploadResult.succsseded == false)
                        {
                            ModelState.AddModelError("", uploadResult.result);
                            return View(model);
                        }

                        var img = uploadResult.result;
                        model.PhotoAddress = "/Upload/Category/" + img;


                        if (!string.IsNullOrEmpty(catFromDb.PhotoAddress))
                        {
                            var LastImagePath = catFromDb.PhotoAddress.Substring(1);
                            LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                            if (System.IO.File.Exists(LastImagePath))
                            {
                                System.IO.File.Delete(LastImagePath);
                            }
                        }

                        //update Newe Pic Address To database
                        catFromDb.PhotoAddress = model.PhotoAddress;

                        var ExistedCategory = await _context.TBL_Category.Where(c => (c.Name == model.Name || c.EnglishName == model.EnglishName) && c.Id != id)
                        .FirstOrDefaultAsync();
                        if (ExistedCategory != null)
                        {
                            ModelState.AddModelError("", "اين دسته بندي  موجود است");
                            return View(model);
                        }
                    }


                    catFromDb.Name = model.Name;
                    catFromDb.EnglishName = model.EnglishName;
                    catFromDb.IsEnabled = model.IsEnabled;
                    await _context.SaveChangesAsync();
                    //TempData["Success"] = "ثبت موفقیت آمیز";
                    //return View(model);


                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        //TempData["Error"] = "خطا در حذف";
                        //return RedirectToAction(nameof(Index));

                        ModelState.AddModelError("", "خطایی رخ داده");
                        return View(model);
                    }
                }

            }
            return View(model);
        }


        #endregion


        #region Delete


        // GET: Admin/TBL_Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await _context.TBL_Category
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }



        // POST: Admin/TBL_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Category = await _context.TBL_Category.FindAsync(id);
            if (Category == null)
            {
                return NotFound();
            }


            var LastImagePath = Category.PhotoAddress.Substring(1);
            LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
            if (!string.IsNullOrEmpty(Category.PhotoAddress) && System.IO.File.Exists(LastImagePath))
            {
                System.IO.File.Delete(LastImagePath);
            }

            try
            {
                _context.TBL_Category.Remove(Category);
                var result = await _context.SaveChangesAsync();
                if (result > 0)
                {
                    TempData["Success"] = "حذف موفقیت آمیز";
                    return RedirectToAction(nameof(Index));

                }
                ModelState.AddModelError("", "خطا در ثبت");
                return View(Category);
            }
            catch
            {
                ModelState.AddModelError("", "خطا در ثبت");
                return View(Category);
            }
        }



        #endregion



        private bool CategoryExists(int id)
        {
            return _context.TBL_Category.Any(e => e.Id == id);
        }
    }
}
