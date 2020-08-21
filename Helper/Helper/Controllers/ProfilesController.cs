using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models;
using Helper.ViewModels;
using Helper.ViewModels.Api.Profiles.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public ProfilesController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
               //JwtGenerator jwtGenerator,
               IHttpContextAccessor httpContextAccessor,
                  IMapper mapper
            )
        {
            _context = context;
            _userManager = userManager;

            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }



        #region get Profile



        [Authorize]
        public async Task<ActionResult> Index()
        {
            var UserId = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _context
                    .Users
                    .Where(c => c.Id == UserId)
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


                        EduEnterDate = c.EducationHistry.EnterDate,
                        EduExitDate = c.EducationHistry.ExitDate,
                        MaghTa = c.EducationHistry.MaghTa,
                        UnivercityName = c.EducationHistry.UnivercityName,
                        //EducationHistryDTO = new EducationHistoryDTO
                        //{
                        //    EnterDate = c.EducationHistry.EnterDate,
                        //    ExitDate = c.EducationHistry.ExitDate,
                        //    MaghTa = c.EducationHistry.MaghTa,
                        //    UnivercityName = c.EducationHistry.UnivercityName,
                        //},

                        WorkEnterDate = c.WorkExperience.EnterDate,
                        WorkExitDate = c.WorkExperience.ExitDate,
                        WorkDescriptions = c.WorkExperience.Descriptions,
                        Semat = c.WorkExperience.Semat,
                        CompanyName = c.WorkExperience.CompanyName,
                        //WorkExperienceDTO = new WorkExperienceDTO
                        //{
                        //    EnterDate = c.WorkExperience.EnterDate,
                        //    ExitDate = c.WorkExperience.ExitDate,
                        //    Descriptions = c.WorkExperience.Descriptions,
                        //    Semat = c.WorkExperience.Semat,
                        //    CompanyName = c.WorkExperience.CompanyName,
                        //},
                    })
                    .FirstOrDefaultAsync();
            if (user != null)
                return View(user);
            return NotFound();


        }







        #region UpdateProfile

        //  /api/Profile/UpdateProfile
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Index(string Id, ProfileVM2 model)
        {
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
                        if (await _context.Users.Where(x => x.UserName == model.UserName && x.UserName != userFromDb.UserName).AnyAsync())
                            return new JsonResult(new { Status = 0, Message = " نام کاربری موجود است" });

                        if (await _context.Users.Where(x => x.Email == model.Email && x.Email != userFromDb.Email).AnyAsync())
                            return new JsonResult(new { Status = 0, Message = " ایمیل  موجود است" });



                        userFromDb.UserName = model.UserName;
                        userFromDb.Email = model.Email;
                        userFromDb.City = model.City;
                        userFromDb.Phone = model.Phone;

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

                        TempData["Success"] = "ثبت موفقیت آمیز";
                        return View(model);
                        //return RedirectToAction(nameof(Index));
                    }

                    TempData["Error"] = "کاربر یافت نشد";
                    return View(model);

                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["Error"] = "خطا در ثبت";
                    return View(model);
                }

            }
            return View(model);

         
        }

        #endregion





        #endregion











    }
}