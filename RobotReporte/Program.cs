using RobotReporte.Services;

var dbService = new DatabaseService();
await dbService.SeedAsync();

Console.WriteLine("Base de datos creada y datos de prueba insertados.");
Console.ReadLine();