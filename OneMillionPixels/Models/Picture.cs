
namespace Models
{
    public class Picture
    {
        public string ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Link { get; set; }
        public byte[] Data { get; set; }
        public string User { get; set; }
        public string ContentType { get; set; }
    }
}
