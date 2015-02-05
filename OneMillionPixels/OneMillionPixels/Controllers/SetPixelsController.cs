using Models;
using OneMillionPixels.Database;
using OneMillionPixels.Models;
using OneMillionPixels.Models.Edit;
using OneMillionPixels.Models.Upload;
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
            try
            {
                ImageManager mngr = new ImageManager();
                var images = mngr.RetrieveAllImages();

                mapSavedPicturesToImageBanners(images, stepTwoModel.Images);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

            var image = Image.FromStream(model.Image.InputStream, true, true);
            stepTwoModel.Width = image.Width;
            stepTwoModel.Height = image.Height;
            stepTwoModel.ContentType = model.Image.ContentType;

            ImageConverter converter = new ImageConverter();
            stepTwoModel.BinaryContent = (byte[])converter.ConvertTo(image, typeof(byte[]));

            return View("StepTwo", stepTwoModel); 
        }

        public ActionResult Upload(UploadImageStepTwo model)
        {
            ImageManager mngr = new ImageManager();
            Picture pic = new Picture();

            try
            {
                mapUploadedImageToPicture(model, pic);

                mngr.SaveNewImage(pic);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

            UploadImageSuccess success = new UploadImageSuccess();
            success.Price = model.Width * model.Height;

            return View(success);
        }

        public ActionResult Edit()
        {
            EditStepOne model = new EditStepOne();
            try
            {
                ImageManager mngr = new ImageManager();
                var images = mngr.RetrieveAllImages(User.Identity.Name);

                mapSavedPicturesToImageBanners(images, model.Images);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

            return View(model);
        }

        public ActionResult EditStepTwo(string id)
        {
            EditStepTwo model = new EditStepTwo();
            model.ID = id;
    
            return View(model);
        }

        public ActionResult Save(EditStepTwo model)
        {
            ImageManager mngr = new ImageManager();
            Picture pic = new Picture();

            try
            {
                pic.ID = model.ID;
                pic.Link = model.Link;
                using (BinaryReader reader = new BinaryReader(model.Image.InputStream))
                {
                    pic.Data = reader.ReadBytes(model.Image.ContentLength);
                }
                pic.ContentType = model.Image.ContentType;
                pic.User = User.Identity.Name;
                mngr.Save(pic);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }

            return View("EditSuccess");
        }

        void mapSavedPicturesToImageBanners(List<Picture> images, List<ImageBanner> banners)
        {
            foreach (var image in images)
            {
                ImageBanner banner = new ImageBanner();
                banner.ID = image.ID;
                banner.X = image.X;
                banner.Y = image.Y;
                banner.Link = image.Link;
                banner.BinaryContent = image.Data;
                banner.ContentType = image.ContentType;

                banners.Add(banner);
            }
        }

        void mapUploadedImageToPicture(UploadImageStepTwo model, Picture picture)
        {
            picture.X = model.XCoordinates.Value;
            picture.Y = model.YCoordinates.Value;
            picture.Link = model.Link;
            picture.Width = model.Width;
            picture.Height = model.Height;
            picture.User = User.Identity.Name;
            picture.Data = model.BinaryContent;
            picture.ContentType = model.ContentType;
        }
    }
}
