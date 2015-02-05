using Models;
using OneMillionPixels.Database;
using OneMillionPixels.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            ImageManager mngr = new ImageManager();
            var images = mngr.RetrieveAllImages();

            mapSavedPicturesToImageBanners(images, model.Images);

            return View("StepOne", model);
        }

        public ActionResult Upload(UploadImageStepOne model)
        {
            Picture picture = new Picture();
            mapUploadedImageToPicture(model, picture);

            ImageManager mngr = new ImageManager();
            mngr.SaveNewImage(picture);

            return View("StepTwo"); 
        }

        void mapSavedPicturesToImageBanners(List<Picture> images, List<ImageBanner> banners)
        {
            foreach (var image in images)
            {
                ImageBanner banner = new ImageBanner();
                banner.X = image.X;
                banner.Y = image.Y;
                banner.Link = image.Link;
                banner.BinaryContent = image.Data;

                banners.Add(banner);
            }
        }

        void mapUploadedImageToPicture(UploadImageStepOne model, Picture picture)
        {
            var image = Image.FromStream(model.Image.InputStream, true, true);

            picture.X = model.XCoordinates.Value;
            picture.Y = model.YCoordinates.Value;
            picture.Link = model.Link;
            picture.Width = image.Width;
            picture.Height = image.Height;
            picture.User = User.Identity.Name;

            ImageConverter converter = new ImageConverter();
            picture.Data = (byte[])converter.ConvertTo(image, typeof(byte[]));
        }
    }
}
