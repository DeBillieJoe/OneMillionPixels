using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using Services;
using OneMillionPixels.Models;
using Models;

namespace OneMillionPixels.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ImageManager mngr = new ImageManager();
            var images = mngr.RetrieveAllImages();
            List<ImageBanner> model = new List<ImageBanner>();

            mapSavedPicturesToImageBanners(images, model);

            return View(model);
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
                banner.Width = image.Width;
                banner.Height = image.Height;

                banners.Add(banner);
            }
        }
        public ActionResult BuyPixels()
        {
            return View();
        }
       
    }
}
