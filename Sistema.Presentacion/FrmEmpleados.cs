using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Sistema.Entidades;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmEmpleados : RJCodeUI_M1.RJForms.RJChildForm
    {
        public FrmEmpleados()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.Users;
            this.Text = "Gestión de Empleados";
            this.tabPrincipal.Appearance = TabAppearance.FlatButtons;
            this.tabPrincipal.ItemSize = new Size(0, 1);
            this.tabPrincipal.SizeMode = TabSizeMode.Fixed;
        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(this);
            cboPrivilegio.SelectedIndex = 0;
            CargarListado();
        }

        private void CargarListado()
        {
            try
            {
                DataTable tabla = N_Empleado.Listar();
                dgvListado.DataSource = tabla;
                FormatearGrid();
                lblTotal.Text = "Total de registros: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrid()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvListado);

            if (dgvListado.Columns.Count > 0)
            {
                dgvListado.Columns["idempleado"].HeaderText = "ID";
                dgvListado.Columns["idempleado"].FillWeight = 40;
                dgvListado.Columns["idempleado"].MinimumWidth = 35;

                dgvListado.Columns["codigo_biometrico"].HeaderText = "Cód. Biométrico";
                dgvListado.Columns["codigo_biometrico"].FillWeight = 65;
                dgvListado.Columns["codigo_biometrico"].MinimumWidth = 55;

                dgvListado.Columns["nombre"].Visible = false;
                dgvListado.Columns["apellido"].Visible = false;

                dgvListado.Columns["nombre_completo"].HeaderText = "Nombres y Apellidos";
                dgvListado.Columns["nombre_completo"].FillWeight = 160;
                dgvListado.Columns["nombre_completo"].MinimumWidth = 120;

                dgvListado.Columns["num_documento"].HeaderText = "Documento";
                dgvListado.Columns["num_documento"].FillWeight = 75;
                dgvListado.Columns["num_documento"].MinimumWidth = 60;

                dgvListado.Columns["departamento"].HeaderText = "Departamento";
                dgvListado.Columns["departamento"].FillWeight = 100;
                dgvListado.Columns["departamento"].MinimumWidth = 80;

                dgvListado.Columns["cargo"].HeaderText = "Cargo";
                dgvListado.Columns["cargo"].FillWeight = 90;
                dgvListado.Columns["cargo"].MinimumWidth = 70;

                if (dgvListado.Columns.Contains("turno"))
                {
                    dgvListado.Columns["turno"].HeaderText = "Turno / Horario";
                    dgvListado.Columns["turno"].FillWeight = 100;
                    dgvListado.Columns["turno"].MinimumWidth = 80;
                }

                if (dgvListado.Columns.Contains("turnoid"))
                    dgvListado.Columns["turnoid"].Visible = false;

                if (dgvListado.Columns.Contains("department_id"))
                    dgvListado.Columns["department_id"].Visible = false;

                if (dgvListado.Columns.Contains("position_id"))
                    dgvListado.Columns["position_id"].Visible = false;

                dgvListado.Columns["tarjeta_rfid"].HeaderText = "Tarjeta RFID";
                dgvListado.Columns["tarjeta_rfid"].FillWeight = 65;
                dgvListado.Columns["tarjeta_rfid"].MinimumWidth = 55;

                dgvListado.Columns["email"].Visible = false;
                dgvListado.Columns["telefono"].Visible = false;
                dgvListado.Columns["password_biometrico"].Visible = false;

                dgvListado.Columns["privilegio"].HeaderText = "Privilegio";
                dgvListado.Columns["privilegio"].FillWeight = 55;
                dgvListado.Columns["privilegio"].MinimumWidth = 45;

                dgvListado.Columns["habilitado"].HeaderText = "Habilitado";
                dgvListado.Columns["habilitado"].FillWeight = 50;
                dgvListado.Columns["habilitado"].MinimumWidth = 40;

                dgvListado.Columns["fecha_registro"].HeaderText = "F. Registro";
                dgvListado.Columns["fecha_registro"].FillWeight = 75;
                dgvListado.Columns["fecha_registro"].MinimumWidth = 65;
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
                    DataTable tabla = N_Empleado.Buscar(valor);
                    dgvListado.DataSource = tabla;
                    FormatearGrid();
                    lblTotal.Text = "Total de registros encontrados: " + tabla.Rows.Count;
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
            LimpiarCampos();
            tabPrincipal.SelectedIndex = 1;
            txtCodigoBiometrico.Focus();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtCodigoBiometrico.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtNumDocumento.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            txtDepartamento.Clear();
            txtCargo.Clear();
            txtTarjetaRFID.Clear();
            txtPasswordBio.Clear();
            cboPrivilegio.SelectedIndex = 0;
            chkHabilitado.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string codigo = txtCodigoBiometrico.Text.Trim();
                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string documento = txtNumDocumento.Text.Trim();
                string email = txtEmail.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string departamento = txtDepartamento.Text.Trim();
                string cargo = txtCargo.Text.Trim();
                string tarjeta = txtTarjetaRFID.Text.Trim();
                string passwordBio = txtPasswordBio.Text.Trim();
                int privilegio = cboPrivilegio.SelectedIndex == 1 ? 3 : 0;
                bool habilitado = chkHabilitado.Checked;

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("El código biométrico (Enroll Number) es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoBiometrico.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre del empleado es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                string respuesta;
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    // Insertar
                    respuesta = N_Empleado.Insertar(codigo, nombre, apellido, documento, email, telefono, departamento, cargo, tarjeta, passwordBio, privilegio, habilitado);
                }
                else
                {
                    // Actualizar
                    int id = Convert.ToInt32(txtId.Text);
                    respuesta = N_Empleado.Actualizar(id, codigo, nombre, apellido, documento, email, telefono, departamento, cargo, tarjeta, passwordBio, privilegio, habilitado);
                }

                if (respuesta == "OK")
                {
                    MessageBox.Show("Empleado guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos();
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
            LimpiarCampos();
            tabPrincipal.SelectedIndex = 0;
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvListado.Rows[e.RowIndex];
                txtId.Text = Convert.ToString(fila.Cells["idempleado"].Value);
                txtCodigoBiometrico.Text = Convert.ToString(fila.Cells["codigo_biometrico"].Value);
                txtNombre.Text = Convert.ToString(fila.Cells["nombre"].Value);
                txtApellido.Text = Convert.ToString(fila.Cells["apellido"].Value);
                txtNumDocumento.Text = Convert.ToString(fila.Cells["num_documento"].Value);
                txtEmail.Text = Convert.ToString(fila.Cells["email"].Value);
                txtTelefono.Text = Convert.ToString(fila.Cells["telefono"].Value);
                txtDepartamento.Text = Convert.ToString(fila.Cells["departamento"].Value);
                txtCargo.Text = Convert.ToString(fila.Cells["cargo"].Value);
                txtTarjetaRFID.Text = Convert.ToString(fila.Cells["tarjeta_rfid"].Value);
                txtPasswordBio.Text = Convert.ToString(fila.Cells["password_biometrico"].Value);

                int priv = Convert.ToInt32(fila.Cells["privilegio"].Value);
                cboPrivilegio.SelectedIndex = priv == 3 ? 1 : 0;
                chkHabilitado.Checked = Convert.ToBoolean(fila.Cells["habilitado"].Value);

                tabPrincipal.SelectedIndex = 1;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el empleado que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idempleado"].Value);
            string codigo = Convert.ToString(dgvListado.CurrentRow.Cells["codigo_biometrico"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre_completo"].Value);

            string advertencia =
                $"⚠️ ADVERTENCIA DE ELIMINACIÓN TOTAL ⚠️\n\n" +
                $"¿Está completamente seguro de eliminar al empleado:\n" +
                $"• Código Biométrico: {codigo}\n" +
                $"• Nombre: {nombre}\n\n" +
                $"Esta acción realizará lo siguiente:\n" +
                $"1. Se dará de baja y eliminará el registro en la Base de Datos del Sistema.\n" +
                $"2. Se borrarán permanentemente sus huellas dactilares, rostros, tarjetas RFID y credenciales de TODOS los relojes biométricos conectados.\n\n" +
                $"¿Desea proceder con la eliminación total?";

            if (MessageBox.Show(advertencia, "Confirmar Eliminación Total (Sistema y Relojes)", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    // 1. Eliminar de la Base de Datos
                    string resBD = N_Empleado.Eliminar(id);
                    if (resBD != "OK")
                    {
                        MessageBox.Show("Error al eliminar de la base de datos: " + resBD, "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 2. Eliminar de todos los dispositivos biométricos activos
                    List<Biometrico> biometricos = N_Biometrico.ListarActivos();
                    int eliminadosEnRelojes = 0;
                    List<string> logsRelojes = new List<string>();

                    using (var service = new ZKTecoService())
                    {
                        foreach (var bio in biometricos)
                        {
                            string msgCon;
                            if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msgCon))
                            {
                                string msgDel;
                                if (service.EliminarUsuario(codigo, out msgDel))
                                {
                                    service.EmitirPitido(100);
                                    eliminadosEnRelojes++;
                                    logsRelojes.Add($"✓ {bio.Nombre} ({bio.DireccionIP}): Eliminado correctamente.");
                                }
                                else
                                {
                                    logsRelojes.Add($"✗ {bio.Nombre} ({bio.DireccionIP}): {msgDel}");
                                }
                                service.Desconectar();
                            }
                            else
                            {
                                logsRelojes.Add($"✗ {bio.Nombre} ({bio.DireccionIP}): No se pudo conectar.");
                            }
                        }
                    }

                    Cursor = Cursors.Default;
                    string resultadoMsg = $"Empleado '{nombre}' (Cód: {codigo}) eliminado exitosamente.\n\n" +
                                         $"• Base de Datos: Registro eliminado\n" +
                                         $"• Relojes Biométricos sincronizados: {eliminadosEnRelojes} de {biometricos.Count}\n\n" +
                                         string.Join("\n", logsRelojes);

                    MessageBox.Show(resultadoMsg, "Eliminación Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListado();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Excepción durante la eliminación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idempleado"].Value);
            N_Empleado.Activar(id);
            CargarListado();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idempleado"].Value);
            N_Empleado.Desactivar(id);
            CargarListado();
        }

        private void btnDescargarBiometrico_Click(object sender, EventArgs e)
        {
            List<Biometrico> biometricos = N_Biometrico.ListarActivos();
            if (biometricos.Count == 0)
            {
                MessageBox.Show("No hay dispositivos biométricos activos registrados. Vaya al módulo de Biométricos para agregar uno.", 
                                "Sin Dispositivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Biometrico bio = biometricos[0]; // Por defecto el primero o permitir elegir
            if (biometricos.Count > 1)
            {
                // Si hay varios, se puede seleccionar
                bio = SeleccionarBiometrico(biometricos);
                if (bio == null) return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                using (var service = new ZKTecoService())
                {
                    string msgCon;
                    if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msgCon))
                    {
                        string msgDescarga;
                        List<Empleado> usuarios = service.DescargarUsuarios(out msgDescarga);
                        service.Desconectar();

                        if (usuarios.Count > 0)
                        {
                            int sincronizados = N_Empleado.SincronizarListaDesdeBiometrico(usuarios);
                            N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Conectado", DateTime.Now);
                            MessageBox.Show($"{msgDescarga}\n\nSe insertaron/actualizaron {sincronizados} empleados en la Base de Datos.", 
                                            "Descarga Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarListado();
                        }
                        else
                        {
                            MessageBox.Show("No se encontraron usuarios en el biométrico o hubo un error:\n" + msgDescarga, 
                                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo conectar al biométrico en " + bio.DireccionIP + ":\n" + msgCon, 
                                        "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la sincronización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSubirBiometrico_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el empleado que desea subir al dispositivo biométrico.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Biometrico> biometricos = N_Biometrico.ListarActivos();
            if (biometricos.Count == 0)
            {
                MessageBox.Show("No hay dispositivos biométricos activos registrados.", "Sin Dispositivos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Biometrico bio = biometricos[0];
            if (biometricos.Count > 1)
            {
                bio = SeleccionarBiometrico(biometricos);
                if (bio == null) return;
            }

            string codigo = Convert.ToString(dgvListado.CurrentRow.Cells["codigo_biometrico"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre_completo"].Value);
            string password = Convert.ToString(dgvListado.CurrentRow.Cells["password_biometrico"].Value);
            int privilegio = Convert.ToInt32(dgvListado.CurrentRow.Cells["privilegio"].Value);
            bool habilitado = Convert.ToBoolean(dgvListado.CurrentRow.Cells["habilitado"].Value);
            string tarjeta = Convert.ToString(dgvListado.CurrentRow.Cells["tarjeta_rfid"].Value);

            Cursor = Cursors.WaitCursor;
            try
            {
                using (var service = new ZKTecoService())
                {
                    string msgCon;
                    if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msgCon))
                    {
                        string msgSubida;
                        if (service.SubirUsuario(codigo, nombre, password, privilegio, habilitado, tarjeta, out msgSubida))
                        {
                            service.EmitirPitido(100);
                            service.Desconectar();
                            MessageBox.Show($"Empleado '{nombre}' (Código: {codigo}) enviado exitosamente al biométrico '{bio.Nombre}' ({bio.DireccionIP}).", 
                                            "Sincronización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            service.Desconectar();
                            MessageBox.Show("Error al subir empleado: " + msgSubida, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo conectar al biométrico: " + msgCon, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private Biometrico SeleccionarBiometrico(List<Biometrico> lista)
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 420;
                prompt.Height = 200;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Seleccionar Biométrico";
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label lbl = new Label() { Left = 20, Top = 20, Width = 360, Text = "Seleccione el dispositivo biométrico de destino:" };
                ComboBox combo = new ComboBox() { Left = 20, Top = 50, Width = 360, DropDownStyle = ComboBoxStyle.DropDownList };
                
                foreach (var b in lista)
                {
                    combo.Items.Add($"{b.Nombre} ({b.DireccionIP}:{b.Puerto})");
                }
                combo.SelectedIndex = 0;

                Button confirmation = new Button() { Text = "Aceptar", Left = 180, Width = 90, Top = 100, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Cancelar", Left = 280, Width = 90, Top = 100, DialogResult = DialogResult.Cancel };

                prompt.Controls.Add(lbl);
                prompt.Controls.Add(combo);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? lista[combo.SelectedIndex] : null;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvListado,
                "Listado_Empleados",
                "Padrón Oficial de Empleados",
                new Dictionary<string, string> { { "Módulo", "Gestión de Empleados" } });
        }
    }
}
