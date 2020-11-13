using System;
using System.Collections.Generic;

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
        public TipoCobro FormaPago { get; set; }
        public virtual ICollection<Viaje> Viajes { get; set; }
        public enum TipoCobro
        {
            EFECTIVO,
            CHEQUE,
            CREDITO,
            DEPOSITO_BANCARIO
        }

    }
}
