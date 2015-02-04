using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneMillionPixels.Models
{
    public class UploadImageStepOne
    {
        [Required(ErrorMessage="Моля, изберете изображение")]
        [Display(Name="Избор на изображение")]
        public HttpPostedFileBase Image { get; set; }

        [Required(ErrorMessage = "Моля, Х координата")]
        [Display(Name = "Избор на X координата")]
        public int? XCoordinates { get; set; }

        [Required(ErrorMessage = "Моля, У координата")]
        [Display(Name = "Избор на Y координата")]
        public int? YCoordinates { get; set; }

        [Required(ErrorMessage = "Моля, изберете линк")]
        [Display(Name = "Задайте линк")]
        public string Link { get; set; }

        public List<ImageBanner> Images { get; set; }
    }

    public class ImageBanner
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Link { get; set; }
        public byte[] BinaryContent { get; set; }
    }
}