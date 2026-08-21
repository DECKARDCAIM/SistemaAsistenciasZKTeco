using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Entidades;
using Sistema.Negocio;

namespace Sistema.Presentacion
{
    public partial class FrmProgresoSync : Form
    {
        private readonly Biometrico _biometrico;
        private readonly DateTime? _fechaDesde;
        private CancellationTokenSource _cts;
        private bool _terminado = false;

        public int RegistrosLeidos { get; private set; }
        public int RegistrosNuevos { get; private set; }
        public int RegistrosDuplicados { get; private set; }
        public bool Exito { get; private set; }

        public FrmProgresoSync(Biometrico biometrico, DateTime? fechaDesde = null)
        {
            InitializeComponent();
            _biometrico = biometrico;
            _fechaDesde = fechaDesde;
            _cts = new CancellationTokenSource();

            lblTitulo.Text = string.Format("Sincronizando: {0}", _biometrico.Nombre);
            lblSubtitulo.Text = string.Format("IP: {0}:{1} • Hospital de El Progreso", _biometrico.DireccionIP, _biometrico.Puerto);
        }

        private async void FrmProgresoSync_Shown(object sender, EventArgs e)
        {
            await IniciarSincronizacionAsync();
        }

        private async Task IniciarSincronizacionAsync()
        {
            IProgress<ProgresoSync> progreso = new Progress<ProgresoSync>(ActualizarUIProgreso);
            btnCancelar.Text = "Cancelar";
            btnCancelar.BackColor = Color.FromArgb(239, 68, 68);

            try
            {
                await Task.Run(() =>
                {
                    using (var service = new ZKTecoService())
                    {
                        progreso.Report(new ProgresoSync
                        {
                            Porcentaje = 2,
                            Fase = "Conectando al Biométrico...",
                            Estado = string.Format("Estableciendo conexión TCP con {0}:{1}...", _biometrico.DireccionIP, _biometrico.Puerto)
                        });

                        string msg;
                        if (!service.Conectar(_biometrico.DireccionIP, _biometrico.Puerto, _biometrico.CommKey, out msg))
                        {
                            throw new Exception("No se pudo conectar al equipo biométrico: " + msg);
                        }

                        // 1. Descargar Marcaciones del Reloj con Progreso (0% a 50%)
                        List<Asistencia> marcaciones = service.DescargarMarcacionesConProgreso(
                            _biometrico.IdBiometrico,
                            _biometrico.Nombre,
                            _fechaDesde,
                            progreso,
                            _cts.Token,
                            out string msgDescarga
                        );

                        RegistrosLeidos = marcaciones != null ? marcaciones.Count : 0;

                        if (_cts.IsCancellationRequested)
                        {
                            service.Desconectar();
                            throw new OperationCanceledException();
                        }

                        // 2. Guardar en Base de Datos con Progreso (50% a 90%)
                        if (RegistrosLeidos > 0)
                        {
                            progreso.Report(new ProgresoSync
                            {
                                Porcentaje = 50,
                                Fase = "Iniciando Inserción Masiva en BD",
                                RegistrosActuales = 0,
                                RegistrosTotales = RegistrosLeidos,
                                Estado = string.Format("Preparando lotes para {0:N0} registros...", RegistrosLeidos)
                            });

                            RegistrosNuevos = N_Asistencia.GuardarMarcacionesMasivasConProgreso(
                                marcaciones,
                                _biometrico.IdBiometrico,
                                _biometrico.Nombre,
                                progreso,
                                _cts.Token
                            );

                            RegistrosDuplicados = RegistrosLeidos - RegistrosNuevos;

                            // 3. Purgar/Limpiar memoria del reloj biométrico (los datos ya están 100% en BD)
                            progreso.Report(new ProgresoSync
                            {
                                Porcentaje = 92,
                                Fase = "Liberando memoria del reloj...",
                                RegistrosActuales = RegistrosLeidos,
                                RegistrosTotales = RegistrosLeidos,
                                RegistrosNuevos = RegistrosNuevos,
                                RegistrosDuplicados = RegistrosDuplicados,
                                Estado = "Borrando registros transferidos del biométrico para evitar duplicados futuros..."
                            });

                            service.LimpiarMarcaciones(out string msgLimpieza);
                        }

                        service.Desconectar();

                        // 4. Actualizar estado del biométrico en la base de datos (con total_marcaciones = 0)
                        N_Biometrico.ActualizarEstado(_biometrico.IdBiometrico, "Conectado", DateTime.Now, logs: 0);
                    }
                }, _cts.Token);

                Exito = true;
                _terminado = true;

                // UI Final Exitosa
                progressBarSync.Value = 100;
                lblPorcentaje.Text = "100%";
                lblPorcentaje.ForeColor = Color.FromArgb(16, 185, 129);
                lblFase.Text = "¡Sincronización Completada Exitosamente!";
                lblFase.ForeColor = Color.FromArgb(16, 185, 129);
                lblDetalle.Text = string.Format("Se procesaron {0:N0} registros ({1:N0} nuevos, {2:N0} existentes) y se liberó la memoria del reloj.", 
                    RegistrosLeidos, RegistrosNuevos, RegistrosDuplicados);

                lblValTotal.Text = RegistrosLeidos.ToString("N0");
                lblValLeidos.Text = RegistrosLeidos.ToString("N0");
                lblValNuevos.Text = RegistrosNuevos.ToString("N0");
                lblValDuplicados.Text = RegistrosDuplicados.ToString("N0");

                btnCancelar.Text = "Aceptar";
                btnCancelar.BackColor = Color.FromArgb(16, 185, 129);
            }
            catch (OperationCanceledException)
            {
                lblFase.Text = "Sincronización Cancelada por el Usuario";
                lblFase.ForeColor = Color.FromArgb(245, 158, 11);
                lblDetalle.Text = "El proceso fue interrumpido.";
                btnCancelar.Text = "Cerrar";
                btnCancelar.BackColor = Color.FromArgb(100, 116, 139);
                _terminado = true;
            }
            catch (Exception ex)
            {
                Exito = false;
                _terminado = true;
                lblFase.Text = "Error durante la sincronización";
                lblFase.ForeColor = Color.FromArgb(239, 68, 68);
                lblDetalle.Text = ex.Message;
                btnCancelar.Text = "Cerrar";
                btnCancelar.BackColor = Color.FromArgb(239, 68, 68);
            }
        }

