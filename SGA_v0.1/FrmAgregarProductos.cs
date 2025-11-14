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
    public partial class FrmAgregarProductos : Form
    {
        ManejadorProductos mp;

        //CONSTRUCTO QUE PERMITE LLENAR LOS CAMPOS SI SE MODIFICAN
        public FrmAgregarProductos()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
            mp.LlenarCategorias(cmbCategoria);
            mp.LlenarComboEstatus(cmbEstatus);
            mp.LlenarComboBox(cmbUnidad, "unidad", "productos");
            if (FrmVerProductos.producto.id_producto > 0)
            {
                txtNombre.Text = FrmVerProductos.producto.nombre;
                txtDescripcion.Text = FrmVerProductos.producto.descripcion;
                txtCosto.Text = FrmVerProductos.producto.precio_salida.ToString();
                txtStockActual.Text = FrmVerProductos.producto.stock.ToString();
                txtStockMinimo.Text = FrmVerProductos.producto.stock_minimo.ToString();
                cmbCategoria.Text = FrmVerProductos.producto.unidad;
                cmbEstatus.Text = FrmVerProductos.producto.status;
                cmbUnidad.Text = FrmVerProductos.producto.unidad;
                cmbCategoria.SelectedValue = FrmVerProductos.producto.fkid_categoria;


            }
        }


        //EVENTO CLICK PARA GUARDAR O MODIFICAR REGISTROS
        private void tnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (FrmVerProductos.producto.id_producto == 0)
                {
                    if (!mp.ValidarCampos(txtNombre, txtDescripcion, txtCosto, txtStockActual, txtStockMinimo))
                    {
                        return;
                    }
                    if (!mp.ValidarNumeros(txtCosto, txtStockActual, txtStockMinimo))
                    {
                        return;
                    }
                    mp.Guardar(new Productos(0, txtNombre.Text, txtDescripcion.Text, cmbUnidad.Text, double.Parse(txtCosto.Text), int.Parse(txtStockActual.Text), int.Parse(txtStockMinimo.Text), cmbEstatus.SelectedValue.ToString(), (int)cmbCategoria.SelectedValue));
                    MessageBox.Show("Datos Guardados Exitosamente");
                    Close();

                }
                else
                {
                    if (!mp.ValidarCampos(txtNombre, txtDescripcion, txtCosto, txtStockActual, txtStockMinimo))
                    {
                        return;
                    }
                    if (!mp.ValidarNumeros(txtCosto, txtStockActual, txtStockMinimo))
                    {
                        return;
                    }
                    mp.Modificar(new Productos(FrmVerProductos.producto.id_producto, txtNombre.Text, txtDescripcion.Text, cmbUnidad.Text, double.Parse(txtCosto.Text), int.Parse(txtStockActual.Text), int.Parse(txtStockMinimo.Text), cmbEstatus.SelectedValue.ToString(), (int)cmbCategoria.SelectedValue));
                    MessageBox.Show("Datos Actualizados Correctamente");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al Guardar los Datos. Hubo un problema: {ex.Message}");
            }

        }


        //EVENTO CLICK PARA CERRAR FORMULARIO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
