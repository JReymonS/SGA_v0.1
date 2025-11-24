using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorDiseño
    {
        // METODO PARA DAR FORMATO A LOS BOTONES (COLOR DE BORDE, FONDO Y REDONDEADO)
        public void EstilosBoton(Button boton)
        {
            int radio = 25;
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatStyle = FlatStyle.Flat;
            boton.BackColor = ColorTranslator.FromHtml("#545454");
            boton.ForeColor = ColorTranslator.FromHtml("#EDE7D5");
            GraphicsPath gp = new GraphicsPath();
            gp.StartFigure();
            gp.AddArc(new Rectangle(0, 0, radio, radio), 180, 90);
            gp.AddLine(radio, 0, boton.Width - radio, 0);
            gp.AddArc(new Rectangle(boton.Width - radio, 0, radio, radio), -90, 90);
            gp.AddLine(boton.Width, radio, boton.Width, boton.Height - radio);
            gp.AddArc(new Rectangle(boton.Width - radio, boton.Height - radio, radio, radio), 0, 90);
            gp.AddLine(boton.Width - radio, boton.Height, radio, boton.Height);
            gp.AddArc(new Rectangle(0, boton.Height - radio, radio, radio), 90, 90);
            gp.CloseFigure();
            boton.Region = new Region(gp);
        }


        // METODO PARA QUITAR LOS BORDES EN BOTONES (BOTONES CON IMAGENES)
        public void QuitarBordesBotones(Button boton)
        {
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatStyle = FlatStyle.Flat;
        }


        //METODO PARA DAR FORMATO AL ENCABEZADO DE CADA FORMULARIO
        public void EstiloPanelTexto(Panel panel, Label etiqueta, Color color)
        {
            panel.BackColor = color;
            etiqueta.ForeColor = ColorTranslator.FromHtml("#EDE7D5");
            //etiqueta.Location = new Point(5, 9);
            etiqueta.Font = new Font("Suravaram", 30, FontStyle.Bold);
        }


        // METODO PARA DAR FORMATO A LOS TEXT BOX (COLOR DE BORDE, FONDO Y REDONDEADO)
        public void EstilizarTextBox(TextBox txt)
        {
            int radio = 45;
            int borde = 2;

            Panel contenedor = new Panel();

            contenedor.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            contenedor.Size = new Size(txt.Width + 40, txt.Height + 18);
            contenedor.Location = txt.Location;

            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            txt.Location = new Point(12, 12); // centrado perfecto
            txt.Width = contenedor.Width - 24;

            contenedor.Paint += (s, e) =>
            {
                Rectangle rect = new Rectangle(
                    borde,
                    borde,
                    contenedor.Width - borde * 2 - 1,
                    contenedor.Height - borde * 2 - 1
                );

                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                    gp.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                    gp.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                    gp.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                    gp.CloseFigure();

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen p = new Pen(ColorTranslator.FromHtml("#545454"), 1))
                    {
                        e.Graphics.DrawPath(p, gp);
                    }
                }
            };

            txt.Parent.Controls.Add(contenedor);
            contenedor.Controls.Add(txt);
            txt.BringToFront();
        }
        // METODO PARA DAR FORMATO A LOS TEXT BOX (COLOR DE BORDE, FONDO Y REDONDEADO) DE LOGIN
        public void EstilizarTextBoxLogin(TextBox txt)
        {
            int radio = 45;
            int borde = 2;

            Panel contenedor = new Panel();

            contenedor.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            contenedor.Size = new Size(txt.Width + 40, txt.Height + 20);
            contenedor.Location = txt.Location;

            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            txt.Location = new Point(12, 8); // centrado perfecto
            txt.Width = contenedor.Width - 24;

            contenedor.Paint += (s, e) =>
            {
                Rectangle rect = new Rectangle(
                    borde,
                    borde,
                    contenedor.Width - borde * 2 - 1,
                    contenedor.Height - borde * 2 - 1
                );

                using (GraphicsPath gp = new GraphicsPath())
                {
                    gp.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
                    gp.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
                    gp.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
                    gp.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
                    gp.CloseFigure();

                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (Pen p = new Pen(ColorTranslator.FromHtml("#B7CC18"), 1))
                    {
                        e.Graphics.DrawPath(p, gp);
                    }
                }
            };

            txt.Parent.Controls.Add(contenedor);
            contenedor.Controls.Add(txt);
            txt.BringToFront();
        }

        //METODO PARA ESTILIZAR EL DATAGRIDVIEW
        public void EstilizarData(DataGridView tabla)
        {
            var colorFondo = ColorTranslator.FromHtml("#D9D9D9");
            var colorSeleccion = ColorTranslator.FromHtml("#B0B0B0");
            var colorGrid = ColorTranslator.FromHtml("#545454");
            var colorBoton = ColorTranslator.FromHtml("#545454");
            var colorTextoBoton = ColorTranslator.FromHtml("#EDE7D5");

            tabla.AllowUserToResizeColumns = false;
            tabla.AllowUserToResizeRows = false;

            tabla.BackgroundColor = colorFondo;
            tabla.DefaultCellStyle.BackColor = colorFondo;
            tabla.DefaultCellStyle.ForeColor = Color.Black;
            tabla.DefaultCellStyle.SelectionBackColor = colorSeleccion;
            tabla.DefaultCellStyle.SelectionForeColor = Color.Black;
            tabla.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabla.AlternatingRowsDefaultCellStyle.BackColor = colorFondo;
            tabla.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            tabla.AlternatingRowsDefaultCellStyle.SelectionBackColor = colorSeleccion;
            tabla.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.Black;

            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = colorFondo;
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            tabla.ColumnHeadersDefaultCellStyle.SelectionBackColor = colorSeleccion;
            tabla.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;
            tabla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            tabla.RowHeadersDefaultCellStyle.BackColor = colorFondo;
            tabla.RowHeadersDefaultCellStyle.ForeColor = Color.Black;
            tabla.RowHeadersVisible = false;

            tabla.GridColor = colorGrid;
            tabla.BorderStyle = BorderStyle.None;
            tabla.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            tabla.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            tabla.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;


            foreach (DataGridViewRow fila in tabla.Rows)
            {
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    if (tabla.Columns[celda.ColumnIndex] is DataGridViewButtonColumn)
                    {
                        celda.Style.BackColor = colorBoton;
                        celda.Style.ForeColor = colorTextoBoton;
                        celda.Style.SelectionBackColor = colorBoton;
                        celda.Style.SelectionForeColor = colorTextoBoton;
                    }
                }
            }
        }

        // METODO PARA AGREGAR BORDE AL FORMULARIO 
        public void AgregarBordeFormulario(Form formulario)
        {
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Paint += (sender, e) =>
            {
                using (Pen penGris = new Pen(Color.Gray, 1))
                using (Pen penNegro = new Pen(Color.Black, 1))
                {
                    e.Graphics.DrawLine(penGris, 0, 0, formulario.Width, 0);
                    e.Graphics.DrawLine(penGris, formulario.Width - 1, 0, formulario.Width - 1, formulario.Height);
                    e.Graphics.DrawLine(penGris, 0, 0, 0, formulario.Height);


                    e.Graphics.DrawLine(penNegro, 0, formulario.Height - 1, formulario.Width, formulario.Height - 1);
                }
            };
        }

        // METODO PARA DAR FORMATO A LOS COMBO BOX (COLOR DE BORDE Y FONDO)
        public void EstilizarComboBox(ComboBox cmb)
        {
            int borde = 1;
            Panel contenedor = new Panel();
            contenedor.BackColor = ColorTranslator.FromHtml("#545454");
            contenedor.Size = new Size(cmb.Width + (borde * 2), cmb.Height + (borde * 2));
            contenedor.Location = cmb.Location;

            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            cmb.ForeColor = Color.Black;
            cmb.Location = new Point(borde, borde);

            cmb.Parent.Controls.Add(contenedor);
            contenedor.Controls.Add(cmb);
            cmb.BringToFront();
        }


        // METODO PARA DAR FORMATO A LOS DATE TIME PICKER (COLOR DE BORDE Y FONDO)
        public void EstilizarDTP(DateTimePicker dtp)
        {
            int borde = 1;
            Panel contenedor = new Panel();
            contenedor.BackColor = ColorTranslator.FromHtml("#545454");
            contenedor.Size = new Size(dtp.Width + (borde * 2), dtp.Height + (borde * 2));
            contenedor.Location = dtp.Location;


            dtp.CalendarMonthBackground = ColorTranslator.FromHtml("#EDE7D5");
            dtp.CalendarTitleBackColor = ColorTranslator.FromHtml("#EDE7D5");
            dtp.CalendarTitleForeColor = Color.Black;
            dtp.CalendarForeColor = Color.Black;
            dtp.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            dtp.ForeColor = Color.Black;
            dtp.Location = new Point(borde, borde);
            dtp.Parent.Controls.Add(contenedor);
            contenedor.Controls.Add(dtp);
            dtp.BringToFront();
        }


        // METODO PARA CERRAR FORMULARIOS ACTIVOS AL CAMBIAR DE OPCION EN EL MENU
        public void CerrarFormulariosActivos(Form formularioPadre)
        {
            foreach (Form formularioHijo in formularioPadre.MdiChildren)
            {
                formularioHijo.Close();
            }
        }


        // METODO PARA COLOREAR SELECCIONES EN EL TOOLSTRIP
        public void Boton(object senderBoton, ToolStrip tsMenu, ToolStripButton tsBoton) 
        {
            Color colorSeleccion = ColorTranslator.FromHtml("#8CBFAF");
            Color colorOriginal = ColorTranslator.FromHtml("#B7CC18");

            foreach(ToolStripItem item in tsMenu.Items) 
            {
                if(item is ToolStripButton) 
                {
                    item.BackColor = colorOriginal;
                }
            }

            if(senderBoton is ToolStripButton boton) 
            {
                boton.BackColor = colorSeleccion;
                tsBoton = boton;
            }
        }
    }
}
