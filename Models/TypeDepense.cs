using System;
using System.Collections.Generic;

namespace rh.Models
{
    public class TypeDepense
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public ICollection<Depense> Depenses { get; set; }
    }
}