using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models;
using Helper.Models.Service;
using Helper.Models.Utilities;
using Helper.ViewModels.Api.Account;
using Helper.ViewModels.Api.Profiles;
using Helper.ViewModels.Api.Profiles.DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {



        #region  ctor

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtGenerator _jwtGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public ProfileController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            JwtGenerator jwtGenerator,
               IHttpContextAccessor httpContextAccessor,
                  IMapper mapper
            )
        {
            _context = context;
            _userManager = userManager;
            //_signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        #endregion

        #region get Profile


        //  /api/Profile/Profile?username=2Fsina
        [HttpGet("Profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Profile(string Id)
        {
            var currentUsername = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var currentSerialNumber = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == PublicHelper.SerialNumberClaim)?.Value;
            try
            {
                var user = await _context
                        .Users
                        .Where(c => c.Id == Id && c.UserName == currentUsername && c.SerialNumber == currentSerialNumber)
                        .Include(c => c.EducationHistry)
                        .Include(c => c.WorkExperience)
                        .Select(c => new ProfilesDTO
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
                            EducationHistryDTO = new EducationHistoryDTO
                            {
                                EnterDate = c.EducationHistry.EnterDate,
                                ExitDate = c.EducationHistry.ExitDate,
                                MaghTa = c.EducationHistry.MaghTa,
                                UnivercityName = c.EducationHistry.UnivercityName,
                            },
                            WorkExperienceDTO = new WorkExperienceDTO
                            {
                                EnterDate = c.WorkExperience.EnterDate,
                                ExitDate = c.WorkExperience.ExitDate,
                                Descriptions = c.WorkExperience.Descriptions,
                                Semat = c.WorkExperience.Semat,
                                CompanyName = c.WorkExperience.CompanyName,
                            },
                        })
                        .FirstOrDefaultAsync();

                if (user != null)
                {
                    //var Profile = _mapper.Map<ApplicationUser, ProfileDTO>(user);

                    return new JsonResult(new { Status = 1, Message = "", Data = user });
                }
                return new JsonResult(new { Status = 0, Message = "اطلاعاتی برای این حساب کاربری یافت نشد", statusCode = 404 });
            }
            catch
            {
                return new JsonResult(new { Status = 0, Message = "خطایی رخ داده است", });
            }

        }

        #endregion

        #region UpdateProfile

        //  /api/Profile/UpdateProfile
        [HttpPut("UpdateProfile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateProfile(string Id, UpdateProfileVM model)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var item in ModelState.Values)
                {
                    foreach (var err in item.Errors)
                    {
                        errors.Add(err.ErrorMessage);
                    }
                }
                return new JsonResult(new { Status = 0, Message = "bad request", Data = errors });
            }

            var currentUsername = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var currentSerialNumber = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == PublicHelper.SerialNumberClaim)?.Value;

            try
            {
                var user = await _context.Users.Where(c => c.UserName == currentUsername && c.SerialNumber == currentSerialNumber)
                    .Include(c=>c.EducationHistry)
                    .Include(c=>c.WorkExperience)
                    .FirstOrDefaultAsync();

                //var user = await _userManager.FindByNameAsync(currentUsername);
                if (user != null)
                {
                    if (await _context.Users.Where(x => x.UserName == model.UserName && x.UserName != user.UserName).AnyAsync())
                        return new JsonResult(new { Status = 0, Message = "این نام کاربری موجود است" });

                    if (await _context.Users.Where(x => x.Email == model.Email && x.Email != user.Email).AnyAsync())
                        return new JsonResult(new { Status = 0, Message = "این ایمیل  موجود است" });
                  
                    //var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.City = model.City;
                    user.Phone = model.Phone;
                    if (user.WorkExperience != null)
                    {
                        user.WorkExperience.CompanyName = model.CompanyName;
                        user.WorkExperience.Descriptions = model.Descriptions;
                        user.WorkExperience.EnterDate = model.WorkEnterDate;
                        user.WorkExperience.ExitDate = model.WorkExitDate;
                        user.WorkExperience.Semat = model.Semat;
                    }
                    if (user.EducationHistry != null)
                    {
                        user.EducationHistry.EnterDate = model.EduEnterDate;
                        user.EducationHistry.ExitDate = model.EduExitDate;
                        user.EducationHistry.MaghTa = model.MaghTa;
                        user.EducationHistry.UnivercityName = model.UnivercityName;
                    }

                    //اطلاعات ديگر
                    user.Birthdate = model.Birthdate;
                    user.Gender = model.Gender;
                    user.MarriedType = model.MarriedType;
                    user.LanguageKnowing = model.LanguageKnowing;




                    var SerialNumber = Guid.NewGuid().ToString().GetHash();
                    user.SerialNumber = SerialNumber;

                    await _context.SaveChangesAsync();

                    var userRoles = await _userManager.GetRolesAsync(user);
                    var role = userRoles.First();
                    var currentUser = new UserVM
                    {
                        Id = user.Id,
                        Email = user.Email,
                        Nickname = user.Nickname,
                        UserName = user.UserName,
                        PhotoAddress = user.PhotoAddress,
                        Token = _jwtGenerator.CreateToken(user, role),
                    };
                    var userInfo = _mapper.Map<ApplicationUser, ProfilesDTO>(user);
                    userInfo.CurrentUser = currentUser;

                    return new JsonResult(new { Status = 1, Message = "", Data = userInfo });
                }
                return new JsonResult(new { Status = 0, Message = "کاربری یافت نشد", });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { Status = 0, Message = "خطایی رخ داده است", });
            }
        }

        #endregion

    }
}