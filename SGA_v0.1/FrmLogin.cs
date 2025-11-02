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
        int intentosFallidos = 0;
        bool mostrarContrasena = false;

        public FrmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
        }


        //EVENTO CLICK PARA INGRESAR AL SISTEMA
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            var rs = ml.ValidarLogin(usuario,contrasena);

            if (rs.Acceso)
            {
                FrmInicio frmInicio = new FrmInicio(rs.UsuarioEncontrado,rs.RolPerteneciente);
                frmInicio.ShowDialog();
                this.Close();
            }
            else 
            {
                intentosFallidos++;
                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Ha excedido el número maximo de intentos. Se activo el bloqueo por 3 segundos.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.Enabled = false;
                    txtContrasena.Enabled = false;
                    btnIngresar.Enabled = false;
                    btnMostrar.Enabled = false;
                    Thread.Sleep(3000);

                    MessageBox.Show("Se desactivo el bloqueo temporal, puede continuar.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            mostrarContrasena = !mostrarContrasena;
            ml.MostrarOcultarContrasena(txtContrasena, mostrarContrasena);
        }
    }
}
