using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Helper.Models.Entities;

namespace Helper.Controllers
{
    public class PlansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PlansController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: Plans
        public async Task<IActionResult> Index()
        {
            return View(await _context.TBL_Plans.ToListAsync());
        }






        // GET: Plans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var plansMony = _context.TBL_Plane_MonyUnit.Where(c => c.IsEnabled == true && c.PlanId == id).ToList();
            var tBL_Plans = await _context.TBL_Plans.Where(c => c.Id == id).FirstAsync();
            tBL_Plans.PlansMonyUnit = plansMony;


            if (tBL_Plans == null)
            {
                return NotFound();
            }
            return View(tBL_Plans);
        }



        // POST: Plans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TBL_Plans model)
        {

            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var Plans = _context.TBL_Plans.Where(c => c.Id == id).FirstOrDefault();
                    var dd = _context.TBL_Plane_MonyUnit.Where(c => c.PlanId == id  && c.IsEnabled==true).ToList();
                    var monies = _context.TBL_MonyUnit.ToList();

                    foreach (var item in monies)
                    {
                        var val = Request.Form[item.Name];
                        foreach (var e in dd)
                        {
                            if (e.MonyName == item.Name)
                            {
                                e.Price = val;
                            }
                        }

                    }

                    Plans.Name = model.Name;
                    Plans.Duration = model.Duration;
                    Plans.Description = model.Description;
                    Plans.ServiceCount = model.ServiceCount;



                    //_context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_PlansExists(model.Id))
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
            return View(model);
        }











        private bool TBL_PlansExists(int id)
        {
            return _context.TBL_Plans.Any(e => e.Id == id);
        }
    }
}
