using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmAsignacionHorarios : RJCodeUI_M1.RJForms.RJChildForm
    {
        private bool _cargandoCombos = false;
        private List<int> _empleadosSeleccionadosParaEdicion = new List<int>();
        private int _deptoSeleccionadoParaEdicion = 0;

        public FrmAsignacionHorarios()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.CalendarAlt;
            this.Text = "Asignación de Turnos";

            this.tabPrincipal.Appearance = TabAppearance.FlatButtons;
            this.tabPrincipal.ItemSize = new Size(0, 1);
            this.tabPrincipal.SizeMode = TabSizeMode.Fixed;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && !this.Disposing)
            {
                RefrescarTodo();
            }
        }

        private void FrmAsignacionHorarios_Load(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(this);

            dtpDesdeMantEmp.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHastaMantEmp.Value = new DateTime(2099, 12, 31);

            dtpDesdeMantDept.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHastaMantDept.Value = new DateTime(2099, 12, 31);

            RefrescarTodo();
        }

        private void RefrescarTodo()
        {
            CargarCombosFiltros();
            CargarCombosAsignacion();
            CargarListadoEmpleados();
            CargarListadoDepartamentos();
        }

        private int ObtenerValorCombo(ComboBox cbo)
        {
            if (cbo == null || cbo.SelectedItem == null) return 0;
            try
            {
                if (cbo.SelectedValue != null)
                {
                    if (cbo.SelectedValue is int iVal) return iVal;
                    if (cbo.SelectedValue is long lVal) return (int)lVal;
                    if (cbo.SelectedValue is short sVal) return (int)sVal;
                    if (int.TryParse(cbo.SelectedValue.ToString(), out int parsed)) return parsed;
                }

                if (cbo.SelectedItem is DataRowView drv && !string.IsNullOrEmpty(cbo.ValueMember))
                {
                    if (drv.Row.Table.Columns.Contains(cbo.ValueMember) && drv[cbo.ValueMember] != DBNull.Value)
                    {
                        if (int.TryParse(drv[cbo.ValueMember].ToString(), out int idFromDrv)) return idFromDrv;
                    }
                }
            }
            catch { }
            return 0;
        }

        private void CargarCombosFiltros()
        {
            _cargandoCombos = true;
            try
            {
                // Departamentos filtro
                DataTable dtDept = N_Departamento.Seleccionar();
                DataRow rowDept = dtDept.NewRow();
                rowDept["id"] = 0;
                rowDept["nombre"] = "-- Todos los Deptos --";
                rowDept["nombre_completo"] = "-- Todos los Deptos --";
                dtDept.Rows.InsertAt(rowDept, 0);

                cboFiltroDept.ValueMember = "id";
                cboFiltroDept.DisplayMember = "nombre";
                cboFiltroDept.DataSource = dtDept;
                cboFiltroDept.SelectedIndex = 0;

                // Turnos filtro
                DataTable dtTurnos = N_Horario.SeleccionarTurnos();
                DataRow rowTurno = dtTurnos.NewRow();
                rowTurno["idturno"] = 0;
                rowTurno["nombre"] = "-- Todos los Turnos --";
                if (dtTurnos.Columns.Contains("nombre_completo"))
                    rowTurno["nombre_completo"] = "-- Todos los Turnos --";
                dtTurnos.Rows.InsertAt(rowTurno, 0);

                cboFiltroTurno.ValueMember = "idturno";
                cboFiltroTurno.DisplayMember = "nombre";
                cboFiltroTurno.DataSource = dtTurnos;
                cboFiltroTurno.SelectedIndex = 0;
            }
            catch { }
            finally
            {
                _cargandoCombos = false;
            }
        }

        private void CargarCombosAsignacion()
        {
            try
            {
                // Combo Turno para Mantenimiento Empleado
                DataTable dtTurnos1 = N_Horario.SeleccionarTurnos();
                cboTurnoMantEmp.ValueMember = "idturno";
                cboTurnoMantEmp.DisplayMember = "nombre";
                cboTurnoMantEmp.DataSource = dtTurnos1;

                // Combo Turno para Mantenimiento Departamento
                DataTable dtTurnos2 = N_Horario.SeleccionarTurnos();
                cboTurnoMantDept.ValueMember = "idturno";
                cboTurnoMantDept.DisplayMember = "nombre";
                cboTurnoMantDept.DataSource = dtTurnos2;
            }
            catch { }
        }

        // ==========================================
        // VISTA / MANTENIMIENTO POR EMPLEADOS
        // ==========================================

        private void CargarListadoEmpleados()
        {
            if (_cargandoCombos) return;

            try
            {
                string valor = txtBuscarEmp.Text.Trim();
                int idDept = ObtenerValorCombo(cboFiltroDept);
                int idTurno = ObtenerValorCombo(cboFiltroTurno);

                DataTable tabla = N_Horario.BuscarHorariosEmpleados(valor, idDept, idTurno);
                dgvAsignacionesEmp.DataSource = tabla;
                FormatearGridEmpleados();
                lblTotalEmp.Text = "Total de empleados: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asignaciones de empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGridEmpleados()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvAsignacionesEmp);

            if (dgvAsignacionesEmp.Columns.Count > 0)
            {
                if (dgvAsignacionesEmp.Columns.Contains("idempleado"))
                {
                    dgvAsignacionesEmp.Columns["idempleado"].HeaderText = "ID Emp";
                    dgvAsignacionesEmp.Columns["idempleado"].FillWeight = 50;
                    dgvAsignacionesEmp.Columns["idempleado"].MinimumWidth = 40;
                    dgvAsignacionesEmp.Columns["idempleado"].ReadOnly = true;
                }

                if (dgvAsignacionesEmp.Columns.Contains("codigo_empleado"))
                {
                    dgvAsignacionesEmp.Columns["codigo_empleado"].HeaderText = "Cód. Biométrico";
                    dgvAsignacionesEmp.Columns["codigo_empleado"].FillWeight = 80;
                    dgvAsignacionesEmp.Columns["codigo_empleado"].MinimumWidth = 60;
                    dgvAsignacionesEmp.Columns["codigo_empleado"].ReadOnly = true;
                }

                if (dgvAsignacionesEmp.Columns.Contains("nombre_empleado"))
                {
                    dgvAsignacionesEmp.Columns["nombre_empleado"].HeaderText = "Empleado";
                    dgvAsignacionesEmp.Columns["nombre_empleado"].FillWeight = 160;
                    dgvAsignacionesEmp.Columns["nombre_empleado"].MinimumWidth = 120;
                    dgvAsignacionesEmp.Columns["nombre_empleado"].ReadOnly = true;
                }

                if (dgvAsignacionesEmp.Columns.Contains("departamento"))
                {
                    dgvAsignacionesEmp.Columns["departamento"].HeaderText = "Departamento";
                    dgvAsignacionesEmp.Columns["departamento"].FillWeight = 110;
                    dgvAsignacionesEmp.Columns["departamento"].MinimumWidth = 80;
                    dgvAsignacionesEmp.Columns["departamento"].ReadOnly = true;
                }

                if (dgvAsignacionesEmp.Columns.Contains("idturno"))
                    dgvAsignacionesEmp.Columns["idturno"].Visible = false;

                if (dgvAsignacionesEmp.Columns.Contains("turno"))
                {
                    dgvAsignacionesEmp.Columns["turno"].HeaderText = "Turno Asignado";
                    dgvAsignacionesEmp.Columns["turno"].FillWeight = 120;
                    dgvAsignacionesEmp.Columns["turno"].MinimumWidth = 90;
                    dgvAsignacionesEmp.Columns["turno"].ReadOnly = true;
                }

                if (dgvAsignacionesEmp.Columns.Contains("fecha_inicio"))
                {
                    dgvAsignacionesEmp.Columns["fecha_inicio"].HeaderText = "Fecha Inicio";
                    dgvAsignacionesEmp.Columns["fecha_inicio"].FillWeight = 75;
                    dgvAsignacionesEmp.Columns["fecha_inicio"].MinimumWidth = 65;
                    dgvAsignacionesEmp.Columns["fecha_inicio"].ReadOnly = true;
                }

                if (dgvAsignacionesEmp.Columns.Contains("fecha_fin"))
                {
                    dgvAsignacionesEmp.Columns["fecha_fin"].HeaderText = "Fecha Fin";
                    dgvAsignacionesEmp.Columns["fecha_fin"].FillWeight = 75;
                    dgvAsignacionesEmp.Columns["fecha_fin"].MinimumWidth = 65;
                    dgvAsignacionesEmp.Columns["fecha_fin"].ReadOnly = true;
                }
            }
        }

        private void btnBuscarEmp_Click(object sender, EventArgs e)
        {
            CargarListadoEmpleados();
        }

        private void txtBuscarEmp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarListadoEmpleados();
            }
        }

        private void cboFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated && !_cargandoCombos) CargarListadoEmpleados();
        }

        private void btnAsignarEmp_Click(object sender, EventArgs e)
        {
            if (dgvAsignacionesEmp.CurrentRow != null)
            {
                AbrirMantenimientoEmpleado(dgvAsignacionesEmp.CurrentRow);
            }
            else
            {
                MessageBox.Show("Por favor seleccione un empleado de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvAsignacionesEmp_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirMantenimientoEmpleado(dgvAsignacionesEmp.Rows[e.RowIndex]);
            }
        }

        private void AbrirMantenimientoEmpleado(DataGridViewRow fila)
        {
            int idEmp = Convert.ToInt32(fila.Cells["idempleado"].Value);
            string codEmp = Convert.ToString(fila.Cells["codigo_empleado"].Value);
            string nombreEmp = Convert.ToString(fila.Cells["nombre_empleado"].Value);
            string deptoEmp = Convert.ToString(fila.Cells["departamento"].Value);

            _empleadosSeleccionadosParaEdicion = new List<int> { idEmp };

            lblTituloMantEmp.Text = "Asignación de Turno por Empleado";
            lblEmpleadoInfo.Text = $"👤 [{codEmp}] {nombreEmp} — {deptoEmp}";
            lblInfoSeleccionados.Text = "Configure el turno y las fechas de vigencia para este empleado.";

            if (fila.Cells["idturno"].Value != DBNull.Value)
            {
                int idTurno = Convert.ToInt32(fila.Cells["idturno"].Value);
                if (idTurno > 0) cboTurnoMantEmp.SelectedValue = idTurno;
            }

            if (fila.Cells["fecha_inicio"].Value != DBNull.Value && DateTime.TryParse(fila.Cells["fecha_inicio"].Value.ToString(), out DateTime fi))
            {
                dtpDesdeMantEmp.Value = fi;
            }
            else
            {
                dtpDesdeMantEmp.Value = new DateTime(DateTime.Today.Year, 1, 1);
            }

            if (fila.Cells["fecha_fin"].Value != DBNull.Value && DateTime.TryParse(fila.Cells["fecha_fin"].Value.ToString(), out DateTime ff))
            {
                dtpHastaMantEmp.Value = ff;
            }
            else
            {
                dtpHastaMantEmp.Value = new DateTime(2099, 12, 31);
            }

            tabPrincipal.SelectedIndex = 1;
            cboTurnoMantEmp.Focus();
        }

        private void btnGuardarMantEmp_Click(object sender, EventArgs e)
        {
            if (_empleadosSeleccionadosParaEdicion.Count == 0)
            {
                MessageBox.Show("No hay empleados seleccionados para la asignación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabPrincipal.SelectedIndex = 0;
                return;
            }

            int idTurno = ObtenerValorCombo(cboTurnoMantEmp);
            if (idTurno <= 0)
            {
                MessageBox.Show("Seleccione el turno que desea asignar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTurnoMantEmp.Focus();
                return;
            }

            DateTime desde = dtpDesdeMantEmp.Value.Date;
            DateTime hasta = dtpHastaMantEmp.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show("La fecha de fin no puede ser anterior a la fecha de inicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpHastaMantEmp.Focus();
                return;
            }

            string rpta = N_Horario.AsignarTurnoMasivoEmpleados(_empleadosSeleccionadosParaEdicion, idTurno, desde, hasta);
            if (rpta == "OK")
            {
                MessageBox.Show($"Turno asignado exitosamente a {_empleadosSeleccionadosParaEdicion.Count} empleado(s).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabPrincipal.SelectedIndex = 0;
                CargarListadoEmpleados();
            }
            else
            {
                MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitarMantEmp_Click(object sender, EventArgs e)
        {
            if (_empleadosSeleccionadosParaEdicion.Count == 0) return;

            if (MessageBox.Show($"¿Desea desvincular el turno asignado a los {_empleadosSeleccionadosParaEdicion.Count} empleado(s)?", "Confirmar Desasignación",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int exitos = 0;
                foreach (int idEmp in _empleadosSeleccionadosParaEdicion)
                {
                    if (N_Horario.DesasignarTurnoEmpleado(idEmp) == "OK") exitos++;
                }

                MessageBox.Show($"Se desvinculó el turno a {exitos} empleado(s).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabPrincipal.SelectedIndex = 0;
                CargarListadoEmpleados();
            }
        }

        private void btnCancelarMantEmp_Click(object sender, EventArgs e)
        {
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnQuitarTurnoEmp_Click(object sender, EventArgs e)
        {
            if (dgvAsignacionesEmp.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el empleado al que desea quitar el turno.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEmp = Convert.ToInt32(dgvAsignacionesEmp.CurrentRow.Cells["idempleado"].Value);
            string nombreEmp = Convert.ToString(dgvAsignacionesEmp.CurrentRow.Cells["nombre_empleado"].Value);

            if (MessageBox.Show($"¿Está seguro de quitar el turno asignado a '{nombreEmp}'?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = N_Horario.DesasignarTurnoEmpleado(idEmp);
                if (rpta == "OK")
                {
                    MessageBox.Show("Turno removido exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoEmpleados();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExportarEmp_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvAsignacionesEmp,
                "Reporte_Asignacion_Turnos_Empleados",
                "Asignación de Turnos y Horarios por Empleado",
                new Dictionary<string, string> { { "Módulo", "Asignación de Turnos" } });
        }

        // ==========================================
        // VISTA / MANTENIMIENTO POR DEPARTAMENTOS
        // ==========================================

        private void CargarListadoDepartamentos()
        {
            try
            {
                string valor = txtBuscarDept.Text.Trim();
                DataTable tabla = N_Horario.ListarAsignacionesDepartamentos(valor);
                dgvAsignacionesDept.DataSource = tabla;
                FormatearGridDepartamentos();
                lblTotalDept.Text = "Total departamentos: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGridDepartamentos()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvAsignacionesDept);

            if (dgvAsignacionesDept.Columns.Count > 0)
            {
                if (dgvAsignacionesDept.Columns.Contains("iddepartamento"))
                {
                    dgvAsignacionesDept.Columns["iddepartamento"].HeaderText = "ID Depto";
                    dgvAsignacionesDept.Columns["iddepartamento"].FillWeight = 50;
                    dgvAsignacionesDept.Columns["iddepartamento"].MinimumWidth = 40;
                }

                if (dgvAsignacionesDept.Columns.Contains("departamento"))
                {
                    dgvAsignacionesDept.Columns["departamento"].HeaderText = "Departamento";
                    dgvAsignacionesDept.Columns["departamento"].FillWeight = 160;
                    dgvAsignacionesDept.Columns["departamento"].MinimumWidth = 120;
                }

                if (dgvAsignacionesDept.Columns.Contains("total_empleados"))
                {
                    dgvAsignacionesDept.Columns["total_empleados"].HeaderText = "Total Empleados";
                    dgvAsignacionesDept.Columns["total_empleados"].FillWeight = 70;
                    dgvAsignacionesDept.Columns["total_empleados"].MinimumWidth = 55;
                }

                if (dgvAsignacionesDept.Columns.Contains("idturno"))
                    dgvAsignacionesDept.Columns["idturno"].Visible = false;

                if (dgvAsignacionesDept.Columns.Contains("turno"))
                {
                    dgvAsignacionesDept.Columns["turno"].HeaderText = "Turno Asignado al Depto";
                    dgvAsignacionesDept.Columns["turno"].FillWeight = 140;
                    dgvAsignacionesDept.Columns["turno"].MinimumWidth = 100;
                }

                if (dgvAsignacionesDept.Columns.Contains("fecha_inicio"))
                {
                    dgvAsignacionesDept.Columns["fecha_inicio"].HeaderText = "Fecha Inicio";
                    dgvAsignacionesDept.Columns["fecha_inicio"].FillWeight = 75;
                    dgvAsignacionesDept.Columns["fecha_inicio"].MinimumWidth = 65;
                }

                if (dgvAsignacionesDept.Columns.Contains("fecha_fin"))
                {
                    dgvAsignacionesDept.Columns["fecha_fin"].HeaderText = "Fecha Fin";
                    dgvAsignacionesDept.Columns["fecha_fin"].FillWeight = 75;
                    dgvAsignacionesDept.Columns["fecha_fin"].MinimumWidth = 65;
                }
            }
        }

        private void btnBuscarDept_Click(object sender, EventArgs e)
        {
            CargarListadoDepartamentos();
        }

        private void txtBuscarDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CargarListadoDepartamentos();
            }
        }

        private void btnAsignarDept_Click(object sender, EventArgs e)
        {
            if (dgvAsignacionesDept.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el departamento que desea configurar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AbrirMantenimientoDepartamento(dgvAsignacionesDept.CurrentRow);
        }

        private void dgvAsignacionesDept_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                AbrirMantenimientoDepartamento(dgvAsignacionesDept.Rows[e.RowIndex]);
            }
        }

        private void AbrirMantenimientoDepartamento(DataGridViewRow fila)
        {
            _deptoSeleccionadoParaEdicion = Convert.ToInt32(fila.Cells["iddepartamento"].Value);
            string nombreDept = Convert.ToString(fila.Cells["departamento"].Value);
            string totEmp = Convert.ToString(fila.Cells["total_empleados"].Value);

            lblTituloMantDept.Text = "Asignación de Turno por Departamento";
            lblDeptoInfo.Text = $"🏢 Departamento: {nombreDept} ({totEmp} empleados activos)";

            if (fila.Cells["idturno"].Value != DBNull.Value)
            {
                int idTurno = Convert.ToInt32(fila.Cells["idturno"].Value);
                if (idTurno > 0) cboTurnoMantDept.SelectedValue = idTurno;
            }

            if (fila.Cells["fecha_inicio"].Value != DBNull.Value && DateTime.TryParse(fila.Cells["fecha_inicio"].Value.ToString(), out DateTime fi))
            {
                dtpDesdeMantDept.Value = fi;
            }
            else
            {
                dtpDesdeMantDept.Value = new DateTime(DateTime.Today.Year, 1, 1);
            }

            if (fila.Cells["fecha_fin"].Value != DBNull.Value && DateTime.TryParse(fila.Cells["fecha_fin"].Value.ToString(), out DateTime ff))
            {
                dtpHastaMantDept.Value = ff;
            }
            else
            {
                dtpHastaMantDept.Value = new DateTime(2099, 12, 31);
            }

            tabPrincipal.SelectedIndex = 3;
            cboTurnoMantDept.Focus();
        }

        private void btnGuardarMantDept_Click(object sender, EventArgs e)
        {
            if (_deptoSeleccionadoParaEdicion <= 0)
            {
                MessageBox.Show("No se ha seleccionado ningún departamento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabPrincipal.SelectedIndex = 2;
                return;
            }

            int idTurno = ObtenerValorCombo(cboTurnoMantDept);
            if (idTurno <= 0)
            {
                MessageBox.Show("Seleccione el turno que desea asignar al departamento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboTurnoMantDept.Focus();
                return;
            }

            DateTime desde = dtpDesdeMantDept.Value.Date;
            DateTime hasta = dtpHastaMantDept.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show("La fecha final no puede ser anterior a la fecha inicial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpHastaMantDept.Focus();
                return;
            }

            bool sincEmp = chkSincronizarEmp.Checked;
            string rpta = N_Horario.AsignarTurnoDepartamento(_deptoSeleccionadoParaEdicion, idTurno, desde, hasta, sincEmp);

            if (rpta == "OK")
            {
                MessageBox.Show("Turno asignado al departamento correctamente." + (sincEmp ? " Y sincronizado a todos sus empleados." : ""), "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabPrincipal.SelectedIndex = 2;
                CargarListadoDepartamentos();
                CargarListadoEmpleados();
            }
            else
            {
                MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnQuitarMantDept_Click(object sender, EventArgs e)
        {
            if (_deptoSeleccionadoParaEdicion <= 0) return;

            if (MessageBox.Show("¿Está seguro de quitar el turno asignado a este departamento?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = N_Horario.DesasignarTurnoDepartamento(_deptoSeleccionadoParaEdicion);
                if (rpta == "OK")
                {
                    MessageBox.Show("Turno del departamento desvinculado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabPrincipal.SelectedIndex = 2;
                    CargarListadoDepartamentos();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancelarMantDept_Click(object sender, EventArgs e)
        {
            tabPrincipal.SelectedIndex = 2;
        }

        private void btnQuitarTurnoDept_Click(object sender, EventArgs e)
        {
            if (dgvAsignacionesDept.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el departamento que desea desasignar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idDept = Convert.ToInt32(dgvAsignacionesDept.CurrentRow.Cells["iddepartamento"].Value);
            string depto = Convert.ToString(dgvAsignacionesDept.CurrentRow.Cells["departamento"].Value);

            if (MessageBox.Show($"¿Desea desvincular el turno asignado al departamento '{depto}'?", "Confirmar",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = N_Horario.DesasignarTurnoDepartamento(idDept);
                if (rpta == "OK")
                {
                    MessageBox.Show("Turno desvinculado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListadoDepartamentos();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExportarDept_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvAsignacionesDept,
                "Reporte_Asignacion_Turnos_Departamentos",
                "Asignación de Turnos y Horarios por Departamento",
                new Dictionary<string, string> { { "Módulo", "Asignación de Turnos" } });
        }

        // ==========================================
        // BOTONES DE CAMBIO DE MODO / VISTA
        // ==========================================

        private void btnSwitchToDept_Click(object sender, EventArgs e)
        {
            tabPrincipal.SelectedIndex = 2;
            CargarListadoDepartamentos();
        }

        private void btnSwitchToEmp_Click(object sender, EventArgs e)
        {
            tabPrincipal.SelectedIndex = 0;
            CargarListadoEmpleados();
        }
    }
}
