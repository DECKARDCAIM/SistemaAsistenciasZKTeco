using System;
using System.Drawing;
using System.Windows.Forms;
using RJCodeUI_M1.Settings;
using RJCodeUI_M1.RJControls;
using RJCodeUI_M1.RJForms;

namespace Sistema.Presentacion.Utils
{
    public static class ThemeManager
    {
        public static void AplicarTemaFormulario(Form form)
        {
            if (form == null) return;

            bool esOscuro = UIAppearance.Theme == UITheme.Dark;
            Color colorFondo = esOscuro ? Color.FromArgb(18, 22, 38) : Color.FromArgb(245, 247, 251);
            Color colorPrimario = UIAppearance.PrimaryStyleColor != Color.Empty ? UIAppearance.PrimaryStyleColor : Color.FromArgb(37, 99, 235);
            Color colorTexto = esOscuro ? Color.FromArgb(225, 235, 245) : Color.FromArgb(30, 41, 59);
            Color colorSubtexto = esOscuro ? Color.FromArgb(160, 175, 200) : Color.FromArgb(100, 116, 139);
            Color colorInputFondo = esOscuro ? Color.FromArgb(30, 36, 58) : Color.White;
            Color colorInputBorder = esOscuro ? Color.FromArgb(55, 65, 95) : Color.FromArgb(203, 213, 225);
            Color colorPanelFondo = colorFondo;
            Color colorTabFondo = colorFondo;

            form.BackColor = colorFondo;
            form.Padding = new Padding(0);

            if (form is RJBaseForm baseForm)
            {
                baseForm.BorderSize = 0;
                baseForm.BorderColor = colorFondo;
                baseForm.Padding = new Padding(0);
            }

            if (form is RJChildForm childForm)
            {
                childForm.IsChildForm = true;
                childForm.BorderSize = 0;
                childForm.BorderColor = colorFondo;
                childForm.Padding = new Padding(0);

                foreach (Control ctrl in form.Controls)
                {
                    if (ctrl is Panel pnl && pnl.Name == "pnlClientArea")
                    {
                        pnl.BackColor = colorFondo;
                        pnl.Padding = new Padding(0);
                        pnl.Dock = DockStyle.Fill;
                    }
                    else if (ctrl is Panel pnlTitle && pnlTitle.Name == "pnlTitleBar")
                    {
                        pnlTitle.Visible = false;
                    }
                }
            }

            AplicarTemaRecursivo(form, esOscuro, colorPrimario, colorTexto, colorSubtexto, colorInputFondo, colorInputBorder, colorPanelFondo, colorTabFondo);
        }

