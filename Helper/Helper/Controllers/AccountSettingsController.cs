using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Extention;
using Helper.Models;
using Helper.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Helper.Controllers
{
    public class AccountSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private IStringLocalizer<AccountSettingsController> _localizer;
        private readonly IMapper _mapper;



        public AccountSettingsController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
                  IMapper mapper,
            IStringLocalizer<AccountSettingsController> localizer)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _localizer = localizer;
        }





        [Authorize]
        public async Task<IActionResult> Index()
        {
            returnViewDate();
            var UserId = User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users
                .Where(c => c.Id == UserId)
                .Include(c => c.BankInfo)
                .FirstOrDefaultAsync();

            var accountInfo = _mapper.Map<ApplicationUser, AccountSettingsVM>(user);
            return View(accountInfo);

        }





        #region changePersonalInfo

        [HttpPost]
        public async Task<ActionResult> ChangePeronalInfo(string Id, ChangePersonInfoVM model)
        {
            if (Id != model.Id)
            {
                return new JsonResult(new { Status = false, Message = _localizer["FailMessage"].Value.ToString() });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var userFromDb = await _context.Users.Where(c => c.Id == model.Id)
                           .FirstOrDefaultAsync();

                    if (userFromDb != null)
                    {
                        //if (await _context.Users.Where(x => x.UserName == model.UserName && x.UserName != userFromDb.UserName).AnyAsync())
                        //{
                        //    return new JsonResult(new { Status = false, Message = _localizer["UserNameExistMessage"].Value.ToString() });
                        //}

                        if (await _context.Users.Where(x => x.Email == model.Email && x.Email != userFromDb.Email).AnyAsync())
                        {
                            return new JsonResult(new { Status = false, Message = _localizer["EmailExistMessage"].Value.ToString() });
                        }

                        //userFromDb.UserName = model.UserName;
                        userFromDb.Email = model.Email;
                        userFromDb.Phone = model.Phone;
                        userFromDb.SiteLanguage = model.SiteLanguage;

                        var result = _context.SaveChanges();

                        await HttpContext.RefreshLoginAsync();
                        return new JsonResult(new { Status = true, Message =_localizer["SuccessMessage"].Value.ToString() });

                    }
                    return new JsonResult(new { Status = false, Message = _localizer["UserNotFoundMessage"].Value.ToString() });

                }
                catch (DbUpdateConcurrencyException)
                {
                    return new JsonResult(new { Status = false, Message = _localizer["FailMessage"].Value.ToString() });
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


        #region   ChangePassword
        [HttpPost]
        public async Task<ActionResult> ChangePassword(string Id, ChangePasswordVM model)
        {

            if (Id != model.Id)
            {
                return new JsonResult(new { Status = false, Message = _localizer["FailMessage"].Value.ToString() });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var userFromDb = await _context.Users.Where(c => c.Id == model.Id)
                           .FirstOrDefaultAsync();

                    if (userFromDb != null)
                    {
                        var result = await _userManager.ChangePasswordAsync(userFromDb, model.OldPassword, model.NewPassword);
                        if (!result.Succeeded)
                        {
                            if (result.Errors.First().Description == "Incorrect password.")
                            {
                                return new JsonResult(new { Status = false, Message = _localizer["CurrentPasswordIsWrongMessage"].Value.ToString() });
                            }
                        }
                        _context.SaveChanges();
                        await HttpContext.RefreshLoginAsync();
                        return new JsonResult(new { Status = true, Message = _localizer["SuccessMessage"].Value.ToString() });

                     
                    }
                    return new JsonResult(new { Status = false, Message = _localizer["UserNotFoundMessage"].Value.ToString() });
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new JsonResult(new { Status = false, Message = _localizer["FailMessage"].Value.ToString() });
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


        #region   ChangeAccountBank


        [HttpPost]
        public async Task<ActionResult> ChangeAccountBank(string Id, ChangeBanckInfoVM model)
        {

            if (Id != model.Id)
            {
                return new JsonResult(new { Status = false, Message = _localizer["FailMessage"].Value.ToString() });
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var userFromDb = await _context.Users.Where(c => c.Id == model.Id)
                        .Include(c => c.BankInfo)
                           .FirstOrDefaultAsync();

                    if (userFromDb != null)
                    {
                        if (userFromDb.BankInfo != null)
                        {
                            userFromDb.BankInfo.AccountOwner = model.BankName;
                            userFromDb.BankInfo.CardNumber = model.CardNumber;
                            userFromDb.BankInfo.BankName = model.BankName;
                            userFromDb.BankInfo.ShabaNumber = model.ShabaNumber;
                            userFromDb.BankInfo.VisaNumber = model.VisaNumber;
                        }
                        _context.SaveChanges();
                        return new JsonResult(new { Status = true, Message = _localizer["SuccessMessage"].Value.ToString() });
                    }
                    return new JsonResult(new { Status = false, Message = _localizer["UserNotFoundMessage"].Value.ToString() });
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new JsonResult(new { Status = false, Message = _localizer["FailMessage"].Value.ToString() });
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






        private void returnViewDate()
        {

            ViewData["PersonalInformation"] = _localizer["PersonalInformation"];
            ViewData["BankAccount"] = _localizer["BankAccount"];
            ViewData["Password"] = _localizer["Password"];
            ViewData["CreateServiceText"] = _localizer["CreateServiceText"];
            ViewData["CreateServiceDescriptions"] = _localizer["CreateServiceDescriptions"];
            ViewData["SaveSettings"] = _localizer["SaveSettings"];






            ViewData["UserName"] = _localizer["UserName"];
            ViewData["Email"] = _localizer["Email"];
            ViewData["MobileNumber"] = _localizer["MobileNumber"];
            ViewData["SiteLanguages"] = _localizer["SiteLanguages"];
            ViewData["EmailPL"] = _localizer["EmailPL"];
            ViewData["BankName"] = _localizer["BankName"];
            ViewData["AccountOwner"] = _localizer["AccountOwner"];
            ViewData["CardNumber"] = _localizer["CardNumber"];
            ViewData["ShabaNumber"] = _localizer["ShabaNumber"];
            ViewData["VisaOrMasterCardNumber"] = _localizer["VisaOrMasterCardNumber"];

            ViewData["OldPass"] = _localizer["OldPass"];
            ViewData["NewPass"] = _localizer["NewPass"];
            ViewData["NewPassRepeat"] = _localizer["NewPassRepeat"];




            ViewData["PersianLanguage"] = _localizer["PersianLanguage"];
            ViewData["EnglishLanguage"] = _localizer["EnglishLanguage"];


        }
    }
}