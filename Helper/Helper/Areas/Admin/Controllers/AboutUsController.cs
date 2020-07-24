using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Helper.Models.Entities;
using Helper.Models.BLL;

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AboutUsManager _aboutUsManager;



        public AboutUsController(ApplicationDbContext context, AboutUsManager aboutUsManager)
        {
            _context = context;
            _aboutUsManager = aboutUsManager;
        }

        // GET: Admin/AboutUs
        public async Task<IActionResult> Index()
        {
            var AboutUsList = await _aboutUsManager.GetAll();
            return View(AboutUsList);
        }

        // GET: Admin/AboutUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBL_AboutUs = await _context.TBL_AboutUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_AboutUs == null)
            {
                return NotFound();
            }

            return View(tBL_AboutUs);
        }

        // GET: Admin/AboutUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/AboutUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,IsMain,Id")] TBL_AboutUs tBL_AboutUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBL_AboutUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBL_AboutUs);
        }

        // GET: Admin/AboutUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBL_AboutUs = await _context.TBL_AboutUs.FindAsync(id);
            if (tBL_AboutUs == null)
            {
                return NotFound();
            }
            return View(tBL_AboutUs);
        }

        // POST: Admin/AboutUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,IsMain,Id")] TBL_AboutUs tBL_AboutUs)
        {
            if (id != tBL_AboutUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBL_AboutUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_AboutUsExists(tBL_AboutUs.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tBL_AboutUs);
        }

        // GET: Admin/AboutUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBL_AboutUs = await _context.TBL_AboutUs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_AboutUs == null)
            {
                return NotFound();
            }

            return View(tBL_AboutUs);
        }

        // POST: Admin/AboutUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBL_AboutUs = await _context.TBL_AboutUs.FindAsync(id);
            _context.TBL_AboutUs.Remove(tBL_AboutUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBL_AboutUsExists(int id)
        {
            return _context.TBL_AboutUs.Any(e => e.Id == id);
        }
    }
}
