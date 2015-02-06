using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneMillionPixels.Models
{
    public class ImageBanner
    {
        public string ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public string Link { get; set; }
        public byte[] BinaryContent { get; set; }
        public string ContentType { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
}