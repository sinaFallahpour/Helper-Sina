using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Helper.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult UserProfile()
        {
            return View();
        }


        public IActionResult PersonalInformation()
        {
            return View();
        }


    }
}
