using System;
using System.Collections.Generic;

#nullable disable

namespace Tp_TransportesRaffi.Models
{
    public partial class Chofer
    {
        public Chofer()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int Id { get; set; }
        public string Cuit { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int Comision { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
