using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Helper.Areas.Admin.Models.ViewModels.User;
using Helper.Data;
using Helper.Extention;
using Helper.Models;
using Helper.Models.Enums;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Static.ADMINROLE)]
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
#pragma warning disable CS0618 // 'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'
        private readonly IHostingEnvironment _hostingEnvironment;
#pragma warning restore CS0618 // 'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'
        public AdminsController(ApplicationDbContext context,
             UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
#pragma warning disable CS0618 // 'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'
                        IHostingEnvironment hostingEnvironment)
#pragma warning restore CS0618 // 'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _hostingEnvironment = hostingEnvironment;

        }


        #region  List
        /// <summary>
        /// GetA All Admins
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            var AdminRoleId = _context.Roles.Where(c => c.Name == Static.ADMINROLE).FirstOrDefault().Id;
            var UserRoles = _context.UserRoles.Where(c => c.RoleId == AdminRoleId).Select(c => c.UserId).ToList();

            var Admins = _context.Users.Where(o => UserRoles.Contains(o.Id))
                .Select(c => new AdminListViewModel
                {
                    Id = c.Id,
                    FullName = c.FirstName + " " + c.LastName,
                    Gender = c.Gender == UserGender.Man ? "مرد " : "زن",
                    Nickname = c.Nickname,
                    PhotoAddress = c.PhotoAddress,
                    Username = c.UserName

                }).ToList();

            return View(Admins);
        }


        #endregion


        #region  Users
        /// <summary>
        /// Get All  Users
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Users()
        {

            var users = (from u in _context.Users
                         join ur in _context.UserRoles
                         on u.Id equals ur.UserId
                         join r in _context.Roles
                         on ur.RoleId equals r.Id
                         select new UserListViewModel
                         {
                             Id = u.Id,
                             UserName = u.UserName,
                             Nickname = u.Nickname,
                             City = u.City,
                             Islocked = u.LockoutEnd != null && u.LockoutEnd > DateTime.Now,
                             PhotoAddress = u.PhotoAddress,
                             CreateDate = u.RegistrationDateTime,
                             RoleName = r.Name
                         })
                         .OrderByDescending(c => c.CreateDate)
                         .AsQueryable();

            //var AdminRoleId = _context.Roles.Where(c => c.Name == Static.ADMINROLE).FirstOrDefault().Id;
            //var UserRoles = _context.UserRoles.Where(c => c.RoleId == AdminRoleId).Select(c => c.UserId).ToList();
            return View(await users.ToListAsync());
        }


        #endregion




        #region ChangePasswordInAdmin

        [HttpPost]
        public async Task<IActionResult> ChangePasswordInAdmin(ChangePassInAdmin model)
        {

            if (ModelState.IsValid)
            {
                var userFromDB = await _userManager.FindByNameAsync(model.Username);
                if (userFromDB == null)
                    return new JsonResult(new { Status = false, Message = $"کاربری با نام کاربری {model.Username} یافت نشد", });
                var newPassword = _userManager.PasswordHasher.HashPassword(userFromDB, model.NewPassword);
                userFromDB.PasswordHash = newPassword;
                var result = await _userManager.UpdateAsync(userFromDB);

                if (result.Succeeded)
                    return new JsonResult(new { Status = true, Message = $"پسورد با موفقیت تغییر یافت", });
                else
                    return new JsonResult(new { Status = false, Message = $"خطایی در تغییر پسورد رخ داده", });
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






        #region    locked User


        [HttpPost]
        public async Task<ActionResult> LockedUser(LockedUserVM model)
        { if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Username))
                    return new JsonResult(new { Status = false, Message = $"کاربری با نام کاربری {model.Username} یافت نشد", });

                var userFromDB = await _context.Users.Where(c => c.UserName == model.Username).FirstOrDefaultAsync();
                if (userFromDB == null)
                    return new JsonResult(new { Status = false, Message = $"کاربری با نام کاربری {model.Username} یافت نشد", });

                var locked = true;
                var LockoutEnd = userFromDB.LockoutEnd;
                if (LockoutEnd != null && LockoutEnd > DateTime.Now)
                {
                    userFromDB.LockoutEnd = null;
                    userFromDB.LockoutEnd = DateTime.Now.AddYears(-1000);
                    locked = false;
                }
                if (LockoutEnd == null || LockoutEnd < DateTime.Now)
                {
                    userFromDB.LockoutEnd = DateTime.Now.AddYears(1000);
                    //userFromDB.LockoutEnd = DateTime.Now.AddYears(1000);
                    locked = true;
                }
                try
                {
                    await _context.SaveChangesAsync();
                    if (locked)
                        return new JsonResult(new { Status = true, Data = locked, Message = $"حساب کاربر با موفقیت قفل  گردید", });
                    else
                        return new JsonResult(new { Status = true, Data = locked, Message = $"حساب کاربر با موفقیت آزاد  شد", });
                }
                catch
                {
                    return new JsonResult(new { Status = false, Message = $"خطایی رخ داده", });
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






        #region   Profile
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
                Birthdate = o.Birthdate,
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
                    profileFromDb.Phone = model.Phone;


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

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await model.Photo.CopyToAsync(stream);
                            }

                            //model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));

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
                    if (result > 0)
                    {
                        //refresh Cookie
                        await HttpContext.RefreshLoginAsync();
                    }
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


        #endregion

        #region Create
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AdminCreateViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (await _context.Users.Where(x => x.UserName == model.Username).AnyAsync())
                {
                    ModelState.AddModelError("", "این نام کاربری موجود است");
                    return View(model);
                }

                if (await _context.Users.Where(x => x.Email == model.Email).AnyAsync())
                {
                    ModelState.AddModelError("", "این ایمیل  موجود است");
                    return View(model);
                }

                var user = new ApplicationUser
                {
                    AccessFailedCount = 0,

                    Birthdate = "",
                    Email = model.Email,

                    NormalizedEmail = "",
                    EmailConfirmed = true,

                    //عدم استفاده از پلن رایگان
                    IsUsedFree = false,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    //Gender = model.Gender.GetEnumDescription(),
                    Nickname = model.Nickname,
                    NormalizedUserName = model.Nickname.Normalize(),
                    RegistrationDateTime = DateTime.Now,
                    UserName = model.Username,
                    Phone = "",
                    //PhotoAddress = "/Upload/User/user.jpg",
                    PhotoAddress = "/Upload/User/default2.png",
                    PhoneNumber = "",
                    CreatedAdminId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Static.ADMINROLE);
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

        #endregion

        #region Login
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            returnUrl = string.IsNullOrEmpty(returnUrl) ? "/admin/admins/Profile" : returnUrl;

            if (_signInManager.IsSignedIn(User) && User.IsInRole(Static.ADMINROLE))
            {
                return Redirect(returnUrl);
            }

            ViewBag.returnUrl = returnUrl;
            //return LocalRedirect(returnUrl);
            return View();
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AdminLoginViewModel model)
        {

            model.returnUrl = model.returnUrl ?? "/admin/admins/Profile";
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
                    return LocalRedirect(model.returnUrl);
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

        #endregion

        #region logOut
        //LogOut
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();
            returnUrl = returnUrl ?? Url.Content("/admin/admins/Profile");

            return RedirectToAction("Login", new { returnUrl = returnUrl });
            //return LocalRedirect(returnUrl);
        }


        //فک کنم این  برا اکس هست
        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await _signInManager.SignOutAsync();
        //    return Json((Status: 1, Message: "Logged Out"));
        //}


        #endregion



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