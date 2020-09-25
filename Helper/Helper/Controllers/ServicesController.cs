using AutoMapper;
using Helper.Data;
using Helper.Models;
using Helper.Models.Entities;
using Helper.Models.Enums;
using Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Helper.Controllers
{

    [Authorize]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private IStringLocalizer<ServicesController> _localizer;
        private readonly UserManager<ApplicationUser> _userManager;


        public ServicesController(
            ApplicationDbContext context,
               //JwtGenerator jwtGenerator,
               IHttpContextAccessor httpContextAccessor,
               IMapper mapper,
               UserManager<ApplicationUser> userManager,
               IStringLocalizer<ServicesController> localizer
            )
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _userManager = userManager;
            _localizer = localizer;
        }



        #region index Create page
        public async Task<IActionResult> Index()
        {
            returnViewDate();



            var userFromDb = await _userManager.GetUserAsync(User);

            var HasActivePlan = true;

            if (userFromDb.PlanCount < 1 || userFromDb.PlanExpDate < DateTime.Now || userFromDb.PlanId == 0)
            {
                HasActivePlan = false;
            }

            ViewBag.HasActivePlan = HasActivePlan;

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

        #endregion

        #region create provider service

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
                    if (model.MinpRice > model.MaxPrice)
                    {
                        return new JsonResult(new { Status = false, Message = _localizer["MinPriceMoreThanMaXPriceMessage"].Value.ToString() });
                    }
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
                            ConfirmServiceType = ConfirmServiceType.Pending,
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


        #endregion

        #region Create Giver service 
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
                    if (model.MinpRice > model.MaxPrice)
                    {
                        return new JsonResult(new { Status = false, Message = _localizer["MinPriceMoreThanMaXPriceMessage"].Value.ToString() });
                    }

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
                            ConfirmServiceType = ConfirmServiceType.Pending,
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

        #endregion



        [Route("Services/UsersService/{username}")]
        public async Task<IActionResult> UsersService(string username, int? limit, int? offset)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.Where(c => c.Id == currentUserId).Select(c => new { c.Id, c.UserName }).FirstOrDefaultAsync();

            var query = _context.TBL_Service.AsQueryable();
            var count = query.Where(c => c.Username == username && c.ServiceType == ServiceType.GiverService).Count();

            var services = await _context.TBL_Service
                 .AsNoTracking()
                .Where(m => m.Username == username && m.ServiceType == ServiceType.GiverService && m.ConfirmServiceType == ConfirmServiceType.Confirmed && m.Category.IsEnabled == true)
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
                    CategoryImageAddres = c.Category.PhotoAddress,
                    IsLiked = c.UserLikeServices.Any(p => p.UserName == user.UserName && p.ServiceId == c.Id),
                })
                .OrderByDescending(c => c.CreateDate)
                .ThenBy(c => c.LikeCount)
                .ToListAsync();
            var response = new { Count = count, services = services };
            return new JsonResult(new { Status = true, Message = "", data = response });
        }


        [Route("Services/SearchService")]
        [AllowAnonymous]
        public IActionResult SearchService()
        {
            returnViewDate();
            return View();
        }






        /// <summary>
        /// search for service
        /// </summary>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <param name="searchedWord"></param>
        /// <param name="skills"></param>
        /// <param name="cityId"></param>
        /// <param name="categoryId"></param>
        /// <param name="monyUnitid"></param>
        /// <param name="minPrice"></param>
        /// <param name="maxPrice"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> SearchAllService(int? limit, int? offset,
                   string searchedWord, string skills, int? cityId, int? firstCaId, int? categoryId, int? monyUnitid
            , int? minPrice, int? maxPrice)
        {
            if (searchedWord?.Length > 100)
            {
                return new JsonResult(new { Status = false, Message = _localizer["Morthan100Char"].Value.ToString() });
            }
            if (skills?.Length > 2000)
            {
                return new JsonResult(new { Status = false, Message = _localizer["Morthan2000Char"].Value.ToString() });
            }

            if ((minPrice != null || maxPrice != null) && monyUnitid == null)
            {
                return new JsonResult(new { Status = false, Message = _localizer["SelectMonyUnitErrorMessage"].Value.ToString() });
            }
            if (minPrice > maxPrice)
            {
                return new JsonResult(new { Status = false, Message = _localizer["MinPriceMoreThanMaXPriceMessage"].Value.ToString() });
            }

            var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            //var user = await _context.Users.Where(c => c.Id == currentUserId).Select(c => new { c.Id, c.UserName }).FirstOrDefaultAsync();


            var service = _context.TBL_Service.AsNoTracking()
                .Where(c => c.ServiceType == ServiceType.GiverService && c.ConfirmServiceType == ConfirmServiceType.Confirmed && c.Category.IsEnabled == true).AsQueryable();
            //var query = _context.TBL_Service.AsQueryable();
            //var count = query.AsNoTracking().Where(c => c.ServiceType == ServiceType.GiverService).Count();



            var findServices = Enumerable.Empty<TBL_Service>().AsQueryable();
            var findService = new List<TBL_Service>();

            if (cityId != null)
                service = service.Where(c => c.CityId == cityId);
            if (firstCaId == null)
            {
                if (categoryId != null)
                    service = service.Where(c => c.CategoryId == categoryId);
            }
            else
            {
                service = service.Where(c => c.CategoryId == firstCaId);
            }
            if (monyUnitid != null)
                service = service.Where(c => c.MonyUnitId == monyUnitid);
            if (!string.IsNullOrEmpty(searchedWord))
                service = service.Where(c => c.Title.ToLower().Trim().Contains(searchedWord.ToLower().Trim()));
            if (minPrice != null)
                service = service.Where(c => c.MinpRice >= minPrice);
            if (maxPrice != null)
                service = service.Where(c => c.MaxPrice <= maxPrice);
            //if (!string.IsNullOrEmpty(skills))
            //{
            //    var listSkill = skills.Split(",").ToList();
            //    foreach (var item in listSkill)
            //    {
            //        var sss = service.Select(x => x.Skills).ToList();
            //        var s = sss.Contains(item);
            //        findService.AddRange(service.Where(c => c.Skills.Contains(item)).ToList());
            //        //service = ;
            //    }
            //    var a = listSkill;

            //    var find = service.ToList();






            //    //service = service.Where(c => IscontainSkills(c, listSkill));
            //    //  do your logic

            //    //service = service.Where((c,i)=> {
            //    //    if (i % 2 == 0) // if it is even element
            //    //        return true;

            //    //    return false;
            //    //});

            //}




            var count = service.Count();

            var services = await service
                .AsNoTracking()
                .Skip(offset ?? 0)
                .Take(limit ?? 8)
                .Include(c => c.Category)
                //.Include(c => c.User.PhotoAddress)
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
                    CategoryImageAddres = c.Category.PhotoAddress,
                    UserImageAddress = c.User.PhotoAddress,
                    IsLiked = c.UserLikeServices.Any(p => p.UserId == currentUserId),
                    Username = c.Username
                })
                .OrderByDescending(c => c.LikeCount)
                .ThenByDescending(c => c.SeenCount)
                .ThenByDescending(c => c.CommentCount)
                .ThenByDescending(c => c.CreateDate)
                .ToListAsync();

            //var count = services.Count();


            var response = new { Count = count, services = services };
            return new JsonResult(new { Status = true, Message = "", data = response });
            //return new JsonResult(new { Status = true, Message = "", data = response });
        }


        private bool IscontainSkills(TBL_Service service, List<string> skills)
        {
            if (service.Skills != null)
            {
                var listSkill = service.Skills.Split(",");
                foreach (var skill in skills)
                {
                    if (listSkill.Contains(skill.Trim()))
                    {
                        return true;
                    }
                }
                return false;
            }
            else return false;
        }





        [AllowAnonymous]
        public async Task<IActionResult> GetallCityCategoryMonuUnit()
        {

            if (CultureInfo.CurrentCulture.Name == PublicHelper.persianCultureName)
            {
                var catses = await _context.TBL_Category.AsNoTracking().Where(c => c.IsEnabled)
                     .Select(c => new
                     {
                         Id = c.Id,
                         Name = c.Name
                     }).ToListAsync();

                var citieses = await _context.TBL_City.AsNoTracking()
                     .Where(c => c.IsEnabled)
                   .Select(c => new
                   {
                       Id = c.Id,
                       Name = c.Name
                   }).ToListAsync();

                var monyUnitses = await _context.TBL_MonyUnit.AsNoTracking()
                      .Where(c => c.IsEnabled)
                      .Select(c => new
                      {
                          Id = c.Id,
                          Name = c.Name
                      }).ToListAsync();

                var d = new { cats = catses, cities = citieses, monyUnits = monyUnitses };
                return new JsonResult(new { Status = true, Message = "", data = d });
            }
            else
            {
                var catses = await _context.TBL_Category.AsNoTracking().Where(c => c.IsEnabled)
                    .Select(c => new
                    {
                        Id = c.Id,
                        Name = c.EnglishName
                    }).ToListAsync();

                var citieses = await _context.TBL_City.AsNoTracking()
                     .Where(c => c.IsEnabled)
                   .Select(c => new
                   {
                       Id = c.Id,
                       Name = c.EnglishName
                   }).ToListAsync();

                var monyUnitses = await _context.TBL_MonyUnit.AsNoTracking()
                      .Where(c => c.IsEnabled)
                      .Select(c => new
                      {
                          Id = c.Id,
                          Name = c.EnglishName
                      }).ToListAsync();


                var d = new { cats = catses, cities = citieses, monyUnits = monyUnitses };
                return new JsonResult(new { Status = true, Message = "", data = d });
            }
        }




        [AllowAnonymous]
        public async Task<IActionResult> ToggleLike(int? serviceId)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new JsonResult(new { Status = false, Message = _localizer["LoginForLikeMessage"].Value.ToString() });
            }
            var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.Where(c => c.Id == currentUserId).Select(c => new { c.Id, c.UserName }).FirstOrDefaultAsync();
            if (user == null)
                return new JsonResult(new { Status = false, Message = _localizer["LoginForLikeMessage"].Value.ToString() });

            //if (string.IsNullOrEmpty(user?.Id))
            //    return new JsonResult(new { Status = false, Message = _localizer["LoginForLikeMessage"].Value.ToString() });
            if (serviceId == null)
                return new JsonResult(new { Status = false, Message = _localizer["ServiceNotFoundMessage"].Value.ToString() });



            //if (User.Identity.IsAuthenticated) {
            //    return new JsonResult(new { Status = 0, Message = "ابتدا وارد حساب خود شوید" });
            //}
            var serviceFromDb = _context.TBL_Service.Find(serviceId);
            if (serviceFromDb == null)
                return new JsonResult(new { Status = false, Message = _localizer["ServiceNotFoundMessage"].Value.ToString() });

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
                return new JsonResult(new { Status = false, Message = _localizer["FailMessage"].Value.ToString() });
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
            ViewData["submitText"] = _localizer["submitText"];
            ViewData["services"] = _localizer["services"];
            ViewData["New"] = _localizer["New"];
            ViewData["searchServiceText"] = _localizer["searchServiceText"];
            ViewData["searchingText"] = _localizer["searchingText"];
            ViewData["LoadingText"] = _localizer["LoadingText"];


            ViewData["HowToSendService"] = _localizer["HowToSendService"];
            ViewData["ServiceRequest"] = _localizer["ServiceRequest"];
            ViewData["ServiceDelivery"] = _localizer["ServiceDelivery"];
            ViewData["CreateService"] = _localizer["CreateService"];
            ViewData["CreateServiceText"] = _localizer["CreateServiceText"];
            ViewData["Prev"] = _localizer["Prev"];
            ViewData["Next"] = _localizer["Next"];

        }

    }
}
