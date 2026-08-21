using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;

namespace RJCodeUI_M1.RJControls
{
    public class RJPictureBox : PictureBox
    {

        #region -> Campos
        private Color borderColor = Color.RoyalBlue; //Obtiene o establece el color de borde.
        private int borderSize = 0;//Obtiene o establece el tamaño de borde.
        private int borderRadius = 0;//Obtiene o establece el tamaño de radio del borde.
        private bool customizable = true; //Obtiene o establece si el color de borde es personalizable, caso contrario, toma el color de la configuración del tema.
        #endregion

        #region -> Propiedades
        [Category("RJ Code Advance")]
        public bool Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set { borderSize = value; this.Invalidate(); }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = value; this.Invalidate(); }
        }
        #endregion

        #region -> Métodos privados
        private void ApplyAppearanceSettings()
        {
            if (customizable == false)
            {
                borderColor = UIAppearance.StyleColor;
            }
        }
        #endregion

        #region -> Métodos anulados

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ApplyAppearanceSettings();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            this.BackColor = this.Parent.BackColor;
            Utils.RoundedControl.RegionAndBorder(this, borderRadius, pe.Graphics, borderColor, borderSize);
        }
        #endregion
    }
}
