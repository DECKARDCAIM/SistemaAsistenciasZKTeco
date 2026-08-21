using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Sistema.Presentacion.Utils
{
    public static class ReporteExporter
    {
        public static string ObtenerCarpetaFormatos()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string formatosDir = Path.Combine(baseDir, "FormatosReportes");
            if (!Directory.Exists(formatosDir))
            {
                Directory.CreateDirectory(formatosDir);
            }
            return formatosDir;
        }

        public static void ExportarDataGridViewConDialogo(
            DataGridView dgv,
            string tituloReporte,
            string subtitulo = "",
            Dictionary<string, string> metadatos = null)
        {
            if (dgv == null || dgv.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos disponibles para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                string sanitizedTitle = tituloReporte.Replace(" ", "_").Replace("/", "-");
                sfd.Filter = "Hoja de Cálculo Excel (*.xls)|*.xls|Reporte Web Imprimible (*.html)|*.html|Valores Separados por Comas (*.csv)|*.csv";
                sfd.FileName = $"{sanitizedTitle}_{DateTime.Now:yyyyMMdd_HHmmss}.xls";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string extension = Path.GetExtension(sfd.FileName).ToLower();
                        string contenido = "";

                        if (extension == ".csv")
                        {
                            contenido = GenerarCSV(dgv);
                            File.WriteAllText(sfd.FileName, contenido, Encoding.UTF8);
                        }
                        else if (extension == ".html" || extension == ".htm")
                        {
                            contenido = GenerarHTMLReporte(dgv, tituloReporte, subtitulo, metadatos, false);
                            File.WriteAllText(sfd.FileName, contenido, Encoding.UTF8);
                        }
                        else // .xls (Excel HTML formatted)
                        {
                            contenido = GenerarHTMLReporte(dgv, tituloReporte, subtitulo, metadatos, true);
                            File.WriteAllText(sfd.FileName, contenido, Encoding.UTF8);
                        }

                        // Guardar copia de respaldo en la carpeta oficial FormatosReportes
                        try
                        {
                            string backupPath = Path.Combine(ObtenerCarpetaFormatos(), Path.GetFileName(sfd.FileName));
                            File.WriteAllText(backupPath, contenido, Encoding.UTF8);
                        }
                        catch { }

                        var resp = MessageBox.Show(
                            $"Reporte generado exitosamente:\n\n{sfd.FileName}\n\n¿Desea abrir el archivo ahora?",
                            "Exportación Completa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (resp == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al generar el archivo de reporte:\n" + ex.Message, "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private static string GenerarCSV(DataGridView dgv)
        {
            StringBuilder sb = new StringBuilder();
            List<string> headers = new List<string>();
            List<int> colIdxs = new List<int>();

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    headers.Add("\"" + dgv.Columns[i].HeaderText.Replace("\"", "\"\"") + "\"");
                    colIdxs.Add(i);
                }
            }
            sb.AppendLine(string.Join(",", headers));

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    List<string> cells = new List<string>();
                    foreach (int idx in colIdxs)
                    {
                        object val = row.Cells[idx].Value;
                        string str = val != null ? val.ToString().Trim() : "";
                        if (val is DateTime dt)
                            str = dt.ToString("yyyy-MM-dd HH:mm:ss");
                        cells.Add("\"" + str.Replace("\"", "\"\"") + "\"");
                    }
                    sb.AppendLine(string.Join(",", cells));
                }
            }
            return sb.ToString();
        }

        private static string GenerarHTMLReporte(
            DataGridView dgv,
            string titulo,
            string subtitulo,
            Dictionary<string, string> metadatos,
            bool esExcel)
        {
            StringBuilder sb = new StringBuilder();

            if (esExcel)
            {
                sb.AppendLine("<html xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\">");
                sb.AppendLine("<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
                sb.AppendLine("<!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>Reporte</x:Name><x:WorksheetOptions><x:DisplayGridlines/></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]-->");
            }
            else
            {
                sb.AppendLine("<!DOCTYPE html>");
                sb.AppendLine("<html lang=\"es\">");
                sb.AppendLine("<head><meta charset=\"utf-8\"><meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\">");
            }

            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif; margin: 20px; background-color: #f8fafc; color: #1e293b; }");
            sb.AppendLine(".header-container { background: linear-gradient(135deg, #1e3a8a, #0284c7); color: white; padding: 20px 25px; border-radius: 8px; margin-bottom: 20px; box-shadow: 0 4px 6px -1px rgba(0,0,0,0.1); }");
            sb.AppendLine(".header-title { font-size: 22px; font-weight: bold; margin: 0 0 5px 0; letter-spacing: 0.5px; }");
            sb.AppendLine(".header-sub { font-size: 14px; opacity: 0.9; margin: 0; }");
            sb.AppendLine(".meta-grid { display: table; width: 100%; margin-top: 15px; padding-top: 12px; border-top: 1px solid rgba(255,255,255,0.25); font-size: 12px; }");
            sb.AppendLine(".meta-item { display: table-cell; padding-right: 20px; }");
            sb.AppendLine(".table-container { background: white; border-radius: 8px; overflow: hidden; box-shadow: 0 1px 3px rgba(0,0,0,0.1); border: 1px solid #e2e8f0; }");
            sb.AppendLine("table { width: 100%; border-collapse: collapse; font-size: 12px; text-align: left; }");
            sb.AppendLine("th { background-color: #0f172a; color: #ffffff; font-weight: 600; padding: 10px 12px; border-bottom: 2px solid #0284c7; text-transform: uppercase; font-size: 11px; letter-spacing: 0.5px; }");
            sb.AppendLine("td { padding: 9px 12px; border-bottom: 1px solid #e2e8f0; vertical-align: middle; }");
            sb.AppendLine("tr:nth-child(even) { background-color: #f8fafc; }");
            sb.AppendLine("tr:hover { background-color: #f1f5f9; }");
            sb.AppendLine(".badge-ok { background-color: #dcfce7; color: #15803d; font-weight: bold; padding: 3px 8px; border-radius: 4px; display: inline-block; }");
            sb.AppendLine(".badge-warn { background-color: #ffedd5; color: #c2410c; font-weight: bold; padding: 3px 8px; border-radius: 4px; display: inline-block; }");
            sb.AppendLine(".badge-danger { background-color: #fee2e2; color: #b91c1c; font-weight: bold; padding: 3px 8px; border-radius: 4px; display: inline-block; }");
            sb.AppendLine(".badge-info { background-color: #e0f2fe; color: #0369a1; font-weight: bold; padding: 3px 8px; border-radius: 4px; display: inline-block; }");
            sb.AppendLine(".footer-summary { margin-top: 20px; font-size: 12px; color: #64748b; text-align: right; font-weight: bold; }");
            sb.AppendLine("@media print { body { margin: 0; background: white; } .header-container { box-shadow: none; } }");
            sb.AppendLine("</style>");
            sb.AppendLine("</head><body>");

            // Header Banner
            sb.AppendLine("<div class=\"header-container\">");
            sb.AppendLine($"  <div class=\"header-title\">HOSPITAL DE EL PROGRESO - {titulo.ToUpper()}</div>");
            sb.AppendLine($"  <div class=\"header-sub\">Ministerio de Salud Pública y Asistencia Social {(string.IsNullOrEmpty(subtitulo) ? "" : "• " + subtitulo)}</div>");

            sb.AppendLine("  <div class=\"meta-grid\">");
            sb.AppendLine($"    <div class=\"meta-item\"><strong>Fecha de Emisión:</strong> {DateTime.Now:dd/MM/yyyy hh:mm tt}</div>");
            sb.AppendLine($"    <div class=\"meta-item\"><strong>Total de Registros:</strong> {dgv.Rows.Count}</div>");
            if (metadatos != null)
            {
                foreach (var kvp in metadatos)
                {
                    sb.AppendLine($"    <div class=\"meta-item\"><strong>{kvp.Key}:</strong> {kvp.Value}</div>");
                }
            }
            sb.AppendLine("  </div>");
            sb.AppendLine("</div>");

            // Table
            sb.AppendLine("<div class=\"table-container\">");
            sb.AppendLine("<table border=\"1\" cellpadding=\"5\" cellspacing=\"0\">");
            sb.AppendLine("<thead><tr>");

            List<int> colIndices = new List<int>();
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible)
                {
                    colIndices.Add(i);
                    sb.AppendLine($"  <th>{dgv.Columns[i].HeaderText}</th>");
                }
            }
            sb.AppendLine("</tr></thead><tbody>");

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                sb.AppendLine("<tr>");
                foreach (int idx in colIndices)
                {
                    object val = row.Cells[idx].Value;
                    string str = val != null ? val.ToString().Trim() : "";
                    string colName = dgv.Columns[idx].Name.ToLower();

                    if (val is DateTime dt)
                    {
                        str = dt.ToString("yyyy-MM-dd HH:mm:ss");
                    }

                    // Format status badges
                    if (colName.Contains("estado"))
                    {
                        if (str.IndexOf("Completo", StringComparison.OrdinalIgnoreCase) >= 0)
                            str = $"<span class=\"badge-ok\">{str}</span>";
                        else if (str.IndexOf("Tardanza", StringComparison.OrdinalIgnoreCase) >= 0)
                            str = $"<span class=\"badge-warn\">{str}</span>";
                        else if (str.IndexOf("No Marcó", StringComparison.OrdinalIgnoreCase) >= 0 || str.IndexOf("No Marco", StringComparison.OrdinalIgnoreCase) >= 0)
                            str = $"<span class=\"badge-danger\">{str}</span>";
                        else
                            str = $"<span class=\"badge-info\">{str}</span>";
                    }

                    sb.AppendLine($"  <td>{str}</td>");
                }
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</tbody></table>");
            sb.AppendLine("</div>");

            sb.AppendLine($"<div class=\"footer-summary\">Reporte Oficial emitido por Sistema ZKTeco • Hospital de El Progreso • Total: {dgv.Rows.Count} registro(s)</div>");
            sb.AppendLine("</body></html>");

            return sb.ToString();
        }
    }
}
