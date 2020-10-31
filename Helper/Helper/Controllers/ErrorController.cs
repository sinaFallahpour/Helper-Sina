using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Helper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Helper.Controllers
{
    public class ErrorController : Controller
    {
        private IStringLocalizer<ShareResource> _shareResource;
        private IStringLocalizer<ErrorController> _localizer;

        public ErrorController(IStringLocalizer<ShareResource> shareResource,
            IStringLocalizer<ErrorController> localizer)
        {
            _shareResource = shareResource;
            _localizer = localizer;
        }


        [Route("/Error/{statusCode}")]
        public IActionResult HttpCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessaage = _shareResource["404"].Value.ToString();
                    break;
                case 500:
                    ViewBag.ErrorMessaage = _shareResource["500"].Value.ToString();
                    break;
                case 400:
                    ViewBag.ErrorMessaage = _shareResource["400"].Value.ToString();
                    break;
                case 401:
                    ViewBag.ErrorMessaage = _shareResource["401"].Value.ToString();
                    break;
                case 403:
                    ViewBag.ErrorMessaage = _shareResource["403"].Value.ToString();
                    break;
                case 504:
                    ViewBag.ErrorMessaage = "TimeOut";
                    break;
                default:
                    ViewBag.ErrorMessaage = "";
                    break;
            }

            return View();
        }


        [Route("/Error/AccesDenied")]
        public IActionResult AccesDenied()
        {
            returnViewDate();
            return View();
        }




        private void returnViewDate()
        {
            ViewData["AccessDenied"] = _localizer["AccessDenied"];
        }


    }
}