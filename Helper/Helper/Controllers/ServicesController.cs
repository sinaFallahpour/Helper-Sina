using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models.Entities;
using Helper.Models.Enums;
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

                            CityId = model.CityId,
                            CategoryId = model.CategoryId,
                            MonyUnitId = model.MonyUnitId,

                            UserId = userFromDb.Id,
                            Username = userFromDb.UserName,
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
                            IsSendByEmail = false,
                            IsSendByNOtification = false,
                            IsSendBySms = false,
                            MinpRice = model.MinpRice,
                            MaxPrice = model.MaxPrice,
                            Skills = model.Skills,
                            Description = model.Description,
                            ServiceType = model.ServiceType,

                            CityId = model.CityId,
                            CategoryId = model.CategoryId,
                            MonyUnitId = model.MonyUnitId,
                            UserId = userFromDb.Id,
                            Username = userFromDb.UserName,
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



        [Route("Services/UsersService/{username}")]
        public async Task<IActionResult> UsersService(string username, int? limit, int? offset)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.Where(c => c.Id == currentUserId).Select(c => new { c.Id, c.UserName }).FirstOrDefaultAsync();



            var query = _context.TBL_Service.AsQueryable();
            var count = query.Where(c => c.Username == username && c.ServiceType == ServiceType.GiverService).Count();

            var services = await _context.TBL_Service
                 .AsNoTracking()
                .Where(m => m.Username == username && m.ServiceType == ServiceType.GiverService)
                .Skip(offset ?? 0)
                .Take(limit ?? 8)
                 .Include(c => c.UserLikeServices)
                .Select(c => new ServiceListVM
                {
                    Id = c.Id,
                    CreateDate = c.CreateDate,
                    Description = c.Description,
                    LikeCount = c.LikeCount,
                    CommentCount = c.CommentCount,
                    SeenCount = c.SeenCount,
                    Title = c.Title,
                    CategoryName = CultureInfo.CurrentCulture.Name == PublicHelper.persianCultureName ? c.Category.Name : c.Category.EnglishName,

                    //CategoryImageAddresc=c.Category.ImageAddress
                    IsLiked = c.UserLikeServices.Any(p => p.UserName == user.UserName && p.ServiceId == c.Id),
                })
                .OrderByDescending(c => c.CreateDate)
                .ThenBy(c => c.LikeCount)
                .ToListAsync();
            var response = new { Count = count, services = services };
            return new JsonResult(new { Status = true, Message = "", data = response });
        }


        [Route("Services/SearchService")]
        public async Task<IActionResult> SearchService(int? limit, int? offset)
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









            //var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            ////var user = await _context.Users.Where(c => c.Id == currentUserId).Select(c => new { c.Id, c.UserName }).FirstOrDefaultAsync();



            ////var query = _context.TBL_Service.AsQueryable();
            ////var count = query.AsNoTracking().Where(c => c.ServiceType == ServiceType.GiverService).Count();

            //var services = await _context.TBL_Service
            //    .AsNoTracking()
            //    .Where(m => m.ServiceType == ServiceType.GiverService)
            //    .Skip(offset ?? 0)
            //    .Take(limit ?? 8)
            //    .Include(c => c.UserLikeServices)
            //    .Select(c => new ServiceListVM
            //    {
            //        Id = c.Id,
            //        CreateDate = c.CreateDate,
            //        Description = c.Description,
            //        LikeCount = c.LikeCount,
            //        CommentCount = c.CommentCount,
            //        SeenCount = c.SeenCount,
            //        Title = c.Title,
            //        CategoryName = CultureInfo.CurrentCulture.Name == PublicHelper.persianCultureName ? c.Category.Name : c.Category.EnglishName,

            //        //CategoryImageAddresc=c.Category.ImageAddress
            //        IsLiked = c.UserLikeServices.Any(p => p.UserId == currentUserId),
            //    })
            //    .OrderByDescending(c => c.LikeCount)
            //    .ThenByDescending(c => c.SeenCount)
            //    .ThenByDescending(c => c.CommentCount)
            //    .ThenByDescending(c => c.CreateDate)
            //    .ToListAsync();

            //return View(services);
            ////var response = new { Count = count, services = services };
            ////return new JsonResult(new { Status = true, Message = "", data = response });
        }


        public async Task<IActionResult> ToggleLike(int? serviceId)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.Where(c => c.Id == currentUserId).Select(c => new { c.Id, c.UserName }).FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(user?.Id))
                return new JsonResult(new { Status = false, Message = "برای لایک  ابتدا لاگین کنید." });
            if (serviceId == null)
                return new JsonResult(new { Status = false, Message = "   این سرویس موجود نیست." });



            //if (User.Identity.IsAuthenticated) {
            //    return new JsonResult(new { Status = 0, Message = "ابتدا وارد حساب خود شوید" });
            //}
            var serviceFromDb = _context.TBL_Service.Find(serviceId);
            if (serviceFromDb == null)
                return new JsonResult(new { Status = false, Message = "این  سرویس موجود نیست" });

            var IsLiked = false;
            var oldLike = _context.TBL_UserLikeSerive.Where(c => c.UserId == user.Id && c.ServiceId == serviceFromDb.Id).FirstOrDefault();
            if (oldLike != null)
            {
                _context.TBL_UserLikeSerive.Remove(oldLike);
                IsLiked = false;
                serviceFromDb.LikeCount--;
            }
            else
            {
                var serviceLike = new TBL_User_Like_Service()
                {
                    UserId = user.Id,
                    ServiceId = serviceFromDb.Id,
                    CrateDate = DateTime.Now,
                    UserName = user.UserName,
                };
                _context.TBL_UserLikeSerive.Add(serviceLike);
                serviceFromDb.LikeCount++;
                IsLiked = true;
            }

            try
            {
                _context.SaveChanges();
                //return new { Status = true, LikeCount = Res.LikeCount, IsLiked = Res.IsLiked };
                return new JsonResult(new { Status = true, LikeCount = serviceFromDb.LikeCount, IsLiked = IsLiked });
            }
            catch
            {
                return new JsonResult(new { Status = false, Message = "خطا  در ثبت" });
            }
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
