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

namespace Helper.Controllers
{
    public class AccountSettingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AccountSettingsController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
                  IMapper mapper
            )
        {
            _context = context;
            _userManager = userManager;

            _mapper = mapper;
        }





        [Authorize]
        public async Task<IActionResult> Index()
        {
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
            TempData["ActiveTab"] = "Info";
            if (Id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var userFromDb = await _context.Users.Where(c => c.Id == model.Id)
                           .FirstOrDefaultAsync();

                    if (userFromDb != null)
                    {
                        if (await _context.Users.Where(x => x.UserName == model.UserName && x.UserName != userFromDb.UserName).AnyAsync())
                        {
                            TempData["InfoError"] = "نام کاربری موجود است.";
                            return RedirectToAction("Index");
                        }

                        if (await _context.Users.Where(x => x.Email == model.Email && x.Email != userFromDb.Email).AnyAsync())
                        {
                            TempData["InfoError"] = " ایمیل موجود است.";
                            return RedirectToAction("Index");
                        }

                        userFromDb.UserName = model.UserName;
                        userFromDb.Email = model.Email;
                        userFromDb.Phone = model.Phone;
                        userFromDb.SiteLanguage = model.SiteLanguage;

                        var result = _context.SaveChanges();

                        await HttpContext.RefreshLoginAsync();
                        TempData["InfoSuccess"] = "ثبت موفقیت آمیز";
                        return RedirectToAction("Index");
                    }
                    TempData["InfoError"] = "کاربر یافت نشد";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["InfoError"] = "خطا در ثبت";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }

        #endregion


        #region   ChangePassword



        [HttpPost]
        public async Task<ActionResult> ChangePassword(string Id, ChangePasswordVM model)
        {
            TempData["ActiveTab"] = "pass";

            if (Id != model.Id)
            {
                return NotFound();
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

                                TempData["PassError"] = "پسورد اشتباه است";
                                return RedirectToAction("Index");
                            }
                        }

                        _context.SaveChanges();

                        await HttpContext.RefreshLoginAsync();
                        TempData["PassSuccess"] = "ثبت موفقیت آمیز";
                        return RedirectToAction("Index");
                    }
                    TempData["PassError"] = "کاربر یافت نشد";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["PassError"] = "خطا در ثبت";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion


        #region   ChangeAccountBank


        [HttpPost]
        public async Task<ActionResult> ChangeAccountBank(string Id, ChangeBanckInfoVM model)
        {
            TempData["ActiveTab"] = "account";

            if (Id != model.Id)
            {
                return NotFound();
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
                        TempData["BankSuccess"] = "ثبت موفقیت آمیز";
                        return RedirectToAction("Index");
                    }
                    TempData["BankError"] = "کاربر یافت نشد";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    TempData["BankError"] = "خطا در ثبت";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
        #endregion

    }
}