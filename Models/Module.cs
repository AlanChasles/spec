using System.Collections.Generic;

namespace rh.Models
{
    public class Module
    {
        public int ID { get; set; }
        public string nom { get; set; }
        public string code { get; set; }
        
        public int projetId { get; set; }
        public Projet projet { get; set; }
        
        public ICollection<Page> pages { get; set; }
        
    }
}