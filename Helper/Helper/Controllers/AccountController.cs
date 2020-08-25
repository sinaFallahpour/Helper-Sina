using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Areas.Admin.Models.ViewModels.User;
using Helper.Data;
using Helper.Models;
using Helper.Models.Entities;
using Helper.Models.Service;
using Helper.Models.Utilities;
using Helper.ViewModels;
using Helper.ViewModels.Api.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Helper.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private IStringLocalizer<AccountController> _localizer;
        public AccountController(ApplicationDbContext context,
             UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
             IStringLocalizer<AccountController> localizer)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _localizer = localizer;
        }




        public IActionResult Index(string returnUrl)
        {
            returnViewDate();
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/profiles" : returnUrl;

            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole(Static.ADMINROLE))
                    return Redirect("/admin/admins/Profile");
                return Redirect(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View("index");
        }




        #region Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            returnViewDate();
           // returnUrl = string.IsNullOrEmpty(returnUrl) ? "/profiles" : returnUrl;

            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole(Static.ADMINROLE))
                    return Redirect("/admin/admins/Profile");
                return Redirect(returnUrl);
            }
            ViewBag.ActiveTab = "Login";
            ViewBag.ReturnUrl = returnUrl;
            //return LocalRedirect(returnUrl);
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVm model)
        {
            var UserReturnUrl = model.ReturnUrl ?? "/profiles";
            var AdminReturnUrl = model.ReturnUrl ?? "/admin/admins/Profile";

            model.ReturnUrl = UserReturnUrl;






            ViewBag.ActiveTab = "Login";
            returnViewDate();
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user == null)
                {
                    ViewBag.Error = "نام کاربری یا رمز عبور غلط میباشد";
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var existingRole = await _userManager.GetRolesAsync(user);  
                    var role = existingRole.SingleOrDefault();

                    if (role == Static.ADMINROLE)
                    {
                        return LocalRedirect(AdminReturnUrl);
                    }
                    //if (User.IsInRole(Static.ADMINROLE))
                    //{
                    //    return LocalRedirect(AdminReturnUrl);
                    //}
                    return LocalRedirect(model.ReturnUrl);
                }
                else
                {

                    ViewBag.Error = "نام کاربری یا رمز عبور اشتباه است ";
                    return View(model);
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
            ModelState.AddModelError("", errors.First());
            return View(model);
        }

        #endregion





        #region  Register


        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Register(RegisterVm model)
        {
            returnViewDate();
            model.ReturnUrl = model.ReturnUrl ?? "/profiles";
            ViewBag.ActiveTab = "Register";
            if (ModelState.IsValid)
            {
                if (await _context.Users.Where(x => x.UserName == model._Username).AnyAsync())
                {
                    ViewBag.RegisterError = "نام کاربری موجود است.";
                    return View("Login");
                }

                if (await _context.Users.Where(x => x.Email == model._Email).AnyAsync())
                {
                    ViewBag.RegisterError = " ایمیل موجود است.";
                    return View("Login");
                }
                var user = new ApplicationUser
                {
                    Email = model._Email,
                    NormalizedEmail = model._Email.Normalize(),
                    UserName = model._Username,
                    NormalizedUserName = model._Username.Normalize(),
                    AcceptRules = model.AcceptRules,
                    
                    //عدم استفاده از پلن رایگان
                    IsUsedFree=false,
                    //SerialNumber = SerialNumber,
                    WorkExperience = new TBL_WorkExperience(),
                    EducationHistry = new TBL_EducationalHistory(),
                    BankInfo = new TBL_BankInfo(),
                };
                var result = await _userManager.CreateAsync(user, model._Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Static.USERROLE);

                    var loginResult = await _signInManager.PasswordSignInAsync(model._Username, model._Password, true, lockoutOnFailure: false);
                    if (loginResult.Succeeded)
                        return LocalRedirect(model.ReturnUrl);
                    return LocalRedirect(model.ReturnUrl);
                }
                else
                {
                    if (result.Errors.Where(i => i.Code == "DuplicateUserName").Any())
                    {
                        ViewBag.RegisterError = string.Format("نام کاربری {0} از قبل ثبت شده است", model._Username);
                        return View("Login");
                    }
                    if (result.Errors.Where(i => i.Code == "DuplicateEmail").Any())
                    {
                        ViewBag.RegisterError = string.Format(" ایمیل {0} از قبل ثبت شده است", model._Email);
                        return View("Login");
                    }
                    ViewBag.RegisterError = "خطا در ثبت";
                    return View("Login");
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
            ModelState.AddModelError("", errors.First());
            return View("Login");
        }





        #endregion



        #region logOut

        //LogOut
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            //returnUrl = returnUrl ?? Url.Content("/admin/admins/Profile");
            return LocalRedirect("/");
        }


        //فک کنم این  برا اکس هست
        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return Json((Status: 1, Message: "Logged Out"));
        //}


        #endregion





        private void returnViewDate()
        {
            ViewData["Login"] = _localizer["Login"];
            ViewData["Register"] = _localizer["Register"];
            ViewData["RememberMe"] = _localizer["RememberMe"];
            ViewData["ForgotPassword"] = _localizer["ForgotPassword"];
            ViewData["UseGoogleText"] = _localizer["UseGoogleText"];
            ViewData["LogInWithGoogle"] = _localizer["LogInWithGoogle"];
            ViewData["AcceptRole"] = _localizer["AcceptRole"];
            ViewData["UserName"] = _localizer["UserName"];
            ViewData["Password"] = _localizer["Password"];
            ViewData["ImLogin"] = _localizer["ImLogin"];

        }


    }
}
