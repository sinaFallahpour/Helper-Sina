using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models.Entities;
using Helper.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers
{
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public ServicesController(
            ApplicationDbContext context,
               //JwtGenerator jwtGenerator,
               IHttpContextAccessor httpContextAccessor,
                  IMapper mapper
            )
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var categories = _context.TBL_Category;
            var cities = _context.TBL_City;
            var monyUnits = _context.TBL_MonyUnit;

            ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            ViewBag.CityId = new SelectList(cities, "Id", "Name");
            ViewBag.MonyUnitId = new SelectList(monyUnits, "Id", "Name");

            return View();
        }









        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceVM model)
        {



            if (ModelState.IsValid)
            {

                if (!User.Identity.IsAuthenticated)
                {
                    return new JsonResult(new { Status = false, Message = " برای ثبت خدمت ابتدا وارد سایت شوید." });
                }
                try
                {
                    var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                    var userFromDb = await _context.Users.Where(c => c.Id == currentUserId)
                           .FirstOrDefaultAsync();

                    if (userFromDb != null)
                    {
                        if (userFromDb.PlanCount < 1 || userFromDb.PlanExpDate < DateTime.Now || userFromDb.PlanId == 0)
                        {
                            return new JsonResult(new { Status = false, Message = "پلن فعالی برای شما  موجود نیست.  ابتدا خریداری کنید.",hasPlan=false });
                        }

                        var TBL_Service = new TBL_Service
                        {
                            Title = model.Title,
                            LikeCount = 0,
                            CommentCount = 0,
                            SeenCount = 0,
                            CreateDate = DateTime.Now,
                            IsAgreement = model.IsAgreement,
                            IsSendByEmail = model.IsSendByEmail,
                            IsSendByNOtification = model.IsSendByNOtification,
                            IsSendBySms = model.IsSendBySms,
                            MinpRice = model.MinpRice,
                            MaxPrice = model.MaxPrice,
                            Skills = model.Skills,
                            Description = model.Description,
                            ServiceType = model.ServiceType,
                            UserId = userFromDb.Id,
                            CityId = model.CityId,
                            CategoryId = model.CategoryId,
                            MonyUnitId = model.MonyUnitId,
                        };


                        userFromDb.PlanCount--;
                        _context.Add(TBL_Service);

                        await _context.SaveChangesAsync();

                        return new JsonResult(new { Status = 1, Message = "ثبت موفقیت آمیز" });
                     
                    }
                    return new JsonResult(new { Status = false, Message = " برای ثبت خدمت ابتدا وارد سایت شوید." });

                }
                catch (DbUpdateConcurrencyException)
                {
                    return new JsonResult(new { Status = false, Message = "خطا در ثبت" });

                }

            }

            var errors = new List<string>();
            foreach (var item in ModelState.Values)
            {
                foreach (var err in item.Errors)
                {
                    errors.Add(err.ErrorMessage);
                }
            }
            return new JsonResult(new { Status = false, Message = errors.First() });
            //return new JsonResult(new { Status = false, Message = "خطا در ثبت" });










            //var categories = _context.TBL_Category;
            //var cities = _context.TBL_City;
            //var monyUnits = _context.TBL_MonyUnit;

            //ViewBag.CategoryId = new SelectList(categories, "Id", "Name");
            //ViewBag.CityId = new SelectList(cities, "Id", "Name");
            //ViewBag.MonyUnitId = new SelectList(monyUnits, "Id", "Name");

            //return View();
        }





    }
}
