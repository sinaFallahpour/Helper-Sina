using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Data;
using Helper.Models;
using Helper.ViewModels.Api;
using Helper.ViewModels.Api.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers.Api
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        //private readonly IJwtGenerator _jwtGenerator;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext context
            //,IJwtGenerator jwtGenerator
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            //_jwtGenerator = jwtGenerator;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<JsonResult> Login(LoginRequestVM model)
        {

            var user = await _userManager.FindByEmailAsync(model.UserName);

            if (user == null) {
                return new JsonResult(new  { Status = 0, Message = "عدم دسترسی" });
            }

            var result = await _signInManager
                .CheckPasswordSignInAsync(user, model.Password,false);

            if (result.Succeeded)
            {
                // TODO: generate token
                var userInfo  = new UserVM
                {
                    Nickname = user.Nickname,
                    //Token = _jwtGenerator.CreateToken(user),
                    UserName = user.UserName,
                    PhotoAddress = user.PhotoAddress
                };
                return new JsonResult(new { Status = 0, Message = "عدم دسترسی",Data=userInfo });
            }

            return new JsonResult(new { Status = 0, Message = "عدم دسترسی" });
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