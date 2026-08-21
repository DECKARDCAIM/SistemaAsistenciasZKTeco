using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeUI_M1.RJForms
{
    public partial class RJPrintForm : RJChildForm
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "RJChildForm" />
        /// </summary>
        /// 

        #region Campos

        private Image screenshot;//Obtiene o establece la fuente de captura de pantalla
        private Size sizeA4;//Obtiene o establece el Tamaño A4 
        private Image imgDocument;//Obtiene o establece el Documento en formato de imagen (esto es lo que se imprime)

        #endregion

        #region Constructor

        public RJPrintForm(Image _screenshot, string docTitle)
        {
            InitializeComponent();//Se utilizó el diseñador para hacer este formulario.

            this.DisableFormOptions = true;//Deshabilitar opciones de formulario
            toolTip1.SetToolTip(btnPrint, "Imprimir documento");
            toolTip1.SetToolTip(btnPortrait, "Orientación Vertical");
            toolTip1.SetToolTip(btnLandscape, "Orientación horizontal");
            toolTip1.SetToolTip(btnCancel, "Cancelar impresión");

            sizeA4 = new Size(794, 1123);//Tamaño de papel A4 de 96 ppp en píxeles         
            lblDate.Text = DateTime.Now.ToLongDateString();//Obtener la fecha actual
            lblTitle.Text = docTitle;//Establecer título del documento
            pbContent.Image = _screenshot;//establecer captura de pantalla en el contenido del cuadro de imagen
            screenshot = _screenshot;//Establecer campo de captura de pantalla

            if (Settings.UIAppearance.Theme == Settings.UITheme.Dark) //Establecer color de fondo del menú de impresión
                this.pnlPrintMenu.BackColor = Settings.RJColors.DarkActiveBackground;
            else
                this.pnlPrintMenu.BackColor = Settings.RJColors.LightItemBackground;

            PortraitOrientation();//Iniciar la vista previa en modo vertical
        }
        #endregion

        #region Métodos

        private void PortraitOrientation()
        {//Diseño de impresión en modo vertical

            if (this.WindowState == FormWindowState.Maximized)
                this.WindowState = FormWindowState.Normal;

            printDoc.DefaultPageSettings.Landscape = false;//Desactivar el modo Horizontal (activa la orientación vertical)

            this.Size = new Size(960, Screen.FromHandle(this.Handle).WorkingArea.Height);//establecer como tamaño 960 y toda la altura del área del escritorio
            this.CenterToScreen(); //Centrar el formulario en la pantalla actual

            pnlDocument.Size = sizeA4; // Establecer el tamaño del panel del documento
            pnlDocument.Location = new Point(70, 50); // Establecer la ubicación del panel del documento
            pbContent.Size = new Size(pnlHeader.Width, 1000); // Establezca el tamaño del cuadro de imagen Contenido.

            // Ajustar la altura del cuadro de imagen igual a la altura de la imagen escalada dentro del cuadro de imagen Contenido.
            double widhtFactor = (double)screenshot.Width / pbContent.Width; // Obtener el factor de ancho.
            double heightFactor = (double)screenshot.Height / pbContent.Height; // Obtener el factor de altura.
            double resizeFactor = Math.Max(widhtFactor, heightFactor); // Retornar el número más grande que indica cuál es el factor de cambio de tamaño.

            pbContent.Height = (int)(screenshot.Height / resizeFactor); // Establecer el NUEVO TAMAÑO del cuadro de imagen contenido (de esta manera la imagen se mostrará en la parte superior y central).
        }
        private void LandscapeOrientation()
        {//Diseño de impresión en modo horizontal

            if (this.WindowState == FormWindowState.Normal)//Maximizar ventana
                this.MaximizeWindow();

            printDoc.DefaultPageSettings.Landscape = true;//Establecer el modo horizontal

            pnlDocument.Size = new Size(sizeA4.Height - 50, sizeA4.Width);//Girar el tamaño a4: Ancho = alto-50 (restamos 50, de alguna manera no es el mismo tamaño) y Alto = Ancho)
            int xCenteredLocation = (this.Width - pnlDocument.Width) / 2;//Obtener la coordenada X para centrar el panel del documento
            pnlDocument.Location = new Point(xCenteredLocation, 50);//Establecer la ubicación del panel de documentos
            pbContent.Size = new Size(pnlHeader.Width, 680);//Establecer el tamaño del cuadro de imagen contenido.

            //Ajustar la altura del cuadro de imagen Contenido igual a la altura de la imagen escalada dentro del cuadro de imagen Contenido.
            double widhtFactor = (double)screenshot.Width / pbContent.Width;
            double heightfactor = (double)screenshot.Height / pbContent.Height;
            double resizeFactor = Math.Max(widhtFactor, heightfactor);

            pbContent.Height = (int)(screenshot.Height / resizeFactor);//Establecer el NUEVO TAMAÑO del cuadro de imagen contenido (de esta manera la imagen se mostrará en la parte superior y central).
        }
        private void PrintDocument()
        {//Metodo responsable de imprimir
            var bmpScreenshot = new Bitmap(pnlDocument.Width, pnlDocument.Height);//Establecer el objeto de mapa de bits al tamaño del panel del escritorio
            pnlDocument.DrawToBitmap(bmpScreenshot, new Rectangle(0, 0, bmpScreenshot.Width, bmpScreenshot.Height));//Dibujar el panel del documento en el mapa de bits
            imgDocument = (Image)bmpScreenshot;//Configure la captura de pantalla del documento para imprimir
            try
            {
                printDoc.Print();//Iniciar la impresión del documento.
                //Este método llama al evento PrintPage ( private void printDoc_PrintPage(object sender, PrintPageEventArgs e))
            }
            catch (Exception ex)
            {
                RJMessageBox.Show("Hubo un problema al intentar imprimir. Vuelve a intentarlo.\nDetails\n" + ex);
            }
        }
        #endregion

        #region Métodos de eventos

        private void printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(imgDocument, 0, 0);//Dibujar imgDocumento en printDocument e imprimir la imagen.
        }
        private void btnLandscape_Click(object sender, EventArgs e)
        {
            LandscapeOrientation();
        }
        private void btnPortrait_Click(object sender, EventArgs e)
        {
            PortraitOrientation();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument();
        }
        #endregion

    }
}
