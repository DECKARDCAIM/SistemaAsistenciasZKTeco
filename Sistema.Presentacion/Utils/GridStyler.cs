using System;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.Utils;

namespace Sistema.Presentacion.Utils
{
    public static class GridStyler
    {
        public static void AplicarEstilo(DataGridView dgv)
        {
            if (dgv == null) return;

            bool esOscuro = UIAppearance.Theme == UITheme.Dark;

            dgv.EnableHeadersVisualStyles = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.Font = new Font("Segoe UI", 9.25F, FontStyle.Regular);

            Color colorHeader = UIAppearance.PrimaryStyleColor != Color.Empty 
                ? UIAppearance.PrimaryStyleColor 
                : Color.FromArgb(40, 53, 147);

            // Estilo de Encabezados Unificado (Garantiza que todos los encabezados tengan exactamente el mismo color del tema)
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                BackColor = colorHeader,
                ForeColor = Color.White,
                SelectionBackColor = colorHeader,
                SelectionForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                Padding = new Padding(8, 0, 0, 0),
                WrapMode = DataGridViewTriState.False
            };

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.HeaderCell.Style.BackColor = colorHeader;
                col.HeaderCell.Style.ForeColor = Color.White;
                col.HeaderCell.Style.SelectionBackColor = colorHeader;
                col.HeaderCell.Style.SelectionForeColor = Color.White;
            }

            // Asegurar que al enlazar datos o agregar columnas se preserve el color uniforme
            dgv.DataBindingComplete -= Dgv_DataBindingComplete;
            dgv.DataBindingComplete += Dgv_DataBindingComplete;
            dgv.ColumnAdded -= Dgv_ColumnAdded;
            dgv.ColumnAdded += Dgv_ColumnAdded;

            // Estilo de Filas
            dgv.RowTemplate.Height = 36;

            if (esOscuro)
            {
                dgv.BackgroundColor = Color.FromArgb(18, 22, 38);
                dgv.GridColor = Color.FromArgb(40, 48, 70);

                dgv.RowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(24, 28, 45),
                    ForeColor = Color.FromArgb(220, 230, 245),
                    SelectionBackColor = Color.FromArgb(50, 65, 105),
                    SelectionForeColor = Color.White,
                    Padding = new Padding(6, 0, 0, 0)
                };

                dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(20, 24, 40),
                    ForeColor = Color.FromArgb(220, 230, 245),
                    SelectionBackColor = Color.FromArgb(50, 65, 105),
                    SelectionForeColor = Color.White,
                    Padding = new Padding(6, 0, 0, 0)
                };
            }
            else
            {
                dgv.BackgroundColor = Color.FromArgb(245, 247, 251);
                dgv.GridColor = Color.FromArgb(230, 235, 245);

                dgv.RowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(30, 41, 59),
                    SelectionBackColor = Color.FromArgb(224, 235, 255),
                    SelectionForeColor = Color.FromArgb(20, 35, 90),
                    Padding = new Padding(6, 0, 0, 0)
                };

                dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(248, 250, 254),
                    ForeColor = Color.FromArgb(30, 41, 59),
                    SelectionBackColor = Color.FromArgb(224, 235, 255),
                    SelectionForeColor = Color.FromArgb(20, 35, 90),
                    Padding = new Padding(6, 0, 0, 0)
                };
            }
        }

        private static void Dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (sender is DataGridView dgv)
            {
                Color colorHeader = UIAppearance.PrimaryStyleColor != Color.Empty 
                    ? UIAppearance.PrimaryStyleColor 
                    : Color.FromArgb(40, 53, 147);

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    col.HeaderCell.Style.BackColor = colorHeader;
                    col.HeaderCell.Style.ForeColor = Color.White;
                    col.HeaderCell.Style.SelectionBackColor = colorHeader;
                    col.HeaderCell.Style.SelectionForeColor = Color.White;
                }
            }
        }

        private static void Dgv_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            Color colorHeader = UIAppearance.PrimaryStyleColor != Color.Empty 
                ? UIAppearance.PrimaryStyleColor 
                : Color.FromArgb(40, 53, 147);

            e.Column.HeaderCell.Style.BackColor = colorHeader;
            e.Column.HeaderCell.Style.ForeColor = Color.White;
            e.Column.HeaderCell.Style.SelectionBackColor = colorHeader;
            e.Column.HeaderCell.Style.SelectionForeColor = Color.White;
        }
    }
}
