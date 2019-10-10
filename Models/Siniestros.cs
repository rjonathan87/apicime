using System;
using System.Collections.Generic;

namespace apicime.Models
{
    public partial class Siniestros
    {
        public Siniestros()
        {
            OrdenesCredito = new HashSet<OrdenesCredito>();
        }

        public int Id { get; set; }
        public string TituloSiniestro { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public int? Status { get; set; }
        public int? IdUser { get; set; }
        public DateTime? FechaCambios { get; set; }
        public int? IdUserCambios { get; set; }
        public int? Expediente { get; set; }
        public int? ExpedienteNavigationId { get; set; }
        public int? IdAseguradora { get; set; }

        public virtual Expediente ExpedienteNavigation { get; set; }
        public virtual CatAseguradoras IdAseguradoraNavigation { get; set; }
        public virtual ICollection<OrdenesCredito> OrdenesCredito { get; set; }
    }
}
