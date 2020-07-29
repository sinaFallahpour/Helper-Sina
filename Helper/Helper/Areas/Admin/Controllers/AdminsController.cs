using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Helper.Areas.Admin.Models.ViewModels.User;
using Helper.Data;
using Helper.Models;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdminsController(ApplicationDbContext context,
             UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }




        /// <summary>
        /// GetA All Admins
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            var Admins = (from user in _context.Users
                          from userRole in user.UserRole
                          join role in _context.Roles.Where(c => c.Name == Static.ADMINROLE) on userRole.RoleId equals role.Id
                          select new AdminListViewModel()
                          {
                              FullName = user.FirstName + " " + user.LastName,
                              Gender = user.Gender,
                              Nickname = user.Nickname,
                              PhotoAddress = user.PhotoAddress
                          }).ToList();

            return View(Admins);
        }




        [Authorize(Roles = Static.ADMINROLE)]
        public IActionResult Create()
        {
            return View();


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Static.ADMINROLE)]
        public async Task<IActionResult> Create(AdminCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                var result = await _userManager.CreateAsync(new ApplicationUser
                {
                    AccessFailedCount = 0,
                    AvatarUrl = "",
                    Birthdate = "",
                    Email = "",
                    NormalizedEmail = "",
                    EmailConfirmed = false,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender.GetEnumDescription(),
                    Nickname = model.Nickname,
                    NormalizedUserName = model.Nickname.Normalize(),
                    RegistrationDateTime = DateTime.Now,
                    UserName = model.Username,
                    Phone = "",
                    PhoneNumber = "",
                    CreatedAdminId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                }, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(await _userManager.FindByNameAsync(model.Username), Static.ADMINROLE);
                    ViewBag.IsSuccess = "ثبت موفثیت آمیز";
                    return View(model);
                }
                else
                {
                    if (result.Errors.Where(i => i.Code == "DuplicateUserName").Any())
                    {
                        ViewBag.Error = string.Format("نام کاربری {0} از قبل ثبت شده است", model.Username);
                        return View(model);
                    }
                    ViewBag.Error = result.Errors.First().Code;
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





        public IActionResult Login(string returnUrl)

        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/admin/admins/Profile" : returnUrl;

            if (_signInManager.IsSignedIn(User) && User.IsInRole(Static.ADMINROLE))
            {
                return Redirect(returnUrl);
            }

            ViewBag.ReturnUrl = returnUrl;
            //return LocalRedirect(returnUrl);
            return View();
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {

            model.ReturnUrl = model.ReturnUrl ?? "/admin/admins/Profile";
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user == null)
                {
                    ViewBag.Error = "نام کاربری یا رمز عبور غلط میباشد";
                    return View(model);
                }
                var IsInAdminRole = await _userManager.IsInRoleAsync(user, Static.ADMINROLE);
                if (!IsInAdminRole)
                {
                    ViewBag.Error = "نام کاربری یا رمز عبور غلط میباشد";
                    return View(model);
                }


                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //if (await  _userManager.IsInRoleAsync(user,Static.ADMINROLE)) {
                    return LocalRedirect(model.ReturnUrl);
                    //}
                    //if (User.IsInRole(Static.ADMINROLE))
                    //{
                    //    return RedirectToAction("Profile");
                    //}

                    //این 2 خط مزخرفه
                    //ViewBag.Error = "نام کاربری یا رمز عبور غلط میباشد";
                    //return View(model);
                }
                else
                {
                    ViewBag.Error = "نام کاربری یا رمز عبور غلط میباشد";
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


    }
}