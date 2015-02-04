using OneMillionPixels.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OneMillionPixels.Controllers
{
    public class SetPixelsController : Controller
    {
        public ActionResult Index()
        {
            UploadImageStepOne model = new UploadImageStepOne();
            model.Images = new List<ImageBanner>();
            OneMillionPixels.Database.Picture db = new Database.Picture();
            var images = OneMillionPixels.Database.Picture.RetrieveAll();

            foreach (var image in images)
            {
                ImageBanner banner = new ImageBanner();
                banner.X = image.X;
                banner.Y = image.Y;
                banner.Link = image.Link;
                banner.BinaryContent = image.Data;

                model.Images.Add(banner);
            }

            return View("StepOne", model);
        }

        public ActionResult Upload(UploadImageStepOne model)
        {
            OneMillionPixels.Database.Picture db = new Database.Picture();
            db.X = model.XCoordinates.Value;
            db.Y = model.YCoordinates.Value;
            db.Link = model.Link;
            db.Width = 100;
            db.Height = 100;
            using (BinaryReader reader = new BinaryReader(model.Image.InputStream))
            {
                db.Data = reader.ReadBytes(model.Image.ContentLength);
            }
            db.SaveNew();
            return View("StepTwo"); 
        }

    }
}