        private void ActualizarUIProgreso(ProgresoSync p)
        {
            if (this.IsDisposed) return;

            int pct = Math.Max(0, Math.Min(100, p.Porcentaje));
            progressBarSync.Value = pct;
            lblPorcentaje.Text = pct + "%";

            if (!string.IsNullOrEmpty(p.Fase))
                lblFase.Text = p.Fase;

            if (!string.IsNullOrEmpty(p.Estado))
                lblDetalle.Text = p.Estado;

            if (p.RegistrosTotales > 0)
                lblValTotal.Text = p.RegistrosTotales.ToString("N0");

            if (p.RegistrosActuales > 0)
                lblValLeidos.Text = p.RegistrosActuales.ToString("N0");

            if (p.RegistrosNuevos > 0)
                lblValNuevos.Text = p.RegistrosNuevos.ToString("N0");

            if (p.RegistrosDuplicados > 0)
                lblValDuplicados.Text = p.RegistrosDuplicados.ToString("N0");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (_terminado)
            {
                this.DialogResult = Exito ? DialogResult.OK : DialogResult.Cancel;
                this.Close();
            }
            else
            {
                if (MessageBox.Show("¿Desea cancelar el proceso de sincronización actual?", "Confirmar Cancelación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _cts?.Cancel();
                    btnCancelar.Enabled = false;
                    lblDetalle.Text = "Cancelando operaciones...";
                }
            }
        }

        private void FrmProgresoSync_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_terminado && !_cts.IsCancellationRequested)
            {
                _cts?.Cancel();
            }
        }
    }
}
