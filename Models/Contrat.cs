using System;

namespace rh.Models
{
    public class Contrat
    {
        public int ID { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public int TypeContratId { get; set; }
        public TypeContrat TypeContrat { get; set; }

        public int CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
    }
}