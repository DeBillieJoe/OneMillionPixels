using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OneMillionPixels.Models.Edit
{
    public class EditStepTwo
    {
        public string ID { get; set; }

        [Required(ErrorMessage = "Моля, изберете линк")]
        [Display(Name = "Избор на линк")]
        public string Link { get; set; }

        [Required(ErrorMessage = "Моля, изберете изображение")]
        [Display(Name = "Избор на изображение")]
        public HttpPostedFileBase Image { get; set; }
    }
}