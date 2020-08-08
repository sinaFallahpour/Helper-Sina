using Helper.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Models.Service
{
    public class UserServioce
    {


        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public UserServioce(ApplicationDbContext context,
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
        /// ایجاد کاربر در دیتا بیس
        /// </summary>
        /// <returns></returns>
        public bool IsUserEmplt()
        {
            return _userManager.Users.Any();
        }




        /// <summary>
        ///          ایجاد کاربر در دیتا بیس
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsUserEmplt(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            return result.Succeeded;
        }





        /// <summary>
        ///        پیدا کردن کاربر با ایمیل
        /// </summary>
        /// <returns></returns>
        public async Task<ApplicationUser> FindByEmail(string Email)
        {
            var user = await _userManager.FindByEmailAsync(Email);
            return user;
        }




        /// <summary>
        ///        کاربر با این پسورد مچ است یا نه
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CheckPasswordSignInAsync(ApplicationUser user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            return result.Succeeded;
        }






        /// <summary>
        ///        تغییر پسورد
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ChangePassword(ApplicationUser user, string oldPassword, string newPassword)
        {

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            if (result.Succeeded)
            {
                await _signInManager.RefreshSignInAsync(user);
                return true;
            }
            return false;

        }

    }
}
