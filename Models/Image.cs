namespace rh.Models
{
    public class Image
    {
        
        public int ID { get; set; }
        
        public string code { get; set; }
        
        public int pageId { get; set; }
        public Page page { get; set; }
        
        public ImageType ImageType { get; set; }
    }
}