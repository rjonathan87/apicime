using System;
using System.Collections.Generic;

namespace apicime.Models
{
    public partial class Expediente
    {
        public Expediente()
        {
            OrdenesContado = new HashSet<OrdenesContado>();
            Siniestros = new HashSet<Siniestros>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Ap { get; set; }
        public string Am { get; set; }
        public DateTime Fn { get; set; }
        public string Rfc { get; set; }
        public int GeneroId { get; set; }
        public string Calle { get; set; }
        public string Numi { get; set; }
        public string Nume { get; set; }
        public string Numc { get; set; }
        public string Numm { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Usuario { get; set; }
        public DateTime UsuarioMod { get; set; }
        public int? CodigoPostalId { get; set; }

        public virtual CodigoPostal CodigoPostal { get; set; }
        public virtual Genero Genero { get; set; }
        public virtual ICollection<OrdenesContado> OrdenesContado { get; set; }
        public virtual ICollection<Siniestros> Siniestros { get; set; }
    }
}
