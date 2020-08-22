using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Models;
using Helper.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DNTPersianUtils.Core;

namespace Helper.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index(string returnUrl)
        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;

            if (_signInManager.IsSignedIn(User))
            {
                return Redirect(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View("index");
        }

        public IActionResult Login(string returnUrl)
        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;

            if (_signInManager.IsSignedIn(User))
            {
                return Redirect(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View("index");
        }

        public IActionResult Register(string returnUrl = "")
        {
            if (_signInManager.IsSignedIn(User)) return Redirect(returnUrl);
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginViewModel input)
        {
            input.ReturnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32(PublicHelper.SessionCaptcha).HasValue == false
                    || HttpContext.Session.GetInt32(PublicHelper.SessionCaptcha).ToString() != input.Captcha)
                {
                    return Json(new { Status = 0, Message = "کپچا را به درستی وارد کنید" });
                }
                var result = await _signInManager.PasswordSignInAsync(input.Username, input.Password, input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (User.IsInRole("admin"))
                        return new JsonResult(new { Status = 1, ReturnUrl = "/admin" });
                    return new JsonResult(new { Status = 1, ReturnUrl = "/" });
                }
                else
                {
                    return new JsonResult(new { Status = 0, Message = "نام کاربری یا کلمه عبور اشتباه است" });
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
            return new JsonResult(new { Status = 0, Message = errors.First() });
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return Redirect("/");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel input)
        {
            input.ReturnUrl = input.ReturnUrl ?? Url.Content("/");

            if (ModelState.IsValid)
            {
                if (HttpContext.Session.GetInt32(PublicHelper.SessionCaptcha).HasValue == false
                    || HttpContext.Session.GetInt32(PublicHelper.SessionCaptcha).ToString() != input.Captcha)
                {
                    return Json(new { Status = 0, Message = "کپچا را به درستی وارد کنید" });
                }
                var result = await _userManager.CreateAsync(new ApplicationUser
                {
                    AccessFailedCount = 0,
                    AvatarUrl = "",
                    Birthdate = "",
                    Email = "",
                    EmailConfirmed = false,
                    FirstName = "",
                    LastName = "",
                    Gender = "",
                    Nickname = input.Nickname,
                    NormalizedUserName = input.Nickname.Normalize(),
                    RegistrationDateTime = DateTime.Now,
                    UserName = input.Email,
                    Phone = "",
                    PhoneNumber = ""
                }, input.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(input.Email), "user");
                    var signIn = await _signInManager.PasswordSignInAsync(input.Email, input.Password, isPersistent: false, lockoutOnFailure: false);
                    if (signIn.Succeeded)
                        return new JsonResult(new { Status = 1, input.ReturnUrl });

                    return new JsonResult(new { Status = 1, input.ReturnUrl });
                }
                else
                {
                    if (result.Errors.Where(i => i.Code == "DuplicateUserName").Any())
                        return new JsonResult(new { Status = 0, Message = string.Format("نام کاربری {0} از قبل ثبت شده است", input.Email) });
                    return new JsonResult(new { Status = 0, Message = result.Errors.First().Code });
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
            return new JsonResult(new { Status = 0, Message = errors.First() });
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            returnUrl = returnUrl ?? Url.Content("/account");
            return LocalRedirect(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Json((Status: 1, Message: "Logged Out"));
        }

        public async Task<IActionResult> CreateRole(string name)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = name, NormalizedName = name.Normalize() });

            return Content("role created: " + name);
        }

        public async Task<IActionResult> CreateUser(string name)
        {
            var f = await _userManager.FindByNameAsync(name);
            if (f == null)
            {
                await _userManager.CreateAsync(new ApplicationUser
                {
                    AvatarUrl = "",
                    Birthdate = "",
                    Email = name + "@gmail.com",
                    NormalizedEmail = name + "@gmail.com".Normalize(),
                    EmailConfirmed = true,
                    FirstName = name,
                    LastName = "",
                    Gender = "",
                    NationalCode = "",
                    Nickname = name,
                    UserName = name,
                    NormalizedUserName = name.Normalize(),
                    Phone = "",
                    PhoneNumber = "",
                    RegistrationDateTime = DateTime.Now,
                    VerificationCode = "",
                }, "123456789");
            }

            await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(name), "admin");
            return Content("user created: " + name);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}