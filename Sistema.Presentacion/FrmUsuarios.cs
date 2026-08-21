using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmUsuarios : RJCodeUI_M1.RJForms.RJChildForm
    {
        public FrmUsuarios()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.UserShield;
            this.Text = "Usuarios del Sistema";
            this.tabPrincipal.Appearance = TabAppearance.FlatButtons;
            this.tabPrincipal.ItemSize = new Size(0, 1);
            this.tabPrincipal.SizeMode = TabSizeMode.Fixed;
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(this);
            if (cboTipoDocumento.Items.Count > 0) cboTipoDocumento.SelectedIndex = 0;
            tabPrincipal.SelectedIndexChanged += tabPrincipal_SelectedIndexChanged;
            CargarRoles();
            CargarListado();
        }

        private void tabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPrincipal.SelectedTab == tabPageAdminsBio)
            {
                CargarAdminsBio();
            }
        }

        private void CargarRoles()
        {
            try
            {
                DataTable dtRoles = N_Rol.Seleccionar();
                cboRol.DataSource = dtRoles;
                cboRol.ValueMember = "idrol";
                cboRol.DisplayMember = "nombre";
            }
            catch
            {
            }
        }

        private void CargarListado()
        {
            try
            {
                DataTable tabla = N_Usuario.Listar();
                dgvListado.DataSource = tabla;
                FormatearGrid();
                lblTotal.Text = "Total de registros: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrid()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvListado);

            if (dgvListado.Columns.Count > 0)
            {
                if (dgvListado.Columns.Contains("idusuario"))
                {
                    dgvListado.Columns["idusuario"].HeaderText = "ID";
                    dgvListado.Columns["idusuario"].FillWeight = 40;
                    dgvListado.Columns["idusuario"].MinimumWidth = 35;
                }

                if (dgvListado.Columns.Contains("username"))
                {
                    dgvListado.Columns["username"].HeaderText = "Usuario";
                    dgvListado.Columns["username"].FillWeight = 90;
                    dgvListado.Columns["username"].MinimumWidth = 70;
                }

                if (dgvListado.Columns.Contains("idrol"))
                    dgvListado.Columns["idrol"].Visible = false;

                if (dgvListado.Columns.Contains("rol"))
                {
                    dgvListado.Columns["rol"].HeaderText = "Rol";
                    dgvListado.Columns["rol"].FillWeight = 90;
                    dgvListado.Columns["rol"].MinimumWidth = 70;
                }

                if (dgvListado.Columns.Contains("nombre"))
                {
                    dgvListado.Columns["nombre"].HeaderText = "Nombre Completo";
                    dgvListado.Columns["nombre"].FillWeight = 160;
                    dgvListado.Columns["nombre"].MinimumWidth = 120;
                }

                if (dgvListado.Columns.Contains("tipo_documento"))
                {
                    dgvListado.Columns["tipo_documento"].HeaderText = "Tipo Doc";
                    dgvListado.Columns["tipo_documento"].FillWeight = 70;
                    dgvListado.Columns["tipo_documento"].MinimumWidth = 55;
                }

                if (dgvListado.Columns.Contains("num_documento"))
                {
                    dgvListado.Columns["num_documento"].HeaderText = "N° Documento";
                    dgvListado.Columns["num_documento"].FillWeight = 85;
                    dgvListado.Columns["num_documento"].MinimumWidth = 65;
                }

                if (dgvListado.Columns.Contains("email"))
                {
                    dgvListado.Columns["email"].HeaderText = "Email";
                    dgvListado.Columns["email"].FillWeight = 130;
                    dgvListado.Columns["email"].MinimumWidth = 100;
                }

                if (dgvListado.Columns.Contains("telefono"))
                {
                    dgvListado.Columns["telefono"].HeaderText = "Teléfono";
                    dgvListado.Columns["telefono"].FillWeight = 85;
                    dgvListado.Columns["telefono"].MinimumWidth = 65;
                }

                if (dgvListado.Columns.Contains("direccion"))
                {
                    dgvListado.Columns["direccion"].HeaderText = "Dirección";
                    dgvListado.Columns["direccion"].FillWeight = 110;
                    dgvListado.Columns["direccion"].MinimumWidth = 80;
                }

                if (dgvListado.Columns.Contains("estado"))
                {
                    dgvListado.Columns["estado"].HeaderText = "Activo";
                    dgvListado.Columns["estado"].FillWeight = 50;
                    dgvListado.Columns["estado"].MinimumWidth = 40;
                }

                if (dgvListado.Columns.Contains("ultimo_login"))
                {
                    dgvListado.Columns["ultimo_login"].HeaderText = "Último Acceso";
                    dgvListado.Columns["ultimo_login"].FillWeight = 100;
                    dgvListado.Columns["ultimo_login"].MinimumWidth = 80;
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
                    DataTable tabla = N_Usuario.Buscar(valor);
                    dgvListado.DataSource = tabla;
                    FormatearGrid();
                    lblTotal.Text = "Total de registros: " + tabla.Rows.Count;
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
            txtNombre.Focus();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            if (cboTipoDocumento.Items.Count > 0) cboTipoDocumento.SelectedIndex = 0;
            txtNumDocumento.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtClave.Clear();
            if (cboRol.Items.Count > 0) cboRol.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboRol.SelectedValue == null)
                {
                    MessageBox.Show("Debe seleccionar un rol para el usuario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idRol = Convert.ToInt32(cboRol.SelectedValue);
                string nombre = txtNombre.Text.Trim();
                string tipoDoc = cboTipoDocumento.SelectedItem != null ? cboTipoDocumento.SelectedItem.ToString() : "DNI";
                string numDoc = txtNumDocumento.Text.Trim();
                string direccion = txtDireccion.Text.Trim();
                string telefono = txtTelefono.Text.Trim();
                string email = txtEmail.Text.Trim();
                string clave = txtClave.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre del usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("El correo electrónico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return;
                }

                string respuesta;
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    if (string.IsNullOrWhiteSpace(clave))
                    {
                        MessageBox.Show("La contraseña de acceso es obligatoria para nuevos usuarios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtClave.Focus();
                        return;
                    }
                    respuesta = N_Usuario.Insertar(idRol, nombre, tipoDoc, numDoc, direccion, telefono, email, clave);
                }
                else
                {
                    int id = Convert.ToInt32(txtId.Text);
                    respuesta = N_Usuario.Actualizar(id, idRol, nombre, tipoDoc, numDoc, direccion, telefono, email, clave);
                }

                if (respuesta == "OK")
                {
                    MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtId.Text = Convert.ToString(fila.Cells["idusuario"].Value);
                txtNombre.Text = Convert.ToString(fila.Cells["nombre"].Value);

                if (dgvListado.Columns.Contains("tipo_documento") && fila.Cells["tipo_documento"].Value != null)
                {
                    string tipoDoc = Convert.ToString(fila.Cells["tipo_documento"].Value);
                    int idx = cboTipoDocumento.FindStringExact(tipoDoc);
                    if (idx >= 0) cboTipoDocumento.SelectedIndex = idx;
                }

                if (dgvListado.Columns.Contains("num_documento") && fila.Cells["num_documento"].Value != null)
                    txtNumDocumento.Text = Convert.ToString(fila.Cells["num_documento"].Value);

                if (dgvListado.Columns.Contains("direccion") && fila.Cells["direccion"].Value != null)
                    txtDireccion.Text = Convert.ToString(fila.Cells["direccion"].Value);

                if (dgvListado.Columns.Contains("telefono") && fila.Cells["telefono"].Value != null)
                    txtTelefono.Text = Convert.ToString(fila.Cells["telefono"].Value);

                if (dgvListado.Columns.Contains("email") && fila.Cells["email"].Value != null)
                    txtEmail.Text = Convert.ToString(fila.Cells["email"].Value);

                txtClave.Clear();

                if (dgvListado.Columns.Contains("rol") && fila.Cells["rol"].Value != null)
                {
                    string rol = Convert.ToString(fila.Cells["rol"].Value);
                    int idxRol = cboRol.FindStringExact(rol);
                    if (idxRol >= 0) cboRol.SelectedIndex = idxRol;
                }

                tabPrincipal.SelectedIndex = 1;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el usuario que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idusuario"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value);

            if (MessageBox.Show($"¿Está seguro de eliminar al usuario '{nombre}'?",
                                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string res = N_Usuario.Eliminar(id);
                if (res == "OK")
                {
                    MessageBox.Show("Usuario eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListado();
                }
                else
                {
                    MessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idusuario"].Value);
            N_Usuario.Activar(id);
            CargarListado();
        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null) return;
            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idusuario"].Value);
            N_Usuario.Desactivar(id);
            CargarListado();
        }

        #region Gestión de Administradores de Biométricos

        public void CargarAdminsBio()
        {
            try
            {
                DataTable tabla = N_Empleado.ListarAdministradoresBiometricos();
                if (dgvAdminsBio == null) return;
                dgvAdminsBio.DataSource = tabla;
                if (tabla.Rows.Count > 0)
                    FormatearGridAdminsBio();
                lblTotalAdminsBio.Text = "Total de Administradores: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar administradores biométricos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGridAdminsBio()
        {
            try
            {
                Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvAdminsBio);

                if (dgvAdminsBio == null || dgvAdminsBio.Columns.Count == 0) return;

                foreach (DataGridViewColumn col in dgvAdminsBio.Columns)
                {
                    if (col == null) continue;
                    switch (col.Name.ToLower())
                    {
                        case "idempleado":
                        case "privilegio":
                            col.Visible = false;
                            break;
                        case "codigo_biometrico":
                            col.HeaderText = "Código";
                            col.Width = 90;
                            break;
                        case "nombre_completo":
                            col.HeaderText = "Nombre Completo";
                            col.Width = 220;
                            break;
                        case "departamento":
                            col.HeaderText = "Departamento";
                            col.Width = 160;
                            break;
                        case "cargo":
                            col.HeaderText = "Cargo";
                            col.Width = 140;
                            break;
                        case "privilegio_texto":
                            col.HeaderText = "Nivel de Privilegio";
                            col.Width = 160;
                            break;
                        case "tiene_clave":
                            col.HeaderText = "¿Tiene Contraseña?";
                            col.Width = 120;
                            break;
                        case "tarjeta_rfid":
                            col.HeaderText = "Tarjeta RFID";
                            col.Width = 110;
                            break;
                        case "estado":
                            col.HeaderText = "Estado";
                            col.Width = 80;
                            break;
                    }
                }
            }
            catch
            {
            }
        }


        private void btnRefrescarAdminsBio_Click(object sender, EventArgs e)
        {
            CargarAdminsBio();
        }

        private void btnConsultarRelojDirecto_Click(object sender, EventArgs e)
        {
            var biometricos = N_Biometrico.ListarActivos();
            if (biometricos.Count == 0)
            {
                MessageBox.Show("No hay dispositivos biométricos activos registrados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.AppendLine("=== ADMINISTRADORES DETECTADOS EN RELOJES FÍSICOS ===");
            sb.AppendLine();

            int totalDetectados = 0;

            try
            {
                using (var service = new ZKTecoService())
                {
                    foreach (var bio in biometricos)
                    {
                        string msgCon;
                        if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msgCon))
                        {
                            string msgUsers;
                            var usuarios = service.DescargarUsuarios(out msgUsers);
                            service.Desconectar();

                            var admins = usuarios.FindAll(u => u.Privilegio > 0 || u.CodigoBiometrico == "99999" || u.CodigoBiometrico == "888" || u.CodigoBiometrico == "3054" || u.CodigoBiometrico == "305150715");
                            sb.AppendLine($"📌 Dispositivo: {bio.Nombre} ({bio.DireccionIP}) - Total Admins: {admins.Count}");

                            foreach (var a in admins)
                            {
                                string tipoPriv = a.Privilegio == 3 ? "Super Administrador (3)" : a.Privilegio == 14 ? "Administrador (14)" : $"Nivel {a.Privilegio}";
                                string tienePass = !string.IsNullOrEmpty(a.PasswordBiometrico) ? " [Con Contraseña]" : "";
                                string tieneCard = !string.IsNullOrEmpty(a.TarjetaRFID) && a.TarjetaRFID != "0" ? $" [Tarjeta: {a.TarjetaRFID}]" : "";
                                sb.AppendLine($"   • Cód: {a.CodigoBiometrico,-10} | Nombre: {a.Nombre,-25} | Rol: {tipoPriv}{tienePass}{tieneCard}");
                                totalDetectados++;
                            }
                            sb.AppendLine();
                        }
                        else
                        {
                            sb.AppendLine($"❌ Dispositivo: {bio.Nombre} ({bio.DireccionIP}) - Error: {msgCon}");
                            sb.AppendLine();
                        }
                    }
                }

                Cursor = Cursors.Default;
                MessageBox.Show(sb.ToString(), "Administradores en Dispositivos Físicos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarAdminsBio();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al consultar dispositivos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOtorgarAdminBio_Click(object sender, EventArgs e)
        {
            DataTable dtEmpleados = N_Empleado.Listar();
            if (dtEmpleados.Rows.Count == 0)
            {
                MessageBox.Show("No hay empleados registrados para seleccionar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form prompt = new Form())
            {
                prompt.Width = 480;
                prompt.Height = 220;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Otorgar Permiso de Administrador en Reloj";
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label lbl = new Label() { Left = 20, Top = 15, Width = 420, Text = "Seleccione el empleado al que desea otorgar permiso de Administrador:" };
                ComboBox combo = new ComboBox() { Left = 20, Top = 45, Width = 420, DropDownStyle = ComboBoxStyle.DropDownList };

                System.Collections.Generic.List<DataRow> filas = new System.Collections.Generic.List<DataRow>();
                foreach (DataRow r in dtEmpleados.Rows)
                {
                    combo.Items.Add($"Cód: {r["codigo_biometrico"]} - {r["nombre_completo"]} ({r["departamento"]})");
                    filas.Add(r);
                }
                combo.SelectedIndex = 0;

                Button confirmation = new Button() { Text = "⭐ Otorgar Admin", Left = 210, Width = 130, Top = 100, DialogResult = DialogResult.OK, BackColor = Color.FromArgb(239, 108, 0), ForeColor = Color.White, FlatStyle = FlatStyle.Flat };
                Button cancel = new Button() { Text = "Cancelar", Left = 350, Width = 90, Top = 100, DialogResult = DialogResult.Cancel, FlatStyle = FlatStyle.Flat };

                prompt.Controls.Add(lbl);
                prompt.Controls.Add(combo);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = confirmation;

                if (prompt.ShowDialog() == DialogResult.OK)
                {
                    DataRow empSeleccionado = filas[combo.SelectedIndex];
                    int idEmp = Convert.ToInt32(empSeleccionado["idempleado"]);
                    string codBio = Convert.ToString(empSeleccionado["codigo_biometrico"]);
                    string nom = Convert.ToString(empSeleccionado["nombre_completo"]);

                    Cursor = Cursors.WaitCursor;
                    try
                    {
                        N_Empleado.ActualizarPrivilegioBiometrico(idEmp, 3);

                        var biometricos = N_Biometrico.ListarActivos();
                        int actualizados = 0;
                        using (var service = new ZKTecoService())
                        {
                            foreach (var bio in biometricos)
                            {
                                string msgCon;
                                if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msgCon))
                                {
                                    string msgSub;
                                    string pass = empSeleccionado["password_biometrico"] != DBNull.Value ? Convert.ToString(empSeleccionado["password_biometrico"]) : "";
                                    string card = empSeleccionado["tarjeta_rfid"] != DBNull.Value ? Convert.ToString(empSeleccionado["tarjeta_rfid"]) : "";
                                    bool hab = Convert.ToBoolean(empSeleccionado["habilitado"]);

                                    if (service.SubirUsuario(codBio, nom, pass, 3, hab, card, out msgSub))
                                    {
                                        actualizados++;
                                    }
                                    service.Desconectar();
                                }
                            }
                        }

                        Cursor = Cursors.Default;
                        MessageBox.Show($"Empleado '{nom}' (Cód: {codBio}) ahora es Super Administrador.\nSincronizado en {actualizados} reloj(es) biométrico(s).", "Permiso Otorgado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarAdminsBio();
                    }
                    catch (Exception ex)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show("Error al otorgar permiso: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRevocarAdminBio_Click(object sender, EventArgs e)
        {
            if (dgvAdminsBio.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el administrador de la lista que desea revocar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvAdminsBio.CurrentRow.Cells["idempleado"].Value);
            string codigo = Convert.ToString(dgvAdminsBio.CurrentRow.Cells["codigo_biometrico"].Value);
            string nombre = Convert.ToString(dgvAdminsBio.CurrentRow.Cells["nombre_completo"].Value);

            string advertencia =
                $"¿Está seguro de revocar el permiso de Administrador al empleado:\n\n" +
                $"• Código: {codigo}\n" +
                $"• Nombre: {nombre}\n\n" +
                $"El usuario pasará a ser 'Usuario Normal' y no podrá acceder al menú de configuración en los relojes biométricos.";

            if (MessageBox.Show(advertencia, "Confirmar Revocación de Privilegio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    N_Empleado.ActualizarPrivilegioBiometrico(id, 0);

                    var biometricos = N_Biometrico.ListarActivos();
                    int actualizados = 0;
                    using (var service = new ZKTecoService())
                    {
                        foreach (var bio in biometricos)
                        {
                            string msgCon;
                            if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msgCon))
                            {
                                string msgSub;
                                if (service.SubirUsuario(codigo, nombre, "", 0, true, "", out msgSub))
                                {
                                    actualizados++;
                                }
                                service.Desconectar();
                            }
                        }
                    }

                    Cursor = Cursors.Default;
                    MessageBox.Show($"Privilegio de administrador revocado para '{nombre}'.\nSincronizado en {actualizados} reloj(es) biométrico(s).", "Revocación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarAdminsBio();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Error al revocar privilegio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIrAdminsBio_Click(object sender, EventArgs e)
        {
            tabPrincipal.SelectedTab = tabPageAdminsBio;
            CargarAdminsBio();
        }

        private void btnVolverDeAdminsBio_Click(object sender, EventArgs e)
        {
            tabPrincipal.SelectedTab = tabPageListado;
            CargarListado();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvListado,
                "Listado_Usuarios_Sistema",
                "Usuarios con Acceso al Sistema",
                new Dictionary<string, string> { { "Módulo", "Usuarios del Sistema" } });
        }

        private void btnExportarAdminsBio_Click(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ReporteExporter.ExportarDataGridViewConDialogo(
                dgvAdminsBio,
                "Administradores_Relojes_Biometricos",
                "Personal con Privilegios en Dispositivos ZKTeco",
                new Dictionary<string, string> { { "Módulo", "Admins de Biométrico" } });
        }

        #endregion
    }
}
