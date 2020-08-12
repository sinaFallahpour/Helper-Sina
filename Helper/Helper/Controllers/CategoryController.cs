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

namespace Helper.Controllers
{
    [Authorize(Roles = Static.ADMINROLE)]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/TBL_Category
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBL_Category.ToListAsync());
        }


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
                    var catFromDb = await _context.TBL_Category.Where(c => c.Name == model.Name).FirstOrDefaultAsync();
                    if (catFromDb != null)
                    {
                        ModelState.AddModelError("", "اين دسته بندي موجود است");
                        return View(model);
                    }
                    model.CreateDate = DateTime.Now;
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return View(model);
                    //return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "خطا در ثبت   دسته بندی");
                    return View(model);
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

            var Category = await _context.TBL_Category.FindAsync(id);
            if (Category == null)
            {
                return NotFound();
            }
            return View(Category);
        }



        // POST: Admin/TBL_Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TBL_Category model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ExistedCategory = await _context.TBL_Category.Where(c => c.Name == model.Name && c.Id != id)
                        .FirstOrDefaultAsync();
                    if (ExistedCategory != null)
                    {
                        ModelState.AddModelError("", "اين دسته بندي موجود است");
                        return View(model);
                    }
                    var catFromDb = _context.TBL_Category.Find(id);
                    if (catFromDb == null)
                    {
                        ModelState.AddModelError("", "این دسته بندی موجود نیست");
                        return View(model);
                    }
                    catFromDb.Name = model.Name;
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return View(model);
                    //return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
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
            try
            {
                _context.TBL_Category.Remove(Category);
                await _context.SaveChangesAsync();
                TempData["Success"] = "حذف موفقیت آمیز";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Error"] = "خطا در حذف";
                return RedirectToAction(nameof(Index));

            }
        }



        #endregion 



        private bool CategoryExists(int id)
        {
            return _context.TBL_Category.Any(e => e.Id == id);
        }
    }
}
