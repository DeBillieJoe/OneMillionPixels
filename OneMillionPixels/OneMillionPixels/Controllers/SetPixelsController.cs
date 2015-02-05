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
            UploadImageStepOne stepOneModel = new UploadImageStepOne();

            return View("StepOne", stepOneModel);
        }

        public ActionResult StepTwo(UploadImageStepOne model)
        {
            UploadImageStepTwo stepTwoModel = new UploadImageStepTwo();
            
            ImageManager mngr = new ImageManager();
            var images = mngr.RetrieveAllImages();

            mapSavedPicturesToImageBanners(images, stepTwoModel.Images);

            var image = Image.FromStream(model.Image.InputStream, true, true);
            stepTwoModel.Width = image.Width;
            stepTwoModel.Height = image.Height;

            ImageConverter converter = new ImageConverter();
            stepTwoModel.BinaryContent = (byte[])converter.ConvertTo(image, typeof(byte[]));

            return View("StepTwo", stepTwoModel); 
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

            //picture.X = model.XCoordinates.Value;
            //picture.Y = model.YCoordinates.Value;
            //picture.Link = model.Link;
            //picture.Width = image.Width;
            //picture.Height = image.Height;
            //picture.User = User.Identity.Name;

            ImageConverter converter = new ImageConverter();
            picture.Data = (byte[])converter.ConvertTo(image, typeof(byte[]));
        }
    }
}
