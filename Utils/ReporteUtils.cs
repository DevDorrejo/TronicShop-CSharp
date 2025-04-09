using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using System.Diagnostics;
using TronicShop.Models;
using TronicShop.Repositories;

namespace TronicShop.Utils
{
    internal class ReporteUtils
    {
        public static void GenerarFacturaPDF(Venta venta, List<DetalleVenta> detalles, string nombreCliente, string nombreUsuario)
        {
            var configRepo = new ConfiguraciónRepository();
            var config = configRepo.GetAll();
            if (config == null) return;

            using SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Archivo PDF|*.pdf";
            saveFileDialog.Title = "Guardar Factura";
            saveFileDialog.FileName = $"factura_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (saveFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                MessageBox.Show("Exportación cancelada por el usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ruta = saveFileDialog.FileName;
            using var fs = new FileStream(ruta, FileMode.Create, FileAccess.Write, FileShare.None);
            using var doc = new Document(PageSize.A4, 40, 40, 40, 40);
            var writer = PdfWriter.GetInstance(doc, fs);

            doc.Open();

            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);
            var fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

            // Encabezado
            doc.Add(new Paragraph(config.NombreEmpresa, fuenteTitulo));
            doc.Add(new Paragraph($"RNC: {config.RNC}", fuenteNormal));
            doc.Add(new Paragraph($"Dirección: {config.Direccion}", fuenteNormal));
            doc.Add(new Paragraph(" "));

            // Cliente y venta info
            doc.Add(new Paragraph($"Cliente: {nombreCliente}", fuenteNormal));
            doc.Add(new Paragraph($"Vendedor: {nombreUsuario}", fuenteNormal));
            doc.Add(new Paragraph($"Fecha: {DateTime.Now:dd/MM/yyyy hh:mm tt}", fuenteNormal));
            doc.Add(new Paragraph(" "));

            // Tabla de productos
            var tabla = new PdfPTable(4) { WidthPercentage = 100 };
            tabla.AddCell(new Phrase("Producto", fuenteNegrita));
            tabla.AddCell(new Phrase("Cantidad", fuenteNegrita));
            tabla.AddCell(new Phrase("Precio", fuenteNegrita));
            tabla.AddCell(new Phrase("Total", fuenteNegrita));

            decimal subtotal = 0;
            foreach (var item in detalles)
            {
                tabla.AddCell(new Phrase(item.ProductoNombre, fuenteNormal));
                tabla.AddCell(new Phrase(item.Cantidad.ToString(), fuenteNormal));
                tabla.AddCell(new Phrase(item.PrecioUnitario.ToString("C"), fuenteNormal));
                tabla.AddCell(new Phrase(item.TotalLinea.ToString("C"), fuenteNormal));
                subtotal += item.TotalLinea;
            }

            doc.Add(tabla);
            doc.Add(new Paragraph(" "));

            // Totales
            decimal itbis = config.Impuesto;
            decimal montoITBIS = subtotal * itbis;
            decimal total = subtotal + montoITBIS;

            doc.Add(new Paragraph($"Subtotal: {subtotal:C}", fuenteNormal));
            doc.Add(new Paragraph($"ITBIS ({(itbis * 100):F2}%): {montoITBIS:C}", fuenteNormal));
            doc.Add(new Paragraph($"Total: {total:C}", fuenteNegrita));

            doc.Close();

