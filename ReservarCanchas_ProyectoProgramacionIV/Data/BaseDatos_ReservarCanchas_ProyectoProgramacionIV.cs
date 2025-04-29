using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReservarCanchas_ProyectoProgramacionIV.Models;

public class BaseDatos_ReservarCanchas_ProyectoProgramacionIV : DbContext
{
    public BaseDatos_ReservarCanchas_ProyectoProgramacionIV(DbContextOptions<BaseDatos_ReservarCanchas_ProyectoProgramacionIV> options)
        : base(options)
    {
    }

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Campus> Campus { get; set; } = default!;


    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.ReservaImplemento> ReservaImplemento { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Administrador> Administrador { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Calendario> Calendario { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Cancha> Cancha { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Carrera> Carrera { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Estudiante> Estudiante { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Facultad> Facultad { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Implemento> Implemento { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.PersonalMantenimiento> PersonalMantenimiento { get; set; } = default!;

    public DbSet<ReservarCanchas_ProyectoProgramacionIV.Models.Reserva> Reserva { get; set; } = default!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configuración del discriminador para manejar las subclases de PersonaUdla
        modelBuilder.Entity<PersonaUdla>()
            .HasDiscriminator<string>("TipoPersona")
            .HasValue<Estudiante>("Estudiante")
            .HasValue<Administrador>("Administrador")
            .HasValue<PersonalMantenimiento>("PersonalMantenimiento");
        // Puedes seguir añadiendo nuevas subclases sin modificar el código aquí
        // y EF se encargará de asignar el tipo correspondiente automáticamente.

        modelBuilder.Entity<Reserva>().ToTable("Reservas");
    }
}
