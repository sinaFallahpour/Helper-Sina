using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Helper.Models.Entities;
using AutoMapper;
using Helper.ViewModels.Api.Plan.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Helper.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;


        public PlansController(
            ApplicationDbContext context,
             IMapper mapper
                )
        {
            _context = context;
            _mapper = mapper;
        }



        // GET: api/Plans
        [HttpGet("List")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<TBL_Plans>>> GetAllPlans()
        {
            var plans = await _context.TBL_Plans.Include(c => c.PlansMonyUnit).ToListAsync();
            var Planses = _mapper.Map<List<TBL_Plans>, List<PlanDTO>>(plans);

            return new JsonResult(new { Status = 1, Message = "", Data = Planses });
        }



    }
}
