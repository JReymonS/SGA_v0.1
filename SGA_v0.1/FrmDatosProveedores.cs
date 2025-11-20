using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmDatosProveedores : Form
    {
        ManejadorProveedores mp;


        //CONSTRUCTOR DEL FORMULARIO
        public FrmDatosProveedores()
        {
            InitializeComponent();
            mp = new ManejadorProveedores();
            if (FrmProveedores.proveedor.id_proveedor > 0)
            {
                txtNombre.Text = FrmProveedores.proveedor.nombre.ToString();
                txtApPa.Text = FrmProveedores.proveedor.apellido_paterno.ToString();
                txtApMa.Text = FrmProveedores.proveedor.apellido_materno.ToString();
                txtTelefono.Text = FrmProveedores.proveedor.telefono.ToString();
                txtCorreo.Text = FrmProveedores.proveedor.correo.ToString();
                txtPlazo.Text = FrmProveedores.proveedor.plazo_disponibilidad.ToString();
                cmbEstatus.Text = FrmProveedores.proveedor.status;
            }
            else 
            {
                cmbEstatus.SelectedIndex = 0;
            }
        }


        //METODO PARA GUARDAR O MODIFICAR PROVEEDORES
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            mp.ValidarCampos(txtNombre, txtApPa, txtApMa, txtTelefono, txtCorreo, txtPlazo); //VALIDAR CAMPOS ANTES DE GUARDAR O MODIFICAR

            if (!mp.valido)
            {
                return;
            }

            if (FrmProveedores.proveedor.id_proveedor == 0 && mp.valido)
            {
                mp.Guardar(new Proveedores(0, txtNombre.Text, txtApPa.Text, txtApMa.Text, txtTelefono.Text, txtCorreo.Text, int.Parse(txtPlazo.Text), cmbEstatus.Text));
            }

            else
            {
                if (mp.valido)
                {
                    mp.Modificar(new Proveedores(FrmProveedores.proveedor.id_proveedor, txtNombre.Text, txtApPa.Text, txtApMa.Text, txtTelefono.Text, txtCorreo.Text, int.Parse(txtPlazo.Text), cmbEstatus.Text));
                }
            }
            Close();
        }


        //METODO PARA CANCELAR LA OPERACION
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
