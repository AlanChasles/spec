namespace rh.Models
{
    public class Lien
    {
        
        public int ID { get; set; }
        public string commentaire { get; set; } 
        
        public int entreePageId { get; set; }
        public Page entreePage { get; set; }
        
        public int sortiePageId { get; set; }
        public Page sortiePage { get; set; }
    }
}