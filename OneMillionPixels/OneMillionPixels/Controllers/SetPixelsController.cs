using OneMillionPixels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneMillionPixels.Controllers
{
    public class SetPixelsController : Controller
    {
        public ActionResult Index()
        {
            UploadImage model = new UploadImage();
            return View(model);
        }

        [HttpGet]
        public ActionResult Upload(UploadImage image)
        {
            

            return View("Index");
        }

    }
}
