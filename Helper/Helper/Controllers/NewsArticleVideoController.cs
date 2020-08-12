using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Helper.Data;
using Helper.Models.Entities;
using Helper.Areas.Admin.Models.ViewModels.NewFolder;
using Helper.Areas.Admin.Models.ViewModels.News;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Helper.Models.Enums;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Authorization;

namespace Helper.Controllers
{

    [RequestSizeLimit(long.MaxValue)]
    [Authorize(Roles = Static.ADMINROLE)]

    public class NewsArticleVideoController : Controller
    {

        #region ctor
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public NewsArticleVideoController(ApplicationDbContext context,
              IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        #endregion

        #region List
        // GET: Admin/TBL_NewsArticleVideo
        public async Task<IActionResult> Index()
        {
            var newses = await _context.TBL_NewsArticleVideo.
                OrderBy(c => c.NewsType)
                .ThenBy(c => c.LikesCount)
                .Select(c => new NewsListViewModel
                {
                    Id = c.Id,
                    LikesCount = c.LikesCount,
                    CommentsCount = c.CommentsCount,
                    SeenCount = c.SeenCount,
                    Title = c.Title,
                    NewsType = c.NewsType,
                }).ToListAsync();

            return View(newses);
        }

        #endregion

        #region details

        // GET: Admin/TBL_NewsArticleVideo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsFromDb = await _context.TBL_NewsArticleVideo
                .Where(c => c.Id == id).Include(c => c.NewsComments).FirstOrDefaultAsync();
               
            if (newsFromDb == null)
            {
                return NotFound();
            }

            return View(newsFromDb);
        }
        #endregion

        #region create  vide and news

        // GET: Admin/TBL_NewsArticleVideo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TBL_NewsArticleVideo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateNewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                #region File validation
                string uniqueFileName = null;
                if (model.Video == null)
                {
                    ModelState.AddModelError("", "لطفا فیلم را آپلود کنید");
                    return View(model);
                }
                if (!model.Video.IsVideo())
                {
                    ModelState.AddModelError("", "به فرمت   مناسب فیلم وارد کنید");
                    return View(model);
                }
                if (model.Video.Length > 41000000)
                {
                    ModelState.AddModelError("", "حجم فایل باید کمتر از 41 مگابایت باشد ");
                    return View(model);
                }
                if (model.Video.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/News");
                    uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + model.Video.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.Video.CopyToAsync(stream);
                    }

