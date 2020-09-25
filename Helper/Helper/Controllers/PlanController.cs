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
            //var plans = await _context.TBL_Plans.Include(c => c.PlansMonyUnit).ToListAsync();
            //var Planses = new List<PlanVM>();




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







        //        Id { get; set; }

        //    Name { get; set; }


        //ServiceCount { get; set; }




        //            Description { get; set; }




        //            Duration { get; set; }





        //            IsSelected { get; set; }



        //            IsFree { get; set; }


        //        /// <summary>
        //        /// لیست واحد های پولی پلن
        //        /// </summary>
        //        public virtual ICollection<MonyUnitTVM> PlanMonyUnits { get; set; }
        //    }



        //    public class MonyUnitTVM
        //{
        //    /// <summary>
        //    /// قیمت پنل
        //    /// </summary>
        //    [Display(Name = "قیت")]
        //    public int Price { get; set; }




        //    [Display(Name = "نام واحد پول")]
        //    public string MonyName { get; set; }
        //}








    }
}
