using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Helper.Data;
using Helper.Migrations;
using Helper.Models.Entities;
using Helper.Models.Enums;
using Helper.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Controllers
{
    public class Newses : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public Newses(
            ApplicationDbContext context,
              IHttpContextAccessor httpContextAccessor,
             IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }


        public async Task<IActionResult> Index()
        {
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



            //var newsesasasa = queryable.Include(c => c.NewsLike).OrderByDescending(c => c.LikesCount)
            //  .ThenBy(c => c.CommentsCount)
            //  .ThenByDescending(c => c.CreateDate)
            //  .ToList();

            var articles = _mapper.Map<List<TBL_NewsArticleVideo>, List<Newse>>(Articles);
            var newses = _mapper.Map<List<TBL_NewsArticleVideo>, List<Newse>>(Newses);
            var videos = _mapper.Map<List<TBL_NewsArticleVideo>, List<Newse>>(Videos);

            model.Articles = articles;
            model.Newses = newses;
            model.Videos = videos;

            return View(model);

        }







        //public IActionResult ToggleLike(int? ProductId, int? UserId)
        //{
        //    if (ProductId == null)
        //        return new { Status = false, Message = "محصول یافت نشد." };

        //    if (UserId == null)
        //        return new { Status = false, Message = "برای لایک محصول ابتدا لاگین کنید." };

        //    LikeManager LikeManager = new LikeManager();
        //    ToggleLikeViewModel Res = LikeManager.ToggleLike((int)UserId, (int)ProductId);
        //    if (Res == null)
        //        return new { Status = false, Message = "خطا رخ داده است." };

        //    return new { Status = true, LikeCount = Res.LikeCount, IsLiked = Res.IsLiked };

        //}







        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> ToggleLike(int? newsID)
        {
            var currentUserId = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var userId = _context.Users.Where(c => c.Id == currentUserId).FirstOrDefault()?.Id;
            if (string.IsNullOrEmpty(userId))
                return new JsonResult(new { Status = false, Message = "برای لایک  ابتدا لاگین کنید." });
            if (newsID == null)
                return new JsonResult(new { Status = false, Message = "   این خبر یا مقاله موجود نیست." });



            //if (User.Identity.IsAuthenticated) {
            //    return new JsonResult(new { Status = 0, Message = "ابتدا وارد حساب خود شوید" });
            //}
            var newsFromDb = await _context.TBL_NewsArticleVideo.FindAsync(newsID);
            if (newsFromDb == null)
            {
                return new JsonResult(new { Status = false, Message = "این خبر یا مقاله موجود نیست" });
            }
            var IsLiked = false;
            var oldLike = await _context.TBL_NewsLike.Where(c => c.UserId == userId && c.NewsId == newsFromDb.Id).FirstOrDefaultAsync();
            if (oldLike != null)
            {
                _context.TBL_NewsLike.Remove(oldLike);
                IsLiked = false;
                newsFromDb.LikesCount--;
            }
            else
            {
                IsLiked = true;
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
