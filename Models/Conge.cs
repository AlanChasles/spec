using System;

namespace rh.Models
{
    public class Conge
    {
        public int ID { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public char PeriodeDebut { get; set; }
        public char PeriodeFin { get; set; }
        public string Commentaire { get; set; }
        public DateTime DateDemande { get; set; }
        public string NomResponsable { get; set; }
        public string PrenomResponsable { get; set; }
        public bool Decision { get; set; }

        public int TypeCongeId { get; set; }
        public TypeConge TypeConge { get; set; }

        public int CollaborateurId { get; set; }
        public Collaborateur Collaborateur { get; set; }
    }
}