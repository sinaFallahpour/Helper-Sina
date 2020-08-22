using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Helper.Controllers
{
    public class News : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
