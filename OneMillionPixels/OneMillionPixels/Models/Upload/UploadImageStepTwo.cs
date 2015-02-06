using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneMillionPixels.Models.Upload
{
    public class UploadImageStepTwo
    {
        public UploadImageStepTwo()
        {
            Images = new List<ImageBanner>();
        }
        [Required(ErrorMessage = "Моля, Х координата")]
        [Display(Name = "X")]
        public int? XCoordinates { get; set; }

        [Required(ErrorMessage = "Моля, У координата")]
        [Display(Name = "Y")]
        public int? YCoordinates { get; set; }

        [Required(ErrorMessage = "Моля, изберете линк")]
        [RegularExpression("^www.[a-zA-Z0-9 .&'-]+.(com|bg|net|edu|org|ru)$", ErrorMessage="Невалиден линк")]
        [Display(Name = "Задайте линк")]
        public string Link { get; set; }

        public List<ImageBanner> Images { get; set; }

        public byte[] BinaryContent { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContentType { get; set; }
         
    }
}   