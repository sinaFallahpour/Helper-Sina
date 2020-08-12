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


    [Authorize(Roles = Static.ADMINROLE)]
    public class MonyUnitController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonyUnitController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region List
        // GET: Admin/MonyUnit
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBL_MonyUnit.ToListAsync());
        }

        #endregion

        #region  create MonyUnit

        // GET: Admin/MonyUnit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/MonyUnit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TBL_MonyUnit model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var MonyFromDb = await _context
                            .TBL_MonyUnit
                            .Where(c => c.Name == model.Name)
                            .FirstOrDefaultAsync();
                    if (MonyFromDb != null)
                    {
                        ModelState.AddModelError("", "اين  واحد پول موجود است");
                        return View(model);
                    }
                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return View(model);
                   
                }
                catch 
                {
                    ModelState.AddModelError("", "خطا در ثبت واحد پول");
                    return View(model);
                }
            }

            return View(model);
        }

        #endregion



        #region   Edit MonyUnit

        // GET: Admin/MonyUnit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var Mony = await _context.TBL_MonyUnit.FindAsync(id);
            if (Mony == null)
            {
                return NotFound();
            }
            return View(Mony);
        }




        // POST: Admin/MonyUnit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TBL_MonyUnit model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ExistedCity = await _context
                        .TBL_MonyUnit
                        .Where(c => c.Name == model.Name && c.Id != id)
                        .FirstOrDefaultAsync();
                    if (ExistedCity != null)
                    {
                        ModelState.AddModelError("", "اين  واحد پول موجود است");
                        return View(model);
                    }
                    var MonyFromDB = _context.TBL_MonyUnit.Find(id);
                    if (MonyFromDB == null)
                    {
                        ModelState.AddModelError("", "این واحد پول  موجود نیست");
                        return View(model);
                    }
                    MonyFromDB.Name = model.Name;
                    await _context.SaveChangesAsync();

                    TempData["Success"] = "ثبت موفقیت آمیز";
                    return View(model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MonyUnitExists(model.Id))
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
        // GET: Admin/MonyUnit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Mony = await _context.TBL_MonyUnit
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Mony == null)
            {
                return NotFound();
            }
            return View(Mony);
        }



        // POST: Admin/MonyUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Mony = await _context.TBL_MonyUnit.FindAsync(id);
            if (Mony == null)
            {
                return NotFound();
            }
            try
            {
                _context.TBL_MonyUnit.Remove(Mony);
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


        private bool MonyUnitExists(int id)
        {
            return _context.TBL_MonyUnit.Any(e => e.Id == id);
        }
    }
}
