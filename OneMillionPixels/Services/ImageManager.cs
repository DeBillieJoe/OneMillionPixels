using DBManagers;
using Models;
using System.Collections.Generic;

namespace Services
{
    public class ImageManager
    {
        public void Save(Picture image)
        {
            using (PictureDBController ctrl = new PictureDBController())
            {
                ctrl.Save(image);
            }
        }

        public void SaveNewImage(Picture image)
        {
            using (PictureDBController ctrl = new PictureDBController())
            {
                ctrl.SaveNew(image);
            }
        }
 
        public List<Picture> RetrieveAllImages()
        {
            using (PictureDBController ctrl = new PictureDBController())
            {
                return ctrl.RetrieveAll();
            }
        }
    }
}
