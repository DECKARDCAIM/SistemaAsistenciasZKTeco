using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using System.Linq;

namespace RJCodeUI_M1.RJControls
{
    public class RJDataGridView : DataGridView
    {
        #region -> Campos

        private bool customizable;//Obtiene o establece si el control es personalizable
        private bool isAlternatingRowsColor;//Obtiene o establece si aplica un color de fondo diferente a las filas impares.
        private int borderRadius;//Obtiene o establece el tamaño de radio del borde (esquinas redondeadas)
        DataGridViewCellStyle ColumnHeaderStyle;//Establece u obtiene el estilo de los encabezados de columna.
        DataGridViewCellStyle RowHeaderStyle;//Establece u obtiene el estilo de los encabezados de fila
        DataGridViewCellStyle RowStyle;//Establece u obtiene el estilo Filas
        private bool stopScroll = true;//Establece u obtiene si la barra de desplazamiento se está moviendo.
        //(True= NO se está esta desplazando: False= Se está desplazando).
        #endregion
      
        #region -> Constructor

        public RJDataGridView()
        {
            //Inicializar objetos de estilo de celda de vista de cuadrícula de datos
            ColumnHeaderStyle = new DataGridViewCellStyle();
            RowHeaderStyle = new DataGridViewCellStyle();
            RowStyle = new DataGridViewCellStyle();

            //Ajustes generales
            this.AllowUserToResizeRows = false;
            this.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.BackgroundColor = RJColors.LightItemBackground;
            this.BorderStyle = BorderStyle.None;
            this.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.EnableHeadersVisualStyles = false;
            this.GridColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            //this.ReadOnly = true;
            this.RightToLeft = RightToLeft.No;
            this.Size = new System.Drawing.Size(450, 250);

            //Establecer estilos de apariencia en encabezados de columna
            ColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            ColumnHeaderStyle.BackColor = Color.MediumPurple;
            ColumnHeaderStyle.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            ColumnHeaderStyle.ForeColor = Color.White;
            ColumnHeaderStyle.WrapMode = DataGridViewTriState.True;
            ColumnHeaderStyle.Padding = new Padding(15, 0, 0, 0);
            this.ColumnHeadersDefaultCellStyle = ColumnHeaderStyle;//Establecer ColumnHeaderStyle
            this.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.ColumnHeadersHeight = 40;//Establecer altura (por alguna razón no funciona al agregar el control al formulario, puse una solución en el evento de cambio de tamaño).

            //Establecer estilos de apariencia en encabezados de fila
            RowHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            RowHeaderStyle.BackColor = Color.WhiteSmoke;
            RowHeaderStyle.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            RowHeaderStyle.ForeColor = Color.White;
            RowHeaderStyle.SelectionBackColor = Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(199)))), ((int)(((byte)(241)))));
            RowHeaderStyle.SelectionForeColor = SystemColors.HighlightText;
            RowHeaderStyle.WrapMode = DataGridViewTriState.False;
            this.RowHeadersDefaultCellStyle = RowHeaderStyle;//Establecer RowHeaderStyle
            this.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            this.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.RowHeadersWidth = 30;//Establecer ancho 
            this.RowHeadersVisible = false;//Ocultar encabezado de fila

            //Establecer estilos de apariencia en filas
            RowStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            RowStyle.BackColor = RJColors.LightItemBackground;
            RowStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            RowStyle.ForeColor = Color.Gray;
            RowStyle.Padding = new Padding(15, 0, 0, 0);
            RowStyle.SelectionBackColor = Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(247)))));
            RowStyle.SelectionForeColor = Color.Gray;
            this.RowsDefaultCellStyle = RowStyle;//Establecer RowStyle
            this.RowTemplate.Height = 40;//Establecer altura 
            BorderRadius = 13;

            //Adjuntar eventos del desplazamiento para determinar si la barra de desplazamiento dejó de moverse y asi volver a dibujar el control.
            HScrollBar horizontalScroll = this.Controls.OfType<HScrollBar>().First();//Obtener la barra de desplazamiento horizontal.
            VScrollBar verticalalScroll = this.Controls.OfType<VScrollBar>().First();//Obtener la barra de desplazamiento vertical.
            horizontalScroll.Scroll += new ScrollEventHandler(ScrollBar_Event);
            verticalalScroll.Scroll += new ScrollEventHandler(ScrollBar_Event);       
        }

 
        #endregion

        #region -> Propiedades

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene la altura del encabezado de la columna")]
        public int ColumnHeaderHeight
        {
            get { return this.ColumnHeadersHeight; }
            set
            {
                this.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                if (value < 40)//Altura mínima
                    this.ColumnHeadersHeight = 40;
                else
                    this.ColumnHeadersHeight = value;
            }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el modo de columnas de tamaño automático de la vista DataGrid")]
        public DataGridViewAutoSizeColumnsMode ColumnsMode
        {
            get { return this.AutoSizeColumnsMode; }
            set { this.AutoSizeColumnsMode = value; }
        }


        [Category("RJ Code Advance")]
        [Description("Establece o obtiene si el control es personalizable o el diseño se establecerá mediante la configuración de apariencia")]
        public bool Customizable
        {
            get { return customizable; }
            set { customizable = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color de fondo del encabezado de la columna")]
        public Color ColumnHeaderColor
        {
            get { return this.ColumnHeadersDefaultCellStyle.BackColor; }
            set { this.ColumnHeadersDefaultCellStyle.BackColor = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color del texto del encabezado de la columna")]
        public Color ColumnHeaderTextColor
        {
            get { return this.ColumnHeadersDefaultCellStyle.ForeColor; }
            set { this.ColumnHeadersDefaultCellStyle.ForeColor = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene la fuente del encabezado de la columna")]
        public Font ColumnHeaderFont
        {
            get { return this.ColumnHeadersDefaultCellStyle.Font; }
            set { this.ColumnHeadersDefaultCellStyle.Font = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color de fondo del encabezado de la fila")]
        public Color RowHeaderColor
        {
            get { return this.RowHeadersDefaultCellStyle.BackColor; }
            set { this.RowHeadersDefaultCellStyle.BackColor = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color de fondo de la selección")]
        public Color SelectionBackColor
        {
            get { return this.RowHeadersDefaultCellStyle.SelectionBackColor; }
            set
            {
                this.RowHeadersDefaultCellStyle.SelectionBackColor = value;
                this.RowsDefaultCellStyle.SelectionBackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color de las filas")]
        public Color RowsColor
        {
            get { return this.RowsDefaultCellStyle.BackColor; }
            set { this.RowsDefaultCellStyle.BackColor = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece si aplica un color de fondo a las filas impares.")]
        public bool AlternatingRowsColorApply
        {
            get { return isAlternatingRowsColor; }
            set
            {
                isAlternatingRowsColor = value;
                if (value == false)//Si el valor es falso, restaura el color predeterminado (Color.Empty)
                {
                    this.AlternatingRowsDefaultCellStyle.BackColor = Color.Empty;
                }
            }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color de las filas alternas")]
        public Color AlternatingRowsColor
        {
            get { return this.AlternatingRowsDefaultCellStyle.BackColor; }
            set
            {
                if (isAlternatingRowsColor)
                    this.AlternatingRowsDefaultCellStyle.BackColor = value;
            }
            //Advertencia: esta propiedad puede causar un impacto en el rendimiento cuando se tiene muchas filas.
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color del texto de las filas")]
        public Color RowsTextColor
        {
            get { return this.RowsDefaultCellStyle.ForeColor; }
            set { this.RowsDefaultCellStyle.ForeColor = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el color de la fila seleccionada")]
        public Color SelectionTextColor
        {
            get { return this.RowsDefaultCellStyle.SelectionForeColor; }
            set { this.RowsDefaultCellStyle.SelectionForeColor = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene la altura de las filas")]
        public int RowHeight
        {
            get { return this.RowTemplate.Height; }
            set { this.RowTemplate.Height = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Establece u obtiene el Color de fondo de DataGridView")]
        public Color DgvBackColor
        {
            get { return this.BackgroundColor; }
            set { this.BackgroundColor = value; }
        }

        [Category("RJ Code Advance")]
        [Description("Obtiene o establece el radio del borde")]
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
        {
            if (customizable == false)//si no es personalizable, aplicar la configuración de apariencia.
            {
                if (UIAppearance.Theme == UITheme.Dark)//Si el tema es oscuro, establecer las siguientes propiedades
                {
                    DgvBackColor = RJColors.DarkItemBackground; //Color de fondo
                    RowsColor = RJColors.DarkItemBackground;//Color de las filas
                    ColumnHeaderColor = RJColors.DarkActiveBackground;//Color de fondo de los encabezados de columna
                    ColumnHeaderTextColor = Color.Gainsboro;//Color de texto  de los encabezados de columna.
                    RowsTextColor = UIAppearance.PrimaryTextColor;//Color del texto de las filas
                    this.GridColor = UIAppearance.BackgroundColor;//Color de cuadrícula

                    if (isAlternatingRowsColor)//Si es Color de filas alternativas, establezca un color para el color de filas alternativas
                    {

                        AlternatingRowsColor = Utils.ColorEditor.Lighten(RJColors.DarkActiveBackground, 5);//Color de fondo de filas alternas
                        SelectionBackColor = Utils.ColorEditor.Lighten(UIAppearance.StyleColor, 30);// Color de fondo de la selección.
                        SelectionTextColor = Color.White;//Color de texto de la selección.
                    }
                    else //Color de filas normal
                    {
                        SelectionBackColor = Utils.ColorEditor.Lighten(RJColors.DarkActiveBackground, 5);//Color de fondo de la selección.
                        SelectionTextColor = UIAppearance.PrimaryTextColor;//Color de texto de la selección.
                    }

                }

                else //Si el tema es claro, establecer las siguientes propiedades
                {
                    DgvBackColor = RJColors.LightItemBackground;//Color de fondo
                    RowsColor = RJColors.LightItemBackground;//Color de las filas
                    ColumnHeaderColor = UIAppearance.StyleColor;//Color de fondo de los encabezados de columna
                    ColumnHeaderTextColor = Color.WhiteSmoke;//Color de texto  de los encabezados de columna.
                    RowsTextColor = UIAppearance.TextColor;//Color del texto de las filas
                    this.GridColor = Color.Gainsboro;//Color de cuadrícula

                    if (isAlternatingRowsColor)//Si es Color de filas alternativas, establezca un color para el color de filas alternativas
                    {
                        AlternatingRowsColor = Utils.ColorEditor.Lighten(UIAppearance.StyleColor, 80);//Color de fondo de filas alternas
                        SelectionBackColor = Utils.ColorEditor.Lighten(UIAppearance.StyleColor, 40);//Color de fondo de la selección.
                        SelectionTextColor = Color.White;//Color de texto de la selección.
                    }
                    else //Color de filas normal
                    {
                        SelectionBackColor = Utils.ColorEditor.Lighten(UIAppearance.StyleColor, 80);//Color de fondo de la selección.
                        SelectionTextColor = UIAppearance.TextColor;//Color de texto de la selección.
                    }
                }
            }
        }
        #endregion

        #region -> Métodos de eventos

        private void ScrollBar_Event(object sender, ScrollEventArgs e)
        {
            //Si el tipo de desplazamiento es EndScroll, guardar el valor y volver dibujar el control.
            if (e.Type == ScrollEventType.EndScroll)
            {
                stopScroll = true;             
                this.Invalidate();
            }
            //Caso contrario, indicar que la barra de desplazamiento se está moviendo.
            else
            {
                stopScroll = false;              
            }
        }
        #endregion

        #region -> Métodos anulados

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            //Es responsable de aplicar la configuración de apariencia en tiempo de ejecución.
            //y validar la altura mínima del encabezado de la columna.
            if (!this.DesignMode)
                ApplyAppearanceSettings();//Aplicar la configuración de apariencia de la interfaz de usuario

            if (this.ColumnHeadersHeight < 40)//Establecer altura mínima
            {
                ColumnHeaderHeight = 40;
            }          
        }

        protected override void OnPaint(PaintEventArgs e)
        {//Responsable de aplicar las esquinas redondeados + suavizado de los bordes
            base.OnPaint(e);
            if (stopScroll == true )//Si la barra de desplazamiento no se está moviendo aplicar y suavizar los bordes redondeados.
                Utils.RoundedControl.RegionAndSmoothed(this, borderRadius, e.Graphics);
        }
    
        #endregion

    }
}
