using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void EstiloPanelTexto(Panel panel, Label etiqueta)
        {
            panel.BackColor = ColorTranslator.FromHtml("#B7CC18");
            etiqueta.ForeColor = ColorTranslator.FromHtml("#EDE7D5");
            etiqueta.Font = new Font("Suravaram", 30, FontStyle.Bold);
        }


        // METODO PARA DAR FORMATO A LOS TEXT BOX (COLOR DE BORDE, FONDO Y REDONDEADO)
        public void EstilizarTextBox(TextBox txt)
        {
            int radio = 45;
            int borde = 2;

            Panel contenedor = new Panel(); 

            contenedor.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            contenedor.Size = new Size(txt.Width + 40, txt.Height + 24);
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
    }
}
