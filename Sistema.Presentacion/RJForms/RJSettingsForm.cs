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
            panelBorde.Padding = new Padding(UIAppearance.FormBorderSize);
            panelBorde.BackColor = UIAppearance.FormBorderColor;          
            panelBackground.BackColor = UIAppearance.BackgroundColor;            
            if (UIAppearance.Style == UIStyle.Supernova)
                panelTitleBar.BackColor = ColorEditor.Darken(UIAppearance.BackgroundColor, 9);
            else panelTitleBar.BackColor = UIAppearance.PrimaryStyleColor;


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

        private void rbLightTheme_CheckedChanged(object sender, EventArgs e)
        {
            if(rbLightTheme.Checked)
                panelBackground.BackColor = RJColors.LightBackground;
            else panelBackground.BackColor = RJColors.DarkBackground;

            if(cbStyles.SelectedIndex==(int)UIStyle.Supernova)
                panelTitleBar.BackColor = ColorEditor.Darken(panelBackground.BackColor, 9);

        }

        private void cbStyles_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            UIStyle style=(UIStyle)cbStyles.SelectedIndex;
            switch (style)
            { 
                case UIStyle.Axolotl:
                    panelTitleBar.BackColor = RJColors.Axolotl;
                    break;
                case UIStyle.FireOpal:
                    panelTitleBar.BackColor = RJColors.FireOpal;
                    break;
                case UIStyle.Forest:
                    panelTitleBar.BackColor = RJColors.Forest;
                    break;
                case UIStyle.Lisianthus:
                    panelTitleBar.BackColor = RJColors.Lisianthus;
                    break;
                case UIStyle.Neptune:
                    panelTitleBar.BackColor = RJColors.Neptune;
                    break;
                case UIStyle.Petunia:
                    panelTitleBar.BackColor = RJColors.Petunia;
                    break;
                case UIStyle.Ruby:
                    panelTitleBar.BackColor = RJColors.Ruby;
                    break;
                case UIStyle.Sky:
                    panelTitleBar.BackColor = RJColors.Sky;
                    break;
                case UIStyle.Spinel:
                    panelTitleBar.BackColor = RJColors.Spinel;
                    break;
                case UIStyle.Supernova:
                    panelTitleBar.BackColor = ColorEditor.Darken(panelBackground.BackColor, 9);
                    break;
            }
            if (tbColorFormBorder.Checked)
            {
                if (cbStyles.SelectedIndex == (int)UIStyle.Supernova)
                    panelBorde.BackColor = RJColors.FantasyColorScheme1;
                else panelBorde.BackColor = panelTitleBar.BackColor;
            }
            else panelBorde.BackColor = RJColors.DefaultFormBorderColor;
        }

        private void tbmFormBorderSize_Scroll(object sender, EventArgs e)
        {
            panelBorde.Padding = new Padding(tbmFormBorderSize.Value);
        }

        private void tbColorFormBorder_CheckedChanged(object sender, EventArgs e)
        {
            if (tbColorFormBorder.Checked)
            {
                if (cbStyles.SelectedIndex == (int)UIStyle.Supernova)
                 panelBorde.BackColor = RJColors.FantasyColorScheme1;
                else panelBorde.BackColor = panelTitleBar.BackColor;
            }
            else panelBorde.BackColor = RJColors.DefaultFormBorderColor;

        }
        #endregion

    }
}
