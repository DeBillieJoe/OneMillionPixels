using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace OneMillionPixels.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        private Bitmap GetBitmap()
        {
            //
            Bitmap bitmap = new Bitmap(1000, 1000);

            for (int x = 0; x < 1000; x++)
                for (int y = 0; y < 1000; y++)
                    bitmap.SetPixel(x, y, Color.DarkRed);

            return bitmap;
        }
        public ActionResult GenerateImage()
        {
            FileContentResult result;
            Bitmap bitmap = GetBitmap();

            using (var memStream = new System.IO.MemoryStream())
            {
                bitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                result = this.File(memStream.GetBuffer(), "image/jpeg");
            }

            return result;
        }
    }
}
