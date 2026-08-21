using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RJCodeUI_M1.RJForms;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;

namespace RJCodeUI_M1.RJForms
{
    public partial class RJSettingsForm : RJChildForm
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "RJChildForm" />
        /// </summary>
        /// 

        #region -> Constructor

        public RJSettingsForm()
        {
            //Esta formulario fue construido por el diseñador.
            InitializeComponent();
        }
        #endregion

        #region -> Event Methods

        private void RJSettingsForm_Load(object sender, EventArgs e)
        {
            LoadAppearanceSettings(); //Cargar y muestrar la configuración de apariencia actual en el formulario.
        }

        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            SaveAppearanceSettings(); //Guardar la configuración de apariencia
        }

        private void lblRestartApp_Click(object sender, EventArgs e)
        {//Reiniciar aplicación

            Application.Restart();
            Environment.Exit(0);
            /* Nota: Al ejecutar la aplicación desde Visual Studio, el archivo de configuración se guarda
             * en la carpeta C:\Users\YourUsername\AppData\Local\RJCodeUI_M1\RJCodeUI_M1.vshost.exe.
             * Y al reiniciar la aplicación el archivo de configuración 
             * se obtiene de la carpeta C:\Users\YourUsername\AppData\Local\RJCodeUI_M1\RJCodeUI_M1.exe, 
             * ya que luego de reiniciar la aplicación se ejecuta 
             * independientemente de Visual Studio, por lo que no cargará la configuración que estableciste 
             * en el primer reinicio, ya que tomará el archivo de Configuración RJCodeUI_M1.exe. Si desea probar
             * y aplicar la configuración establecida cuando está desarrollando la aplicación, le recomiendo que
             * cierre la aplicación (o deje de depurar) y vuelva a ejecutar desde Visual Studio o compile el proyecto
             * y ejecute la aplicación directamente desde la carpeta bin del proyecto.*/
        }
        #endregion

        #region -> Métodos privados

        private void LoadAppearanceSettings()
        {//Mostrar la configuración de apariencia actual en el formulario.

            //Tema
            if (UIAppearance.Theme == UITheme.Dark)
                rbDarkTheme.Checked = true;
            else
                rbLightTheme.Checked = true;

            //Estilo
            cbStyles.DataSource = Enum.GetValues(typeof(UIStyle));
            cbStyles.SelectedIndex = (int)UIAppearance.Style;

            //Tamaño de borde del formualario
            tbmFormBorderSize.Value = UIAppearance.FormBorderSize;

            //Si el color de borde del formulario es de color o no.
            tbColorFormBorder.Checked = UIAppearance.FormBorderColor == RJColors.DefaultFormBorderColor ? false : true;

            //Marcador del formulario secundario
            tbChildFormMarker.Checked = UIAppearance.ChildFormMarker;

            //Mostrar icono del formulario en un elemento activado del menú desplegable.
            tbIconMenuItem.Checked = UIAppearance.FormIconActiveMenuItem;

            //Abrir múltiples formularios secundarios?
            tbMultiChildForms.Checked = UIAppearance.MultiChildForms;

            //Vista previa
            ActualizarVistaPrevia();
        }
        private void SaveAppearanceSettings()
        {
            //Guardar la configuración de apariencia
            Settings.SettingsManager.SaveAppearanceSettings(rbDarkTheme.Checked ? (int)UITheme.Dark : (int)UITheme.Light,/*Tema*/
                                                            (int)cbStyles.SelectedValue,/*Estilo*/
                                                            tbmFormBorderSize.Value,/*Tamaño de borde del formulario*/
                                                            tbColorFormBorder.Checked,/*Borde de formulario de color*/
                                                            tbChildFormMarker.Checked,/*Marcador de formulario secundario*/
                                                            tbIconMenuItem.Checked,/*Icono de formulario en el elemento activado de menú*/
                                                            tbMultiChildForms.Checked);/*Múltiples formularios secundarios*/

            // Cargar y aplicar los cambios inmediatamente en tiempo real
            Settings.SettingsManager.LoadApperanceSettings();
            var frmPrincipal = Application.OpenForms.OfType<Sistema.Presentacion.FrmPrincipal>().FirstOrDefault();
            if (frmPrincipal != null)
            {
                frmPrincipal.AplicarTema();
            }

            //Mostrar mensaje de confirmación
            var result = RJMessageBox.Show("Configuración guardada y aplicada correctamente.\n¿Desea reiniciar la aplicación ahora para asegurar el refresco completo de todos los componentes?",
                                           "Apariencia Guardada",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)//Reiniciar aplicación
            {
                Application.Restart();
                Environment.Exit(0);
            }
            else
            {
                lblRestartApp.Visible = true;
            }

        }
        #endregion   
 
        #region -> Vista previa de cambios

        private void ActualizarVistaPrevia()
        {
            try
            {
                bool isDark = rbDarkTheme.Checked;
                Color bgColor = isDark ? Color.FromArgb(18, 22, 38) : Color.FromArgb(240, 245, 249);
                Color textColor = isDark ? Color.White : Color.FromArgb(30, 41, 59);

                Color styleColor = RJColors.Forest;
                if (cbStyles.SelectedIndex >= 0)
                {
                    UIStyle style = (UIStyle)cbStyles.SelectedIndex;
                    switch (style)
                    {
                        case UIStyle.Axolotl: styleColor = RJColors.Axolotl; break;
                        case UIStyle.FireOpal: styleColor = RJColors.FireOpal; break;
                        case UIStyle.Forest: styleColor = RJColors.Forest; break;
                        case UIStyle.Lisianthus: styleColor = RJColors.Lisianthus; break;
                        case UIStyle.Neptune: styleColor = RJColors.Neptune; break;
                        case UIStyle.Petunia: styleColor = RJColors.Petunia; break;
                        case UIStyle.Ruby: styleColor = RJColors.Ruby; break;
                        case UIStyle.Sky: styleColor = RJColors.Sky; break;
                        case UIStyle.Spinel: styleColor = RJColors.Spinel; break;
                        case UIStyle.Supernova: styleColor = ColorEditor.Darken(bgColor, 9); break;
                    }
                }

                int borderSize = Math.Max(1, tbmFormBorderSize.Value);
                panelBorde.Padding = new Padding(borderSize);

                if (tbColorFormBorder.Checked)
                    panelBorde.BackColor = (cbStyles.SelectedIndex == (int)UIStyle.Supernova) ? RJColors.FantasyColorScheme1 : styleColor;
                else
                    panelBorde.BackColor = isDark ? Color.FromArgb(60, 70, 95) : Color.FromArgb(200, 205, 215);

                panelBackground.BackColor = bgColor;
                panelTitleBar.BackColor = styleColor;

                lblVista.Text = $"Ventana de Ejemplo - Tema {(isDark ? "Oscuro" : "Claro")}\nEstilo: {cbStyles.Text}";
                lblVista.ForeColor = textColor;
            }
            catch { }
        }

        private void rbLightTheme_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVistaPrevia();
        }

        private void cbStyles_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarVistaPrevia();
        }

        private void tbmFormBorderSize_Scroll(object sender, EventArgs e)
        {
            ActualizarVistaPrevia();
        }

        private void tbColorFormBorder_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarVistaPrevia();
        }
        #endregion

    }
}
