using System;
using System.Collections.Generic;

#nullable disable

namespace Tp_TransportesRaffi.Models
{
    public partial class Viaje
    {
        public int Id { get; set; }
        public int? Idcliente { get; set; }
        public int? Idvehiculo { get; set; }
        public DateTime FechaHoraEntrega { get; set; }
        public string DomicilioEntrega { get; set; }
        public string DescripcionPaquete { get; set; }
        public double ValorViaje { get; set; }
        public Estado EstadoViaje { get; set; }
        public enum Estado
        {
            LISTO,
            EN_TRANSITO,
            FINALIZADO
        }
        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Vehiculo IdvehiculoNavigation { get; set; }
    }
}
