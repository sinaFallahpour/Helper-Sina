using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models.Entities;
using Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers
{
    public class PlanController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;



        public PlanController(
            ApplicationDbContext context,
             IMapper mapper
                )
        {
            _context = context;
            _mapper = mapper;
        }






        // GET: api/Plans
        [Authorize()]
        public async Task<ActionResult> Index()
        {
            var plans = await _context.TBL_Plans.Include(c => c.PlansMonyUnit).ToListAsync();
            var Planses = _mapper.Map<List<TBL_Plans>, List<PlanVM>>(plans);
            return View(Planses);
            //return new JsonResult(new { Status = 1, Message = "", Data = Planses });
        }


    }
}
