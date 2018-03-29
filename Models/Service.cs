using System;
using System.Collections.Generic;

namespace rh.Models
{
    public class Service
    {
        public int ID { get; set; }
        public string Label { get; set; }
        public ICollection<Collaborateur> Collaborateurs { get; set; }
    }
}