using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models;
using Helper.Models.DTO.News;
using Helper.Models.Entities;
using Helper.Models.Enums;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public NewsesController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
             IHttpContextAccessor httpContextAccessor,
             IMapper mapper)

        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _userManager = userManager;
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
            var newses = queryable.Include(c => c.NewsLike).OrderByDescending(c => c.LikesCount)
                .ThenBy(c => c.CommentsCount)
                .ThenByDescending(c => c.CreateDate)
                .ToList();
            var newsesDTO = _mapper.Map<List<TBL_NewsArticleVideo>, List<ListNewsDTO>>(newses);

            return new JsonResult(new { Status = 1, Message = "", Data = newsesDTO });
        }







        /// <summary>
        //  /api/Newses/LikeNews?newsId = 1
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("LikeNews")]
        public async Task<IActionResult> LikeNews(int? newsId)
        {

            var currentUsername = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;


            var userId = _context.Users.Where(c => c.UserName == currentUsername).FirstOrDefault()?.Id;
            if (string.IsNullOrEmpty(userId))
            {
                return new JsonResult(new { Status = 0, Message = "ابتدا وارد حساب خود شوید" });
            }


            //if (User.Identity.IsAuthenticated) {
            //    return new JsonResult(new { Status = 0, Message = "ابتدا وارد حساب خود شوید" });
            //}
            var newsFromDb = await _context.TBL_NewsArticleVideo.FindAsync(newsId);
            if (newsFromDb == null)
            {
                return new JsonResult(new { Status = 0, Message = "این خبر یا مقاله موجود نیست" });
            }

            var oldLike = await _context.TBL_NewsLike.Where(c => c.UserId == userId && c.NewsId == newsFromDb.Id).FirstOrDefaultAsync();
            if (oldLike != null)
            {
                _context.TBL_NewsLike.Remove(oldLike);
                newsFromDb.LikesCount--;
                //return new JsonResult(new { Status = 1, Message = "ثبت موفقیت آمیز" });
            }
            else
            {
               
                var newsLike = new TBL_NewsLike()
                {
                    UserId = userId,
                    NewsId = newsFromDb.Id,
                    CrateDate = DateTime.Now,
                };
                _context.TBL_NewsLike.Add(newsLike);
                newsFromDb.LikesCount++;
            }

            try
            {
                await _context.SaveChangesAsync();
                return new JsonResult(new { Status = 1, Message = "ثبت موفقیت آمیز" });
            }
            catch
            {
                return new JsonResult(new { Status = 0, Message = "خطا  در ثبت" });
            }


            //var queryable = _context.TBL_NewsArticleVideo.AsQueryable();
            //if (newsType == NewsType.Arrticle)
            //{
            //    queryable = queryable.Where(c => c.NewsType == NewsType.Arrticle);
            //}

            //_context.TBL_NewsLike.

            //else if (newsType == NewsType.News)
            //{
            //    queryable = queryable.Where(c => c.NewsType == NewsType.News);
            //}
            //else
            //{
            //    queryable = queryable.Where(c => c.NewsType == NewsType.Videos);
            //    //.Include(c => c.NewsLike)
            //    //.ThenInclude(c => c.Select(e => e.User));
            //}
            //var newses = queryable.Include(c => c.NewsLike).OrderByDescending(c => c.LikesCount)
            //    .ThenBy(c => c.CommentsCount)
            //    .ThenByDescending(c => c.CreateDate)
            //    .ToList();
            //var newsesDTO = _mapper.Map<List<TBL_NewsArticleVideo>, List<ListNewsDTO>>(newses);

            //return new JsonResult(new { Status = 1, Message = "", Data = 's' });
        }






    }
}