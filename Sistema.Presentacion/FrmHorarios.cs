using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Sistema.Entidades;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmHorarios : RJCodeUI_M1.RJForms.RJChildForm
    {
        public FrmHorarios()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.Clock;
            this.tabPrincipal.Appearance = TabAppearance.FlatButtons;
            this.tabPrincipal.ItemSize = new Size(0, 1);
            this.tabPrincipal.SizeMode = TabSizeMode.Fixed;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && !this.Disposing)
            {
                CargarListadoIntervalos();
                CargarListadoTurnos();
            }
        }

        private void FrmHorarios_Load(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(this);
            CargarListadoIntervalos();
            CargarListadoTurnos();
        }

        #region ========================= 1. INTERVALOS DE HORARIO =========================

        private void CargarListadoIntervalos()
        {
            try
            {
                DataTable tabla = N_Horario.ListarIntervalos();
                dgvIntervalos.DataSource = tabla;
                FormatearGridIntervalos();
                lblTotalIntervalos.Text = "Total de intervalos registrados: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar intervalos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGridIntervalos()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvIntervalos);

            if (dgvIntervalos.Columns.Count > 0)
            {
                if (dgvIntervalos.Columns.Contains("idintervalo"))
                {
                    dgvIntervalos.Columns["idintervalo"].HeaderText = "ID";
                    dgvIntervalos.Columns["idintervalo"].FillWeight = 40;
                    dgvIntervalos.Columns["idintervalo"].MinimumWidth = 35;
                }

                if (dgvIntervalos.Columns.Contains("nombre"))
                {
                    dgvIntervalos.Columns["nombre"].HeaderText = "Nombre / Horario";
                    dgvIntervalos.Columns["nombre"].FillWeight = 160;
                    dgvIntervalos.Columns["nombre"].MinimumWidth = 120;
                }

                if (dgvIntervalos.Columns.Contains("hora_entrada"))
                {
                    dgvIntervalos.Columns["hora_entrada"].HeaderText = "Entrada";
                    dgvIntervalos.Columns["hora_entrada"].FillWeight = 70;
                    dgvIntervalos.Columns["hora_entrada"].MinimumWidth = 60;
                }

                if (dgvIntervalos.Columns.Contains("hora_salida"))
                {
                    dgvIntervalos.Columns["hora_salida"].HeaderText = "Salida";
                    dgvIntervalos.Columns["hora_salida"].FillWeight = 70;
                    dgvIntervalos.Columns["hora_salida"].MinimumWidth = 60;
                }

                if (dgvIntervalos.Columns.Contains("duracion_horas"))
                {
                    dgvIntervalos.Columns["duracion_horas"].HeaderText = "Horas Jornada";
                    dgvIntervalos.Columns["duracion_horas"].FillWeight = 75;
                    dgvIntervalos.Columns["duracion_horas"].MinimumWidth = 65;
                }

                if (dgvIntervalos.Columns.Contains("tolerancia_entrada_min"))
                {
                    dgvIntervalos.Columns["tolerancia_entrada_min"].HeaderText = "Tol. Entrada (min)";
                    dgvIntervalos.Columns["tolerancia_entrada_min"].FillWeight = 85;
                    dgvIntervalos.Columns["tolerancia_entrada_min"].MinimumWidth = 70;
                }

                if (dgvIntervalos.Columns.Contains("tolerancia_salida_min"))
                {
                    dgvIntervalos.Columns["tolerancia_salida_min"].HeaderText = "Tol. Salida (min)";
                    dgvIntervalos.Columns["tolerancia_salida_min"].FillWeight = 85;
                    dgvIntervalos.Columns["tolerancia_salida_min"].MinimumWidth = 70;
                }

                if (dgvIntervalos.Columns.Contains("margen_antes_entrada"))
                    dgvIntervalos.Columns["margen_antes_entrada"].Visible = false;

                if (dgvIntervalos.Columns.Contains("margen_despues_entrada"))
                    dgvIntervalos.Columns["margen_despues_entrada"].Visible = false;

                if (dgvIntervalos.Columns.Contains("margen_antes_salida"))
                    dgvIntervalos.Columns["margen_antes_salida"].Visible = false;

                if (dgvIntervalos.Columns.Contains("margen_despues_salida"))
                    dgvIntervalos.Columns["margen_despues_salida"].Visible = false;

                if (dgvIntervalos.Columns.Contains("duracion_minutos"))
                    dgvIntervalos.Columns["duracion_minutos"].Visible = false;

                if (dgvIntervalos.Columns.Contains("dias_computados"))
                    dgvIntervalos.Columns["dias_computados"].Visible = false;

                if (dgvIntervalos.Columns.Contains("entrada_obligatoria"))
                    dgvIntervalos.Columns["entrada_obligatoria"].Visible = false;

                if (dgvIntervalos.Columns.Contains("salida_obligatoria"))
                    dgvIntervalos.Columns["salida_obligatoria"].Visible = false;

                if (dgvIntervalos.Columns.Contains("estado"))
                    dgvIntervalos.Columns["estado"].Visible = false;
            }
        }

        private void btnBuscarIntervalo_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = txtBuscarIntervalo.Text.Trim();
                if (string.IsNullOrWhiteSpace(valor))
                {
                    CargarListadoIntervalos();
                }
                else
                {
                    DataTable tabla = N_Horario.BuscarIntervalos(valor);
                    dgvIntervalos.DataSource = tabla;
                    FormatearGridIntervalos();
                    lblTotalIntervalos.Text = "Total encontrados: " + tabla.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar intervalos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarIntervalo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarIntervalo.PerformClick();
            }
        }

        private void btnNuevoIntervalo_Click(object sender, EventArgs e)
        {
            LimpiarIntervalo();
            lblTituloMantIntervalo.Text = "Nuevo Horario / Intervalo";
            tabPrincipal.SelectedIndex = 1;
            txtAliasIntervalo.Focus();
        }

        private void btnEditarIntervalo_Click(object sender, EventArgs e)
        {
            if (dgvIntervalos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el intervalo de horario que desea editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarParaEdicionIntervalo(dgvIntervalos.CurrentRow);
        }

        private void dgvIntervalos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CargarParaEdicionIntervalo(dgvIntervalos.Rows[e.RowIndex]);
            }
        }

        private void CargarParaEdicionIntervalo(DataGridViewRow fila)
        {
            txtIdIntervalo.Text = Convert.ToString(fila.Cells["idintervalo"].Value);
            txtAliasIntervalo.Text = Convert.ToString(fila.Cells["nombre"].Value);

            if (TimeSpan.TryParse(Convert.ToString(fila.Cells["hora_entrada"].Value), out TimeSpan ent))
            {
                dtpHoraEntrada.Value = DateTime.Today.Add(ent);
            }

            if (TimeSpan.TryParse(Convert.ToString(fila.Cells["hora_salida"].Value), out TimeSpan sal))
            {
                dtpHoraSalida.Value = DateTime.Today.Add(sal);
            }

            nudToleranciaEntrada.Value = Convert.ToDecimal(fila.Cells["tolerancia_entrada_min"].Value);
            nudToleranciaSalida.Value = Convert.ToDecimal(fila.Cells["tolerancia_salida_min"].Value);
            nudMargenAntesEntrada.Value = Convert.ToDecimal(fila.Cells["margen_antes_entrada"].Value);
            nudMargenDespuesSalida.Value = Convert.ToDecimal(fila.Cells["margen_despues_salida"].Value);

            chkEntradaObligatoria.Checked = Convert.ToInt32(fila.Cells["entrada_obligatoria"].Value) == 1;
            chkSalidaObligatoria.Checked = Convert.ToInt32(fila.Cells["salida_obligatoria"].Value) == 1;

            lblTituloMantIntervalo.Text = "Editar Horario: " + txtAliasIntervalo.Text;
            tabPrincipal.SelectedIndex = 1;
            txtAliasIntervalo.Focus();
        }

        private void LimpiarIntervalo()
        {
            txtIdIntervalo.Clear();
            txtAliasIntervalo.Clear();
            dtpHoraEntrada.Value = DateTime.Today.AddHours(8);
            dtpHoraSalida.Value = DateTime.Today.AddHours(17);
            nudToleranciaEntrada.Value = 5;
            nudToleranciaSalida.Value = 5;
            nudMargenAntesEntrada.Value = 60;
            nudMargenDespuesSalida.Value = 120;
            chkEntradaObligatoria.Checked = true;
            chkSalidaObligatoria.Checked = true;
        }

        private void btnGuardarIntervalo_Click(object sender, EventArgs e)
        {
            try
            {
                string alias = txtAliasIntervalo.Text.Trim();
                TimeSpan inTime = dtpHoraEntrada.Value.TimeOfDay;
                TimeSpan outTime = dtpHoraSalida.Value.TimeOfDay;
                int tolEnt = (int)nudToleranciaEntrada.Value;
                int tolSal = (int)nudToleranciaSalida.Value;
                int margAntes = (int)nudMargenAntesEntrada.Value;
                int margDesp = (int)nudMargenDespuesSalida.Value;
                int inReq = chkEntradaObligatoria.Checked ? 1 : 0;
                int outReq = chkSalidaObligatoria.Checked ? 1 : 0;

                if (string.IsNullOrWhiteSpace(alias))
                {
                    MessageBox.Show("El nombre del horario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAliasIntervalo.Focus();
                    return;
                }

                string rpta;
                if (string.IsNullOrWhiteSpace(txtIdIntervalo.Text))
                {
                    rpta = N_Horario.InsertarIntervalo(alias, inTime, outTime, tolEnt, tolSal, margAntes, margDesp, 60, margDesp, 1.0, inReq, outReq);
                }
                else
                {
                    int id = Convert.ToInt32(txtIdIntervalo.Text);
                    rpta = N_Horario.ActualizarIntervalo(id, alias, inTime, outTime, tolEnt, tolSal, margAntes, margDesp, 60, margDesp, 1.0, inReq, outReq);
                }

                if (rpta == "OK")
                {
                    MessageBox.Show("Horario / Intervalo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarIntervalo();
                    tabPrincipal.SelectedIndex = 0;
                    CargarListadoIntervalos();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarIntervalo_Click(object sender, EventArgs e)
        {
            LimpiarIntervalo();
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnEliminarIntervalo_Click(object sender, EventArgs e)
        {
            if (dgvIntervalos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el intervalo que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvIntervalos.CurrentRow.Cells["idintervalo"].Value);
            string nombre = Convert.ToString(dgvIntervalos.CurrentRow.Cells["nombre"].Value);

            if (MessageBox.Show($"¿Está seguro de eliminar el intervalo de horario '{nombre}'?", "Confirmar Eliminación", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = N_Horario.EliminarIntervalo(id);
                if (rpta == "OK")
                {
                    MessageBox.Show("Intervalo eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoIntervalos();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExportarIntervalos_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvIntervalos,
                "Listado_Intervalos_Horario",
                "Catálogo de Intervalos de Horarios",
                new Dictionary<string, string> { { "Módulo", "Configuración de Horarios" } });
        }

        #endregion

        #region ========================= 2. TURNOS DE TRABAJO (SHIFTS) =========================

        private void CargarListadoTurnos()
        {
            try
            {
                DataTable tabla = N_Horario.ListarTurnos();
                dgvTurnos.DataSource = tabla;
                FormatearGridTurnos();
                lblTotalTurnos.Text = "Total de turnos registrados: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar turnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGridTurnos()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvTurnos);

            if (dgvTurnos.Columns.Count > 0)
            {
                if (dgvTurnos.Columns.Contains("idturno"))
                {
                    dgvTurnos.Columns["idturno"].HeaderText = "ID";
                    dgvTurnos.Columns["idturno"].FillWeight = 40;
                    dgvTurnos.Columns["idturno"].MinimumWidth = 35;
                }

                if (dgvTurnos.Columns.Contains("nombre_turno"))
                {
                    dgvTurnos.Columns["nombre_turno"].HeaderText = "Nombre del Turno";
                    dgvTurnos.Columns["nombre_turno"].FillWeight = 160;
                    dgvTurnos.Columns["nombre_turno"].MinimumWidth = 120;
                }

                if (dgvTurnos.Columns.Contains("trabaja_fin_semana"))
                {
                    dgvTurnos.Columns["trabaja_fin_semana"].HeaderText = "Fin de Semana";
                    dgvTurnos.Columns["trabaja_fin_semana"].FillWeight = 75;
                    dgvTurnos.Columns["trabaja_fin_semana"].MinimumWidth = 60;
                }

                if (dgvTurnos.Columns.Contains("total_empleados_asignados"))
                {
                    dgvTurnos.Columns["total_empleados_asignados"].HeaderText = "Empleados Asignados";
                    dgvTurnos.Columns["total_empleados_asignados"].FillWeight = 90;
                    dgvTurnos.Columns["total_empleados_asignados"].MinimumWidth = 70;
                }

                if (dgvTurnos.Columns.Contains("total_departamentos_asignados"))
                {
                    dgvTurnos.Columns["total_departamentos_asignados"].HeaderText = "Deptos Asignados";
                    dgvTurnos.Columns["total_departamentos_asignados"].FillWeight = 85;
                    dgvTurnos.Columns["total_departamentos_asignados"].MinimumWidth = 70;
                }

                if (dgvTurnos.Columns.Contains("unidad_ciclo"))
                    dgvTurnos.Columns["unidad_ciclo"].Visible = false;

                if (dgvTurnos.Columns.Contains("ciclo"))
                    dgvTurnos.Columns["ciclo"].Visible = false;
            }
        }

        private void btnBuscarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = txtBuscarTurno.Text.Trim();
                if (string.IsNullOrWhiteSpace(valor))
                {
                    CargarListadoTurnos();
                }
                else
                {
                    DataTable tabla = N_Horario.BuscarTurnos(valor);
                    dgvTurnos.DataSource = tabla;
                    FormatearGridTurnos();
                    lblTotalTurnos.Text = "Total encontrados: " + tabla.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar turnos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscarTurno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscarTurno.PerformClick();
            }
        }

        private void CargarCombosDiasSemana()
        {
            DataTable dtBase = N_Horario.SeleccionarIntervalos();

            ComboBox[] combos = new ComboBox[] { cboLunes, cboMartes, cboMiercoles, cboJueves, cboViernes, cboSabado, cboDomingo };

            foreach (var combo in combos)
            {
                DataTable dtClon = dtBase.Copy();
                DataRow rowDescanso = dtClon.NewRow();
                rowDescanso["idintervalo"] = 0;
                rowDescanso["nombre_completo"] = "💤 Descanso / Día Libre";
                rowDescanso["nombre"] = "Descanso";
                dtClon.Rows.InsertAt(rowDescanso, 0);

                combo.DataSource = dtClon;
                combo.ValueMember = "idintervalo";
                combo.DisplayMember = "nombre_completo";
                combo.SelectedIndex = 0;
            }
        }

        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            LimpiarTurno();
            CargarCombosDiasSemana();

            // Por defecto pre-seleccionar primer intervalo en L-V si existe
            if (cboLunes.Items.Count > 1)
            {
                cboLunes.SelectedIndex = 1;
                cboMartes.SelectedIndex = 1;
                cboMiercoles.SelectedIndex = 1;
                cboJueves.SelectedIndex = 1;
                cboViernes.SelectedIndex = 1;
                cboSabado.SelectedIndex = 0;
                cboDomingo.SelectedIndex = 0;
            }

            lblTituloMantTurno.Text = "Nuevo Turno de Trabajo";
            tabPrincipal.SelectedIndex = 3;
            txtAliasTurno.Focus();
        }

        private void btnEditarTurno_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el turno que desea editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarParaEdicionTurno(dgvTurnos.CurrentRow);
        }

        private void dgvTurnos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CargarParaEdicionTurno(dgvTurnos.Rows[e.RowIndex]);
            }
        }

        private void CargarParaEdicionTurno(DataGridViewRow fila)
        {
            int id = Convert.ToInt32(fila.Cells["idturno"].Value);
            txtIdTurno.Text = id.ToString();
            txtAliasTurno.Text = Convert.ToString(fila.Cells["nombre_turno"].Value);
            chkTrabajaFinSemana.Checked = Convert.ToBoolean(fila.Cells["trabaja_fin_semana"].Value);

            CargarCombosDiasSemana();

            // Cargar detalles de cada día
            DataTable dtDetalles = N_Horario.ObtenerDetallesTurno(id);
            ComboBox[] combos = new ComboBox[] { cboLunes, cboMartes, cboMiercoles, cboJueves, cboViernes, cboSabado, cboDomingo };

            foreach (DataRow row in dtDetalles.Rows)
            {
                int dayIndex = Convert.ToInt32(row["day_index"]);
                int idIntervalo = row["time_interval_id"] != DBNull.Value ? Convert.ToInt32(row["time_interval_id"]) : 0;

                if (dayIndex >= 0 && dayIndex < combos.Length)
                {
                    combos[dayIndex].SelectedValue = idIntervalo;
                }
            }

            lblTituloMantTurno.Text = "Editar Turno: " + txtAliasTurno.Text;
            tabPrincipal.SelectedIndex = 3;
            txtAliasTurno.Focus();
        }

        private void LimpiarTurno()
        {
            txtIdTurno.Clear();
            txtAliasTurno.Clear();
            chkTrabajaFinSemana.Checked = false;
        }

        private void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            try
            {
                string alias = txtAliasTurno.Text.Trim();
                bool trabajaFinSemana = chkTrabajaFinSemana.Checked;

                if (string.IsNullOrWhiteSpace(alias))
                {
                    MessageBox.Show("El nombre del turno es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAliasTurno.Focus();
                    return;
                }

                ComboBox[] combos = new ComboBox[] { cboLunes, cboMartes, cboMiercoles, cboJueves, cboViernes, cboSabado, cboDomingo };
                List<DetalleTurno> detalles = new List<DetalleTurno>();

                for (int d = 0; d < 7; d++)
                {
                    int idIntervalo = Convert.ToInt32(combos[d].SelectedValue);
                    if (idIntervalo > 0)
                    {
                        DataRowView drv = combos[d].SelectedItem as DataRowView;
                        TimeSpan inTime = TimeSpan.Zero;
                        TimeSpan outTime = TimeSpan.Zero;
                        if (drv != null)
                        {
                            if (drv["hora_entrada"] != DBNull.Value) inTime = (TimeSpan)drv["hora_entrada"];
                            if (drv["hora_salida"] != DBNull.Value) outTime = (TimeSpan)drv["hora_salida"];
                        }

                        detalles.Add(new DetalleTurno
                        {
                            DayIndex = d,
                            TimeIntervalId = idIntervalo,
                            InTime = inTime,
                            OutTime = outTime
                        });
                    }
                }

                int idTurno = string.IsNullOrWhiteSpace(txtIdTurno.Text) ? 0 : Convert.ToInt32(txtIdTurno.Text);
                string rpta = N_Horario.GuardarTurnoConDetalles(idTurno, alias, trabajaFinSemana, detalles);

                if (rpta == "OK")
                {
                    MessageBox.Show("Turno de trabajo guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarTurno();
                    tabPrincipal.SelectedIndex = 2;
                    CargarListadoTurnos();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar turno: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarTurno_Click(object sender, EventArgs e)
        {
            LimpiarTurno();
            tabPrincipal.SelectedIndex = 2;
        }

        private void btnEliminarTurno_Click(object sender, EventArgs e)
        {
            if (dgvTurnos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el turno que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["idturno"].Value);
            string nombre = Convert.ToString(dgvTurnos.CurrentRow.Cells["nombre_turno"].Value);
            int totalAsignados = Convert.ToInt32(dgvTurnos.CurrentRow.Cells["total_empleados_asignados"].Value);

            if (totalAsignados > 0)
            {
                MessageBox.Show($"No se puede eliminar el turno '{nombre}' porque actualmente tiene {totalAsignados} empleados asignados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Está seguro de eliminar el turno '{nombre}'?", "Confirmar Eliminación", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = N_Horario.EliminarTurno(id);
                if (rpta == "OK")
                {
                    MessageBox.Show("Turno eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoTurnos();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExportarTurnos_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvTurnos,
                "Listado_Turnos_Trabajo",
                "Catálogo de Turnos de Trabajo",
                new Dictionary<string, string> { { "Módulo", "Configuración de Horarios" } });
        }

        private void btnSwitchToTurnos_Click(object sender, EventArgs e)
        {
            tabPrincipal.SelectedIndex = 2;
            CargarListadoTurnos();
        }

        private void btnSwitchToIntervalos_Click(object sender, EventArgs e)
        {
            tabPrincipal.SelectedIndex = 0;
            CargarListadoIntervalos();
        }

        #endregion
    }
}
