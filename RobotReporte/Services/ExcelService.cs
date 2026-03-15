using ClosedXML.Excel;
using RobotReporte.Models;

namespace RobotReporte.Services;

public class ExcelService
{
    public string GenerarReporte(List<Empleado> empleados)
    {
        // aca crea el archivo excel 
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Empleados");

        // Encabezados
        ws.Cell(1, 1).Value = "ID";
        ws.Cell(1, 2).Value = "Nombre";
        ws.Cell(1, 3).Value = "Departamento";
        ws.Cell(1, 4).Value = "Salario";
        ws.Cell(1, 5).Value = "Fecha Ingreso";

        // Estilo de encabezados
        var header = ws.Range(1, 1, 1, 5);
        header.Style.Font.Bold = true;
        header.Style.Fill.BackgroundColor = XLColor.DarkBlue;
        header.Style.Font.FontColor = XLColor.White;

        // Datos
        for (int i = 0; i < empleados.Count; i++)
        {
            var e = empleados[i];
            ws.Cell(i + 2, 1).Value = e.Id;
            ws.Cell(i + 2, 2).Value = e.Nombre;
            ws.Cell(i + 2, 3).Value = e.Departamento;
            ws.Cell(i + 2, 4).Value = e.Salario;
            ws.Cell(i + 2, 5).Value = e.FechaIngreso.ToString("dd/MM/yyyy");
        }
        /// Autoajuste de columnas
        ws.Columns().AdjustToContents();

        string ruta = $"reporte_{DateTime.Now:yyyyMMdd_HHmm}.xlsx";
        wb.SaveAs(ruta);
        return ruta;
    }
}