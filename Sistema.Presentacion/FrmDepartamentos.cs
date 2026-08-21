using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmDepartamentos : RJCodeUI_M1.RJForms.RJChildForm
    {
        public FrmDepartamentos()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.Building;
            this.Text = "Gestión de Departamentos";
            this.tabPrincipal.Appearance = TabAppearance.FlatButtons;
            this.tabPrincipal.ItemSize = new Size(0, 1);
            this.tabPrincipal.SizeMode = TabSizeMode.Fixed;
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (this.Visible && !this.Disposing)
            {
                CargarListado();
            }
        }

        private void FrmDepartamentos_Load(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(this);
            CargarListado();
        }

        private void CargarCombosPadre(int idExcluir = 0)
        {
            try
            {
                DataTable dt = N_Departamento.Seleccionar(idExcluir);
                DataRow row = dt.NewRow();
                row["id"] = 0;
                row["nombre_completo"] = "--- Ninguno (Nivel Superior Principal) ---";
                row["nombre"] = "--- Ninguno ---";
                dt.Rows.InsertAt(row, 0);

                cboDeptoPadre.DataSource = dt;
                cboDeptoPadre.ValueMember = "id";
                cboDeptoPadre.DisplayMember = "nombre_completo";
                cboDeptoPadre.SelectedIndex = 0;
            }
            catch { }
        }

        private void CargarListado()
        {
            try
            {
                DataTable tabla = N_Departamento.Listar();
                dgvListado.DataSource = tabla;
                FormatearGrid();
                lblTotal.Text = "Total de registros: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrid()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvListado);

            if (dgvListado.Columns.Count > 0)
            {
                if (dgvListado.Columns.Contains("iddepartamento"))
                {
                    dgvListado.Columns["iddepartamento"].HeaderText = "ID";
                    dgvListado.Columns["iddepartamento"].FillWeight = 40;
                    dgvListado.Columns["iddepartamento"].MinimumWidth = 35;
                }

                if (dgvListado.Columns.Contains("codigo"))
                {
                    dgvListado.Columns["codigo"].HeaderText = "Código";
                    dgvListado.Columns["codigo"].FillWeight = 60;
                    dgvListado.Columns["codigo"].MinimumWidth = 50;
                }

                if (dgvListado.Columns.Contains("nombre"))
                {
                    dgvListado.Columns["nombre"].HeaderText = "Nombre del Departamento";
                    dgvListado.Columns["nombre"].FillWeight = 160;
                    dgvListado.Columns["nombre"].MinimumWidth = 120;
                }

                if (dgvListado.Columns.Contains("id_padre"))
                    dgvListado.Columns["id_padre"].Visible = false;

                if (dgvListado.Columns.Contains("departamento_padre"))
                {
                    dgvListado.Columns["departamento_padre"].HeaderText = "Departamento Superior";
                    dgvListado.Columns["departamento_padre"].FillWeight = 120;
                    dgvListado.Columns["departamento_padre"].MinimumWidth = 90;
                }

                if (dgvListado.Columns.Contains("es_predeterminado"))
                    dgvListado.Columns["es_predeterminado"].Visible = false;

                if (dgvListado.Columns.Contains("total_empleados"))
                {
                    dgvListado.Columns["total_empleados"].HeaderText = "Total Empleados";
                    dgvListado.Columns["total_empleados"].FillWeight = 70;
                    dgvListado.Columns["total_empleados"].MinimumWidth = 60;
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string valor = txtBuscar.Text.Trim();
                if (string.IsNullOrWhiteSpace(valor))
                {
                    CargarListado();
                }
                else
                {
                    DataTable tabla = N_Departamento.Buscar(valor);
                    dgvListado.DataSource = tabla;
                    FormatearGrid();
                    lblTotal.Text = "Total encontrados: " + tabla.Rows.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            CargarCombosPadre(0);
            lblTituloMant.Text = "Nuevo Departamento";
            tabPrincipal.SelectedIndex = 1;
            txtCodigo.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el departamento que desea editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            int id = Convert.ToInt32(fila.Cells["iddepartamento"].Value);
            txtId.Text = id.ToString();
            txtCodigo.Text = Convert.ToString(fila.Cells["codigo"].Value);
            txtNombre.Text = Convert.ToString(fila.Cells["nombre"].Value);

            CargarCombosPadre(id);

            if (fila.Cells["id_padre"].Value != DBNull.Value && fila.Cells["id_padre"].Value != null)
            {
                int idPadre = Convert.ToInt32(fila.Cells["id_padre"].Value);
                cboDeptoPadre.SelectedValue = idPadre;
            }
            else
            {
                cboDeptoPadre.SelectedIndex = 0;
            }

            lblTituloMant.Text = "Editar Departamento: " + txtNombre.Text;
            tabPrincipal.SelectedIndex = 1;
            txtNombre.Focus();
        }

        private void Limpiar()
        {
            txtId.Clear();
            txtCodigo.Clear();
            txtNombre.Clear();
            if (cboDeptoPadre.Items.Count > 0)
                cboDeptoPadre.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigo.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                int? parentId = null;

                if (cboDeptoPadre.SelectedValue != null && Convert.ToInt32(cboDeptoPadre.SelectedValue) > 0)
                {
                    parentId = Convert.ToInt32(cboDeptoPadre.SelectedValue);
                }

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("El código de departamento es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre del departamento es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                string respuesta;
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    respuesta = N_Departamento.Insertar(codigo, nombre, parentId);
                }
                else
                {
                    int id = Convert.ToInt32(txtId.Text);
                    respuesta = N_Departamento.Actualizar(id, codigo, nombre, parentId);
                }

                if (respuesta == "OK")
                {
                    MessageBox.Show("Departamento guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    tabPrincipal.SelectedIndex = 0;
                    CargarListado();
                }
                else
                {
                    MessageBox.Show(respuesta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el departamento que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["iddepartamento"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value);
            int totalEmp = Convert.ToInt32(dgvListado.CurrentRow.Cells["total_empleados"].Value);

            string msg = $"¿Está seguro de eliminar el departamento '{nombre}'?";
            if (totalEmp > 0)
            {
                msg += $"\n\n⚠️ Atención: Hay {totalEmp} empleados asignados a este departamento. Sus fichas quedarán sin departamento asignado.";
            }

            if (MessageBox.Show(msg, "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string rpta = N_Departamento.Eliminar(id);
                    if (rpta == "OK")
                    {
                        MessageBox.Show("Departamento eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarListado();
                    }
                    else
                    {
                        MessageBox.Show(rpta, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvListado,
                "Listado_Departamentos",
                "Estructura Organizacional - Departamentos",
                new Dictionary<string, string> { { "Módulo", "Gestión de Departamentos" } });
        }
    }
}
