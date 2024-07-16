using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace MercDevs_ej2.MercydevsEjercicio2;

public partial class MercyDeveloperContext : DbContext
{
    public MercyDeveloperContext()
    {
    }

    public MercyDeveloperContext(DbContextOptions<MercyDeveloperContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Datosfichatecnica> Datosfichatecnicas { get; set; }

    public virtual DbSet<Descripcionservicio> Descripcionservicios { get; set; }

    public virtual DbSet<Diagnosticosolucion> Diagnosticosolucions { get; set; }

    public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }

    public virtual DbSet<Recepcionequipo> Recepcionequipos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.IdCliente)
                .HasColumnType("int(11)")
                .HasColumnName("idCliente");
            entity.Property(e => e.Apellido).HasMaxLength(45);
            entity.Property(e => e.Correo).HasMaxLength(45);
            entity.Property(e => e.Direccion).HasMaxLength(45);
            entity.Property(e => e.Estado).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Telefono).HasMaxLength(45);
        });

        modelBuilder.Entity<Datosfichatecnica>(entity =>
        {
            entity.HasKey(e => e.IdFichaTecnica).HasName("PRIMARY");

            entity.ToTable("datosfichatecnica");

            entity.HasIndex(e => e.RecepcionEquipoId, "fk_DatosFichaTecnica_RecepcionEquipo1_idx");

            entity.Property(e => e.IdFichaTecnica)
                .HasColumnType("int(11)")
                .HasColumnName("idFichaTecnica");
            entity.Property(e => e.AntivirusInstalado).HasMaxLength(100);
            entity.Property(e => e.FechaFinalizacion).HasColumnType("datetime");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.LectorPdfinstalado)
                .HasColumnType("int(11)")
                .HasColumnName("LectorPDFInstalado");
            entity.Property(e => e.NavegadorWebInstalado).HasColumnType("int(11)");
            entity.Property(e => e.PobservacionRecomendaciones)
                .HasMaxLength(2000)
                .HasColumnName("PObservacionRecomendaciones");
            entity.Property(e => e.RecepcionEquipoId).HasColumnType("int(11)");
            entity.Property(e => e.Soinstalado)
                .HasColumnType("int(11)")
                .HasColumnName("SOInstalado");
            entity.Property(e => e.SuiteOfficeInstalada).HasColumnType("int(11)");

            entity.HasOne(d => d.RecepcionEquipo).WithMany(p => p.Datosfichatecnicas)
                .HasForeignKey(d => d.RecepcionEquipoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DatosFichaTecnica_RecepcionEquipo1");
        });

        modelBuilder.Entity<Descripcionservicio>(entity =>
        {
            entity.HasKey(e => e.IdDescServ).HasName("PRIMARY");

            entity.ToTable("descripcionservicio");

            entity.HasIndex(e => e.IdServicio, "fk_DescripcionServicio_Servicio1_idx");

            entity.Property(e => e.IdDescServ)
                .HasColumnType("int(11)")
                .HasColumnName("idDescServ");
            entity.Property(e => e.IdServicio)
                .HasColumnType("int(11)")
                .HasColumnName("idServicio");
            entity.Property(e => e.Nombre).HasMaxLength(45);

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Descripcionservicios)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DescripcionServicio_Servicio1");
        });

        modelBuilder.Entity<Diagnosticosolucion>(entity =>
        {
            entity.HasKey(e => e.IdDiagnosticoSolucion).HasName("PRIMARY");

            entity.ToTable("diagnosticosolucion");

            entity.HasIndex(e => e.IdFichaTecnica, "fk_DiagnosticoSolucion_DatosFichaTecnica1_idx");

            entity.Property(e => e.IdDiagnosticoSolucion)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("idDiagnosticoSolucion");
            entity.Property(e => e.DescripcionDiagnostico).HasMaxLength(1000);
            entity.Property(e => e.DescripcionSolucion).HasMaxLength(1000);
            entity.Property(e => e.IdFichaTecnica)
                .ValueGeneratedOnAdd()
                .HasColumnType("int(11)");

            entity.HasOne(d => d.IdFichaTecnicaNavigation).WithMany(p => p.Diagnosticosolucions)
                .HasForeignKey(d => d.IdFichaTecnica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DiagnosticoSolucion_DatosFichaTecnica1");
        });

        modelBuilder.Entity<Efmigrationshistory>(entity =>
        {
            entity.HasKey(e => e.MigrationId).HasName("PRIMARY");

            entity
                .ToTable("__efmigrationshistory")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_general_ci");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<Recepcionequipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("recepcionequipo");

            entity.HasIndex(e => e.IdCliente, "fk_RecepcionEquipo_Cliente1_idx");

            entity.HasIndex(e => e.IdServicio, "fk_RecepcionEquipo_Servicio1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Accesorio).HasMaxLength(45);
            entity.Property(e => e.CapacidadAlmacenamiento).HasMaxLength(45);
            entity.Property(e => e.CapacidadRam).HasColumnType("int(11)");
            entity.Property(e => e.Estado).HasColumnType("int(11)");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Grafico).HasMaxLength(45);
            entity.Property(e => e.IdCliente).HasColumnType("int(11)");
            entity.Property(e => e.IdServicio).HasColumnType("int(11)");
            entity.Property(e => e.MarcaPc).HasMaxLength(45);
            entity.Property(e => e.ModeloPc).HasMaxLength(45);
            entity.Property(e => e.Nserie)
                .HasMaxLength(45)
                .HasColumnName("NSerie");
            entity.Property(e => e.TipoAlmacenamiento).HasColumnType("int(11)");
            entity.Property(e => e.TipoGpu).HasColumnType("int(11)");
            entity.Property(e => e.TipoPc).HasColumnType("int(11)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Recepcionequipos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RecepcionEquipo_Cliente1");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Recepcionequipos)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RecepcionEquipo_Servicio1");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdServicio).HasName("PRIMARY");

            entity.ToTable("servicio");

            entity.HasIndex(e => e.IdUsuario, "fk_Servicio_Usuario_idx");

            entity.Property(e => e.IdServicio)
                .HasColumnType("int(11)")
                .HasColumnName("idServicio");
            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("idUsuario");
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Precio).HasColumnType("int(11)");
            entity.Property(e => e.Sku).HasMaxLength(45);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Servicio_Usuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario)
                .HasColumnType("int(11)")
                .HasColumnName("idUsuario");
            entity.Property(e => e.Apellido).HasMaxLength(45);
            entity.Property(e => e.Correo).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Password)
                .HasMaxLength(64)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
