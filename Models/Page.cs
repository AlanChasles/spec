using System.Collections.Generic;

namespace rh.Models
{
    public class Page
    {
        public int ID { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public string code { get; set; }
        public int moduleId { get; set; }
        public Module module { get; set; }
        public UtilisateurType utilisateur { get; set; }
        public ICollection<Info> infos { get; set; }
        public ICollection<Image> images { get; set; }
        public ICollection<Lien> sortieLiens { get; set; }
        public ICollection<Lien> entreeLiens { get; set; }
        
        
    }
}