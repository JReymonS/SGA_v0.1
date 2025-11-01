using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace SGA_v0._1
{
    public partial class FrmLogin : Form
    {
        ManejadorLogin ml;
        public FrmLogin()
        {
            InitializeComponent();
            ml = new ManejadorLogin();
        }

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
                MessageBox.Show(rs.Mensaje, "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
