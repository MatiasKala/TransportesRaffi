using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tp_TransportesRaffi.Models.Enums;

#nullable disable

namespace Tp_TransportesRaffi.Models
{
    public partial class Viaje
    {
        public int Id { get; set; }
        [Display(Name="Nombre del cliente")]
        public int? Idcliente { get; set; }
        [Display(Name = "Nombre del vehiculo")]
        public int? Idvehiculo { get; set; }
        [Display(Name = "Fecha y hora de entrega")]
        public DateTime FechaHoraEntrega { get; set; }
        [Display(Name = "Domicilio de entrega")]
        public string DomicilioEntrega { get; set; }
        [Display(Name = "Descripcion del paquete")]
        public string DescripcionPaquete { get; set; }
        [Display(Name = "Valor del viaje")]
        public double ValorViaje { get; set; }
        [Display(Name = "Estado del viaje")]
        public EstadoViajeEnum EstadoViaje { get; set; }
        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Vehiculo IdvehiculoNavigation { get; set; }
    }
}
