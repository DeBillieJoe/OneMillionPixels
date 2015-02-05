using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneMillionPixels.Models
{
    public class ImageBanner
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Link { get; set; }
        public byte[] BinaryContent { get; set; } 
    }
}