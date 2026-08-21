using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Sistema.Entidades;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmVacacionesPermisos : RJCodeUI_M1.RJForms.RJChildForm
    {
        private bool _cargandoCombos = false;

        public FrmVacacionesPermisos()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.UmbrellaBeach;
            this.Text = "Gestión de Vacaciones y Permisos";

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

        private void FrmVacacionesPermisos_Load(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(this);

            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = new DateTime(DateTime.Today.Year, 12, 31);

            dtpFechaInicio.Value = DateTime.Today.AddHours(8);
            dtpFechaFin.Value = DateTime.Today.AddDays(1).AddHours(16).AddMinutes(30);

            RefrescarTodo();
        }

        private void RefrescarTodo()
        {
            CargarCombosFiltros();
            CargarCombosMantenimiento();
            CargarListado();
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
                // Departamentos
                DataTable dtDept = N_Departamento.Seleccionar();
                DataRow rowDept = dtDept.NewRow();
                rowDept["id"] = 0;
                rowDept["nombre"] = "-- Todos los Deptos --";
                rowDept["nombre_completo"] = "-- Todos los Deptos --";
                dtDept.Rows.InsertAt(rowDept, 0);

                cboFiltroDepto.ValueMember = "id";
                cboFiltroDepto.DisplayMember = "nombre";
                cboFiltroDepto.DataSource = dtDept;
                cboFiltroDepto.SelectedIndex = 0;

                // Categorías de Permisos y Vacaciones
                DataTable dtCat = N_VacacionPermiso.ListarCategorias();
                DataRow rowCat = dtCat.NewRow();
                rowCat["idcategoria"] = 0;
                rowCat["nombre"] = "-- Todos los Tipos --";
                rowCat["nombre_completo"] = "-- Todos los Tipos / Vacaciones --";
                dtCat.Rows.InsertAt(rowCat, 0);

                cboFiltroCategoria.ValueMember = "idcategoria";
                cboFiltroCategoria.DisplayMember = "nombre_completo";
                cboFiltroCategoria.DataSource = dtCat;
                cboFiltroCategoria.SelectedIndex = 0;

                // Estados de Aprobación
                DataTable dtEstados = new DataTable();
                dtEstados.Columns.Add("id", typeof(int));
                dtEstados.Columns.Add("nombre", typeof(string));
                dtEstados.Rows.Add(-1, "-- Todos los Estados --");
                dtEstados.Rows.Add(2, "Aprobados");
                dtEstados.Rows.Add(1, "Pendientes");
                dtEstados.Rows.Add(3, "Rechazados");

                cboFiltroEstado.ValueMember = "id";
                cboFiltroEstado.DisplayMember = "nombre";
                cboFiltroEstado.DataSource = dtEstados;
                cboFiltroEstado.SelectedIndex = 0;
            }
            catch { }
            finally
            {
                _cargandoCombos = false;
            }
        }

        private void CargarCombosMantenimiento()
        {
            try
            {
                // Empleados
                DataTable dtEmp = N_Empleado.SeleccionarActivos();
                cboEmpleadoMant.ValueMember = "idempleado";
                cboEmpleadoMant.DisplayMember = "nombre_completo";
                cboEmpleadoMant.DataSource = dtEmp;

                // Categorías
                DataTable dtCat = N_VacacionPermiso.ListarCategorias();
                cboCategoriaMant.ValueMember = "idcategoria";
                cboCategoriaMant.DisplayMember = "nombre_completo";
                cboCategoriaMant.DataSource = dtCat;

                // Estados
                DataTable dtEstadosMant = new DataTable();
                dtEstadosMant.Columns.Add("id", typeof(int));
                dtEstadosMant.Columns.Add("nombre", typeof(string));
                dtEstadosMant.Rows.Add(2, "Aprobado");
                dtEstadosMant.Rows.Add(1, "Pendiente");
                dtEstadosMant.Rows.Add(3, "Rechazado");

                cboEstadoMant.ValueMember = "id";
                cboEstadoMant.DisplayMember = "nombre";
                cboEstadoMant.DataSource = dtEstadosMant;
                cboEstadoMant.SelectedValue = 2;
            }
            catch { }
        }

        private void CargarListado()
        {
            if (_cargandoCombos) return;

            try
            {
                string valor = txtBuscar.Text.Trim();
                int idDept = ObtenerValorCombo(cboFiltroDepto);
                int idCat = ObtenerValorCombo(cboFiltroCategoria);
                int estado = ObtenerValorCombo(cboFiltroEstado);
                DateTime? desde = dtpDesde.Value.Date;
                DateTime? hasta = dtpHasta.Value.Date;

                DataTable tabla = N_VacacionPermiso.Buscar(valor, idDept, idCat, desde, hasta, estado);
                dgvListado.DataSource = tabla;
                FormatearGrid();

                lblTotal.Text = "Total registros encontrados: " + tabla.Rows.Count;

                // Calcular estadísticas
                int totalVac = 0;
                int totalPerm = 0;
                foreach (DataRow row in tabla.Rows)
                {
                    if (row["idcategoria"] != DBNull.Value && Convert.ToInt32(row["idcategoria"]) == 7)
                        totalVac++;
                    else
                        totalPerm++;
                }

                lblResumenStats.Text = $"🏖️ Vacaciones: {totalVac}  |  📋 Permisos / Licencias: {totalPerm}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar vacaciones y permisos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrid()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvListado);

            if (dgvListado.Columns.Count > 0)
            {
                if (dgvListado.Columns.Contains("idsolicitud"))
                {
                    dgvListado.Columns["idsolicitud"].HeaderText = "ID";
                    dgvListado.Columns["idsolicitud"].FillWeight = 40;
                    dgvListado.Columns["idsolicitud"].MinimumWidth = 35;
                }

                if (dgvListado.Columns.Contains("idempleado"))
                    dgvListado.Columns["idempleado"].Visible = false;

                if (dgvListado.Columns.Contains("codigo_empleado"))
                {
                    dgvListado.Columns["codigo_empleado"].HeaderText = "Cód.";
                    dgvListado.Columns["codigo_empleado"].FillWeight = 50;
                    dgvListado.Columns["codigo_empleado"].MinimumWidth = 45;
                }

                if (dgvListado.Columns.Contains("nombre_empleado"))
                {
                    dgvListado.Columns["nombre_empleado"].HeaderText = "Empleado";
                    dgvListado.Columns["nombre_empleado"].FillWeight = 140;
                    dgvListado.Columns["nombre_empleado"].MinimumWidth = 110;
                }

                if (dgvListado.Columns.Contains("iddepartamento"))
                    dgvListado.Columns["iddepartamento"].Visible = false;

                if (dgvListado.Columns.Contains("departamento"))
                {
                    dgvListado.Columns["departamento"].HeaderText = "Departamento";
                    dgvListado.Columns["departamento"].FillWeight = 95;
                    dgvListado.Columns["departamento"].MinimumWidth = 75;
                }

                if (dgvListado.Columns.Contains("idcategoria"))
                    dgvListado.Columns["idcategoria"].Visible = false;

                if (dgvListado.Columns.Contains("tipo_permiso"))
                {
                    dgvListado.Columns["tipo_permiso"].HeaderText = "Tipo / Solicitud";
                    dgvListado.Columns["tipo_permiso"].FillWeight = 110;
                    dgvListado.Columns["tipo_permiso"].MinimumWidth = 85;
                }

                if (dgvListado.Columns.Contains("simbolo_permiso"))
                    dgvListado.Columns["simbolo_permiso"].Visible = false;

                if (dgvListado.Columns.Contains("fecha_inicio"))
                {
                    dgvListado.Columns["fecha_inicio"].HeaderText = "Desde";
                    dgvListado.Columns["fecha_inicio"].FillWeight = 90;
                    dgvListado.Columns["fecha_inicio"].MinimumWidth = 75;
                }

                if (dgvListado.Columns.Contains("fecha_fin"))
                {
                    dgvListado.Columns["fecha_fin"].HeaderText = "Hasta";
                    dgvListado.Columns["fecha_fin"].FillWeight = 90;
                    dgvListado.Columns["fecha_fin"].MinimumWidth = 75;
                }

                if (dgvListado.Columns.Contains("dias_solicitados"))
                {
                    dgvListado.Columns["dias_solicitados"].HeaderText = "Días";
                    dgvListado.Columns["dias_solicitados"].FillWeight = 45;
                    dgvListado.Columns["dias_solicitados"].MinimumWidth = 40;
                }

                if (dgvListado.Columns.Contains("motivo_solicitud"))
                {
                    dgvListado.Columns["motivo_solicitud"].HeaderText = "Motivo / Justificación";
                    dgvListado.Columns["motivo_solicitud"].FillWeight = 160;
                    dgvListado.Columns["motivo_solicitud"].MinimumWidth = 120;
                }

                if (dgvListado.Columns.Contains("fecha_solicitud"))
                    dgvListado.Columns["fecha_solicitud"].Visible = false;

                if (dgvListado.Columns.Contains("motivo_auditoria"))
                {
                    dgvListado.Columns["motivo_auditoria"].HeaderText = "Resolución RRHH";
                    dgvListado.Columns["motivo_auditoria"].FillWeight = 120;
                    dgvListado.Columns["motivo_auditoria"].MinimumWidth = 90;
                }

                if (dgvListado.Columns.Contains("fecha_auditoria"))
                    dgvListado.Columns["fecha_auditoria"].Visible = false;

                if (dgvListado.Columns.Contains("aprobador"))
                {
                    dgvListado.Columns["aprobador"].HeaderText = "Aprobador";
                    dgvListado.Columns["aprobador"].FillWeight = 65;
                    dgvListado.Columns["aprobador"].MinimumWidth = 55;
                }

                if (dgvListado.Columns.Contains("estado_auditoria"))
                    dgvListado.Columns["estado_auditoria"].Visible = false;

                if (dgvListado.Columns.Contains("estado_descripcion"))
                {
                    dgvListado.Columns["estado_descripcion"].HeaderText = "Estado";
                    dgvListado.Columns["estado_descripcion"].FillWeight = 65;
                    dgvListado.Columns["estado_descripcion"].MinimumWidth = 55;
                }

                if (dgvListado.Columns.Contains("es_vacaciones"))
                    dgvListado.Columns["es_vacaciones"].Visible = false;

                if (dgvListado.Columns.Contains("adjunto"))
                    dgvListado.Columns["adjunto"].Visible = false;
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarListado();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnFiltrar.PerformClick();
            }
        }

        private void cboFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsHandleCreated && !_cargandoCombos) CargarListado();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            lblTituloMant.Text = "Nueva Solicitud de Vacaciones / Permiso";
            tabPrincipal.SelectedIndex = 1;
            cboEmpleadoMant.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el registro que desea editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarParaEdicion(dgvListado.CurrentRow);
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CargarParaEdicion(dgvListado.Rows[e.RowIndex]);
            }
        }

        private void CargarParaEdicion(DataGridViewRow fila)
        {
            int id = Convert.ToInt32(fila.Cells["idsolicitud"].Value);
            txtId.Text = id.ToString();

            if (fila.Cells["idempleado"].Value != DBNull.Value)
            {
                cboEmpleadoMant.SelectedValue = Convert.ToInt32(fila.Cells["idempleado"].Value);
            }

            if (fila.Cells["idcategoria"].Value != DBNull.Value)
            {
                cboCategoriaMant.SelectedValue = Convert.ToInt32(fila.Cells["idcategoria"].Value);
            }

            if (fila.Cells["fecha_inicio"].Value != DBNull.Value)
            {
                dtpFechaInicio.Value = Convert.ToDateTime(fila.Cells["fecha_inicio"].Value);
            }

            if (fila.Cells["fecha_fin"].Value != DBNull.Value)
            {
                dtpFechaFin.Value = Convert.ToDateTime(fila.Cells["fecha_fin"].Value);
            }

            txtMotivo.Text = fila.Cells["motivo_solicitud"].Value != DBNull.Value ? Convert.ToString(fila.Cells["motivo_solicitud"].Value) : "";
            txtResolucion.Text = fila.Cells["motivo_auditoria"].Value != DBNull.Value ? Convert.ToString(fila.Cells["motivo_auditoria"].Value) : "Aprobado por RRHH.";
            txtAprobador.Text = fila.Cells["aprobador"].Value != DBNull.Value ? Convert.ToString(fila.Cells["aprobador"].Value) : "admin";

            if (fila.Cells["estado_auditoria"].Value != DBNull.Value)
            {
                cboEstadoMant.SelectedValue = Convert.ToInt32(fila.Cells["estado_auditoria"].Value);
            }

            lblTituloMant.Text = "Editar Registro: " + Convert.ToString(fila.Cells["nombre_empleado"].Value);
            tabPrincipal.SelectedIndex = 1;
            txtMotivo.Focus();
        }

        private void Limpiar()
        {
            txtId.Clear();
            if (cboEmpleadoMant.Items.Count > 0) cboEmpleadoMant.SelectedIndex = 0;
            if (cboCategoriaMant.Items.Count > 0) cboCategoriaMant.SelectedIndex = 0;
            dtpFechaInicio.Value = DateTime.Today.AddHours(8);
            dtpFechaFin.Value = DateTime.Today.AddDays(1).AddHours(16).AddMinutes(30);
            txtMotivo.Clear();
            txtResolucion.Text = "Aprobado por RRHH.";
            txtAprobador.Text = "admin";
            cboEstadoMant.SelectedValue = 2;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                int idEmpleado = ObtenerValorCombo(cboEmpleadoMant);
                int idCategoria = ObtenerValorCombo(cboCategoriaMant);

                if (idEmpleado <= 0)
                {
                    MessageBox.Show("Seleccione el empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboEmpleadoMant.Focus();
                    return;
                }

                if (idCategoria <= 0)
                {
                    MessageBox.Show("Seleccione el tipo de permiso o vacación.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboCategoriaMant.Focus();
                    return;
                }

                DateTime inicio = dtpFechaInicio.Value;
                DateTime fin = dtpFechaFin.Value;

                if (fin < inicio)
                {
                    MessageBox.Show("La fecha final no puede ser anterior a la fecha de inicio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpFechaFin.Focus();
                    return;
                }

                string motivo = txtMotivo.Text.Trim();
                if (string.IsNullOrWhiteSpace(motivo))
                {
                    MessageBox.Show("Ingrese el motivo o justificación de la solicitud.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMotivo.Focus();
                    return;
                }

                string resolucion = txtResolucion.Text.Trim();
                string aprobador = txtAprobador.Text.Trim();
                short estado = (short)ObtenerValorCombo(cboEstadoMant);

                string rpta;
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    rpta = N_VacacionPermiso.Insertar(idEmpleado, idCategoria, inicio, fin, motivo, aprobador, resolucion, estado);
                }
                else
                {
                    int id = Convert.ToInt32(txtId.Text);
                    rpta = N_VacacionPermiso.Actualizar(id, idEmpleado, idCategoria, inicio, fin, motivo, aprobador, resolucion, estado);
                }

                if (rpta == "OK")
                {
                    MessageBox.Show("Registro guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    tabPrincipal.SelectedIndex = 0;
                    CargarListado();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            tabPrincipal.SelectedIndex = 0;
        }

        private void btnAprobar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el registro que desea aprobar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idsolicitud"].Value);
            string emp = Convert.ToString(dgvListado.CurrentRow.Cells["nombre_empleado"].Value);
            string tipo = Convert.ToString(dgvListado.CurrentRow.Cells["tipo_permiso"].Value);

            if (MessageBox.Show($"¿Desea aprobar la solicitud de {tipo} para el empleado '{emp}'?", "Confirmar Aprobación", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = N_VacacionPermiso.Aprobar(id, "admin", "Aprobado por RRHH.");
                if (rpta == "OK")
                {
                    MessageBox.Show("Solicitud aprobada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListado();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el registro que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idsolicitud"].Value);
            string emp = Convert.ToString(dgvListado.CurrentRow.Cells["nombre_empleado"].Value);
            string tipo = Convert.ToString(dgvListado.CurrentRow.Cells["tipo_permiso"].Value);

            if (MessageBox.Show($"¿Está seguro de eliminar el registro de {tipo} de '{emp}'?", "Confirmar Eliminación", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string rpta = N_VacacionPermiso.Eliminar(id);
                if (rpta == "OK")
                {
                    MessageBox.Show("Registro eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListado();
                }
                else
                {
                    MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvListado,
                "Reporte_Vacaciones_Permisos",
                "Registro General de Vacaciones y Permisos Laborales",
                new Dictionary<string, string> { { "Módulo", "Gestión de Vacaciones y Permisos" } });
        }
    }
}
