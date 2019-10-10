using System;
using System.Collections.Generic;

namespace apicime.Models
{
    public partial class Genero
    {
        public Genero()
        {
            Expediente = new HashSet<Expediente>();
        }

        public int Id { get; set; }
        public string NombreGenero { get; set; }

        public virtual ICollection<Expediente> Expediente { get; set; }
    }
}