        private static void AplicarTemaRecursivo(Control parent, bool esOscuro, Color colorPrimario, Color colorTexto, Color colorSubtexto, Color colorInputFondo, Color colorInputBorder, Color colorPanelFondo, Color colorTabFondo)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is TabControl tab)
                {
                    tab.BackColor = colorTabFondo;
                    tab.Margin = new Padding(0);
                    tab.Padding = new Point(0, 0);

                    if (tab.ItemSize.Height <= 1 || tab.Appearance == TabAppearance.FlatButtons)
                    {
                        tab.Dock = DockStyle.None;
                        tab.Location = new Point(-6, -6);
                        tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        if (tab.Parent != null)
                        {
                            tab.Size = new Size(tab.Parent.ClientSize.Width + 12, tab.Parent.ClientSize.Height + 12);
                            tab.Parent.SizeChanged -= TabParent_SizeChanged;
                            tab.Parent.SizeChanged += TabParent_SizeChanged;
                        }
                    }
                    else
                    {
                        tab.DrawMode = TabDrawMode.OwnerDrawFixed;
                        tab.ItemSize = new Size(140, 34);
                        tab.SizeMode = TabSizeMode.Fixed;

                        tab.DrawItem -= Tab_DrawItem;
                        tab.DrawItem += Tab_DrawItem;
                    }

                    foreach (TabPage page in tab.TabPages)
                    {
                        page.BackColor = colorTabFondo;
                        page.ForeColor = colorTexto;
                        page.Margin = new Padding(0);
                        page.Padding = new Padding(12);
                        page.BorderStyle = BorderStyle.None;
                        AplicarTemaRecursivo(page, esOscuro, colorPrimario, colorTexto, colorSubtexto, colorInputFondo, colorInputBorder, colorPanelFondo, colorTabFondo);
                    }
                }
                else if (c is RJDataGridView rjDgv)
                {
                    GridStyler.AplicarEstilo(rjDgv);
                }
                else if (c is DataGridView dgv)
                {
                    GridStyler.AplicarEstilo(dgv);
                }
                else if (c is RJTextBox rjTxt)
                {
                    rjTxt.BackColor = colorInputFondo;
                    rjTxt.ForeColor = colorTexto;
                    rjTxt.BorderColor = colorPrimario;
                }
                else if (c is TextBox txt)
                {
                    txt.BackColor = colorInputFondo;
                    txt.ForeColor = colorTexto;
                    txt.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (c is ComboBox cbo)
                {
                    cbo.BackColor = colorInputFondo;
                    cbo.ForeColor = colorTexto;
                    cbo.FlatStyle = FlatStyle.Flat;
                }
                else if (c is RJDatePicker rjDtp)
                {
                    rjDtp.Customizable = false;
                    rjDtp.BackColor = colorInputFondo;
                    rjDtp.ForeColor = colorTexto;
                    rjDtp.BorderColor = colorPrimario;
                    rjDtp.IconColor = colorPrimario;
                    rjDtp.Font = new Font("Segoe UI", 9.5F);
                }
                else if (c is DateTimePicker dtp)
                {
                    dtp.CalendarMonthBackground = colorInputFondo;
                    dtp.CalendarForeColor = colorTexto;
                    dtp.CalendarTitleBackColor = colorPrimario;
                    dtp.CalendarTitleForeColor = Color.White;
                    dtp.CalendarTrailingForeColor = colorSubtexto;
                    dtp.Font = new Font("Segoe UI", 9.5F);
                }
                else if (c is RadioButton rdo)
                {
                    rdo.ForeColor = colorTexto;
                    rdo.BackColor = (rdo.Parent != null ? rdo.Parent.BackColor : colorTabFondo);
                }
                else if (c is CheckBox chk)
                {
                    chk.ForeColor = colorTexto;
                    chk.BackColor = (chk.Parent != null ? chk.Parent.BackColor : colorTabFondo);
                }
                else if (c is Label lbl)
                {
                    if (lbl.Parent is Panel pnl && (pnl.Name.StartsWith("pnlCard") || pnl.Name.Contains("Banner")))
                    {
                    }
                    else
                    {
                        if (lbl.Name.StartsWith("lblTotal") || lbl.Name.StartsWith("lblSub"))
                        {
                            lbl.ForeColor = colorSubtexto;
                        }
                        else
                        {
                            lbl.ForeColor = colorTexto;
                        }
                    }
                }
                else if (c is Button btn && !(c is RJMenuButton))
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Cursor = Cursors.Hand;
                }
                else if (c is Panel pnl)
                {
                    // Skip the RJChildForm title bar panel (pnlTitleBar)
                    if (pnl.Name == "pnlTitleBar" && pnl.Parent is RJChildForm)
                    {
                        pnl.Visible = false;
                        continue;
                    }

                    if (pnl.Name == "pnlFiltros" || pnl.Name == "pnlAcciones")
                    {
                        pnl.BackColor = colorPanelFondo;
                        pnl.BorderStyle = BorderStyle.None;
                        pnl.Padding = new Padding(0);
                    }
                    else if (pnl.Name.StartsWith("pnlCard"))
                    {
                    }
                    else if (pnl.Name == "pnlClientArea")
                    {
                        pnl.BackColor = colorTabFondo;
                        pnl.Padding = new Padding(0);
                    }
                    else if (!pnl.Name.Contains("Grafica"))
                    {
                        pnl.BackColor = colorTabFondo;
                    }

                    AplicarTemaRecursivo(pnl, esOscuro, colorPrimario, colorTexto, colorSubtexto, colorInputFondo, colorInputBorder, colorPanelFondo, colorTabFondo);
                }
                else if (c.HasChildren)
                {
                    AplicarTemaRecursivo(c, esOscuro, colorPrimario, colorTexto, colorSubtexto, colorInputFondo, colorInputBorder, colorPanelFondo, colorTabFondo);
                }
            }
        }

        private static void Tab_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabControl tab = sender as TabControl;
            if (tab == null || e.Index < 0 || e.Index >= tab.TabPages.Count) return;

            TabPage page = tab.TabPages[e.Index];
            bool isSelected = (tab.SelectedIndex == e.Index);
            bool esOscuro = UIAppearance.Theme == UITheme.Dark;

            Color bgTab = isSelected
                ? (esOscuro ? Color.FromArgb(32, 38, 62) : Color.White)
                : (esOscuro ? Color.FromArgb(18, 22, 38) : Color.FromArgb(235, 238, 245));

            Color textTab = isSelected
                ? (UIAppearance.PrimaryStyleColor != Color.Empty ? UIAppearance.PrimaryStyleColor : Color.FromArgb(37, 99, 235))
                : (esOscuro ? Color.FromArgb(160, 175, 200) : Color.FromArgb(100, 116, 139));

            Rectangle tabRect = e.Bounds;

            using (SolidBrush brushBg = new SolidBrush(bgTab))
            {
                e.Graphics.FillRectangle(brushBg, tabRect);
            }

            if (isSelected)
            {
                Color barColor = UIAppearance.PrimaryStyleColor != Color.Empty ? UIAppearance.PrimaryStyleColor : Color.FromArgb(37, 99, 235);
                using (SolidBrush barBrush = new SolidBrush(barColor))
                {
                    e.Graphics.FillRectangle(barBrush, tabRect.X, tabRect.Bottom - 3, tabRect.Width, 3);
                }
            }

            using (Font font = new Font("Segoe UI", 9.5f, isSelected ? FontStyle.Bold : FontStyle.Regular))
            using (SolidBrush brushText = new SolidBrush(textTab))
            using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center })
            {
                e.Graphics.DrawString(page.Text, font, brushText, tabRect, sf);
            }
        }

        private static void TabParent_SizeChanged(object sender, EventArgs e)
        {
            if (sender is Control parent)
            {
                foreach (Control c in parent.Controls)
                {
                    if (c is TabControl tab && (tab.ItemSize.Height <= 1 || tab.Appearance == TabAppearance.FlatButtons))
                    {
                        tab.Location = new Point(-6, -6);
                        tab.Size = new Size(parent.ClientSize.Width + 12, parent.ClientSize.Height + 12);
                    }
                }
            }
        }
    }
}
