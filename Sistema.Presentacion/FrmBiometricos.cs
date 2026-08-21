using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Entidades;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmBiometricos : RJCodeUI_M1.RJForms.RJChildForm
    {
        public FrmBiometricos()
        {
            InitializeComponent();
            this.FormIcon = FontAwesome.Sharp.IconChar.Fingerprint;
            this.Text = "Gestión de Biométricos ZKTeco";
            this.tabPrincipal.Appearance = TabAppearance.FlatButtons;
            this.tabPrincipal.ItemSize = new Size(0, 1);
            this.tabPrincipal.SizeMode = TabSizeMode.Fixed;
        }

        private void FrmBiometricos_Load(object sender, EventArgs e)
        {
            Sistema.Presentacion.Utils.ThemeManager.AplicarTemaFormulario(this);
            CargarListado();
        }

        private void CargarListado()
        {
            try
            {
                DataTable tabla = N_Biometrico.Listar();
                dgvListado.DataSource = tabla;
                FormatearGrid();
                lblTotal.Text = "Total de registros: " + tabla.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar biométricos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatearGrid()
        {
            Sistema.Presentacion.Utils.GridStyler.AplicarEstilo(dgvListado);

            if (dgvListado.Columns.Count > 0)
            {
                dgvListado.Columns["idbiometrico"].HeaderText = "ID";
                dgvListado.Columns["idbiometrico"].FillWeight = 40;
                dgvListado.Columns["idbiometrico"].MinimumWidth = 35;

                dgvListado.Columns["nombre"].HeaderText = "Nombre Biométrico";
                dgvListado.Columns["nombre"].FillWeight = 140;
                dgvListado.Columns["nombre"].MinimumWidth = 110;

                dgvListado.Columns["direccion_ip"].HeaderText = "Dirección IP";
                dgvListado.Columns["direccion_ip"].FillWeight = 95;
                dgvListado.Columns["direccion_ip"].MinimumWidth = 80;

                dgvListado.Columns["puerto"].HeaderText = "Puerto";
                dgvListado.Columns["puerto"].FillWeight = 55;
                dgvListado.Columns["puerto"].MinimumWidth = 45;

                dgvListado.Columns["comm_key"].HeaderText = "CommKey";
                dgvListado.Columns["comm_key"].FillWeight = 60;
                dgvListado.Columns["comm_key"].MinimumWidth = 50;

                dgvListado.Columns["ubicacion"].HeaderText = "Ubicación";
                dgvListado.Columns["ubicacion"].FillWeight = 110;
                dgvListado.Columns["ubicacion"].MinimumWidth = 80;

                dgvListado.Columns["modelo"].HeaderText = "Modelo";
                dgvListado.Columns["modelo"].FillWeight = 90;
                dgvListado.Columns["modelo"].MinimumWidth = 70;

                dgvListado.Columns["numero_serie"].HeaderText = "N° Serie";
                dgvListado.Columns["numero_serie"].FillWeight = 90;
                dgvListado.Columns["numero_serie"].MinimumWidth = 70;

                dgvListado.Columns["estado_conexion"].HeaderText = "Estado";
                dgvListado.Columns["estado_conexion"].FillWeight = 75;
                dgvListado.Columns["estado_conexion"].MinimumWidth = 60;

                dgvListado.Columns["ultima_sincronizacion"].HeaderText = "Última Sync";
                dgvListado.Columns["ultima_sincronizacion"].FillWeight = 95;
                dgvListado.Columns["ultima_sincronizacion"].MinimumWidth = 75;

                dgvListado.Columns["activo"].HeaderText = "Activo";
                dgvListado.Columns["activo"].FillWeight = 50;
                dgvListado.Columns["activo"].MinimumWidth = 40;
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
                    DataTable tabla = N_Biometrico.Buscar(valor);
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
            LimpiarCampos();
            tabPrincipal.SelectedIndex = 1;
            txtNombre.Focus();
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Text = "Biométrico Principal";
            txtDireccionIP.Text = "192.168.1.201";
            txtPuerto.Text = "4370";
            txtCommKey.Text = "0";
            txtUbicacion.Text = "Recepción";
            txtModelo.Text = "ZKTeco K40 / MB20";
            txtNumeroSerie.Clear();
            chkActivo.Checked = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string ip = txtDireccionIP.Text.Trim();
                int puerto = 4370;
                int.TryParse(txtPuerto.Text.Trim(), out puerto);
                int commKey = 0;
                int.TryParse(txtCommKey.Text.Trim(), out commKey);
                string ubicacion = txtUbicacion.Text.Trim();
                string modelo = txtModelo.Text.Trim();
                string sn = txtNumeroSerie.Text.Trim();
                bool activo = chkActivo.Checked;

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El nombre del biométrico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(ip))
                {
                    MessageBox.Show("La dirección IP es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDireccionIP.Focus();
                    return;
                }

                string respuesta;
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    respuesta = N_Biometrico.Insertar(nombre, ip, puerto, commKey, ubicacion, modelo, sn, activo);
                }
                else
                {
                    int id = Convert.ToInt32(txtId.Text);
                    respuesta = N_Biometrico.Actualizar(id, nombre, ip, puerto, commKey, ubicacion, modelo, sn, activo);
                }

                if (respuesta == "OK")
                {
                    MessageBox.Show("Biométrico guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtId.Text = Convert.ToString(fila.Cells["idbiometrico"].Value);
                txtNombre.Text = Convert.ToString(fila.Cells["nombre"].Value);
                txtDireccionIP.Text = Convert.ToString(fila.Cells["direccion_ip"].Value);
                txtPuerto.Text = Convert.ToString(fila.Cells["puerto"].Value);
                txtCommKey.Text = Convert.ToString(fila.Cells["comm_key"].Value);
                txtUbicacion.Text = Convert.ToString(fila.Cells["ubicacion"].Value);
                txtModelo.Text = Convert.ToString(fila.Cells["modelo"].Value);
                txtNumeroSerie.Text = Convert.ToString(fila.Cells["numero_serie"].Value);
                chkActivo.Checked = Convert.ToBoolean(fila.Cells["activo"].Value);

                tabPrincipal.SelectedIndex = 1;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Seleccione el biométrico que desea eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(dgvListado.CurrentRow.Cells["idbiometrico"].Value);
            string nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value);

            if (MessageBox.Show($"¿Está seguro de eliminar el registro del biométrico '{nombre}'?", 
                                "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string res = N_Biometrico.Eliminar(id);
                if (res == "OK")
                {
                    MessageBox.Show("Biométrico eliminado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListado();
                }
                else
                {
                    MessageBox.Show(res, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region Operaciones Directas con ZKTecoService

        private Biometrico ObtenerBiometricoSeleccionado()
        {
            if (dgvListado.CurrentRow == null)
            {
                MessageBox.Show("Por favor seleccione un dispositivo biométrico de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            return new Biometrico
            {
                IdBiometrico = Convert.ToInt32(dgvListado.CurrentRow.Cells["idbiometrico"].Value),
                Nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value),
                DireccionIP = Convert.ToString(dgvListado.CurrentRow.Cells["direccion_ip"].Value),
                Puerto = Convert.ToInt32(dgvListado.CurrentRow.Cells["puerto"].Value),
                CommKey = Convert.ToInt32(dgvListado.CurrentRow.Cells["comm_key"].Value)
            };
        }

        private void btnProbarConexion_Click(object sender, EventArgs e)
        {
            Biometrico bio = ObtenerBiometricoSeleccionado();
            if (bio == null) return;

            Cursor = Cursors.WaitCursor;
            try
            {
                using (var service = new ZKTecoService())
                {
                    string msg;
                    if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msg))
                    {
                        service.EmitirPitido(100);
                        var info = service.ObtenerInformacionDispositivo();
                        service.Desconectar();

                        string sn = info.ContainsKey("NumeroSerie") ? info["NumeroSerie"] : "";
                        string modelo = info.ContainsKey("Modelo") ? info["Modelo"] : "";
                        string firmware = info.ContainsKey("Firmware") ? info["Firmware"] : "";
                        string usuarios = info.ContainsKey("CantidadUsuarios") ? info["CantidadUsuarios"] : "";
                        string huellas = info.ContainsKey("CantidadHuellas") ? info["CantidadHuellas"] : "";
                        string logs = info.ContainsKey("CantidadLogs") ? info["CantidadLogs"] : "";

                        int uCount = 0, hCount = 0, lCount = 0;
                        int.TryParse(usuarios, out uCount);
                        int.TryParse(huellas, out hCount);
                        int.TryParse(logs, out lCount);

                        N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Conectado", DateTime.Now, modelo, sn, uCount, lCount, hCount);
                        CargarListado();

                        MessageBox.Show($"¡Conexión Exitosa con el Biométrico!\n\n" +
                                        $"• IP: {bio.DireccionIP}:{bio.Puerto}\n" +
                                        $"• Modelo: {modelo}\n" +
                                        $"• N° Serie: {sn}\n" +
                                        $"• Firmware: {firmware}\n" +
                                        $"• Usuarios en equipo: {usuarios}\n" +
                                        $"• Huellas registradas: {huellas}\n" +
                                        $"• Marcaciones en memoria: {logs}", 
                                        "Biométrico ZKTeco Online", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Error Conexión");
                        CargarListado();
                        MessageBox.Show("Fallo al conectar con el biométrico:\n\n" + msg + 
                                        "\n\nVerifique:\n1. Que el equipo esté encendido y conectado a la misma red.\n2. La IP y Puerto (por defecto 4370).\n3. La clave CommKey en la configuración del reloj.", 
                                        "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnSyncHora_Click(object sender, EventArgs e)
        {
            Biometrico bio = ObtenerBiometricoSeleccionado();
            if (bio == null) return;

            Cursor = Cursors.WaitCursor;
            try
            {
                using (var service = new ZKTecoService())
                {
                    string msg;
                    if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msg))
                    {
                        string msgHora;
                        if (service.SincronizarHoraDispositivo(out msgHora))
                        {
                            service.EmitirPitido(100);
                            service.Desconectar();
                            MessageBox.Show(msgHora, "Hora Sincronizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            service.Desconectar();
                            MessageBox.Show(msgHora, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo conectar al biométrico: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnDescargarUsuarios_Click(object sender, EventArgs e)
        {
            Biometrico bio = ObtenerBiometricoSeleccionado();
            if (bio == null) return;

            Cursor = Cursors.WaitCursor;
            try
            {
                using (var service = new ZKTecoService())
                {
                    string msg;
                    if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msg))
                    {
                        string msgDescarga;
                        List<Empleado> usuarios = service.DescargarUsuarios(out msgDescarga);
                        service.Desconectar();

                        if (usuarios.Count > 0)
                        {
                            int sincronizados = N_Empleado.SincronizarListaDesdeBiometrico(usuarios);
                            N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Conectado", DateTime.Now);
                            CargarListado();
                            MessageBox.Show($"{msgDescarga}\n\nSe insertaron/actualizaron {sincronizados} empleados en la Base de Datos.", 
                                            "Usuarios Sincronizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(msgDescarga, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo conectar al biométrico: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnDescargarMarcaciones_Click(object sender, EventArgs e)
        {
            List<Biometrico> dispositivos = N_Biometrico.ListarActivos();
            if (dispositivos == null || dispositivos.Count == 0)
            {
                MessageBox.Show("No hay dispositivos biométricos activos registrados para sincronizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var bio in dispositivos)
            {
                using (var frmProgreso = new FrmProgresoSync(bio))
                {
                    var result = frmProgreso.ShowDialog(this);
                    if (result == DialogResult.Cancel && !frmProgreso.Exito)
                    {
                        // Si el usuario canceló explícitamente, detener el recorrido
                        break;
                    }
                }
            }

            CargarListado();
        }


        private void btnSubirTodosEmpleados_Click(object sender, EventArgs e)
        {
            Biometrico bio = ObtenerBiometricoSeleccionado();
            if (bio == null) return;

            DataTable dtEmpleados = N_Empleado.Listar();
            if (dtEmpleados.Rows.Count == 0)
            {
                MessageBox.Show("No hay empleados registrados en la Base de Datos para subir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"¿Desea enviar los {dtEmpleados.Rows.Count} empleados registrados en la base de datos al biométrico '{bio.Nombre}'?", 
                                "Confirmar Sincronización Masiva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            int enviados = 0;
            try
            {
                using (var service = new ZKTecoService())
                {
                    string msg;
                    if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msg))
                    {
                        foreach (DataRow row in dtEmpleados.Rows)
                        {
                            string codigo = Convert.ToString(row["codigo_biometrico"]);
                            string nombre = Convert.ToString(row["nombre_completo"]);
                            string password = row["password_biometrico"] != DBNull.Value ? Convert.ToString(row["password_biometrico"]) : "";
                            int privilegio = Convert.ToInt32(row["privilegio"]);
                            bool habilitado = Convert.ToBoolean(row["habilitado"]);
                            string tarjeta = row["tarjeta_rfid"] != DBNull.Value ? Convert.ToString(row["tarjeta_rfid"]) : "";

                            string msgSub;
                            if (service.SubirUsuario(codigo, nombre, password, privilegio, habilitado, tarjeta, out msgSub))
                            {
                                enviados++;
                            }
                        }

                        service.EmitirPitido(150);
                        service.Desconectar();
                        MessageBox.Show($"Se subieron {enviados} de {dtEmpleados.Rows.Count} empleados al biométrico exitosamente.", 
                                        "Sincronización Finalizada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se pudo conectar al biométrico: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Biometrico bio = ObtenerBiometricoSeleccionado();
            if (bio == null) return;

            if (MessageBox.Show($"¿Está seguro que desea reiniciar el biométrico '{bio.Nombre}' ({bio.DireccionIP})?", 
                                "Confirmar Reinicio", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            try
            {
                using (var service = new ZKTecoService())
                {
                    string msg;
                    if (service.Conectar(bio.DireccionIP, bio.Puerto, bio.CommKey, out msg))
                    {
                        string msgReinicio;
                        if (service.ReiniciarDispositivo(out msgReinicio))
                        {
                            N_Biometrico.ActualizarEstado(bio.IdBiometrico, "Reiniciando...");
                            CargarListado();
                            MessageBox.Show("El comando de reinicio ha sido enviado al equipo.", "Reinicio en Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al reiniciar: " + msgReinicio, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se pudo conectar al biométrico: " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excepción: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #endregion
    }
}
