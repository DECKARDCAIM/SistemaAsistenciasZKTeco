using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Datos;

namespace Sistema.Presentacion
{
    public partial class FrmSplash : Form
    {
        private int _progreso = 0;
        private bool _conexionProbada = false;
        private bool _conexionExitosa = false;
        private string _mensajeConexion = "";

        public FrmSplash()
        {
            InitializeComponent();
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            timerProgress.Start();
            Task.Run(() =>
            {
                _conexionExitosa = Conexion.ProbarConexion(out _mensajeConexion);
                _conexionProbada = true;
            });
        }

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            _progreso += 2;

            if (_progreso <= 25)
            {
                lblStatus.Text = "Iniciando componentes y librerías visuales...";
            }
            else if (_progreso <= 60)
            {
                lblStatus.Text = "Verificando conexión con base de datos PostgreSQL...";
            }
            else if (_progreso <= 85)
            {
                lblStatus.Text = "Cargando servicios de comunicación biométrica ZKTeco...";
            }
            else if (_progreso < 100)
            {
                lblStatus.Text = "Preparando módulos del sistema...";
            }

            if (_progreso >= 70 && !_conexionProbada)
            {
                _progreso = 70;
            }

            if (_progreso >= 100)
            {
                timerProgress.Stop();
                progressBar.Value = 100;
                lblStatus.Text = "¡Listo para iniciar!";
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                progressBar.Value = _progreso;
            }
        }
    }
}
