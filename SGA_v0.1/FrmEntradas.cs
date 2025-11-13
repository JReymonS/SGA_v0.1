using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Entidades;
using Manejadores;

namespace SGA_v0._1
{
    public partial class FrmEntradas : Form
    {
        ManejadorEntradas me = new ManejadorEntradas();
        ManejadorDetalleEntradas mde = new ManejadorDetalleEntradas();

        List<DetalleEntradas> listaTemporal = new List<DetalleEntradas>();
        int idProductoSeleccionado = 0;
        int idProveedorSeleccionado = 0;
        int idUsuario = 1;
        private int idProductoActual = 0;

        // 🔹 Constructor normal (para agregar nuevas entradas)
        public FrmEntradas()
        {
            InitializeComponent();
            CargarProveedores();

            if (FrmEntradasDatos.detalleEntrada.id_detalleEntrada != 0)
            {
                CargarDatosParaModificar();
            }

            this.FormClosed += FrmEntradas_FormClosed;
        }

        // 🔹 Constructor alternativo (para editar un producto específico)
        public FrmEntradas(int idProducto)
        {
            InitializeComponent();
            CargarProveedores();
            idProductoActual = idProducto;

            if (FrmEntradasDatos.detalleEntrada.id_detalleEntrada != 0)
            {
                CargarDatosParaModificar();
            }

            this.FormClosed += FrmEntradas_FormClosed;
        }

