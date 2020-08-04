using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models.DTO.News;
using Helper.Models.Entities;
using Helper.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public NewsesController(ApplicationDbContext context,
             IHttpContextAccessor httpContextAccessor,
             IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }





        /// <summary>
       //  /api/Newses/list? newsType = 1
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Admin")]
        [HttpGet("List")]
        public IActionResult List(NewsType newsType)
        {

            //var currentUsername = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            var queryable = _context.TBL_NewsArticleVideo.AsQueryable();
            if (newsType == NewsType.Arrticle)
            {
                queryable = queryable.Where(c => c.NewsType == NewsType.Arrticle);
            }
            else if (newsType == NewsType.News)
            {
                queryable = queryable.Where(c => c.NewsType == NewsType.News);
            }
            else
            {
                queryable = queryable.Where(c => c.NewsType == NewsType.Videos);
                    //.Include(c => c.NewsLike)
                    //.ThenInclude(c => c.Select(e => e.User));
            }
            var newses = queryable.Include(c=>c.NewsLike).ToList();
            var newsesDTO = _mapper.Map<List<TBL_NewsArticleVideo>, List<ListNewsDTO>>(newses);

            return new JsonResult(new { Status = 1, Message = "", Data = newsesDTO });
        }
    }
}