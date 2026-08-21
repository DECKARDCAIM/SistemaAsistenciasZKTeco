using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RJCodeUI_M1.RJControls
{
    public class RJImageColorOverlay : Panel
    {
        /// <summary>
        /// Esta clase hereda de la clase <see cref = "Panel" />
        /// Este control incorpora la función de superponer color a las imágenes. Esto significa que cubres
        /// una imagen con un cuadro de color semitransparente. Este método es muy popular en los sitios web porque
        /// mejora la apariencia considerablemente y los elementos son más legibles, así que decidí
        /// hacer uno para formularios de Windows.
        ///
        /// el truco aquí es dibujar un cuadro con un color semitransparente (puedes establecer la opacidad) en el panel
        /// con un fondo de imagen. Para obtener un color semitransparente, se debe establecer el componente de color alfa.
        /// En Windows, el componente alfa es un número entre 0 (totalmente transparente) y 255 (totalmente opaco).
        /// </summary>
        /// 

        #region -> Campos

        private int opacity;//Establece u obtiene opacidad (porcentaje de transparencia, 0 = totalmente transparente y 100 totalmente opaco/solido)
        private int alpha;//Establece u obtiene el valor del parámetro alfa
        private Color overlayColor;//Establece u obtiene el color de superposición
        private int borderRadius;//Establece u obtiene el radio del borde
        private bool customizable;//Establece u obtiene si el color de apariencia del control es personalizable.

        #endregion

        #region -> Constructor

        public RJImageColorOverlay()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | //Establecer estilos de control para evitar el parpadeo
                              ControlStyles.UserPaint |
                              ControlStyles.OptimizedDoubleBuffer,
                              true);
            this.BackgroundImage = Properties.Resources.BackImage;//Establecer imagen predeterminada
            this.BackgroundImageLayout = ImageLayout.Stretch;//Establecer el diseño de imagen predeterminado
            this.TabStop = false;
            this.Size = new System.Drawing.Size(250, 250);
            Opacity = 50;//Establecer una opacidad predeterminada del 50%
            OverlayColor = Color.MediumSlateBlue;//Establecer el color de superposición predeterminado

        }
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si los colores de apariencia del control es personalizable")]
        public bool Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene opacidad (porcentaje de transparencia, 0 = totalmente transparente y 100 totalmente opaco/solido)")]
        public int Opacity
        {
            get { return opacity; }
            set
            {
                if (value < 0 || value > 100)
                    return;
                opacity = value;//Establecer valor
                alpha = Convert.ToInt32(opacity / 100D * 255);//Convirtir el valor de opacidad en un valor alfa válido para windows.
                //Alpha= Opacity / 100% *255 (En Windows, el valor alfa máximo es 255, que es completamente opaco)
                //El sufijo D es de tipo doble que sería igual a 100,00 o (double) 100.
                if (this.DesignMode) this.Invalidate(false);//Volver a dibujar el control para aplicar los cambios (invoca el evento OnPaint) -> vista previa en modo de diseño
            }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color de superposición")]
        public Color OverlayColor
        {
            get { return overlayColor; }
            set
            {
                overlayColor = value;//Establecer valor
                //Volver a dibujar el control para aplicar los cambios (invoca el evento OnPaint) -> vista previa en modo de diseño
                if (this.DesignMode) this.Invalidate(false);
            }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene la imagen de fondo")]
        public Image Image
        {
            get { return this.BackgroundImage; }
            set { this.BackgroundImage = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el diseño de la imagen")]
        public ImageLayout ImageMode
        {
            get { return this.BackgroundImageLayout; }
            set { this.BackgroundImageLayout = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el radio del borde")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();//Volver a dibujar el control para actualizar la apariencia.
            }
        }

        #endregion

        #region -> Métodos privados
        private void ApplyAppearanceSettings()
        {//Aplicar la configuracion de apariencia al control
            if (customizable == false)
            {
                overlayColor = Settings.UIAppearance.StyleColor;
            }
        }

        #endregion

        #region -> Métodos anulados

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();
        }
        protected override void OnPaint(PaintEventArgs e)
        {//Ocurre cuando se vuelve a dibujar el control

            base.OnPaint(e);//Dibujar el control normalmente
            Graphics graph = e.Graphics;
            //Crear un objeto de pincel de color sólido a partir del parámetro de color de superposición y la opacidad establecida en el parámetro alfa
            using (var brush = new SolidBrush(Color.FromArgb(alpha, overlayColor)))
            {
                graph.FillRectangle(brush, this.ClientRectangle);//Rellenar el interior del panel con el pincel sólido creado
                //Básicamente, dibuja un rectángulo de color transparente (basado en el valor alfa definido por la opacidad) en el panel.
                Utils.RoundedControl.RegionAndSmoothed(this, borderRadius, graph);//Aplicar las esquinas redondeados + Suavizado de bordes.
            }
        }
        #endregion

    }
}