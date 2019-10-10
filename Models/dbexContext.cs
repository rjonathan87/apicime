using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apicime.Models
{
    public partial class dbexContext : DbContext
    {
        public dbexContext()
        {
        }

        public dbexContext(DbContextOptions<dbexContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatAseguradoras> CatAseguradoras { get; set; }
        public virtual DbSet<CodigoPostal> CodigoPostal { get; set; }
        public virtual DbSet<Expediente> Expediente { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }
        public virtual DbSet<OrdenesContado> OrdenesContado { get; set; }
        public virtual DbSet<OrdenesCredito> OrdenesCredito { get; set; }
        public virtual DbSet<Siniestros> Siniestros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseSqlServer("server=cimesistema.ddns.net;user=sa;password=Auto1342$;database=dbex");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<CatAseguradoras>(entity =>
            {
                entity.HasKey(e => e.IdAseguradora)
                    .HasName("PK_cat_aseguradoras");

                entity.Property(e => e.Codigo).HasMaxLength(10);

                entity.Property(e => e.Colonia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Delegacion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Rfc)
                    .IsRequired()
                    .HasMaxLength(15);
            });

            modelBuilder.Entity<Expediente>(entity =>
            {
                entity.HasIndex(e => e.CodigoPostalId);

                entity.HasIndex(e => e.GeneroId);

                entity.Property(e => e.Am).IsRequired();

                entity.Property(e => e.Ap).IsRequired();

                entity.Property(e => e.Nombre).IsRequired();

                entity.Property(e => e.Rfc).IsRequired();

                entity.HasOne(d => d.CodigoPostal)
                    .WithMany(p => p.Expediente)
                    .HasForeignKey(d => d.CodigoPostalId);

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Expediente)
                    .HasForeignKey(d => d.GeneroId);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.Property(e => e.NombreGenero).IsRequired();
            });

            modelBuilder.Entity<OrdenesContado>(entity =>
            {
                entity.HasIndex(e => e.Expediente);

                entity.HasOne(d => d.ExpedienteNavigation)
                    .WithMany(p => p.OrdenesContado)
                    .HasForeignKey(d => d.Expediente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenesContado_Expediente");
            });

            modelBuilder.Entity<OrdenesCredito>(entity =>
            {
                entity.HasIndex(e => e.Siniestro);

                entity.HasIndex(e => e.SiniestroNavigationId);

                entity.HasOne(d => d.SiniestroNavigation)
                    .WithMany(p => p.OrdenesCredito)
                    .HasForeignKey(d => d.Siniestro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrdenesCredito_Siniestros");
            });

            modelBuilder.Entity<Siniestros>(entity =>
            {
                entity.HasIndex(e => e.ExpedienteNavigationId);

                entity.HasIndex(e => e.IdAseguradora);

                entity.HasOne(d => d.ExpedienteNavigation)
                    .WithMany(p => p.Siniestros)
                    .HasForeignKey(d => d.ExpedienteNavigationId);

                entity.HasOne(d => d.IdAseguradoraNavigation)
                    .WithMany(p => p.Siniestros)
                    .HasForeignKey(d => d.IdAseguradora)
                    .HasConstraintName("FK_Siniestros_CatAseguradoras");
            });
        }
    }
}
