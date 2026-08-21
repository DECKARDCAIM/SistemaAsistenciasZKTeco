using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Entidades;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmAsistencias : RJCodeUI_M1.RJForms.RJChildForm
    {
        private DataTable dtActual;

        public FrmAsistencias()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.CalendarCheck;
            this.Text = "Marcaciones y Asistencias";
            this.tabPrincipal.Appearance = TabAppearance.FlatButtons;
            this.tabPrincipal.ItemSize = new Size(0, 1);
            this.tabPrincipal.SizeMode = TabSizeMode.Fixed;
        }

        private void FrmAsistencias_Load(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(this);
            dtpDesde.Value = DateTime.Today;
            dtpHasta.Value = DateTime.Today;
            dgvAsistencias.CellFormatting += dgvAsistencias_CellFormatting;
            dgvAsistencias.CellDoubleClick += dgvAsistencias_CellDoubleClick;
            CargarCombosFiltros();
            Consultar();
        }

        private void dgvAsistencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvAsistencias.Columns.Contains("estado") && e.ColumnIndex == dgvAsistencias.Columns["estado"].Index && e.Value != null)
            {
                string estado = e.Value.ToString();
                if (estado.StartsWith("No Marcó", StringComparison.OrdinalIgnoreCase) || estado.StartsWith("No Marco", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(220, 38, 38);
                    e.CellStyle.Font = new Font(dgvAsistencias.Font, FontStyle.Bold);
                }
                else if (estado.StartsWith("Tardanza", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(234, 88, 12);
                    e.CellStyle.Font = new Font(dgvAsistencias.Font, FontStyle.Bold);
                }
                else if (estado.Equals("Completo", StringComparison.OrdinalIgnoreCase))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(22, 163, 74);
                    e.CellStyle.Font = new Font(dgvAsistencias.Font, FontStyle.Bold);
                }
                else if (estado.Contains("Almuerzo"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(14, 116, 144);
                    e.CellStyle.Font = new Font(dgvAsistencias.Font, FontStyle.Bold);
                }
                else if (estado.Contains("Incompleto") || estado.Contains("Jornada"))
                {
                    e.CellStyle.ForeColor = Color.FromArgb(100, 116, 139);
                    e.CellStyle.Font = new Font(dgvAsistencias.Font, FontStyle.Regular);
                }
            }
        }

        private void CargarCombosFiltros()
        {
            try
            {
                DataTable dtDept = N_Departamento.Seleccionar();
                DataRow rowDept = dtDept.NewRow();
                rowDept["id"] = 0;
                rowDept["nombre"] = "-- Todos los Departamentos --";
                dtDept.Rows.InsertAt(rowDept, 0);
                cboDepartamento.DataSource = dtDept;
                cboDepartamento.ValueMember = "id";
                cboDepartamento.DisplayMember = "nombre";
                cboDepartamento.SelectedIndex = 0;

                DataTable dtTurno = N_Horario.SeleccionarTurnos();
                DataRow rowTurno = dtTurno.NewRow();
                rowTurno["idturno"] = 0;
                rowTurno["nombre"] = "-- Todos los Turnos --";
                dtTurno.Rows.InsertAt(rowTurno, 0);
                cboTurno.DataSource = dtTurno;
                cboTurno.ValueMember = "idturno";
                cboTurno.DisplayMember = "nombre";
                cboTurno.SelectedIndex = 0;

                DataTable dtEmp = N_Empleado.SeleccionarActivos();
                DataRow rowEmp = dtEmp.NewRow();
                rowEmp["idempleado"] = 0;
                rowEmp["nombre_completo"] = "-- Todos los Empleados --";
                dtEmp.Rows.InsertAt(rowEmp, 0);
                cboEmpleado.DataSource = dtEmp;
                cboEmpleado.ValueMember = "idempleado";
                cboEmpleado.DisplayMember = "nombre_completo";
                cboEmpleado.SelectedIndex = 0;
            }
            catch
            {
            }
        }

        private void rdoModo_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton rdo && rdo.Checked)
            {
                Consultar();
            }
        }

        private void Consultar()
        {
            try
            {
                DateTime desde = dtpDesde.Value.Date;
                DateTime hasta = dtpHasta.Value.Date.AddDays(1).AddTicks(-1);

                int? idDepartamento = null;
                if (cboDepartamento.SelectedValue != null && Convert.ToInt32(cboDepartamento.SelectedValue) > 0)
                    idDepartamento = Convert.ToInt32(cboDepartamento.SelectedValue);

                int? idTurno = null;
                if (cboTurno.SelectedValue != null && Convert.ToInt32(cboTurno.SelectedValue) > 0)
                    idTurno = Convert.ToInt32(cboTurno.SelectedValue);

                int? idEmpleado = null;
                if (cboEmpleado.SelectedValue != null && Convert.ToInt32(cboEmpleado.SelectedValue) > 0)
                    idEmpleado = Convert.ToInt32(cboEmpleado.SelectedValue);

                string buscar = txtBuscar.Text.Trim();

                if (rdoConsolidado.Checked)
                {
                    dtActual = N_Asistencia.GenerarReporteConsolidado(desde, hasta, idDepartamento, idEmpleado, idTurno, buscar);
                    dgvAsistencias.DataSource = dtActual;
                    FormatearGridConsolidado();
                    lblTotal.Text = "Reporte Consolidado: " + dtActual.Rows.Count + " días/registros";
                }
                else
                {
                    dtActual = N_Asistencia.Listar(desde, hasta, idEmpleado, null, idDepartamento, idTurno, buscar);
                    dgvAsistencias.DataSource = dtActual;
                    FormatearGridDetallado();
                    lblTotal.Text = "Marcaciones Individuales: " + dtActual.Rows.Count + " registros";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar asistencias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGridConsolidado()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvAsistencias);

            if (dgvAsistencias.Columns.Count > 0)
            {
                if (dgvAsistencias.Columns.Contains("idempleado"))
                    dgvAsistencias.Columns["idempleado"].Visible = false;

                if (dgvAsistencias.Columns.Contains("department_id"))
                    dgvAsistencias.Columns["department_id"].Visible = false;

                if (dgvAsistencias.Columns.Contains("turnoid"))
                    dgvAsistencias.Columns["turnoid"].Visible = false;

                if (dgvAsistencias.Columns.Contains("total_marcaciones"))
                    dgvAsistencias.Columns["total_marcaciones"].Visible = false;

                if (dgvAsistencias.Columns.Contains("codigo_empleado"))
                {
                    dgvAsistencias.Columns["codigo_empleado"].HeaderText = "Cód.";
                    dgvAsistencias.Columns["codigo_empleado"].FillWeight = 45;
                    dgvAsistencias.Columns["codigo_empleado"].MinimumWidth = 45;
                }

                if (dgvAsistencias.Columns.Contains("empleado"))
                {
                    dgvAsistencias.Columns["empleado"].HeaderText = "Empleado";
                    dgvAsistencias.Columns["empleado"].FillWeight = 160;
                    dgvAsistencias.Columns["empleado"].MinimumWidth = 120;
                }

                if (dgvAsistencias.Columns.Contains("departamento"))
                {
                    dgvAsistencias.Columns["departamento"].HeaderText = "Departamento";
                    dgvAsistencias.Columns["departamento"].FillWeight = 100;
                    dgvAsistencias.Columns["departamento"].MinimumWidth = 80;
                }

                if (dgvAsistencias.Columns.Contains("turno"))
                {
                    dgvAsistencias.Columns["turno"].HeaderText = "Turno";
                    dgvAsistencias.Columns["turno"].FillWeight = 90;
                    dgvAsistencias.Columns["turno"].MinimumWidth = 70;
                }

                if (dgvAsistencias.Columns.Contains("fecha"))
                {
                    dgvAsistencias.Columns["fecha"].HeaderText = "Fecha";
                    dgvAsistencias.Columns["fecha"].FillWeight = 75;
                    dgvAsistencias.Columns["fecha"].MinimumWidth = 65;
                    dgvAsistencias.Columns["fecha"].DefaultCellStyle.Format = "yyyy-MM-dd";
                }

                if (dgvAsistencias.Columns.Contains("hora_entrada"))
                {
                    dgvAsistencias.Columns["hora_entrada"].HeaderText = "🟢 Entrada";
                    dgvAsistencias.Columns["hora_entrada"].FillWeight = 65;
                    dgvAsistencias.Columns["hora_entrada"].MinimumWidth = 60;
                }

                if (dgvAsistencias.Columns.Contains("salida_almuerzo"))
                {
                    dgvAsistencias.Columns["salida_almuerzo"].HeaderText = "🍽️ Sal. Almuerzo";
                    dgvAsistencias.Columns["salida_almuerzo"].FillWeight = 75;
                    dgvAsistencias.Columns["salida_almuerzo"].MinimumWidth = 65;
                }

                if (dgvAsistencias.Columns.Contains("regreso_almuerzo"))
                {
                    dgvAsistencias.Columns["regreso_almuerzo"].HeaderText = "↩️ Reg. Almuerzo";
                    dgvAsistencias.Columns["regreso_almuerzo"].FillWeight = 75;
                    dgvAsistencias.Columns["regreso_almuerzo"].MinimumWidth = 65;
                }

                if (dgvAsistencias.Columns.Contains("hora_salida"))
                {
                    dgvAsistencias.Columns["hora_salida"].HeaderText = "🔴 Salida";
                    dgvAsistencias.Columns["hora_salida"].FillWeight = 65;
                    dgvAsistencias.Columns["hora_salida"].MinimumWidth = 60;
                }

                if (dgvAsistencias.Columns.Contains("horas_trabajadas"))
                {
                    dgvAsistencias.Columns["horas_trabajadas"].HeaderText = "⏱️ Horas Trab.";
                    dgvAsistencias.Columns["horas_trabajadas"].FillWeight = 60;
                    dgvAsistencias.Columns["horas_trabajadas"].MinimumWidth = 55;
                }

                if (dgvAsistencias.Columns.Contains("estado"))
                {
                    dgvAsistencias.Columns["estado"].HeaderText = "Estado";
                    dgvAsistencias.Columns["estado"].FillWeight = 90;
                    dgvAsistencias.Columns["estado"].MinimumWidth = 80;
                }
            }
        }

        private void FormatearGridDetallado()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvAsistencias);

            if (dgvAsistencias.Columns.Count > 0)
            {
                if (dgvAsistencias.Columns.Contains("idasistencia"))
                {
                    dgvAsistencias.Columns["idasistencia"].HeaderText = "ID";
                    dgvAsistencias.Columns["idasistencia"].FillWeight = 40;
                    dgvAsistencias.Columns["idasistencia"].MinimumWidth = 35;
                }

                if (dgvAsistencias.Columns.Contains("idempleado"))
                    dgvAsistencias.Columns["idempleado"].Visible = false;

                if (dgvAsistencias.Columns.Contains("idbiometrico"))
                    dgvAsistencias.Columns["idbiometrico"].Visible = false;

                if (dgvAsistencias.Columns.Contains("tipo_marcacion"))
                    dgvAsistencias.Columns["tipo_marcacion"].Visible = false;

                if (dgvAsistencias.Columns.Contains("metodo_verificacion"))
                    dgvAsistencias.Columns["metodo_verificacion"].Visible = false;

                if (dgvAsistencias.Columns.Contains("fecha_registro"))
                    dgvAsistencias.Columns["fecha_registro"].Visible = false;

                if (dgvAsistencias.Columns.Contains("codigo_biometrico"))
                {
                    dgvAsistencias.Columns["codigo_biometrico"].HeaderText = "Cód.";
                    dgvAsistencias.Columns["codigo_biometrico"].FillWeight = 50;
                    dgvAsistencias.Columns["codigo_biometrico"].MinimumWidth = 45;
                }

                if (dgvAsistencias.Columns.Contains("empleado"))
                {
                    dgvAsistencias.Columns["empleado"].HeaderText = "Empleado";
                    dgvAsistencias.Columns["empleado"].FillWeight = 160;
                    dgvAsistencias.Columns["empleado"].MinimumWidth = 120;
                }

                if (dgvAsistencias.Columns.Contains("departamento"))
                {
                    dgvAsistencias.Columns["departamento"].HeaderText = "Departamento";
                    dgvAsistencias.Columns["departamento"].FillWeight = 100;
                    dgvAsistencias.Columns["departamento"].MinimumWidth = 80;
                }

                if (dgvAsistencias.Columns.Contains("turno"))
                {
                    dgvAsistencias.Columns["turno"].HeaderText = "Turno";
                    dgvAsistencias.Columns["turno"].FillWeight = 90;
                    dgvAsistencias.Columns["turno"].MinimumWidth = 70;
                }

                if (dgvAsistencias.Columns.Contains("fecha_hora"))
                {
                    dgvAsistencias.Columns["fecha_hora"].HeaderText = "Fecha y Hora";
                    dgvAsistencias.Columns["fecha_hora"].FillWeight = 110;
                    dgvAsistencias.Columns["fecha_hora"].MinimumWidth = 90;
                    dgvAsistencias.Columns["fecha_hora"].DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss";
                }

                if (dgvAsistencias.Columns.Contains("tipo_descripcion"))
                {
                    dgvAsistencias.Columns["tipo_descripcion"].HeaderText = "Tipo";
                    dgvAsistencias.Columns["tipo_descripcion"].Width = 110;
                }

                if (dgvAsistencias.Columns.Contains("metodo_descripcion"))
                {
                    dgvAsistencias.Columns["metodo_descripcion"].HeaderText = "Método";
                    dgvAsistencias.Columns["metodo_descripcion"].Width = 100;
                }

                if (dgvAsistencias.Columns.Contains("biometrico"))
                {
                    dgvAsistencias.Columns["biometrico"].HeaderText = "Dispositivo Biométrico";
                    dgvAsistencias.Columns["biometrico"].Width = 140;
                }
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Consultar();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Consultar();
            }
        }

        private void dgvAsistencias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvAsistencias.Rows.Count > e.RowIndex)
            {
                DataGridViewRow fila = dgvAsistencias.Rows[e.RowIndex];
                if (rdoConsolidado.Checked)
                {
                    string empleado = "";
                    if (dgvAsistencias.Columns.Contains("empleado") && fila.Cells["empleado"].Value != null)
                        empleado = fila.Cells["empleado"].Value.ToString();
                    else if (dgvAsistencias.Columns.Contains("codigo_empleado") && fila.Cells["codigo_empleado"].Value != null)
                        empleado = fila.Cells["codigo_empleado"].Value.ToString();

                    if (dgvAsistencias.Columns.Contains("fecha") && fila.Cells["fecha"].Value != null && DateTime.TryParse(fila.Cells["fecha"].Value.ToString(), out DateTime fechaFila))
                    {
                        dtpDesde.Value = fechaFila;
                        dtpHasta.Value = fechaFila;
                    }

                    txtBuscar.Text = empleado;
                    rdoDetallado.Checked = true;
                }
                else
                {
                    string emp = dgvAsistencias.Columns.Contains("empleado") && fila.Cells["empleado"].Value != null ? fila.Cells["empleado"].Value.ToString() : "Empleado";
                    string fechaHora = dgvAsistencias.Columns.Contains("fecha_hora") && fila.Cells["fecha_hora"].Value != null ? fila.Cells["fecha_hora"].Value.ToString() : "";
                    string bio = dgvAsistencias.Columns.Contains("nombre_biometrico") && fila.Cells["nombre_biometrico"].Value != null ? fila.Cells["nombre_biometrico"].Value.ToString() : "";
                    string depto = dgvAsistencias.Columns.Contains("departamento") && fila.Cells["departamento"].Value != null ? fila.Cells["departamento"].Value.ToString() : "";
                    string turno = dgvAsistencias.Columns.Contains("turno") && fila.Cells["turno"].Value != null ? fila.Cells["turno"].Value.ToString() : "";
                    string estado = dgvAsistencias.Columns.Contains("estado_asistencia") && fila.Cells["estado_asistencia"].Value != null ? fila.Cells["estado_asistencia"].Value.ToString() : "";

                    string info = $"📋 DETALLES DE MARCACIÓN BIOMÉTRICA\n\n" +
                                  $"👤 Empleado: {emp}\n" +
                                  $"🏢 Departamento: {depto}\n" +
                                  $"⏱️ Turno: {turno}\n" +
                                  $"📅 Fecha y Hora: {fechaHora}\n" +
                                  $"📡 Dispositivo Reloj: {bio}\n" +
                                  $"📌 Estado: {estado}";

                    MessageBox.Show(info, "Detalle de Marcación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            string titulo = rdoConsolidado.Checked ? "Reporte_Consolidado_Asistencias" : "Reporte_Marcaciones_Detalladas";
            string subtitulo = rdoConsolidado.Checked ? "Control Consolidado Diario" : "Registro Detallado de Marcaciones";

            var meta = new Dictionary<string, string>
            {
                { "Periodo", $"{dtpDesde.Value:yyyy-MM-dd} al {dtpHasta.Value:yyyy-MM-dd}" },
                { "Departamento", cboDepartamento.Text },
                { "Turno", cboTurno.Text },
                { "Modalidad", rdoConsolidado.Checked ? "Consolidado" : "Detallado" }
            };

            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvAsistencias,
                titulo,
                subtitulo,
                meta);
        }

        private async void btnDescargarBio_Click(object sender, EventArgs e)
        {
            try
            {
                List<Biometrico> dispositivos = N_Biometrico.ListarActivos();
                if (dispositivos == null || dispositivos.Count == 0)
                {
                    MessageBox.Show("No hay dispositivos biométricos activos para sincronizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                Cursor = Cursors.WaitCursor;
                btnDescargarBio.Enabled = false;
                int totalDescargadas = 0;
                List<string> errores = new List<string>();

                await Task.Run(() =>
                {
                    using (ZKTecoService service = new ZKTecoService())
                    {
                        foreach (var bio in dispositivos)
                        {
                            string msgCon;
                            if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msgCon))
                            {
                                try
                                {
                                    string msgLog;
                                    List<Asistencia> marcaciones = service.DescargarMarcaciones(bio.IdBiometrico, bio.Nombre, null, out msgLog);
                                    if (marcaciones != null && marcaciones.Count > 0)
                                    {
                                        int guardadas = N_Asistencia.GuardarMarcacionesMasivas(marcaciones, bio.IdBiometrico, bio.Nombre);
                                        totalDescargadas += guardadas;
                                    }
                                    N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Conectado", DateTime.Now);
                                }
                                catch (Exception ex)
                                {
                                    errores.Add($"{bio.Nombre}: {ex.Message}");
                                }
                                finally
                                {
                                    service.Desconectar();
                                }
                            }
                            else
                            {
                                N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Desconectado");
                                errores.Add($"{bio.Nombre} ({bio.DireccionIP}): {msgCon}");
                            }
                        }
                    }
                });

                string mensaje = $"Sincronización finalizada.\nNuevas marcaciones guardadas: {totalDescargadas}";
                if (errores.Count > 0)
                    mensaje += "\n\nObservaciones:\n" + string.Join("\n", errores);

                MessageBox.Show(mensaje, "Sincronización de Biométricos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error durante la descarga de marcaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDescargarBio.Enabled = true;
                Cursor = Cursors.Default;
            }
        }
    }
}
