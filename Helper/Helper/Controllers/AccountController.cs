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

namespace Helper.Controllers
{
    public class AccountController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(ApplicationDbContext context,
             UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }




        public IActionResult Index(string returnUrl)
        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/Profile" : returnUrl;

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
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/Profile" : returnUrl;

            if (_signInManager.IsSignedIn(User))
            {
                if (User.IsInRole(Static.ADMINROLE))
                    return Redirect("/admin/admins/Profile");
                return Redirect(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;
            //return LocalRedirect(returnUrl);
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVm model)
        {
            model.ReturnUrl = model.ReturnUrl ?? "/Profile";
            var AdminReturnUrl = model.ReturnUrl ?? "/admin/admins/Profile";
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
                    if (User.IsInRole(Static.ADMINROLE))
                    {
                        return LocalRedirect(AdminReturnUrl);
                    }
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
            return View(model);
        }

        #endregion



        #region  Register

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequestVM model)
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

            if (await _context.Users.Where(x => x.UserName == model.UserName).AnyAsync())
                return new JsonResult(new { Status = 0, Message = "این نام کاربری موجود است" });

            if (await _context.Users.Where(x => x.Email == model.Email).AnyAsync())
                return new JsonResult(new { Status = 0, Message = "این ایمیل  موجود است" });



            var SerialNumber = Guid.NewGuid().ToString().GetHash();


            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName,
                AcceptRules = model.AcceptRules,
                SerialNumber = SerialNumber,
                WorkExperience = new TBL_WorkExperience(),
                EducationHistry = new TBL_EducationalHistory(),
                BankInfo = new TBL_BankInfo(),
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Static.USERROLE);

                var userInfo = new UserVM
                {
                    Id = user.Id,
                    Nickname = user.Nickname,
                    //Token = JwtGenerator.CreateToken(user, PublicHelper.USERROLE),
                    UserName = user.UserName,
                    PhotoAddress = user.PhotoAddress,
                    Email = user.Email
                };
                return new JsonResult(new { Status = 1, Message = " ثبت نام موفقیت آمیز", Data = userInfo });
            }
            return new JsonResult(new { Status = 0, Message = " خطا در ثبت" });
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


    }
}
