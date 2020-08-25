using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Models.Entities;
using Helper.Models.Enums;
using Helper.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Helper.Controllers
{
    public class NewsesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        private IStringLocalizer<NewsesController> _localizer;


        public NewsesController(
            ApplicationDbContext context,
              IHttpContextAccessor httpContextAccessor,
             IMapper mapper,
             IStringLocalizer<NewsesController> localizer)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            _localizer = localizer;
        }


        public async Task<IActionResult> Index()
        {
            ViewData["New"] = _localizer["New"];
            ViewData["EducationalVideos"] = _localizer["EducationalVideos"];
            ViewData["HelperNews"] = _localizer["HelperNews"];
            ViewData["Articles"] = _localizer["Articles"];






            var model = new NewsesVM();
            //var queryable = _context.TBL_NewsArticleVideo.asquer();

            var Articles = await _context.TBL_NewsArticleVideo
                .Where(c => c.NewsType == NewsType.Arrticle)
                .OrderByDescending(c => c.LikesCount)
                .ThenByDescending(c => c.CommentsCount)
                .Include(c => c.NewsLike)
                .ToListAsync();

            var Newses = await _context.TBL_NewsArticleVideo
                       .Where(c => c.NewsType == NewsType.News)
                       .OrderByDescending(c => c.LikesCount)
                       .ThenByDescending(c => c.CommentsCount)
                        .Include(c => c.NewsLike)
                       .ToListAsync();

            var Videos = await _context.TBL_NewsArticleVideo
                .Where(c => c.NewsType == NewsType.Videos)
                   .OrderByDescending(c => c.LikesCount)
                    .ThenByDescending(c => c.CommentsCount)
                    .Include(c => c.NewsLike)
                    .ToListAsync();


            var articles = _mapper.Map<List<TBL_NewsArticleVideo>, List<Newse>>(Articles);
            var newses = _mapper.Map<List<TBL_NewsArticleVideo>, List<Newse>>(Newses);
            var videos = _mapper.Map<List<TBL_NewsArticleVideo>, List<Newse>>(Videos);

            model.Articles = articles;
            model.Newses = newses;
            model.Videos = videos;

            return View(model);

        }






        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public IActionResult ToggleLike(int? newsID)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var user = _context.Users.Where(c => c.Id == currentUserId).FirstOrDefault();
            var userId = user.Id;
            if (string.IsNullOrEmpty(userId))
                return new JsonResult(new { Status = false, Message = "برای لایک  ابتدا لاگین کنید." });
            if (newsID == null)
                return new JsonResult(new { Status = false, Message = "   این خبر یا مقاله موجود نیست." });



            //if (User.Identity.IsAuthenticated) {
            //    return new JsonResult(new { Status = 0, Message = "ابتدا وارد حساب خود شوید" });
            //}
            var newsFromDb = _context.TBL_NewsArticleVideo.Find(newsID);
            if (newsFromDb == null)
                return new JsonResult(new { Status = false, Message = "این خبر یا مقاله موجود نیست" });

            var IsLiked = false;
            var oldLike = _context.TBL_NewsLike.Where(c => c.UserId == userId && c.NewsId == newsFromDb.Id).FirstOrDefault();
            if (oldLike != null)
            {
                _context.TBL_NewsLike.Remove(oldLike);
                IsLiked = false;
                newsFromDb.LikesCount--;
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
                IsLiked = true;
            }

            try
            {
                _context.SaveChanges();
                //return new { Status = true, LikeCount = Res.LikeCount, IsLiked = Res.IsLiked };
                return new JsonResult(new { Status = true, LikeCount = newsFromDb.LikesCount, IsLiked = IsLiked });
            }
            catch
            {
                return new JsonResult(new { Status = false, Message = "خطا  در ثبت" });
            }
        }



    }
}
