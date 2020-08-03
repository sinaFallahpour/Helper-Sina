using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Helper.Models.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Helper.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlidesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SlidesController(ApplicationDbContext context)
        {
            _context = context;
        }



        /// <summary>
        /// /api/slides/list?model=1
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
        [HttpGet("List")]
        public IActionResult List(SlideType model)
        {
            var queryable = _context.TBL_Sliders.AsQueryable();
            if (model == SlideType.IsActive)
            {
                queryable = queryable.Where(c => c.IsActive);
            }
            else if (model == SlideType.NotActive)
            {
                queryable = queryable.Where(c => !c.IsActive);
            }
            var slides = queryable.ToList();
            return new JsonResult(new { Status = 1, Message = "", Data = slides });
        }
    }
}