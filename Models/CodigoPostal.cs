using System;
using System.Collections.Generic;

namespace apicime.Models
{
    public partial class CodigoPostal
    {
        public CodigoPostal()
        {
            Expediente = new HashSet<Expediente>();
        }

        public int Id { get; set; }
        public string Dcodigo { get; set; }
        public string Dasenta { get; set; }
        public string DtipoAsenta { get; set; }
        public string Dmnpio { get; set; }
        public string Destado { get; set; }
        public string Dciudad { get; set; }
        public string Dcp { get; set; }
        public int? Cestado { get; set; }
        public int? Coficina { get; set; }
        public int? Ccp { get; set; }
        public int? CtipoAsenta { get; set; }
        public string Cmnpio { get; set; }
        public string IdAsentaCpcons { get; set; }
        public string Dzona { get; set; }
        public int? CcveCiudad { get; set; }

        public virtual ICollection<Expediente> Expediente { get; set; }
    }
}
