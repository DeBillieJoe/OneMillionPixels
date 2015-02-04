using OneMillionPixels.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OneMillionPixels.Controllers
{
    public class SetPixelsController : Controller
    {
        public ActionResult Index()
        {
            UploadImageStepOne model = new UploadImageStepOne();
            return View("StepOne", model);
        }

        public ActionResult Upload(HttpPostedFileBase image)
        {
            OneMillionPixels.Database.Picture db = new Database.Picture() {X=1, Y=1, Width=2, Link="asd" };
            using (BinaryReader reader = new BinaryReader(image.InputStream))
            {
                db.Data = reader.ReadBytes(image.ContentLength);
            }

            return View("StepTwo");
        }

    }
}
