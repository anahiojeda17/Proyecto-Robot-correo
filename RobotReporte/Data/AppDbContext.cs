using Microsoft.EntityFrameworkCore;
using RobotReporte.Models;

namespace RobotReporte.Data;

public class AppDbContext : DbContext
{
    public DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=reporte.db");
}