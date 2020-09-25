using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Data;
using Helper.Models.Enums;
using Helper.Models.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Helper.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = Static.ADMINROLE)]
    public class ServicesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ServicesController(ApplicationDbContext context)
        {
            _context = context;
        }



        /// <summary>
        ///    صفحه  خدمت دهندگان برسی نشده
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var serviceProviders = await _context.TBL_Service
                .Where(c => c.ServiceType == ServiceType.GiverService && c.ConfirmServiceType == ConfirmServiceType.Pending)
              .Include(c => c.MonyUnit)
                .OrderByDescending(c => c.CreateDate)
                .ToListAsync();
            return View(serviceProviders);
        }





        /// <summary>
        ///    صفحه  خدمت گیرندان جه بررسی ش ده چه نشده و....کلش
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllServiceProvider()
        {
            var serviceProviders = await _context.TBL_Service
                .Where(c => c.ServiceType == ServiceType.GiverService)
                 .Include(c => c.MonyUnit)
                 .OrderBy(c => c.ConfirmServiceType)
                .OrderByDescending(c => c.CreateDate)
                .ToListAsync();
            return View(serviceProviders);
        }









        /*   ------------------------------------- Service  getters     -------------------------------------*/



        /// <summary>
        ///    صفحه  خدمت گیرندگان برسی نشده
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> ServiceGiverInPendding()
        {
            var serviceProviders = await _context.TBL_Service
                .Where(c => c.ServiceType == ServiceType.GetterService && c.ConfirmServiceType == ConfirmServiceType.Pending)
                  .Include(c => c.MonyUnit)
                .OrderByDescending(c => c.ConfirmServiceType)
                .ToListAsync();
            return View(serviceProviders);
        }




        /// <summary>
        ///    صفحه  خدمت گیرندگان جه بررسی شده چه نشده و....کلش
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> AllServiceGivver()
        {
            var serviceProviders = await _context.TBL_Service
                .Where(c => c.ServiceType == ServiceType.GetterService)
                  .Include(c => c.MonyUnit)
                  .OrderBy(c => c.ConfirmServiceType)
                .OrderByDescending(c => c.CreateDate)
                .ToListAsync();
            return View(serviceProviders);
        }




        #region details

        // GET: Admin/TBL_NewsArticleVideo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceFromDb = await _context.TBL_Service
                .Where(c => c.Id == id)
                .Include(c => c.MonyUnit)
                .Include(c => c.Category)
                .Include(c => c.City)
                .FirstOrDefaultAsync();

            if (serviceFromDb == null)
            {
                return NotFound();
            }

            return View(serviceFromDb);
        }
        #endregion





        /// <summary>
        /// تایید خدمت   
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> ToggleConfirmService(int? serviceId)
        {
            try
            {
                if (serviceId == null)
                    return new JsonResult(new { Status = false, Message = "این سرویس یافت نشد" });
                var serviceFromDb = await _context.TBL_Service
                    .Where(c => c.Id == serviceId)
                    .Include(c => c.User).FirstOrDefaultAsync();
                if (serviceFromDb == null)
                {
                    return new JsonResult(new { Status = false, Message = "این سرویس یافت نشد" });
                }

                serviceFromDb.ConfirmServiceType = ConfirmServiceType.Confirmed;

                if (serviceFromDb.ServiceType == ServiceType.GiverService)
                {
                    serviceFromDb.User.HasProviderService = true;
                }

                var result = _context.SaveChanges();

                return new JsonResult(new { Status = true, Message = "ثبت موفقیت آمیز", });
            }

            catch
            {
                return new JsonResult(new { Status = false, Message = "خطا در ثبت اطلاعات" });
            }
        }





        /// <summary>
        /// رد تایید خدمت   
        /// </summary>
        /// <param name="serviceId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> TogglRegectService(int? serviceId, string username)
        {
            try
            {
                if (serviceId == null)
                    return new JsonResult(new { Status = false, Message = "این سرویس یافت نشد" });
                var serviceFromDb = await _context.TBL_Service
                    .Where(c => c.Id == serviceId)
                    .Include(c => c.User).FirstOrDefaultAsync();
                if (serviceFromDb == null)
                {
                    return new JsonResult(new { Status = false, Message = "این سرویس یافت نشد" });
                }

                serviceFromDb.ConfirmServiceType = ConfirmServiceType.Pending;

                if (serviceFromDb.ServiceType == ServiceType.GiverService)
                {
                    var userSrviceCount = _context.TBL_Service.Where(c => c.Username == username).Count();
                    if (userSrviceCount == 1)
                    {
                        serviceFromDb.User.HasProviderService = false;
                    }
                }
                var result = _context.SaveChanges();

                return new JsonResult(new { Status = true, Message = "ثبت موفقیت آمیز", });
            }
            catch
            {
                return new JsonResult(new { Status = false, Message = "خطا در ثبت اطلاعات" });
            }
        }







        ///// <summary>
        ///// تایید خدمت دهندگان 
        ///// </summary>
        ///// <param name="serviceId"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult> ToggleConfirmService(int? serviceId)
        //{
        //    try
        //    {
        //        if (serviceId == null)
        //            return new JsonResult(new { Status = false, Message = "این سرویس یافت نشد" });
        //        var serviceFromDb = await _context.TBL_Service
        //            .Where(c => c.Id == serviceId)
        //            .Include(c => c.User).FirstOrDefaultAsync();
        //        if (serviceFromDb == null)
        //        {
        //            return new JsonResult(new { Status = false, Message = "این سرویس یافت نشد" });
        //        }

        //        serviceFromDb.ConfirmServiceType = ConfirmServiceType.Confirmed;

        //        if (serviceFromDb.ServiceType == ServiceType.GiverService)
        //        {
        //            serviceFromDb.User.HasProviderService = true;
        //        }

        //        var result = _context.SaveChanges();

        //        return new JsonResult(new { Status = true, Message = "ثبت موفقیت آمیز", });
        //    }

        //    catch
        //    {
        //        return new JsonResult(new { Status = false, Message = "خطا در ثبت اطلاعات" });
        //    }
        //}








    }
}
