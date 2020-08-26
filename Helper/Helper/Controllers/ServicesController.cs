using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models.Entities;
using Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Helper.Controllers
{

    [Authorize]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private IStringLocalizer<ServicesController> _localizer;

        public ServicesController(
            ApplicationDbContext context,
               //JwtGenerator jwtGenerator,
               IHttpContextAccessor httpContextAccessor,
                  IMapper mapper,
                   IStringLocalizer<ServicesController> localizer
            )
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _localizer = localizer;
        }



        public async Task<IActionResult> Index()
        {


            returnViewDate();


            List<TBL_Category> cats;
            List<TBL_City> cities;
            List<TBL_MonyUnit> monyUnits;

            if (CultureInfo.CurrentCulture.Name == PublicHelper.persianCultureName)
            {
                cats = await _context.TBL_Category.Where(c => c.IsEnabled).ToListAsync();
                cities = await _context.TBL_City.Where(c => c.IsEnabled).ToListAsync();
                monyUnits = await _context.TBL_MonyUnit.Where(c => c.IsEnabled).ToListAsync();


                ViewBag.CategoryId = new SelectList(cats, "Id", "Name");
                ViewBag.CityId = new SelectList(cities, "Id", "Name");
                ViewBag.MonyUnitId = new SelectList(monyUnits, "Id", "Name");

            }
            else
            {
                cats = await _context.TBL_Category.Where(c => c.IsEnabled).ToListAsync();
                cities = await _context.TBL_City.Where(c => c.IsEnabled).ToListAsync();
                monyUnits = await _context.TBL_MonyUnit.Where(c => c.IsEnabled).ToListAsync();

                ViewBag.CategoryId = new SelectList(cats, "Id", "EnglishName");
                ViewBag.CityId = new SelectList(cities, "Id", "EnglishName");
                ViewBag.MonyUnitId = new SelectList(monyUnits, "Id", "EnglishName");
            }



            return View();
        }









        [HttpPost]
        public async Task<IActionResult> ServiceProviderCreate(CreateServiceVM model)
        {

            if (ModelState.IsValid)
            {

                if (!User.Identity.IsAuthenticated)
                {
                    return new JsonResult(new { Status = false, Message = _localizer["NotLogeInMessage"].Value.ToString() });
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
                            return new JsonResult(new { Status = false, Message = _localizer["NoActivePlanMessage"].Value.ToString(), hasPlan = false });
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
                        userFromDb.Skils = userFromDb.Skils != null ? userFromDb.Skils + "," + model.Skills : model.Skills;
                        _context.Add(TBL_Service);

                        await _context.SaveChangesAsync();

                        return new JsonResult(new { Status = 1, Message = _localizer["SuccessFullRegisterMessage"].Value.ToString() });

                    }
                    return new JsonResult(new { Status = false, Message = _localizer["NotLogeInMessage"].Value.ToString() });

                }
                catch (DbUpdateConcurrencyException)
                {
                    return new JsonResult(new { Status = false, Message = _localizer["ErrorMessage"].Value.ToString() });

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
 
        }







        [HttpPost]
        public async Task<IActionResult> ServiceRequestCreate(CreateServiceVM model)
        {

            if (ModelState.IsValid)
            {

                if (!User.Identity.IsAuthenticated)
                {
                    return new JsonResult(new { Status = false, Message = _localizer["NotLogeInMessage"].Value.ToString() });
                }
                try
                {
                    var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

                    var userFromDb = await _context.Users.Where(c => c.Id == currentUserId)
                           .FirstOrDefaultAsync();

                    if (userFromDb != null)
                    {
                        //if (userFromDb.PlanCount < 1 || userFromDb.PlanExpDate < DateTime.Now || userFromDb.PlanId == 0)
                        //{
                        //    return new JsonResult(new { Status = false, Message = _localizer["NoActivePlanMessage"].Value.ToString(), hasPlan = false });
                        //}

                        var TBL_Service = new TBL_Service
                        {
                            Title = model.Title,
                            LikeCount = 0,
                            CommentCount = 0,
                            SeenCount = 0,
                            CreateDate = DateTime.Now,
                            IsAgreement = model.IsAgreement,
                            IsSendByEmail =false,
                            IsSendByNOtification = false,
                            IsSendBySms = false,
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


                        //userFromDb.PlanCount--;
                        userFromDb.SkilsRequest = userFromDb.Skils != null ? userFromDb.Skils + "," + model.Skills : model.Skills;
                        _context.Add(TBL_Service);

                        await _context.SaveChangesAsync();

                        return new JsonResult(new { Status = 1, Message = _localizer["SuccessFullRegisterMessage"].Value.ToString() });

                    }
                    return new JsonResult(new { Status = false, Message = _localizer["NotLogeInMessage"].Value.ToString() });

                }
                catch (DbUpdateConcurrencyException)
                {
                    return new JsonResult(new { Status = false, Message = _localizer["ErrorMessage"].Value.ToString() });

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

        }







        private void returnViewDate()
        {
            ViewData["Titles"] = _localizer["Titles"];
            ViewData["Descriptions"] = _localizer["Descriptions"];
            ViewData["Categories"] = _localizer["Categories"];
            ViewData["City"] = _localizer["City"];
            ViewData["Skills"] = _localizer["Skills"];
            ViewData["PriceRange"] = _localizer["PriceRange"];
            ViewData["Agreed"] = _localizer["Agreed"];
            ViewData["Email"] = _localizer["Email"];
            ViewData["Notification"] = _localizer["Notification"];
            ViewData["Sms"] = _localizer["Sms"];
            ViewData["Submit"] = _localizer["Submit"];
            ViewData["FromPrice"] = _localizer["FromPrice"];
            ViewData["ToPrice"] = _localizer["ToPrice"];
            ViewData["HowToSendService"] = _localizer["HowToSendService"];
            ViewData["ServiceRequest"] = _localizer["ServiceRequest"];
            ViewData["ServiceDelivery"] = _localizer["ServiceDelivery"];
            ViewData["CreateService"] = _localizer["CreateService"];
            ViewData["CreateServiceText"] = _localizer["CreateServiceText"];

        }

    }
}
