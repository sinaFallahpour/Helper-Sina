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
using Microsoft.AspNetCore.Http;
using Helper.Areas.Admin.ViewModel;
using System.Runtime.CompilerServices;

namespace Helper.Controllers
{

    [Area("Admin")]
    [RequestSizeLimit(long.MaxValue)]
    [Authorize(Roles = Static.ADMINROLE)]

    public class NewsArticleVideoController : Controller
    {

        #region ctor
        private readonly ApplicationDbContext _context;
#pragma warning disable CS0618 // 'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'
        private readonly IHostingEnvironment _hostingEnvironment;
#pragma warning restore CS0618 // 'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'
        public NewsArticleVideoController(ApplicationDbContext context,
#pragma warning disable CS0618 // 'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'
              IHostingEnvironment hostingEnvironment)
#pragma warning restore CS0618 // 'IHostingEnvironment' is obsolete: 'This type is obsolete and will be removed in a future version. The recommended alternative is Microsoft.AspNetCore.Hosting.IWebHostEnvironment.'
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
                    EnglishTitle = c.EnglishTitle
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

                var res = await UploadVideo(model.Video, false);
                if (res.Status == false)
                {
                    ModelState.AddModelError("", res.Message);
                    return View(model);
                }
                model.VideoAddress = res.Message;

                var res2 = await UploadVideo(model.EngishVideo, false);
                if (res2.Status == false)
                {
                    ModelState.AddModelError("", res2.Message);
                    return View(model);
                }
                model.EnglishViewVideoAddress = res2.Message;



