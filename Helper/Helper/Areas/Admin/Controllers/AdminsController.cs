using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Helper.Areas.Admin.Models.ViewModels.User;
using Helper.Data;
using Helper.Models;
using Helper.Models.Enums;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        public AdminsController(ApplicationDbContext context,
             UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
                        IHostingEnvironment hostingEnvironment)

        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;



        }




        [Authorize(Roles = Static.ADMINROLE)]
        public async Task<IActionResult> Profile(string Username)
        {
            var currentUsername = "";
            if (!string.IsNullOrEmpty(Username))
            {
                currentUsername = Username;
            }
            else
            {
                currentUsername = User.Identity.Name;
            }
            //var currentAdnmin = await _userManager.FindByNameAsync(currentUsername);
            var UserProfile = await _context.Users.Where(c => c.UserName == currentUsername)
            .Select(o => new AdminProfileViewModel       
            {
                Id = o.Id,
                Username = o.UserName,
                Email = o.Email,
                Nickname = o.Nickname,
                FirstName = o.FirstName,
                LastName = o.LastName,
                Address = o.Address,
                Birthdate = o.Birthdate,
                NationalCode = o.NationalCode,
                Phone = o.Phone,
                PhotoAddress = o.PhotoAddress
            }).FirstOrDefaultAsync();
            if (UserProfile == null)
            {
                return NotFound();
            }

            return View(UserProfile);
        }






        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Profile(string id, AdminProfileViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var profileFromDb = await _userManager.FindByIdAsync(model.Id);
                    //_context.Users.SingleOrDefault(c => c.Id == model.Id);
                    profileFromDb.UserName = model.Username;
                    profileFromDb.Email = model.Email;
                    profileFromDb.Nickname = model.Nickname;
                    profileFromDb.FirstName = model.FirstName;
                    profileFromDb.LastName = model.LastName;
                    profileFromDb.Birthdate = model.Birthdate;
                    profileFromDb.NationalCode = model.NationalCode;
                    profileFromDb.Phone = model.Phone;
                    profileFromDb.Address = model.Address;

                    if (model.Photo != null)
                    {
                        string uniqueFileName = null;
                        if (!model.Photo.IsImage())
                        {
                            ModelState.AddModelError("", "به فرمت عکس وارد کنید");
                            return View(model);
                        }
                        if (model.Photo.Length > 5000000)
                        {
                            ModelState.AddModelError("", "حجم فایل زیاد است");
                            return View(model);
                        }
                        if (model.Photo != null && model.Photo.Length > 0 && model.Photo.IsImage())
                        {
                            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/User");
                            uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + model.Photo.FileName);
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

                            //Delete LastImage Image
                            if (!string.IsNullOrEmpty(profileFromDb.PhotoAddress))
                            {
                                var LastImagePath = profileFromDb.PhotoAddress.Substring(1);
                                LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                                if (System.IO.File.Exists(LastImagePath))
                                {
                                    System.IO.File.Delete(LastImagePath);
                                }
                            }

                            //update Newe Pic Address To database
                            profileFromDb.PhotoAddress = "/Upload/User/" + uniqueFileName;
                        }
                    }

                    var result = _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }

            }
            return View(model);
        }







        /// <summary>
        /// GetA All Admins
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = Static.ADMINROLE)]
        public IActionResult Index()
        {

            var AdminRoleId = _context.Roles.Where(c => c.Name == Static.ADMINROLE).FirstOrDefault().Id;
            var UserRoles = _context.UserRoles.Where(c => c.RoleId == AdminRoleId).Select(c => c.UserId).ToList();

            var Admins = _context.Users.Where(o => UserRoles.Contains(o.Id))
                .Select(c => new AdminListViewModel
                {
                    Id = c.Id,
                    FullName = c.FirstName + " " + c.LastName,
                    Gender = c.Gender,
                    Nickname = c.Nickname,
                    PhotoAddress = c.PhotoAddress,
                    Username = c.UserName

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
                    //Gender = model.Gender.GetEnumDescription(),
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




        //LogOut
        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            returnUrl = returnUrl ?? Url.Content("/admin/admins/login");
            return LocalRedirect(returnUrl);
        }


        //فک کنم این  برا اکس هست
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Json((Status: 1, Message: "Logged Out"));
        }




        private bool TBL_ProfileExists(string id)
        {
            return _context.Users.Any(e => e.Id == id);
        }





        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }




    }
}