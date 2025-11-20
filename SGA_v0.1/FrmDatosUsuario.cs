using Manejadores;
using System;
using System.Windows.Forms;
using Entidades;

namespace SGA_v0._1
{
    public partial class FrmDatosUsuario : Form
    {
        ManejadorUsuarios mu;
        public FrmDatosUsuario()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
            mu.LLenarRoles(cmbRol);
            cmbEstatus.SelectedIndex = 0;
            if (FrmUsuarios.usuario.id_usuario > 0) 
            {
                txtNombre.Text = FrmUsuarios.usuario.nombre;
                txtApellidoPaterno.Text = FrmUsuarios.usuario.apellido_paterno;
                txtApellidoMaterno.Text = FrmUsuarios.usuario.apellido_materno;
                txtClave.Text = FrmUsuarios.usuario.clave;
                cmbEstatus.SelectedValue = FrmUsuarios.usuario.status;
                cmbRol.SelectedValue = FrmUsuarios.usuario.fkid_rol;

            }
        }


        //EVENTO CLICK PARA GUARDAR REGISTROS O MODIFICACIONES
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmUsuarios.usuario.id_usuario == 0)
            {
                mu.ValidarCampos(txtNombre, txtApellidoPaterno, txtApellidoMaterno, txtClave, true);

                if (!mu.valido)
                {
                    return;
                }

                else
                {
                    mu.Guardar(new Usuarios(0, txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtClave.Text, mu.Codificacion(cmbEstatus), int.Parse(cmbRol.SelectedValue.ToString())));
                }
            }
            else 
            {
                if (txtClave.Text == "")
                {
                    mu.ValidarCampos(txtNombre, txtApellidoPaterno, txtApellidoMaterno, txtClave, false);
                    if (!mu.valido)
                    {
                        return;
                    }

                    else
                    {
                        mu.Modificar(new Usuarios(FrmUsuarios.usuario.id_usuario, txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, FrmUsuarios.usuario.clave, mu.Codificacion(cmbEstatus), int.Parse(cmbRol.SelectedValue.ToString())), false);
                    }
                }
                else
                {
                    mu.ValidarCampos(txtNombre, txtApellidoPaterno, txtApellidoMaterno, txtClave, true);
                    if (!mu.valido)
                    {
                        return;
                    }
                    else
                    {
                        mu.Modificar(new Usuarios(FrmUsuarios.usuario.id_usuario, txtNombre.Text, txtApellidoPaterno.Text, txtApellidoMaterno.Text, txtClave.Text, mu.Codificacion(cmbEstatus), int.Parse(cmbRol.SelectedValue.ToString())), true);
                    }
                }
            }
            Close();
        }


        //EVENTO CLICK PARA CANCELAR REGISTRO O MODIFICACION
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
