using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tp_TransportesRaffi.Models.Enums;

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
        [Display(Name = "Nombre del chofer")]
        public int? Idchofer { get; set; }
        public string Patente { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        [Display(Name = "Año")]
        public int Anio { get; set; }
        public string Seguro { get; set; }
        public TipoDeVehiculo Tipo { get; set; }
        public virtual Chofer IdchoferNavigation { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
    }
}
