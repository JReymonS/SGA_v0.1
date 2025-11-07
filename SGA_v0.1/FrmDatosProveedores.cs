using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmDatosProveedores : Form
    {
        ManejadorProveedores mp;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApPa.Text) ||
                string.IsNullOrWhiteSpace(txtApMa.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Ingrese todos los datos del proveedor");
                return;
            }
            if (txtTelefono.Text.Length > 12)
            {
                MessageBox.Show("Ingrese correctamente el telefono");
                return;
            }
            try
            {
                if (FrmProveedores.proveedor.id_proveedor == 0)
                {
                    mp.Guardar(new Proveedores(0, txtNombre.Text, txtApPa.Text, txtApMa.Text, txtTelefono.Text,
                        txtCorreo.Text, int.Parse(txtPlazo.Text), cmbEstatus.Text));
                }
                else
                {
                    if (cmbEstatus.Text == "activo")
                        FrmProveedores.proveedor.status = "activo";
                    else
                        FrmProveedores.proveedor.status = "inactivo";

                    mp.Modificar(new Proveedores(FrmProveedores.proveedor.id_proveedor, txtNombre.Text, txtApPa.Text, txtApMa.Text, txtTelefono.Text,
                       txtCorreo.Text, int.Parse(txtPlazo.Text), cmbEstatus.Text));
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
