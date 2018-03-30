using System.Collections.Generic;

namespace rh.Models
{
    public class Projet
    {
        public int ID { get; set; }
        public string nom { get; set; }
        
        public ICollection<Module> modules { get; set; }
        
    }
}