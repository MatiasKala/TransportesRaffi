using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tp_TransportesRaffi.Models.Enums;

#nullable disable

namespace Tp_TransportesRaffi.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Viajes = new HashSet<Viaje>();
        }

        public int Id { get; set; }
        public string Cuit { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        [Display(Name = "Forma de pago")]
        public TipoCobroCliente FormaPago { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }

    }
}
