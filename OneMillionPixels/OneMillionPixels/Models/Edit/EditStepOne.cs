using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneMillionPixels.Models.Edit
{
    public class EditStepOne
    {
        public EditStepOne()
        {
            Images = new List<ImageBanner>();
        }

        public List<ImageBanner> Images { get; set; }
    }
}