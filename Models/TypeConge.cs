using System;
using System.Collections.Generic;

namespace rh.Models
{
    public class TypeConge
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public ICollection<Conge> Conges { get; set; }
    }
}