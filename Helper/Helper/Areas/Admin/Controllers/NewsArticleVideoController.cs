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
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Helper.Models.Enums;

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsArticleVideoController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        public NewsArticleVideoController(ApplicationDbContext context,
              IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

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





        // GET: Admin/TBL_NewsArticleVideo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBL_NewsArticleVideo = await _context.TBL_NewsArticleVideo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_NewsArticleVideo == null)
            {
                return NotFound();
            }

            return View(tBL_NewsArticleVideo);
        }








        // GET: Admin/TBL_NewsArticleVideo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/TBL_NewsArticleVideo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TBL_NewsArticleVideo model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }





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
                if (model.ArticlePhoto.Length > 11000000)
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

































        // GET: Admin/TBL_NewsArticleVideo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBL_NewsArticleVideo = await _context.TBL_NewsArticleVideo.FindAsync(id);
            if (tBL_NewsArticleVideo == null)
            {
                return NotFound();
            }
            return View(tBL_NewsArticleVideo);
        }

        // POST: Admin/TBL_NewsArticleVideo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,CreateDate,LikesCount,CommentsCount,SeenCount,NewsType,ArticlePhotoAddress,VideoAddress,Id")] TBL_NewsArticleVideo tBL_NewsArticleVideo)
        {
            if (id != tBL_NewsArticleVideo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBL_NewsArticleVideo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBL_NewsArticleVideoExists(tBL_NewsArticleVideo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tBL_NewsArticleVideo);
        }

        // GET: Admin/TBL_NewsArticleVideo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBL_NewsArticleVideo = await _context.TBL_NewsArticleVideo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tBL_NewsArticleVideo == null)
            {
                return NotFound();
            }

            return View(tBL_NewsArticleVideo);
        }

        // POST: Admin/TBL_NewsArticleVideo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBL_NewsArticleVideo = await _context.TBL_NewsArticleVideo.FindAsync(id);
            _context.TBL_NewsArticleVideo.Remove(tBL_NewsArticleVideo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBL_NewsArticleVideoExists(int id)
        {
            return _context.TBL_NewsArticleVideo.Any(e => e.Id == id);
        }
    }
}
