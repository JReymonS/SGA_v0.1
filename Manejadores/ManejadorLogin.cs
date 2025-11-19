using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Manejadores
{
    public class ManejadorLogin
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");


        //METODO PARA VALIDAR LOGIN Y RECUPERAR PERMISOS
        public (bool Acceso, string Mensaje, Usuarios UsuarioEncontrado, Roles RolPerteneciente) ValidarLogin(string usuario, string contrasena) 
        {
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena)) 
            {
                return (false, "Por favor complete todos los campos.", null,null);
            }

            DataSet ds = b.Consulta($"SELECT * FROM v_UsuariosRolPermisos WHERE BINARY NombreUsuario like '%{usuario}%' AND Clave like '%{Sha1(contrasena)}%'", "v_UsuariosRolPermisos");
            if (ds.Tables.Count >0 && ds.Tables[0].Rows.Count >=1)
            {
                DataTable dt = ds.Tables[0];
                Usuarios user = new Usuarios(0,"","","","","",0);
                Roles rol = new Roles(0,"","","");

                foreach (DataRow row in dt.Rows) 
                {
                    if (user.id_usuario == 0) 
                    {
                        user.id_usuario = Convert.ToInt32(row["IdUsuario"]);
                        user.nombre = row["NombreUsuario"].ToString();
                        user.fkid_rol = Convert.ToInt32(row["IdRol"]);
                    }

                    Permisos permisos = new Permisos
                    (
                        Convert.ToInt32(row["IdPermiso"]),
                        Convert.ToString(row["PermisoCrear"]),
                        Convert.ToString(row["PermisoLeer"]),
                        Convert.ToString(row["PermisoModificar"]),
                        Convert.ToString(row["PermisoEliminar"]),
                        Convert.ToInt32(row["IdRol"]),
                        Convert.ToInt32(row["IdModulo"])

                    );
                    rol.permisos.Add(permisos);
                }
                return(true, "Acceso concedido.", user, rol);
            }
            else 
            {
                return (false, "Usuario o contraseña incorrectos.", null,null);
            }

        }


        //METODO PARA MOSTRAR CONTRASEÑA O OCULTARLA
        public void MostrarOcultarContrasena(TextBox caja, bool mostrar)
        {
            if (mostrar)
            {
                caja.PasswordChar = '\0';
            }
            else
            {
                caja.PasswordChar = '*';
            }
        }


        //METODO PARA LIMPIAR CAJAS DE TEXTO
        public void LimipiarCajas(TextBox caja1, TextBox caja2)
        {
            caja1.Clear();
            caja2.Clear();
        }


        //METODO PARA ENCRIPTADO DE CONTRASEÑA
        public static string Sha1(string texto)
        {
            SHA1 sha1 = SHA1CryptoServiceProvider.Create();
            Byte[] textOriginal = ASCIIEncoding.Default.GetBytes(texto);
            Byte[] hash = sha1.ComputeHash(textOriginal);
            StringBuilder cadena = new StringBuilder();

            foreach (byte i in hash)
            {
                cadena.AppendFormat("{0:x2}", i);
            }
            return cadena.ToString();
        }



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

        public void QuitarBordesBotones(Button boton)
        {
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatStyle = FlatStyle.Flat;
        }

        public void EstiloPanelTexto(Panel panel, Label etiqueta)
        {
            panel.BackColor = ColorTranslator.FromHtml("#B7CC18");
            etiqueta.ForeColor = ColorTranslator.FromHtml("#EDE7D5");
            etiqueta.Font = new Font("Suravaram", 30, FontStyle.Bold);
        }

        public void EstilizarTextBox(TextBox txt)
        {
            int radio = 45; 
            int borde = 2;

            // Crear panel contenedor con MARGEN suficiente
            Panel contenedor = new Panel();
            contenedor.BackColor = ColorTranslator.FromHtml("#EDE7D5");

            // Más espacio lateral y más abajo para el borde
            contenedor.Size = new Size(txt.Width + 40, txt.Height + 24);
            contenedor.Location = txt.Location;

            // Ajustes del textbox
            txt.BorderStyle = BorderStyle.None;
            txt.BackColor = ColorTranslator.FromHtml("#EDE7D5");

            txt.Location = new Point(12, 8); // centrado perfecto
            txt.Width = contenedor.Width - 24;

            // Dibujar borde redondeado sin que se corte
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

            // Agregar panel y textbox
            txt.Parent.Controls.Add(contenedor);
            contenedor.Controls.Add(txt);
            txt.BringToFront();
        }








    }
}
