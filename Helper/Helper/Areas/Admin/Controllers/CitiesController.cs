using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Helper.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Helper.Models.Utilities;

namespace Helper.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = Static.ADMINROLE)]
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region List
        // GET: Admin/Cities
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBL_City.ToListAsync());
        }

        #endregion

        #region  create City

        // GET: Admin/Cities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Cities/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TBL_City model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var cityFromDb = await _context.TBL_City.Where(c => c.Name == model.Name).FirstOrDefaultAsync();
                    if (cityFromDb != null)
                    {
                        ModelState.AddModelError("", "اين  شهر موجود است");
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
                    ModelState.AddModelError("", "خطا در ثبت شهر");
                    return View(model);
                }
            }

            return View(model);
        }

        #endregion

        #region   Edit City

        // GET: Admin/Cities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var City = await _context.TBL_City.FindAsync(id);
            if (City == null)
            {
                return NotFound();
            }
            return View(City);
        }




        // POST: Admin/Cities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TBL_City model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ExistedCity = await _context.TBL_City.Where(c => c.Name == model.Name && c.Id != id)
                        .FirstOrDefaultAsync();
                    if (ExistedCity != null)
                    {
                        ModelState.AddModelError("", "اين  شهر موجود است");
                        return View(model);
                    }
                    var cityFromDb = _context.TBL_City.Find(id);
                    if (cityFromDb == null)
                    {
                        ModelState.AddModelError("", "این شهر  موجود نیست");
                        return View(model);
                    }
                    cityFromDb.Name = model.Name;
                    cityFromDb.IsEnabled = model.IsEnabled;
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return View(model);
                    //return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityExists(model.Id))
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

        #region  Detele
        // GET: Admin/Cities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var City = await _context.TBL_City
                .FirstOrDefaultAsync(m => m.Id == id);
            if (City == null)
            {
                return NotFound();
            }
            return View(City);
        }



        // POST: Admin/Cities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var City = await _context.TBL_City.FindAsync(id);
            if (City == null)
            {
                return NotFound();
            }
            try
            {
                _context.TBL_City.Remove(City);
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


        private bool CityExists(int id)
        {
            return _context.TBL_City.Any(e => e.Id == id);
        }
    }
}
