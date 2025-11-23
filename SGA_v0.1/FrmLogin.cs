using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace SGA_v0._1
{
    public partial class FrmLogin : Form
    {
        ManejadorLogin ml;
        ManejadorDiseño md;
        int intentosFallidos = 0;
        bool mostrarContrasena = false;
        
        // CONSTRUCTOR PARA INICIALIZAR FUNCIONES 
        public FrmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
            md = new ManejadorDiseño();
            md.EstiloPanelTexto(pLogin, lblLogin, ColorTranslator.FromHtml("#B7CC18"));
            md.EstilosBoton(btnIngresar);
            md.EstilizarTextBox(txtContrasena, ColorTranslator.FromHtml("#B7CC18"));
            md.EstilizarTextBox(txtUsuario, ColorTranslator.FromHtml("#B7CC18"));
            md.QuitarBordesBotones(btnMostrar);
            md.QuitarBordesBotones(btnVer);
            md.QuitarBordesBotones(btnCerrar);
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
        }


        //EVENTO CLICK PARA INGRESAR AL SISTEMA
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            var rs = ml.ValidarLogin(usuario,contrasena);

            if (rs.Acceso)
            {
                //RECUPERAR AL USUARIO Y SU ROL GLOBALMENTE PARA HACER USO DE LOS DATOS EN LOS SIGUIENTES REGISTROS DE SALIDA DE PRODUCTOS

                FrmUsuarioSesion.Usuario = rs.UsuarioEncontrado;
                FrmUsuarioSesion.Rol = rs.RolPerteneciente;

                FrmInicio frmInicio = new FrmInicio(rs.UsuarioEncontrado,rs.RolPerteneciente);
                frmInicio.Show();
                this.Hide();
            }
            else 
            {
                intentosFallidos++;
                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Ha excedido el número maximo de intentos.\n\nSe activo el bloqueo por 3 segundos.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Enabled = false;
                    txtContrasena.Enabled = false;
                    btnIngresar.Enabled = false;
                    btnMostrar.Enabled = false;
                    Thread.Sleep(3000);

                    MessageBox.Show("Se desactivó el bloqueo temporal, puede intentar nuevamente.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtUsuario.Enabled = true;
                    txtContrasena.Enabled = true;
                    btnIngresar.Enabled = true;
                    btnMostrar.Enabled = true;
                    intentosFallidos = 0;
                    ml.LimipiarCajas(txtUsuario, txtContrasena);
                }
                else
                {
                    MessageBox.Show(rs.Mensaje, "¡ERROR DE AUTENTICACIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ml.LimipiarCajas(txtUsuario, txtContrasena);
                }
                
            }
        }


        //EVENTO CLICK PARA MOSTRAR U OCULTAR CONTRASEÑA
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarContrasena = true;

            ml.MostrarOcultarContrasena(txtContrasena, mostrarContrasena);

           

            btnVer.Visible = true;     
            btnMostrar.Visible = false;
            
        }


        private void btnMostrar_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            
            btnIngresar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            btnIngresar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnIngresar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            mostrarContrasena = false;
            ml.MostrarOcultarContrasena(txtContrasena, mostrarContrasena);
            btnMostrar.Visible = true;   
            btnVer.Visible = false;   
        }

        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = ColorTranslator.FromHtml("#8CBFAF");
            
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = ColorTranslator.FromHtml("#B7CC18");   
        }
    }
}