        private void CargarDatosParaModificar()
        {
            try
            {
                var detalle = FrmEntradasDatos.detalleEntrada;

                if (detalle.id_detalleEntrada == 0)
                {
                    MessageBox.Show("No hay un detalle válido para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BtnMostrar.Visible = false;
                CbProveedor.Visible = false;
                DtpFecha.Visible = false;
                BtnAgregar.Visible = false;
                BtnConfirmar.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                DtgListaR.Visible = true;
                DtgListaR.Columns.Clear();
                DtgListaR.Rows.Clear();

                DtgListaR.Columns.Add("Producto", "Producto");
                DtgListaR.Columns.Add("Descripcion", "Descripción");
                DtgListaR.Columns.Add("Cantidad", "Cantidad");
                DtgListaR.Columns.Add("CostoUnitario", "Costo Unitario");

                DataRow producto = me.ObtenerProductoPorId(detalle.fkid_producto);

                if (producto == null)
                {
                    MessageBox.Show("No se encontró el producto en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                TxtProducto.Text = producto["nombre"].ToString();
                TxtCantidad.Text = detalle.cantidad_entrada.ToString();
                TxtCosto.Text = detalle.precio_entrada.ToString("F2");

                DtgListaR.Rows.Add(
                    producto["nombre"].ToString(),
                    producto["descripcion"].ToString(),
                    detalle.cantidad_entrada,
                    detalle.precio_entrada.ToString("F2")
                );

                DtgListaR.AutoResizeColumns();
                DtgListaR.ReadOnly = true;

                idProductoActual = detalle.fkid_producto; // ✅ Guarda el producto actual
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos para modificar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProveedores()
        {
            DataTable dt = me.ObtenerProveedores();
            if (dt != null)
            {
                CbProveedor.DisplayMember = "nombre";
                CbProveedor.ValueMember = "id_proveedor";
                CbProveedor.DataSource = dt;
            }
        }

        private void BtnMostrar_Click(object sender, EventArgs e)
        {
            idProveedorSeleccionado = Convert.ToInt32(CbProveedor.SelectedValue);
            me.MostrarProductos(DtpFecha.Value, idProveedorSeleccionado, DtgLista);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtCantidad.Text))
            {
                MessageBox.Show("Debes ingresar una cantidad.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int siguienteIdDetalle = mde.ObtenerSiguienteIdDetalle(idProductoSeleccionado);

            DetalleEntradas d = new DetalleEntradas(
                siguienteIdDetalle,
                double.Parse(TxtCosto.Text),
                int.Parse(TxtCantidad.Text),
                idProductoSeleccionado,
                0
            );

            listaTemporal.Add(d);
            ActualizarListaTemporal();
            LimpiarCampos();
        }

        private void ActualizarListaTemporal()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Cantidad", typeof(int));
            dt.Columns.Add("Costo", typeof(double));

            foreach (var item in listaTemporal)
            {
                string nombreProducto = me.ObtenerNombreProducto(item.fkid_producto);
                string descripcionProducto = me.ObtenerDescripcionProducto(item.fkid_producto);

                dt.Rows.Add(nombreProducto, descripcionProducto, item.cantidad_entrada, item.precio_entrada);
            }

            DtgListaR.DataSource = dt;

            if (!DtgListaR.Columns.Contains("Eliminar"))
                DtgListaR.Columns.Add(ManejadorEntradas.Boton("Eliminar", Color.Red));

            DtgListaR.AutoResizeColumns();
            DtgListaR.AutoResizeRows();
        }

        private void DtgListaR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtgListaR.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                listaTemporal.RemoveAt(e.RowIndex);
                ActualizarListaTemporal();
            }
        }

        private void LimpiarCampos()
        {
            TxtProducto.Clear();
            TxtCosto.Clear();
            TxtCantidad.Clear();
            idProductoSeleccionado = 0;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DtgLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtgLista.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                idProductoSeleccionado = Convert.ToInt32(DtgLista.Rows[e.RowIndex].Cells["id_producto"].Value);
                TxtProducto.Text = DtgLista.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
                TxtCosto.Text = DtgLista.Rows[e.RowIndex].Cells["precio_entrada"].Value.ToString();
                TxtCantidad.Clear();
                TxtCantidad.Focus();
            }
        }

        private void BtnConfirmar_Click(object sender, EventArgs e)
        {
            if (listaTemporal.Count == 0)
            {
                MessageBox.Show("No hay productos para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var detalle in listaTemporal)
            {
                Entradas entrada = new Entradas(
                    0,
                    DtpFecha.Value.ToString("yyyy-MM-dd"),
                    idUsuario,
                    idProveedorSeleccionado
                );

                int idEntrada = me.GuardarEntrada(entrada);

                if (idEntrada > 0)
                {
                    detalle.fkid_entrada = idEntrada;
                }
                else
                {
                    MessageBox.Show($"No se pudo guardar la entrada para el producto {detalle.fkid_producto}.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Se crearon entradas independientes para cada producto.\nLos detalles se guardarán al presionar 'Guardar'.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmEntradasDatos.detalleEntrada.id_detalleEntrada != 0)
            {
                int nuevaCantidad;
                if (int.TryParse(TxtCantidad.Text, out nuevaCantidad))
                {
                    int cantidadAnterior = FrmEntradasDatos.detalleEntrada.cantidad_entrada;

                    mde.ActualizarCantidadDetalle(FrmEntradasDatos.detalleEntrada.id_detalleEntrada, nuevaCantidad);

                    // ✅ Ahora usa el ID del producto actual (no compartido)
                    me.ActualizarStockProducto(idProductoActual, cantidadAnterior, nuevaCantidad);

                    MessageBox.Show("Cantidad y stock actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Cantidad no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                if (listaTemporal.Count == 0)
                {
                    MessageBox.Show("No hay productos agregados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    mde.GuardarDetalle(listaTemporal);

                    foreach (var detalle in listaTemporal)
                    {
                        me.SumarStockProducto(detalle.fkid_producto, detalle.cantidad_entrada);
                    }

                    MessageBox.Show("Detalles de entrada guardados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listaTemporal.Clear();
                    DtgListaR.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmEntradas_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmEntradasDatos.detalleEntrada = new DetalleEntradas(0, 0.0, 0, 0, 0);
        }

        private void DtgListaR_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
