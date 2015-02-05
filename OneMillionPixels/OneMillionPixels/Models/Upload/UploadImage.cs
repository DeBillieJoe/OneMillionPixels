using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneMillionPixels.Models.Upload
{
	public class UploadImage
	{
        [Display(Name="Изберете изображение")]
        [Required]
        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Изберете X координата")]
        [Required]
        public int XCoordinates { get; set; }

        [Display(Name = "Изберете Y координата")]
        [Required]
        public int YCoordinates { get; set; }

        [Display(Name = "Изберете линк")]
        [Required]
        public string Link { get; set; } 
	}
}