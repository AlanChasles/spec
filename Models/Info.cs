namespace rh.Models
{
    public class Info
    {
        
        public int ID { get; set; }
        public string commentaire { get; set; }
        
        public int pageId { get; set; }
        public Page page { get; set; }
        public InfoPageType infoPageType { get; set; }
    }
}