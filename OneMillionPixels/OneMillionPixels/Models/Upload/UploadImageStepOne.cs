using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneMillionPixels.Models.Upload
{
    public class UploadImageStepOne
    {
        [Required(ErrorMessage = "Моля, изберете изображение")]
        [Display(Name = "Избор на изображение")]
        public HttpPostedFileBase Image { get; set; }

    }


}