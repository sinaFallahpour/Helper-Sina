﻿using Helper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Helper.Extention
{
    public static class RefreshCookieExtention
    {
        public static async Task RefreshLoginAsync(this HttpContext context)
        {
            if (context.User == null)
                return;

            // The example uses base class, IdentityUser, yours may be called 
            // ApplicationUser if you have added any extra fields to the model
            var userManager = context.RequestServices
                .GetRequiredService<UserManager<ApplicationUser>>();
            var signInManager = context.RequestServices
                .GetRequiredService<SignInManager<ApplicationUser>>();

            var user = await userManager.GetUserAsync(context.User);

            if (signInManager.IsSignedIn(context.User))
            {
                await signInManager.RefreshSignInAsync(user);
            }
        }
    }
}
