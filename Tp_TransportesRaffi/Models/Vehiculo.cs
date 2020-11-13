using System;
using System.Collections.Generic;

#nullable disable

namespace Tp_TransportesRaffi.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int Id { get; set; }
        public int? Idchofer { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Seguro { get; set; }
        public int Tipo { get; set; }

        public virtual Chofere IdchoferNavigation { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