                    model.VideoAddress = "/Upload/News/" + uniqueFileName;
                }
                #endregion File validation
                try
                {
                    var TBL_Article = new TBL_NewsArticleVideo()
                    {
                        Title = model.Title,
                        NewsType = model.NewsType,
                        Description = model.Description,
                        VideoAddress = model.VideoAddress,
                        CreateDate = DateTime.Now.ToString(),
                        CommentsCount = 0,
                        LikesCount = 0,
                        SeenCount = 0,
                    };

                    _context.Add(TBL_Article);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
            }
            return View(model);
        }


        #endregion 

        #region CreateArticle

        // GET: Admin/TBL_NewsArticleVideo/CreateArticle
        public IActionResult CreateArticle()
        {
            return View();
        }

        // POST: Admin/TBL_NewsArticleVideo/CreateArticle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArticle(CreateArticleViewModel model)
        {

            if (ModelState.IsValid)
            {
                #region File validation
                string uniqueFileName = null;
                if (model.ArticlePhoto == null)
                {
                    ModelState.AddModelError("", "لطفا عکس را آپلود کنید");
                    return View(model);
                }
                if (!model.ArticlePhoto.IsImage())
                {
                    ModelState.AddModelError("", "به فرمت عکس وارد کنید");
                    return View(model);
                }
                if (model.ArticlePhoto.Length > 22000000)
                {
                    ModelState.AddModelError("", "حجم فایل زیاد است");
                    return View(model);
                }
                if (model.ArticlePhoto.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/News");
                    uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + model.ArticlePhoto.FileName);
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ArticlePhoto.CopyToAsync(stream);
                    }
                    //model.ArticlePhoto.CopyTo(new FileStream(filePath, FileMode.Create));

                    model.ArticlePhotoAddress = "/Upload/News/" + uniqueFileName;
                }
                #endregion File validation
                try
                {
                    var TBL_Article = new TBL_NewsArticleVideo()
                    {
                        Title = model.Title,
                        NewsType = NewsType.Arrticle,
                        Description = model.Description,
                        ArticlePhotoAddress = model.ArticlePhotoAddress,
                        CreateDate = DateTime.Now.ToString(),
                        CommentsCount = 0,
                        LikesCount = 0,
                        SeenCount = 0,
                    };

                    _context.Add(TBL_Article);
                    var result = await _context.SaveChangesAsync();
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
                catch
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
            }
            return View(model);
        }


        #endregion


        #region  Edit Vide and news

        // GET: Admin/TBL_NewsArticleVideo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var news = await _context.TBL_NewsArticleVideo.FindAsync(id);
            
            if (news == null)
            {
                return NotFound();
            }
            var model = new EditNewsViewModel()
            {
                Id = news.Id,
                Title = news.Title,
                NewsType = NewsType.Arrticle,
                Description = news.Description,
                VideoAddress = news.VideoAddress,
                CreateDate = DateTime.Now.ToString(),
            };
            return View(model);
        }



        // POST: Admin/TBL_NewsArticleVideo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EditNewsViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var newsFromDb =await _context.TBL_NewsArticleVideo.FirstOrDefaultAsync(c => c.Id == model.Id);
                    newsFromDb.Description = model.Description;
                    newsFromDb.Title = model.Title;

                    #region file validation
                    if (model.Video != null)
                    {
                        string uniqueFileName = null;
                        if (!model.Video.IsVideo())
                        {
                            ModelState.AddModelError("", "به فرمت فیلم وارد کنید");
                            return View(model);
                        }
                        if (model.Video.Length > 41000000)
                        {
                            ModelState.AddModelError("", "حجم فایل زیاد است");
                            return View(model);
                        }
                        if ( model.Video.Length > 0 )
                        {
                            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/Slider");
                            uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + model.Video.FileName);
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                            model.Video.CopyTo(new FileStream(filePath, FileMode.Create));


                            //Delete LastImage Image
                            if (!string.IsNullOrEmpty(newsFromDb.VideoAddress))
                            {
                                var LastImagePath = newsFromDb.VideoAddress.Substring(1);
                                LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                                if (System.IO.File.Exists(LastImagePath))
                                {
                                    System.IO.File.Delete(LastImagePath);
                                }
                            }

                            //update Newe Pic Address To database
                            newsFromDb.VideoAddress = "/Upload/Slider/" + uniqueFileName;
                        }
                    }
                    #endregion file validation

                    var result = _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
            }
            return View(model);
          
        }

        #endregion  Edit Vide and news

        #region  Edit Vide and news

        // GET: Admin/TBL_NewsArticleVideo/Edit/5
        public async Task<IActionResult> EditArticle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.TBL_NewsArticleVideo.FindAsync(id);

            if (news == null)
            {
                return NotFound();
            }
            var model = new EditArticleViewModel()
            {
                Id = news.Id,
                Title = news.Title,
                NewsType = NewsType.Arrticle,
                Description = news.Description,
                ArticlePhotoAddress = news.ArticlePhotoAddress,
                CreateDate = DateTime.Now.ToString(),
            };
            return View(model);
        }



        // POST: Admin/TBL_NewsArticleVideo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditArticle(int id, EditArticleViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    var articleFromDb = await _context.TBL_NewsArticleVideo.FirstOrDefaultAsync(c => c.Id == model.Id);
                    articleFromDb.Description = model.Description;
                    articleFromDb.Title = model.Title;

                    #region file validation
                    if (model.ArticlePhoto != null)
                    {
                        string uniqueFileName = null;
                        if (!model.ArticlePhoto.IsImage())
                        {
                            ModelState.AddModelError("", "به فرمت فیلم وارد کنید");
                            return View(model);
                        }
                        if (model.ArticlePhoto.Length > 22000000)
                        {
                            ModelState.AddModelError("", "حجم فایل زیاد است");
                            return View(model);
                        }
                        if (model.ArticlePhoto.Length > 0)
                        {
                            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/Slider");
                            uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + model.ArticlePhoto.FileName);
                            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await model.ArticlePhoto.CopyToAsync(stream);
                            }

                            //model.ArticlePhoto.CopyTo(new FileStream(filePath, FileMode.Create));

                            //Delete LastImage Image
                            if (!string.IsNullOrEmpty(articleFromDb.ArticlePhotoAddress))
                            {
                                var LastImagePath = articleFromDb.ArticlePhotoAddress.Substring(1);
                                LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                                if (System.IO.File.Exists(LastImagePath))
                                {
                                    System.IO.File.Delete(LastImagePath);
                                }
                            }

                            //update Newe Pic Address To database
                            articleFromDb.ArticlePhotoAddress = "/Upload/Slider/" + uniqueFileName;
                        }
                    }
                    #endregion file validation

                    var result = _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
            }
            return View(model);

        }

        #endregion  Edit Vide and news

        #region delete   article news video

        // GET: Admin/TBL_NewsArticleVideo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.TBL_NewsArticleVideo
                .FirstOrDefaultAsync(m => m.Id == id);

            news.CreateDate = news.CreateDate.ToDateTime().ToPersianDateTime().ToString();

            //.AsNoTracking()
            //.Include(c => c.NewsComments)
            //.ThenInclude(e => e.Select(c => c.User));
            //.FirstOrDefaultAsync(m => m.Id == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }


        // POST: Admin/TBL_NewsArticleVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            var NewsFromDb = await _context.TBL_NewsArticleVideo.FindAsync(id);


            if (NewsFromDb != null)
            {
                if (NewsFromDb.NewsType == NewsType.Arrticle)
                {
                    //delete Image
                    var LastImagePath = NewsFromDb.ArticlePhotoAddress.Substring(1);
                    LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                    if (!string.IsNullOrEmpty(NewsFromDb.ArticlePhotoAddress) && System.IO.File.Exists(LastImagePath))
                    {
                        System.IO.File.Delete(LastImagePath);
                    }
                }
                else
                {
                    //delete videos
                    var LastImagePath = NewsFromDb.VideoAddress.Substring(1);
                    LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                    if (!string.IsNullOrEmpty(NewsFromDb.VideoAddress) && System.IO.File.Exists(LastImagePath))
                    {
                        System.IO.File.Delete(LastImagePath);
                    }
                }


                try
                {
                    _context.TBL_NewsArticleVideo.Remove(NewsFromDb);
                    var result = _context.SaveChanges();
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(NewsFromDb);
                }
                catch
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(NewsFromDb);
                }
            }
            return NotFound();

        }

        #endregion

        #region IsExist
        private bool TBL_NewsArticleVideoExists(int id)
        {
            return _context.TBL_NewsArticleVideo.Any(e => e.Id == id);
        }

        #endregion
    }
}
