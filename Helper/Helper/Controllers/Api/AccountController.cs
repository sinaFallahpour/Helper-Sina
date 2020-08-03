using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Helper.Data;
using Helper.Models;
using Helper.Models.Service;
using Helper.Models.Utilities;
using Helper.ViewModels.Api;
using Helper.ViewModels.Api.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly JwtGenerator _jwtGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context,
            JwtGenerator jwtGenerator,
               IHttpContextAccessor httpContextAccessor
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
            _httpContextAccessor = httpContextAccessor;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<JsonResult> Login(LoginRequestVM model)
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


            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null)
            {
                return new JsonResult(new { Status = 0, Message = " نام کاربری یا رمز عبور اشتباست " });
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, model.Password, false);
            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var role = userRoles.First();
                // TODO: generate token
                var userInfo = new UserVM
                {
                    Nickname = user.Nickname,
                    Token = _jwtGenerator.CreateToken(user, role),
                    UserName = user.UserName,
                    PhotoAddress = user.PhotoAddress,
                    Email = user.Email

                };
                return new JsonResult(new { Status = 1, Message = "ورود موفقیت آمیز", Data = userInfo });
            }

            return new JsonResult(new { Status = 0, Message = " نام کاربری یا رمز عبور اشتباست " });
        }





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

            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName,
                AcceptRules = model.AcceptRules
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, Static.USERROLE);

                var userInfo = new UserVM
                {
                    Nickname = user.Nickname,
                    Token = _jwtGenerator.CreateToken(user, PublicHelper.USERROLE),
                    UserName = user.UserName,
                    PhotoAddress = user.PhotoAddress,
                    Email = user.Email
                };
                return new JsonResult(new { Status = 1, Message = " ثبت نام موفقیت آمیز", Data = userInfo });
            }
            return new JsonResult(new { Status = 0, Message = " خطا در ثبت" });

        }






        [HttpGet("currentUser")]
        public async Task<ActionResult> CurrentUser()
        {
            var currentUsername = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            //return username;

            try
            {
                var user = await _userManager.FindByNameAsync(currentUsername);
                if (user == null)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var role = userRoles.First();

                    var currentUser = new UserVM
                    {
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
                return new JsonResult(new { Status = 0, Message = "کاربری یافت نشد", });
            }



        }






        //[AllowAnonymous]
        //[HttpPost("register")]
        //public async Task<ActionResult<User>> Register(RegisterRequestVM model)
        //{
        //    return await Mediator.Send(command);
        //}

        //[HttpGet]
        //public async Task<ActionResult<User>> CurrentUser()
        //{
        //    return await Mediator.Send(new CurrentUser.Query());
        //}

    }
}