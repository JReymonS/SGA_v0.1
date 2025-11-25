using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmDatosUsuario : Form
    {
        ManejadorUsuarios mu;
        ManejadorDiseño md;
        public FrmDatosUsuario()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
            md = new ManejadorDiseño();
            mu.LLenarRoles(cmbRol);
            md.EstilizarTextBox(txtApellidoMaterno);
            md.EstilizarTextBox(txtApellidoPaterno);
            md.EstilizarTextBox(txtClave);
            md.EstilizarTextBox(txtNombre);
            md.EstilizarComboBox(cmbEstatus);
            md.EstilizarComboBox(cmbRol);
            md.EstilosBoton(btnCancelar);
            md.EstilosBoton(btnGuardar);
            md.EstiloPanelTexto(pNombre, lblNombre, ColorTranslator.FromHtml("#8CBFAF"));
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            md.AgregarBordeFormulario(this);
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
                      
                    if(!mu.valido) 
                    {
                       return;
                    }
                    Close();
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
                        if(!mu.valido) 
                        {
                            return;
                        }
                        Close();
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
                        if(!mu.valido) 
                        {
                            return;
                        }
                        Close();
                    }
                }
            }
        }


        //EVENTO CLICK PARA CANCELAR REGISTRO O MODIFICACION
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


        //EVENTO CLICK PARA DISEÑO DEL FORMULARIO
        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            btnGuardar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            btnGuardar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnGuardar);
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnCancelar);
        }
        // FIN EVENTOS PARA DISEÑO DEL FORMULARIO
    }
}
