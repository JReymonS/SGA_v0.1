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
    public partial class FrmAgregarSalidaProductos : Form
    {
        // CREACION DE OBJETOS Y VARIABLES
        public static Productos producto = new Productos(0, "", "", "", 0.0, 0, 0, "", 0);
        public static Salidas salida = new Salidas(0, "", 0);
        private int idSalida = 0;
        private int idDetalleSalida = 0; 
        private bool esModificacion = false; 

        ManejadorSalidas ms;
        ManejadorDetallesSalidas mds;

        int fila1 = 0, fila2 = 0;
        int columna1 = 0, columna2 = 0;


        //CONSTRUCTOR PARA INICIALIZAR EL FORMULARIO CON DATOS SEGUN SEA EL CASO (MODIFICAR / NUEVO REGISTRO)
        public FrmAgregarSalidaProductos()
        {
            

            InitializeComponent();
            ms = new ManejadorSalidas();
            mds = new ManejadorDetallesSalidas();
            mds.MostrarProductos("SELECT * FROM v_Productos", dtgMostrarProductos, "v_Productos");
           

            // SI ES MODIFICACION, CARGAR DATOS EXISTENTES OBTENIDOS DEL DTG DEL FORMULARIO FRMVERPRODUCTOS
            if (FrmVerSalidaProductos.salida.id_salida > 0)
            {
                esModificacion = true;
                idSalida = FrmVerSalidaProductos.salida.id_salida;
                idDetalleSalida = FrmVerSalidaProductos.detalleSalida.id_detalleSalida;

                dtpFecha.Text = FrmVerSalidaProductos.salida.fecha_salida;
                txtProducto.Text = FrmVerSalidaProductos.producto.nombre;
                txtCantidad.Text = FrmVerSalidaProductos.detalleSalida.cantidad_salida.ToString();

                producto.id_producto = FrmVerSalidaProductos.producto.id_producto;
                producto.nombre = FrmVerSalidaProductos.producto.nombre;
                producto.descripcion = FrmVerSalidaProductos.producto.descripcion;
                producto.precio_salida = FrmVerSalidaProductos.producto.precio_salida;
                dtgMostrarProductos.Enabled = false;
                dtgListaProductos.Enabled = false;
                txtProducto.Enabled = false;
                dtpFecha.Enabled = false;

                
                mds.AgregarProductoTemporal(
                    producto.id_producto.ToString(),
                    producto.nombre,
                    producto.descripcion,
                    FrmVerSalidaProductos.detalleSalida.cantidad_salida.ToString(),
                    producto.precio_salida.ToString()
                );
                mds.MostrarProductosTemporales(dtgListaProductos);
            }

        }


        //EVENTO CELL ENTER QUE OBTIENE LA CELDA ACTUAL
        private void dtgMostrarProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila1 = e.RowIndex;
            columna1 = e.ColumnIndex;

        }


        //EVENTO CELL CLICK QUE PERMITE IDENTIFICAR LAS COLUMNAS PARA AGREGAR EL NOMBRE AL TEXTBOX
        private void dtgMostrarProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                producto.id_producto = int.Parse(dtgMostrarProductos.Rows[e.RowIndex].Cells["id_producto"].Value.ToString());
                producto.nombre = dtgMostrarProductos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                producto.descripcion = dtgMostrarProductos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
                producto.stock = int.Parse(dtgMostrarProductos.Rows[e.RowIndex].Cells["Stock Actual"].Value.ToString());
                producto.precio_salida = double.Parse(dtgMostrarProductos.Rows[e.RowIndex].Cells["Costo Salida"].Value.ToString());

                switch (columna1)
                {
                    case 0:
                        {
                            txtProducto.Text = producto.nombre;
                            txtCantidad.Focus();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar el producto:\n\n{ex.Message}\n\nAsegúrese de hacer clic en el botón 'Seleccionar' un producto válido.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        //PERMITE AGREGAR PRODUCTOS A LA TABLA TEMPORAL
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            int stockActual = mds.ObtenerStockActual(producto.id_producto);
            if (producto.id_producto == 0 || string.IsNullOrEmpty(producto.nombre) || txtProducto.Text == null)
            {
                MessageBox.Show("Por favor seleccione un producto del primero.\nDebe hacer clic en el botón 'Seleccionar' del producto deseado.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número mayor a cero.",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                txtCantidad.Clear();
                return;
            }

            // VALIDACIÓN DE STOCK
            if (cantidad > stockActual)
            {
                MessageBox.Show($"La cantidad solicitada ({cantidad}) supera el stock disponible ({producto.stock}).",
                    "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                txtCantidad.Clear();
                return;
            }
            try
            {
                
                mds.AgregarProductoTemporal(
                    producto.id_producto.ToString(),
                    producto.nombre,
                    producto.descripcion,
                    txtCantidad.Text,
                    producto.precio_salida.ToString()
                );

                mds.MostrarProductosTemporales(dtgListaProductos);

                txtProducto.Clear();
                txtCantidad.Clear();
                txtCantidad.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el producto:\n\n{ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //EVENTO CLICK DE BOTON PARA CREAR EL REGISTRO DE LA SALIDA Y TRABAJAR SOBRE LA ID PARA LOS DETALLES SALIDAS
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (FrmUsuarioSesion.Usuario == null)
            {
                MessageBox.Show("No hay un usuario activo en sesión. Por favor inicie sesión antes de registrar una salida.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (esModificacion)
            {
                MessageBox.Show("Salida existente.",
                    "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fecha = dtpFecha.Value.ToString("yyyy-MM-dd");
            idSalida = ms.GuardarSalidaObtenerId(new Salidas(0, fecha, FrmUsuarioSesion.Usuario.id_usuario));

            MessageBox.Show("Salida confirmada. Ahora presione 'Guardar'",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //EVENTO CLICK QUE REALIZA EL REGISTRO DE LOS DETALLESSALIDAS DE CADA PRODUCTO A REGISTRAR
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (idSalida == 0)
            {
                MessageBox.Show("Primero debe confirmar la salida antes de guardar los detalles",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (esModificacion)
                {
                    mds.ModificarDetalleSalida(idDetalleSalida, idSalida);
                    MessageBox.Show("La Salida se ha modificado correctamente",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.Clear();
                    txtProducto.Clear();
                    dtgListaProductos.Columns.Clear();
                    dtgMostrarProductos.Columns.Clear();
                }
                else
                {
                    
                    mds.GuardarDetalleSalidas(idSalida);
                    MessageBox.Show("Salida registrada Correctamente. \nEl stock ha sido actualizado.",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCantidad.Clear();
                    txtProducto.Clear();
                    dtgListaProductos.Columns.Clear();
                    dtgMostrarProductos.Columns.Clear();
                }

                
                mds.LimpiarProductosTemporales();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //EVENTO CLICK QUE ELIMINA EL REGISTRO DE LA TABLA SALIDAS PARA REVERTIR LOS CAMBIOS AL NO TERMINAR EL REGISTRO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (idSalida > 0 && !esModificacion)
            {
                DialogResult resultado = MessageBox.Show(
                    "¿Esta seguro que desea cancelar?",
                    "Confirmar cancelacion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        ms.EliminarSalida(idSalida);
                        mds.LimpiarProductosTemporales();
                        MessageBox.Show("Salida cancelada correctamente",
                            "Cancelado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al cancelar: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                mds.LimpiarProductosTemporales();
                this.Close();
            }
        }


        //EVENTO CELL CLICK QUE PERMITE ELIMINAR PRODUCTOS DE LA TABLA TEMPORAL
        private void dtgListaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            switch (columna2)
            {
                case 0: 
                    {
                        try
                        {
                            
                            string idProducto = dtgListaProductos.Rows[e.RowIndex].Cells["id_producto"].Value.ToString();

                            mds.EliminarProductoTemporal(idProducto);
                            mds.MostrarProductosTemporales(dtgListaProductos);
                            MessageBox.Show("Producto eliminado de la lista",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al eliminar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    break;
            }
        }


        //EVENTO CELL ENTER PARA OBTENER CELDAD EN EL CONTENEDOR DE PRODUCTOS SELECCIONADOS
        private void dtgListaProductos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila2 = e.RowIndex;
            columna2 = e.ColumnIndex;
        }
    }
}