                #endregion File validation
                try
                {
                    var TBL_Article = new TBL_NewsArticleVideo()
                    {
                        Title = model.Title,
                        EnglishTitle = model.EnglishTitle,
                        NewsType = model.NewsType,
                        Description = model.Description,
                        EnglishDescription = model.EnglishDescription,
                        VideoAddress = model.VideoAddress,
                        EnglishVideoAddress = model.EnglishViewVideoAddress,
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
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
                catch (Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
                {
                    ModelState.AddModelError("", "خطا در ثبت");
                    return View(model);
                }
            }
            return View(model);
        }





        private async Task<ResponseVM> UploadVideo(IFormFile file, bool IsEditMode)
        {


            string uniqueFileName = null;
            if (IsEditMode == false && file == null)
            {
                return new ResponseVM
                {
                    Status = false,
                    Message = "لطفا فیلم را آپلود کنید",
                };
            }
            if (file == null)
            {
                return new ResponseVM
                {
                    Status = true,
                    Message = "no File",
                };
            }
            if (!file.IsVideo())
            {
                return new ResponseVM
                {
                    Status = false,
                    Message = "به فرمت   مناسب فیلم وارد کنید",
                };
            }
            if (file.Length > 41000000)
            {
                return new ResponseVM
                {
                    Status = false,
                    Message = "حجم فایل باید کمتر از 41 مگابایت باشد ",
                };
            }
            if (file.Length == 0)
            {
                return new ResponseVM
                {
                    Status = false,
                    Message = "حجم فایل 0 است ",
                };
            }

            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/News");
            uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return new ResponseVM
            {
                Status = true,
                Message = "/Upload/News/" + uniqueFileName
            };
        }



        private async Task<ResponseVM> UploadImage(IFormFile file, bool IsEditMode)
        {


            string uniqueFileName = null;
            if (IsEditMode == false && file == null)
            {
                return new ResponseVM
                {
                    Status = false,
                    Message = "لطفا عکس را آپلود کنید",
                };
            }
            if (file == null)
            {
                return new ResponseVM
                {
                    Status = true,
                    Message = "no File",
                };
            }
            if (!file.IsImage())
            {
                return new ResponseVM
                {
                    Status = false,
                    Message = "به فرمت   مناسب عکس وارد کنید",
                };
            }
            if (file.Length > 22000000)
            {
                return new ResponseVM
                {
                    Status = false,
                    Message = "حجم فایل باید کمتر از 22 مگابایت باشد ",
                };
            }
            if (file.Length == 0)
            {
                return new ResponseVM
                {
                    Status = false,
                    Message = "حجم فایل 0 است ",
                };
            }

            var uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "Upload/News");
            uniqueFileName = (Guid.NewGuid().ToString().GetImgUrlFriendly() + "_" + file.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return new ResponseVM
            {
                Status = true,
                Message = "/Upload/News/" + uniqueFileName
            };
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

                var res = await UploadImage(model.ArticlePhoto, false);
                if (res.Status == false)
                {
                    ModelState.AddModelError("", res.Message);
                    return View(model);
                }
                model.ArticlePhotoAddress = res.Message;

                var res2 = await UploadImage(model.EnglishArticlePhoto, false);
                if (res2.Status == false)
                {
                    ModelState.AddModelError("", res2.Message);
                    return View(model);
                }
                model.EnglishArticlePhotoAddress = res2.Message;


                #endregion File validation
                try
                {

                    var TBL_Article = new TBL_NewsArticleVideo()
                    {
                        Title = model.Title,
                        EnglishTitle = model.EnglishTitle,
                        NewsType =NewsType.Arrticle,
                        Description = model.Description,
                        EnglishDescription = model.EnglishDescription,

                        ArticlePhotoAddress = model.ArticlePhotoAddress,
                        EnglishArticlePhotoAddress = model.EnglishArticlePhotoAddress,
                      
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
                EnglishTitle = news.EnglishTitle,

                NewsType = NewsType.Arrticle,
                Description = news.Description,
                EnglishDescription = news.EnglishDescription,
                VideoAddress = news.VideoAddress,
                EnglishVideoAddress = news.EnglishVideoAddress,
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
                    var newsFromDb = await _context.TBL_NewsArticleVideo.FirstOrDefaultAsync(c => c.Id == model.Id);
                    newsFromDb.Description = model.Description;
                    newsFromDb.EnglishDescription = model.EnglishDescription;
                    newsFromDb.Title = model.Title;
                    newsFromDb.EnglishTitle = model.EnglishTitle;

                    #region file validation


                    var res = await UploadVideo(model.Video, true);
                    if (res.Status == false)
                    {
                        ModelState.AddModelError("", res.Message);
                        return View(model);
                    }
                    if (res.Message != "no File")
                    {
                        model.VideoAddress = res.Message;
                    }

                    var res2 = await UploadVideo(model.EnglishVideo, true);
                    if (res2.Status == false)
                    {
                        ModelState.AddModelError("", res2.Message);
                        return View(model);
                    }
                    if (res2.Message != "no File")
                    {
                        model.EnglishVideoAddress = res2.Message;
                    }



                    //Delete LastImage video
                    if (res.Message != "no File")
                    {
                        if (!string.IsNullOrEmpty(newsFromDb.VideoAddress))
                        {
                            var LastImagePath = newsFromDb.VideoAddress.Substring(1);
                            LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                            if (System.IO.File.Exists(LastImagePath))
                            {
                                System.IO.File.Delete(LastImagePath);
                            }
                        }

                        newsFromDb.VideoAddress = model.VideoAddress;
                    }


                    //Delete LastImage video
                    if (res2.Message != "no File")
                    {
                        if (!string.IsNullOrEmpty(newsFromDb.EnglishVideoAddress))
                        {
                            var LastImagePath = newsFromDb.EnglishVideoAddress.Substring(1);
                            LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                            if (System.IO.File.Exists(LastImagePath))
                            {
                                System.IO.File.Delete(LastImagePath);
                            }
                        }
                        newsFromDb.EnglishVideoAddress = model.EnglishVideoAddress;
                    }


                    //update Newe Pic Address To database
                    //newsFromDb.VideoAddress = "/Upload/Slider/" + uniqueFileName;
                    //}

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

        #region  Edit Article

        // GET: Admin/TBL_NewsArticleVideo/Edit/5
        public async Task<IActionResult> EditArticle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.TBL_NewsArticleVideo.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }
            var model = new EditArticleViewModel()
            {
                Id = article.Id,
                Title = article.Title,
                EnglishTitle = article.EnglishTitle,
                NewsType = NewsType.Arrticle,
                Description = article.Description,
                EnglishDescription = article.EnglishDescription,
                ArticlePhotoAddress = article.ArticlePhotoAddress,
                EnglishArticlePhotoAddress = article.EnglishArticlePhotoAddress,
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
                    articleFromDb.EnglishDescription = model.EnglishDescription;
                    articleFromDb.EnglishTitle = model.EnglishTitle;
                    articleFromDb.Title = model.Title;



                    #region file validation


                    var res = await UploadImage(model.ArticlePhoto, true);
                    if (res.Status == false)
                    {
                        ModelState.AddModelError("", res.Message);
                        return View(model);
                    }
                    if (res.Message != "no File")
                    {
                        model.ArticlePhotoAddress = res.Message;
                    }

                    var res2 = await UploadImage(model.englishArticlePhoto, true);
                    if (res2.Status == false)
                    {
                        ModelState.AddModelError("", res2.Message);
                        return View(model);
                    }
                    if (res2.Message != "no File")
                    {
                        model.EnglishArticlePhotoAddress = res2.Message;
                    }



                    //Delete LastImage video
                    if (res.Message != "no File")
                    {
                        if (!string.IsNullOrEmpty(articleFromDb.ArticlePhotoAddress))
                        {
                            var LastImagePath = articleFromDb.ArticlePhotoAddress.Substring(1);
                            LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                            if (System.IO.File.Exists(LastImagePath))
                            {
                                System.IO.File.Delete(LastImagePath);
                            }
                        }

                        articleFromDb.ArticlePhotoAddress = model.ArticlePhotoAddress;
                    }


                    //Delete LastImage video
                    if (res2.Message != "no File")
                    {
                        if (!string.IsNullOrEmpty(articleFromDb.EnglishArticlePhotoAddress))
                        {
                            var LastImagePath = articleFromDb.EnglishArticlePhotoAddress.Substring(1);
                            LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                            if (System.IO.File.Exists(LastImagePath))
                            {
                                System.IO.File.Delete(LastImagePath);
                            }
                        }
                        articleFromDb.EnglishArticlePhotoAddress = model.EnglishArticlePhotoAddress;
                    }


                    //update Newe Pic Address To database
                    //newsFromDb.VideoAddress = "/Upload/Slider/" + uniqueFileName;
                    //}

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
                    if (!string.IsNullOrEmpty(NewsFromDb.ArticlePhotoAddress))
                    {
                        var LastImagePath = NewsFromDb.ArticlePhotoAddress.Substring(1);
                        LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);
                        if (System.IO.File.Exists(LastImagePath))
                        {
                            System.IO.File.Delete(LastImagePath);
                        }
                    }
                    //delete english Image
                    if (!string.IsNullOrEmpty(NewsFromDb.EnglishArticlePhotoAddress))
                    {
                        var EnglishLastImagePath = NewsFromDb.EnglishArticlePhotoAddress.Substring(1);
                        EnglishLastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, EnglishLastImagePath);

                        if (System.IO.File.Exists(EnglishLastImagePath))
                        {
                            System.IO.File.Delete(EnglishLastImagePath);
                        }
                    }

                }
                else
                {

                    //delete videos

                    if (!string.IsNullOrEmpty(NewsFromDb.VideoAddress))
                    {
                        var LastImagePath = NewsFromDb.VideoAddress.Substring(1);
                        LastImagePath = Path.Combine(_hostingEnvironment.WebRootPath, LastImagePath);

                        if (System.IO.File.Exists(LastImagePath))
                        {
                            System.IO.File.Delete(LastImagePath);
                        }
                    }


                    //delete EnglishVideo
                    if (!string.IsNullOrEmpty(NewsFromDb.EnglishVideoAddress))
                    {
                        var lastPathes = NewsFromDb.EnglishVideoAddress.Substring(1);
                        lastPathes = Path.Combine(_hostingEnvironment.WebRootPath, lastPathes);
                        if (System.IO.File.Exists(lastPathes))
                        {
                            System.IO.File.Delete(lastPathes);
                        }
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
