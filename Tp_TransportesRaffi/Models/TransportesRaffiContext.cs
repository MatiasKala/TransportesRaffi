using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Tp_TransportesRaffi.Models
{
    public partial class TransportesRaffiContext : DbContext
    {
        public TransportesRaffiContext()
        {
        }

        public TransportesRaffiContext(DbContextOptions<TransportesRaffiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chofere> Choferes { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<Viaje> Viajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-MATI;Initial Catalog=TransportesRaffi;Integrated Security=True;\n");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chofere>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cuit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CUIT");

                entity.Property(e => e.FechaNacimiento).HasColumnType("date");

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cuit)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("CUIT");

                entity.Property(e => e.Direccion).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Idchofer).HasColumnName("IDChofer");

                entity.Property(e => e.Patente)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdchoferNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.Idchofer)
                    .HasConstraintName("FK_Vehiculos_Choferes");
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasIndex(e => e.Idvehiculo, "IX_Viajes_VehiculoPatente");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DescripcionPaquete).IsRequired();

                entity.Property(e => e.DomicilioEntrega).IsRequired();

                entity.Property(e => e.Idcliente).HasColumnName("IDCliente");

                entity.Property(e => e.Idvehiculo).HasColumnName("IDVehiculo");

                entity.HasOne(d => d.IdclienteNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.Idcliente)
                    .HasConstraintName("FK_Viajes_Clientes");

                entity.HasOne(d => d.IdvehiculoNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.Idvehiculo)
                    .HasConstraintName("FK_Viajes_Vehiculos");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
