using System;
using System.Collections.Generic;

namespace apicime.Models
{
    public partial class CatAseguradoras
    {
        public CatAseguradoras()
        {
            Siniestros = new HashSet<Siniestros>();
        }

        public int IdAseguradora { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public string Numero { get; set; }
        public string Direccion { get; set; }
        public string Colonia { get; set; }
        public string Delegacion { get; set; }
        public int? Cp { get; set; }
        public string Rfc { get; set; }
        public string Mail { get; set; }
        public string Login { get; set; }
        public string Codigo { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Siniestros> Siniestros { get; set; }
    }
}
