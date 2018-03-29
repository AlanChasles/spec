using System;

namespace rh.Models
{
    public class Depense
    {
        public int ID { get; set; }
        public DateTime DateDepense { get; set; }
        public string NomClient { get; set; }
        public string VilleClient { get; set; }
        public string MotifDepense { get; set; }
        public decimal NombreKms { get; set; }
        public decimal LocationVoiture { get; set; }
        public decimal TaxiBus { get; set; }
        public decimal AvionTrain { get; set; }
        public decimal ParkingPeage { get; set; }
        public decimal Restaurant { get; set; } 
        public decimal Hotel { get; set; }
        public decimal Divers { get; set; }
        public decimal TauxDevise { get; set; }
        public string Commentaire { get; set; }
        public string CommentaireRefus { get; set; }

        public int TypeDepenseId { get; set; }
        public TypeDepense TypeDepense { get; set; }
    }
}