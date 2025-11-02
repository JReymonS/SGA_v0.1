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
using Entidades;

namespace SGA_v0._1
{
    public partial class FrmAgregarProductos : Form
    {
        ManejadorProductos mp;

        // El constructor permitira llenar los campos si se modificara un registo
        public FrmAgregarProductos()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
            mp.LlenarCategorias(cmbCategoria);
            mp.LlenarComboBox(cmbEstatus, "status", "productos");
            mp.LlenarComboBox(cmbUnidad, "unidad", "productos");
            if(FrmVerProductos.producto.id_producto > 0)
            {
                txtNombre.Text = FrmVerProductos.producto.nombre;
                txtDescripcion.Text = FrmVerProductos.producto.descripcion;
                txtCosto.Text = FrmVerProductos.producto.precio_salida.ToString();
                txtStockActual.Text = FrmVerProductos.producto.stock.ToString();
                txtStockMinimo.Text = FrmVerProductos.producto.stock_minimo.ToString();
                cmbCategoria.Text = FrmVerProductos.producto.unidad;
                cmbEstatus.Text = FrmVerProductos.producto.status;
                cmbCategoria.SelectedValue = FrmVerProductos.producto.fkid_categoria;

            }
        }
        // Permite guardar los cambios o nuevos registros

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(FrmVerProductos.producto.id_producto == 0)
                {
                    mp.Guardar(new Productos(0, txtNombre.Text, txtDescripcion.Text, cmbUnidad.Text, double.Parse(txtCosto.Text), int.Parse(txtStockActual.Text),int.Parse(txtStockMinimo.Text), cmbEstatus.Text,(int) cmbCategoria.SelectedValue));
                    MessageBox.Show("Datos Guardados Exitosamente");
                    Close();
                }
                else
                {
                    mp.Modificar(new Productos(FrmVerProductos.producto.id_producto, txtNombre.Text, txtDescripcion.Text, cmbUnidad.Text, double.Parse(txtCosto.Text), int.Parse(txtStockActual.Text), int.Parse(txtStockMinimo.Text), cmbEstatus.Text, (int)cmbCategoria.SelectedValue));
                    MessageBox.Show("Datos Actualizados Correctamente");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al Guardar los Datos. Hubo un problema: {ex.Message}");
            }
        }

        // Boton para salir de la ventana de registo de productos

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
