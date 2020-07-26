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


        #region Index


        // GET: Admin/AboutUs
        public async Task<IActionResult> Index()
        {
            var AboutUsList = await _aboutUsManager.GetAll();
            return View(AboutUsList);
        }



        #endregion  Index

        #region Create

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
        public IActionResult Create(TBL_AboutUs model)
        {
            if (ModelState.IsValid)
            {
                var result = _aboutUsManager.Add(model);
                if (!result)
                {
                    ModelState.AddModelError("", "خطا دز ثبت اطلاعات");
                    return View(model);
                }
                //_context.Add(tBL_AboutUs);
                //await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }


        #endregion Create


        #region  Edit



        // GET: Admin/AboutUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AboutUs = await _aboutUsManager.GetById(id);
            if (AboutUs == null)
            {
                return NotFound();
            }
            return View(AboutUs);
        }



        // POST: Admin/AboutUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TBL_AboutUs model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var result = _aboutUsManager.Update(model);
                if (!result)
                {
                    if (!TBL_AboutUsExists(model.Id))
                    {
                        return NotFound();
                    }

                    ModelState.AddModelError("", "خطا دز ثبت اطلاعات");
                    return View(model);
                }
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }



        #endregion  Edit


        #region Delete

        // GET: Admin/AboutUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var AboutUs = await _aboutUsManager.GetById(id);

            if (AboutUs == null)
            {
                return NotFound();
            }

            return View(AboutUs);
        }

        // POST: Admin/AboutUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var result = _aboutUsManager.Delete(id);
            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", "خطا دز ثبت اطلاعات");
                return View(null);
            }
          

            return RedirectToAction(nameof(Index));

        }


        #endregion Delete

        private bool TBL_AboutUsExists(int id)
        {
            return _context.TBL_AboutUs.Any(e => e.Id == id);
        }


    }
}
