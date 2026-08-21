using System;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                RJCodeUI_M1.Settings.SettingsManager.LoadApperanceSettings();

                FrmSplash splash = new FrmSplash();
                if (splash.ShowDialog() == DialogResult.OK)
                {
                    while (true)
                    {
                        using (FrmLogin login = new FrmLogin())
                        {
                            if (login.ShowDialog() != DialogResult.OK || login.UsuarioAutenticado == null)
                            {
                                break;
                            }

                            using (FrmPrincipal principal = new FrmPrincipal(login.UsuarioAutenticado))
                            {
                                principal.ShowDialog();
                                if (!principal.CerrarSesionSolicitado)
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error inesperado al iniciar la aplicación:\n\n" + ex.Message + "\n\n" + ex.StackTrace,
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
