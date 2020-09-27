using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Extention;
using Helper.Models;
using Helper.ViewModels;
using Helper.ViewModels.Api.Profiles.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Helper.Models.Enums;

namespace Helper.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private IStringLocalizer<ProfilesController> _localizer;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ProfilesController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            IWebHostEnvironment hostingEnvironment,
               //JwtGenerator jwtGenerator,
               IHttpContextAccessor httpContextAccessor,
                  IMapper mapper,
           IStringLocalizer<ProfilesController> localizer)
        {
            _context = context;
            _userManager = userManager;
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _localizer = localizer;
        }



        #region get Profile
        [Authorize]
        public async Task<ActionResult> Index()
        {
            returnViewDate();

            var UserId = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _context
                    .Users
                    .Where(c => c.Id == UserId)
                    .AsNoTracking()
                    .Include(c => c.EducationHistry)
                    .Include(c => c.WorkExperience)
                    .Select(c => new ProfileVM2
                    {
                        Id = c.Id,
                        UserName = c.UserName,
                        Email = c.Email,
                        Birthdate = c.Birthdate,
                        //Descriptions = c.Descriptions,
                        //IsMarid = c.IsMarid,
                        Nickname = c.Nickname,
                        Phone = c.Phone,
                        LanguageKnowing = c.LanguageKnowing,
                        City = c.City,
                        Gender = c.Gender,
                        MarriedType = c.MarriedType,
                        PhotoAddress = c.PhotoAddress,


                        EduEnterDate = c.EducationHistry.EnterDate,
                        EduExitDate = c.EducationHistry.ExitDate,
                        MaghTa = c.EducationHistry.MaghTa,
                        UnivercityName = c.EducationHistry.UnivercityName,

                        WorkEnterDate = c.WorkExperience.EnterDate,
                        WorkExitDate = c.WorkExperience.ExitDate,
                        WorkDescriptions = c.WorkExperience.Descriptions,
                        Semat = c.WorkExperience.Semat,
                        CompanyName = c.WorkExperience.CompanyName,
                    })
                    .FirstOrDefaultAsync();


            if (user == null)
                return NotFound();

            var query = _context.TBL_Service.AsQueryable();
            var count = query.Where(c => c.Username == user.UserName && c.ServiceType == ServiceType.GiverService).Count();

            var services = await _context.TBL_Service
                 .AsNoTracking()
                .Where(m => m.Username == user.UserName && m.ServiceType == ServiceType.GiverService)
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
                    ConfirmServiceType = c.ConfirmServiceType,
                    
                    //IsLiked = c.UserLikeServices.Any(p => p.UserName == user.UserName && p.ServiceId == c.Id),
                })
                .OrderByDescending(c => c.CreateDate)
                .ThenBy(c => c.LikeCount)
                .ThenBy(c => c.ConfirmServiceType == ConfirmServiceType.Confirmed)
                .ToListAsync();



            var data = new ProfileWithDashboardVM()
            {
                Profile = user,
                Services = services
            };

            return View(data);


            //return View(user);
        }
        #endregion





        #region UpdateProfile

        //  /api/Profile/UpdateProfile
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Index(string Id, ProfileVM2 model)
        {
            returnViewDate();


            if (Id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var userFromDb = await _context.Users.Where(c => c.Id == model.Id)
                          .Include(c => c.EducationHistry)
                          .Include(c => c.WorkExperience)
                           .FirstOrDefaultAsync();

                    if (userFromDb != null)
                    {
                        //if (await _context.Users.Where(x => x.UserName == model.UserName && x.UserName != userFromDb.UserName).AnyAsync())
                        //{
                        //    TempData["Error"] = _localizer["ExistUserName"].Value.ToString();
                        //    return View(model);
                        //}

                        if (await _context.Users.Where(x => x.Email == model.Email && x.Email != userFromDb.Email).AnyAsync())
                        {
                            return new JsonResult(new { Status = false, Message = _localizer["ExistEmail"].Value.ToString() });

                            //TempData["Error"] = _localizer["ExistEmail"].Value.ToString();
                            //return View(model);
                        }




                        if (model.file != null)
                        {
                            if (!FileUploader.IsImageMimeTypeValid(model.file) || !FileUploader.IsImageExtentionValid(model.file))
                            {
                                return new JsonResult(new { Status = false, Message = _localizer["image format Is not valid"].Value.ToString() });
                            }

                            if (!FileUploader.IsImageSizeValid(model.file, 0.4))
                            {
                                return new JsonResult(new { Status = false, Message = _localizer[$"Image size should less than {400} kiloBite"].Value.ToString() });
                            }




                            var host = _hostingEnvironment.WebRootPath;
                            var url = "Upload/User";
                            var savePath = Path.Combine(host, url);
                            var uploadResult = FileUploader.UploadImagePng(file: model.file, maxLength: 0.4, path: savePath, compression: 100);
                            if (uploadResult.succsseded == false)
                            {

                                return new JsonResult(new { Status = false, Message = uploadResult.result });

                                //ModelState.AddModelError("", uploadResult.result);
                                //return View(model);
                            }

                            var img = uploadResult.result;
                            model.PhotoAddress = "/Upload/User/" + img;


                            if (!string.IsNullOrEmpty(userFromDb.PhotoAddress))
                            {
                                var LastImagePath = userFromDb.PhotoAddress.Substring(1);
                                LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                                if (System.IO.File.Exists(LastImagePath))
                                {
                                    System.IO.File.Delete(LastImagePath);
                                }
                            }
                            //update Newe Pic Address To database
                            userFromDb.PhotoAddress = model.PhotoAddress;
                        }







                        userFromDb.Nickname = model.Nickname;
                        //userFromDb.UserName = model.UserName;
                        userFromDb.Email = model.Email;
                        userFromDb.City = model.City;
                        userFromDb.Phone = model.Phone;

                        //Helper.Models.Utilities.FileUploader()

                        //اطلاعات کاری
                        if (userFromDb.WorkExperience != null)
                        {
                            userFromDb.WorkExperience.CompanyName = model.CompanyName;
                            userFromDb.WorkExperience.Descriptions = model.Descriptions;
                            userFromDb.WorkExperience.EnterDate = model.WorkEnterDate;
                            userFromDb.WorkExperience.ExitDate = model.WorkExitDate;
                            userFromDb.WorkExperience.Semat = model.Semat;
                        }

                        //اطلاهات درسی
                        if (userFromDb.EducationHistry != null)
                        {
                            userFromDb.EducationHistry.EnterDate = model.EduEnterDate;
                            userFromDb.EducationHistry.ExitDate = model.EduExitDate;
                            userFromDb.EducationHistry.MaghTa = model.MaghTa;
                            userFromDb.EducationHistry.UnivercityName = model.UnivercityName;
                        }

                        //اطلاعات ديگر
                        userFromDb.Birthdate = model.Birthdate;
                        userFromDb.Gender = model.Gender;
                        userFromDb.MarriedType = model.MarriedType;
                        userFromDb.LanguageKnowing = model.LanguageKnowing;

                        var result = _context.SaveChanges();

                        await HttpContext.RefreshLoginAsync();
                        return new JsonResult(new { Status = true, Message = _localizer["SuccessMessage"].Value.ToString(), data = userFromDb.PhotoAddress });

                        //TempData["Success"] = "ثبت موفقیت آمیز";
                        //return View(model);
                        //return RedirectToAction(nameof(Index));
                    }
                    return new JsonResult(new { Status = false, Message = _localizer["UserNotFoundMessage"].Value.ToString() });

                    //TempData["Error"] = "کاربر یافت نشد";
                    //return View(model);

                }
                catch (DbUpdateConcurrencyException)
                {
                    return new JsonResult(new { Status = false, Message = _localizer["FailMessage"].Value.ToString() });
                }

            }
            return View(model);


        }

        #endregion



        [Authorize]
        [Route("Profiles/OtherUserProfile/{username}")]
        public async Task<ActionResult> OtherUserProfile(string username)
        {

            returnViewDate();
            var currentUsername = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _context
                .Users
                .Where(c => c.UserName == username)
                .AsNoTracking()
                .Include(c => c.EducationHistry)
                .Include(c => c.WorkExperience)
                .Select(c => new OtherUserProfileVM
                {
                    Id = c.Id,
                    UserName = c.UserName,
                    Nickname = c.Nickname,
                    Birthdate = c.Birthdate,
                    Descriptions = c.Descriptions,
                    PhotoAddress = c.PhotoAddress,

                ////////////////////////////////////////Phone = c.Phone,
                LanguageKnowing = c.LanguageKnowing,
                    City = c.City,
                    Gender = c.Gender,
                    MarriedType = c.MarriedType,
                    SKILLS = c.Skils,


                    EduEnterDate = c.EducationHistry != null ? c.EducationHistry.EnterDate : null,
                    EduExitDate = c.EducationHistry != null ? c.EducationHistry.ExitDate : null,
                    MaghTa = c.EducationHistry != null ? c.EducationHistry.MaghTa : null,
                    UnivercityName = c.EducationHistry != null ? c.EducationHistry.UnivercityName : null,


                    WorkEnterDate = c.WorkExperience != null ? c.WorkExperience.EnterDate : null,
                    WorkExitDate = c.WorkExperience != null ? c.WorkExperience.ExitDate : null,
                    WorkDescriptions = c.WorkExperience != null ? c.WorkExperience.Descriptions : null,
                    Semat = c.WorkExperience != null ? c.WorkExperience.Semat : null,
                    CompanyName = c.WorkExperience != null ? c.WorkExperience.CompanyName : null,
                })
                .FirstOrDefaultAsync();

            if (user != null)
            {
                //var Profile = _mapper.Map<ApplicationUser, ProfileDTO>(user);

                return View(user);
            }
            return NotFound();


        }




        private void returnViewDate()
        {
            ViewData["EditProfile"] = _localizer["EditProfile"];
            ViewData["Dashboard"] = _localizer["Dashboard"];


            ViewData["from"] = _localizer["from"];
            ViewData["to"] = _localizer["to"];
            ViewData["Position"] = _localizer["Position"];
            ViewData["BirthDate"] = _localizer["BirthDate"];

            ViewData["LanguageKnowingPL"] = _localizer["LanguageKnowingPL"];
            ViewData["LanguageKnowing"] = _localizer["LanguageKnowing"];

            ViewData["Resume"] = _localizer["Resume"];
            ViewData["OtherInfo"] = _localizer["OtherInfo"];
            ViewData["AcademicRecords"] = _localizer["AcademicRecords"];


            ViewData["NameAndLastNamePL"] = _localizer["NameAndLastNamePL"];
            ViewData["UserNamePL"] = _localizer["UserNamePL"];
            ViewData["EmailPL"] = _localizer["EmailPL"];
            ViewData["CityPL"] = _localizer["CityPL"];
            ViewData["MobileNumberPL"] = _localizer["MobileNumberPL"];
            ViewData["OfficePL"] = _localizer["OfficePL"];
            ViewData["PositionPL"] = _localizer["PositionPL"];
            ViewData["fromPL"] = _localizer["fromPL"];
            ViewData["toPL"] = _localizer["toPL"];
            ViewData["DescriptionPL"] = _localizer["DescriptionPL"];
            ViewData["GradePL"] = _localizer["GradePL"];
            ViewData["UniverCityName"] = _localizer["UniverCityName"];
            ViewData["Office"] = _localizer["Office"];

            ViewData["BirthDatePL"] = _localizer["BirthDatePL"];
            ViewData["GenderPL"] = _localizer["GenderPL"];
            ViewData["SituationPL"] = _localizer["SituationPL"];


            ViewData["UniverCityNamePL"] = _localizer["UniverCityNamePL"];
            ViewData["StartEduDatePL"] = _localizer["StartEduDatePL"];
            ViewData["EndEduDatePL"] = _localizer["EndEduDatePL"];


            ViewData["Skills"] = _localizer["Skills"];

            ViewData["Services"] = _localizer["Services"];
            ViewData["RequestService"] = _localizer["RequestService"];
            ViewData["SendMsg"] = _localizer["SendMsg"];
            ViewData["Resume2"] = _localizer["Resume2"];

            ViewData["Next"] = _localizer["Next"];
            ViewData["Prev"] = _localizer["Prev"];

            ViewData["SaveChanges"] = _localizer["SaveChanges"];

        }


    }
}