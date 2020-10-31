using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models.Entities;
using Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Helper.Controllers
{
    public class PlanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ServicesController> _serviceControllerLocalizer;


       

        public PlanController(
            ApplicationDbContext context,
             IMapper mapper,
             IStringLocalizer<ServicesController> serviceControllerLocalizer
                )
        {
            _context = context;
            _mapper = mapper;
            _serviceControllerLocalizer = serviceControllerLocalizer;
        }






        // GET: api/Plans
        [Authorize()]
        public async Task<ActionResult> Index()
        {
            returnViewDate();
            //var plans = await _context.TBL_Plans.Include(c => c.PlansMonyUnit).ToListAsync();
            //var Planses = new List<PlanVM>();

            if (CultureInfo.CurrentCulture.Name == PublicHelper.persianCultureName)
            {
                var data = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.CreateServiceText).FirstOrDefaultAsync();
                ViewBag.CreateServiceText = data.Value;
            }
            else
            {
                var data = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.CreateServiceText).FirstOrDefaultAsync();
                ViewBag.CreateServiceText = data.EnglishValue;
            }

            var plans = await _context.TBL_Plans.AsNoTracking().Select(c => new PlanVM
            {
                Id = c.Id,
                Name = c.Name,
                ServiceCount = c.ServiceCount,
                Description = c.Description,
                Duration = c.Duration,
                IsFree = c.IsFree,
                PlanMonyUnits = c.PlansMonyUnit.Select(v => new MonyUnitTVM
                {
                    Price = v.Price,
                    MonyName = v.MonyName
                }).ToList()
            }).ToListAsync();

            return View(plans);

            //try
            //{
            //    Planses = _mapper.Map<List<TBL_Plans>, List<PlanVM>>(plans);
            //}
            //catch (Exception ex)
            //{

            //}

            //return View(Planses);

            //return new JsonResult(new { Status = 1, Message = "", Data = Planses });
        }








        private void returnViewDate()
        {
            ViewData["CreateService"] = _serviceControllerLocalizer["CreateService"];
        }







    }
}
