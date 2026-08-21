using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RJCodeUI_M1.RJControls
{
    public class RJPanel : Panel
    {
        /// <summary>
        /// Este control no tiene muchas propiedades de personalización adicionales,
        /// simplemente establece el color de fondo según el tema establecido por la configuración de apariencia,
        /// y poder establecer un radio al borde del control.
        /// </summary>
        /// 

        #region -> Campos
        private bool customizable;//Obtiene o establece si los colores de apariencia es personalizable
        private int borderRadius;//Obtiene o establece el radio del borde
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
        [Description("Obtiene o establece el radio del borde")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                borderRadius = value;
                this.Invalidate();//Volver a dibujar el control para actualizar la apariencia del control.
            }
        }
        #endregion

        #region -> Métodos privados
        private void ApplyAppearanceSettings()
        {//Aplicar configuración de apariencia
            if (customizable == false)
            {
                this.BackColor = Settings.UIAppearance.ItemBackgroundColor;
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
        {
            base.OnPaint(e);
            Utils.RoundedControl.RegionAndSmoothed(this, borderRadius, e.Graphics);
        }
        #endregion

    }
}
