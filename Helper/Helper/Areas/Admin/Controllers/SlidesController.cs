using System;
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

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IHostingEnvironment _hostingEnvironment;

        public SlidesController(ApplicationDbContext context,
            IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Admin/Slides
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBL_Sliders.ToListAsync());
        }





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

                    model.PhotoAddress = "/ReactPages/assets/uploads/slider/" + uniqueFileName;
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
            return View(model);
        }




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
            var model = new EditSliderViewModel()
            {
                Id = tBL_Slide.Id,
                Description = tBL_Slide.Description,
                PhotoAddress = tBL_Slide.PhotoAddress,
                Title = tBL_Slide.Title
            };
           
            return View(model);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditSliderViewModel model)
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
                    if (model.Photo != null)
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



                            //Delete LastImage Image
                            var LastImagePath =  slideFromDb.PhotoAddress.Substring(1);
                            LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                            if (!string.IsNullOrEmpty(slideFromDb.PhotoAddress) && System.IO.File.Exists(LastImagePath))
                            {
                                System.IO.File.Delete(LastImagePath);
                            }


                            //update Newe Pic Address To database
                            slideFromDb.PhotoAddress = "/ReactPages/assets/uploads/slider/" + uniqueFileName;
                        }
                    }

                    var result = _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_SlideExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ModelState.AddModelError("", "خطا در ثبت");
                        return View(model);
                    }
                }

            }
            return View(model);
        }






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
    }
}
