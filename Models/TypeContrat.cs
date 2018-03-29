using System;
using System.Collections.Generic;

namespace rh.Models
{
    public class TypeContrat
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public ICollection<Contrat> Contrats { get; set; }
    }
}