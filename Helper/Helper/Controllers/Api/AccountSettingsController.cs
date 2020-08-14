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
using Helper.ViewModels.Api.AccountSettings;
using Helper.ViewModels.Api.AccountSettings.DTO;
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
    public class AccountSettingsController : ControllerBase
    {
        #region  ctor

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtGenerator _jwtGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        public AccountSettingsController(UserManager<ApplicationUser> userManager,
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


        //  /api/AccountSettings/Profile?username=2Fsina
        [HttpGet("Profile")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Profile(string Id)
        {
            var currentUsername = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var currentSerialNumber = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == PublicHelper.SerialNumberClaim)?.Value;
            try
            {
                var user = await _context.Users
                    .Where(c => c.Id == Id && c.UserName == currentUsername && c.SerialNumber == currentSerialNumber)
                    .Include(c=>c.BankInfo)
                    .FirstOrDefaultAsync();

                if (user != null)
                {
                    var Profile = _mapper.Map<ApplicationUser, ProfileDTO>(user);

                    return new JsonResult(new { Status = 1, Message = "", Data = Profile });
                }
                return new JsonResult(new { Status = 0, Message = "اطلاعاتی برای این حساب کاربری یافت نشد", statusCode = 404 });
            }
            catch
            {
                return new JsonResult(new { Status = 0, Message = "خطایی رخ داده است", });
            }

        }

        #endregion




        #region changePersonalInfo

        //  /api/AccountSettings/ChangePeronalInfo
        [HttpPut("ChangePeronalInfo")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ChangePeronalInfo(string Id, ChangePrsonalInfoVM model)
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
                var user = await _context.Users.Where(c => c.UserName == currentUsername && c.SerialNumber == currentSerialNumber).FirstOrDefaultAsync();

                if (user != null)
                {

                    if (await _context.Users.Where(x => x.UserName == model.UserName && x.UserName != user.UserName).AnyAsync())
                        return new JsonResult(new { Status = 0, Message = "این نام کاربری موجود است" });

                    if (await _context.Users.Where(x => x.Email == model.Email && x.Email != user.Email).AnyAsync())
                        return new JsonResult(new { Status = 0, Message = "این ایمیل  موجود است" });


                    //var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Phone = model.Phone;
                    user.SiteLanguage = model.SiteLanguage;


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
                    var userInfo = _mapper.Map<ApplicationUser, ChangePrsonalInfoDTO>(user);
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


        #region   ChangePassword

        //  /api/AccountSettings/ChangePassword
        [HttpPut("ChangePassword")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ChangePassword(string Id, ChangePasswordRequestVM model)
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
                var user = await _context.Users.Where(c => c.Id == Id && c.UserName == currentUsername && c.SerialNumber == currentSerialNumber).FirstOrDefaultAsync();

                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if (!result.Succeeded)
                    {
                        var errors = new List<string>();
                        foreach (var item in result.Errors)
                        {
                            errors.Add(item.Description);
                        }
                        return new JsonResult(new { Status = 0, Message = "bad request", Data = errors, StatusCode = 400 });
                    }

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
                    return new JsonResult(new { Status = 1, Message = "", Data = currentUser });
                }
                return new JsonResult(new { Status = 0, Message = "کاربری یافت نشد", });
            }
            catch
            {
                return new JsonResult(new { Status = 0, Message = "خطایی رخ داده است", });
            }

        }

        #endregion


        #region   ChangeAccountBank

        //  /api/AccountSettings/ChangeAccountBank
        [HttpPut("ChangeAccountBank")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ChangeAccountBank(string Id, ChangeAccountBankVM model)
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
                var user = await _context.Users
                    .Where(c => c.UserName == currentUsername && c.SerialNumber == currentSerialNumber)
                    .Include(c => c.BankInfo)
                    .FirstOrDefaultAsync();

                //var user = await _userManager.FindByNameAsync(currentUsername);
                if (user != null)
                {

                    if (user.BankInfo != null)
                    {
                        user.BankInfo.AccountOwner = model.BankName;
                        user.BankInfo.CardNumber = model.CardNumber;
                        user.BankInfo.BankName = model.BankName;
                        user.BankInfo.ShabaNumber = model.ShabaNumber;
                        user.BankInfo.VisaNumber = model.VisaNumber;
                    
                    }

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
                    var Profile = _mapper.Map<ApplicationUser, ChangeBankDTO>(user);
                    Profile.CurrentUser = currentUser;


                    return new JsonResult(new { Status = 1, Message = "", Data = Profile });
                }
                return new JsonResult(new { Status = 0, Message = "کاربری یافت نشد", });
            }
            catch
            {
                return new JsonResult(new { Status = 0, Message = "خطایی رخ داده است", });
            }
        }


        #endregion





    }
}