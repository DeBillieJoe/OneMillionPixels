using DBManagers;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ImageManager
    {
        public void SaveNewImage(Picture image)
        {
            PictureDBController ctrl = new PictureDBController();
            ctrl.SaveNew(image);
        }
 
        public List<Picture> RetrieveAllImages()
        {
            PictureDBController ctrl = new PictureDBController();
            var images = ctrl.RetrieveAll();

            return images;
        }
    }
}
