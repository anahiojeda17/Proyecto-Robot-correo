using RobotReporte.Services;

var dbService    = new DatabaseService();
var excelService = new ExcelService();

await dbService.SeedAsync();

var empleados = await dbService.ObtenerEmpleadosAsync();
Console.WriteLine($"Registros encontrados: {empleados.Count}");

string archivo = excelService.GenerarReporte(empleados);
Console.WriteLine($"Excel generado: {archivo}");

Console.ReadLine();