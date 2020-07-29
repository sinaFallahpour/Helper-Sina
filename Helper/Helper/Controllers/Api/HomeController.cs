using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }



        // GET: api/Home/aboutUs
        [HttpGet("aboutUs")]
        public async Task<JsonResult> AboutUs()
        {
            var AboutUs = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.AboutUsKeyName).FirstOrDefaultAsync();
            return new JsonResult(new { Status = 1, Message = "", data = AboutUs });
        }



        // GET: api/Home/ContactUs
        [HttpGet("ContactUs")]
        public async Task<JsonResult> ContactUs()
        {
            var ContactUs = await _context.TBL_Settings.Where(c => c.Key == PublicHelper.ContactKeyName).FirstOrDefaultAsync();
            return new JsonResult(new { Status = 1, Message = "", data = ContactUs });
        }


    }
}