            // Abrir el PDF automáticamente
            Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
        }
        public static bool? GenerarFacturaDesdeVenta(Venta venta)
        {
            if (venta == null || venta.Detalles == null || venta.Detalles.Count == 0)
            {
                MessageBox.Show("Venta inválida o sin detalles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            try
            {
                using var sfd = new SaveFileDialog
                {
                    Title = "Guardar Factura",
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    FileName = $"factura_{venta.Id}_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
                };

                if (sfd.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(sfd.FileName))
                {
                    return null; // usuario canceló
                }

                using var fs = new FileStream(sfd.FileName, FileMode.Create);
                using var doc = new Document(PageSize.Letter, 40, 40, 40, 40);
                PdfWriter.GetInstance(doc, fs);
                doc.Open();

                var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                var fuenteNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);

                doc.Add(new Paragraph("FACTURA DE VENTA", fuenteTitulo) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph(" "));

                doc.Add(new Paragraph($"Fecha: {venta.Fecha:dd/MM/yyyy hh:mm tt}", fuenteNormal));
                doc.Add(new Paragraph($"Cliente: {venta.ClienteNombre}", fuenteNormal));
                doc.Add(new Paragraph($"Vendedor: {venta.UsuarioNombre}", fuenteNormal));
                doc.Add(new Paragraph(" "));

                var tabla = new PdfPTable(4) { WidthPercentage = 100 };
                tabla.SetWidths(new float[] { 3, 1, 1, 1 });

                tabla.AddCell(new Phrase("Producto", fuenteNegrita));
                tabla.AddCell(new Phrase("Cantidad", fuenteNegrita));
                tabla.AddCell(new Phrase("Precio", fuenteNegrita));
                tabla.AddCell(new Phrase("Total", fuenteNegrita));

                foreach (var d in venta.Detalles)
                {
                    tabla.AddCell(new Phrase(d.ProductoNombre, fuenteNormal));
                    tabla.AddCell(new Phrase(d.Cantidad.ToString(), fuenteNormal));
                    tabla.AddCell(new Phrase($"RD$ {d.PrecioUnitario:0.00}", fuenteNormal));
                    tabla.AddCell(new Phrase($"RD$ {d.TotalLinea:0.00}", fuenteNormal));
                }

                doc.Add(tabla);
                doc.Add(new Paragraph(" "));
                doc.Add(new Paragraph($"Total General: RD$ {venta.Total:0.00}", fuenteNegrita) { Alignment = Element.ALIGN_RIGHT });

                doc.Close();
                Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar la factura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static void ProductosPDF(List<Producto> productos)
        {
            var configRepo = new ConfiguraciónRepository();
            var config = configRepo.GetAll();
            if (config == null) return;

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Archivo PDF|*.pdf",
                Title = "Guardar Reporte de Productos",
                FileName = $"Reporte_Productos_{DateTime.Now:yyyyMMddHHmmss}.pdf"
            };

            if (sfd.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(sfd.FileName))
            {
                MessageBox.Show("Exportación cancelada por el usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string ruta = sfd.FileName;

            Document doc = new Document(PageSize.Letter.Rotate(), 20, 20, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            var fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
            var fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
            var fontRow = FontFactory.GetFont(FontFactory.HELVETICA, 9);

            doc.Add(new Paragraph(config.NombreEmpresa, fontTitle) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("REPORTE DE PRODUCTOS", fontTitle) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(6) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 2, 2, 1, 1, 1, 2 });

            string[] headers = { "Producto", "Código", "Precio", "Stock", "Creado", "Proveedor" };
            foreach (var h in headers)
            {
                tabla.AddCell(new PdfPCell(new Phrase(h, fontHeader)) { BackgroundColor = BaseColor.LightGray });
            }

            foreach (var p in productos)
            {
                tabla.AddCell(new Phrase(p.Nombre, fontRow));
                tabla.AddCell(new Phrase(p.CódigoBarra, fontRow));
                tabla.AddCell(new Phrase($"RD$ {p.Precio:0.00}", fontRow));
                tabla.AddCell(new Phrase(p.Stock.ToString(), fontRow));
                tabla.AddCell(new Phrase(p.FechaCreado.ToString("dd/MM/yyyy hh:mm tt"), fontRow));
                tabla.AddCell(new Phrase(p.NombreProveedor));
            }

            doc.Add(tabla);
            doc.Close();

            MessageBox.Show("Reporte PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
        }
        public static bool? GenerarFacturaExcel(Venta venta, List<DetalleVenta> detalles, string nombreCliente, string nombreUsuario)
        {
            var configRepo = new ConfiguraciónRepository();
            var config = configRepo.GetAll();
            if (config == null) return false;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Guardar Factura en Excel",
                FileName = $"factura_{venta.Id}_{DateTime.Now:yyyyMMddHHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK || string.IsNullOrWhiteSpace(saveFileDialog.FileName))
            {
                return null; 
            }

            try
            {
                using (var wb = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Factura");

                    int fila = 1;
                    ws.Cell(fila++, 1).Value = config.NombreEmpresa;
                    ws.Cell(fila++, 1).Value = $"Cliente: {nombreCliente}";
                    ws.Cell(fila++, 1).Value = $"Vendedor: {nombreUsuario}";
                    ws.Cell(fila++, 1).Value = $"Fecha: {venta.Fecha:dd/MM/yyyy hh:mm tt}";
                    fila++;

                    ws.Cell(fila, 1).Value = "Producto";
                    ws.Cell(fila, 2).Value = "Cantidad";
                    ws.Cell(fila, 3).Value = "Precio Unitario";
                    ws.Cell(fila, 4).Value = "Total Línea";
                    fila++;

                    foreach (var d in detalles)
                    {
                        ws.Cell(fila, 1).Value = d.ProductoNombre;
                        ws.Cell(fila, 2).Value = d.Cantidad;
                        ws.Cell(fila, 3).Value = d.PrecioUnitario;
                        ws.Cell(fila, 4).Value = d.TotalLinea;
                        fila++;
                    }

                    decimal subtotal = detalles.Sum(x => x.TotalLinea);
                    decimal itbisDecimal = config.Impuesto;
                    decimal montoITBIS = subtotal * itbisDecimal;
                    decimal totalFinal = subtotal + montoITBIS;

                    fila++;
                    ws.Cell(fila++, 3).Value = "Subtotal:";
                    ws.Cell(fila - 1, 4).Value = subtotal;
                    ws.Cell(fila++, 3).Value = $"ITBIS ({itbisDecimal * 100:F2}%):";
                    ws.Cell(fila - 1, 4).Value = montoITBIS;
                    ws.Cell(fila++, 3).Value = "Total:";
                    ws.Cell(fila - 1, 4).Value = totalFinal;

                    wb.SaveAs(saveFileDialog.FileName);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al exportar Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static void GenerarReporteProductosExcel(List<Producto> productos)
        {
            var configRepo = new ConfiguraciónRepository();
            var config = configRepo.GetAll();
            if (config == null) return;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Guardar Reporte de Productos",
                FileName = $"productos_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            using (var wb = new ClosedXML.Excel.XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Productos");

                int fila = 1;
                ws.Cell(fila++, 1).Value = config.NombreEmpresa;
                ws.Cell(fila++, 1).Value = $"Reporte de Productos - {DateTime.Now:dd/MM/yyyy hh:mm tt}";
                fila++;

                // Encabezados
                ws.Cell(fila, 1).Value = "Nombre";
                ws.Cell(fila, 2).Value = "Precio";
                ws.Cell(fila, 3).Value = "Stock";
                ws.Cell(fila, 4).Value = "Estado";
                ws.Cell(fila, 5).Value = "Fecha creación";
                fila++;

                foreach (var p in productos)
                {
                    ws.Cell(fila, 1).Value = p.Nombre;
                    ws.Cell(fila, 2).Value = p.Precio;
                    ws.Cell(fila, 3).Value = p.Stock;
                    ws.Cell(fila, 4).Value = p.Estado ? "Activo" : "Inactivo";
                    ws.Cell(fila, 5).Value = p.FechaCreado.ToString("dd/MM/yyyy hh:mm tt");
                    fila++;
                }

                wb.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Productos exportados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}