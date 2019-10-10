using System;
using System.Collections.Generic;

namespace apicime.Models
{
    public partial class OrdenesContado
    {
        public int Id { get; set; }
        public int Expediente { get; set; }
        public int Status { get; set; }
        public int? Habitacion { get; set; }
        public DateTime? FechaOrden { get; set; }
        public int? ElaboraOrden { get; set; }
        public int? MedicoGuardia { get; set; }
        public int? Usuario { get; set; }
        public DateTime? UsuarioModifica { get; set; }
        public int? Vigencia { get; set; }
        public string Comentarios { get; set; }
        public string ComentariosEnf { get; set; }
        public int? Ubicacion { get; set; }
        public DateTime? UbicacionDate { get; set; }
        public int? UbicacionUser { get; set; }

        public virtual Expediente ExpedienteNavigation { get; set; }
    }
}
