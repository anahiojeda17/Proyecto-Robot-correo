// Services/DatabaseService.cs
using Microsoft.EntityFrameworkCore;
using RobotReporte.Data;
using RobotReporte.Models;

namespace RobotReporte.Services;

public class DatabaseService
{
    public async Task<List<Empleado>> ObtenerEmpleadosAsync()
    {
        using var db = new AppDbContext();
        return await db.Empleados.ToListAsync();
    }

    // Método auxiliar para cargar datos de prueba
    public async Task SeedAsync()
    {
        using var db = new AppDbContext();
        await db.Database.EnsureCreatedAsync(); // Crea la tabla si no existe

        if (!db.Empleados.Any())
        {
            db.Empleados.AddRange(
                new Empleado { Nombre = "Anahi Ojeda",    Departamento = "IT",       Salario = 50000, FechaIngreso = DateTime.Now.AddYears(-3) },
                new Empleado { Nombre = "Juan Perez",  Departamento = "Ventas",   Salario = 45000, FechaIngreso = DateTime.Now.AddYears(-1) },
                new Empleado { Nombre = "María Dominguez",   Departamento = "RRHH",     Salario = 48000, FechaIngreso = DateTime.Now.AddYears(-5) }
            );
            await db.SaveChangesAsync();
        }
    }
}