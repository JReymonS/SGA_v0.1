using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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

                idProductoActual = detalle.fkid_producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dt.Columns.Add("id_producto", typeof(int)); // Columna oculta para ID

            foreach (var item in listaTemporal)
            {
                string nombreProducto = me.ObtenerNombreProducto(item.fkid_producto);
                string descripcionProducto = me.ObtenerDescripcionProducto(item.fkid_producto);

                dt.Rows.Add(nombreProducto, descripcionProducto, item.cantidad_entrada, item.precio_entrada, item.fkid_producto);
            }

            DtgListaR.DataSource = dt;

            if (!DtgListaR.Columns.Contains("Eliminar"))
                DtgListaR.Columns.Add(ManejadorEntradas.Boton("Eliminar", Color.Red));

            DtgListaR.Columns["id_producto"].Visible = false; // Oculta columna ID
            DtgListaR.AutoResizeColumns();
            DtgListaR.AutoResizeRows();
        }

        private void DtgListaR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtgListaR.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                // 1️⃣ Obtener el id del producto eliminado
                if (e.RowIndex < listaTemporal.Count)
                {
                    int idProductoEliminado = listaTemporal[e.RowIndex].fkid_producto;

                    // 2️⃣ Remover el producto de la lista temporal
                    listaTemporal.RemoveAt(e.RowIndex);
                    ActualizarListaTemporal();

                    // 3️⃣ Actualizar el TxtIdsProductosSeleccionados
                    if (!string.IsNullOrWhiteSpace(TxtIdsProductosSeleccionados.Text))
                    {
                        var ids = TxtIdsProductosSeleccionados.Text.Split(',')
                            .Where(id => !string.IsNullOrWhiteSpace(id))
                            .Select(id => id.Trim())
                            .ToList();

                        ids.Remove(idProductoEliminado.ToString());

                        TxtIdsProductosSeleccionados.Text = string.Join(",", ids);
                    }
                }
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

                // Agregar al TextBox sin eliminar duplicados
                if (string.IsNullOrWhiteSpace(TxtIdsProductosSeleccionados.Text))
                    TxtIdsProductosSeleccionados.Text = idProductoSeleccionado.ToString();
                else
                    TxtIdsProductosSeleccionados.Text += "," + idProductoSeleccionado;
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
                    MessageBox.Show($"No se pudo guardar la entrada para el producto {detalle.fkid_producto}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            MessageBox.Show("Se crearon entradas independientes para cada producto.\nLos detalles se guardarán al presionar 'Guardar'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Si estamos editando un detalle existente, mantenemos tu lógica actual
            if (FrmEntradasDatos.detalleEntrada.id_detalleEntrada != 0)
            {
                if (int.TryParse(TxtCantidad.Text, out int nuevaCantidad))
                {
                    int cantidadAnterior = FrmEntradasDatos.detalleEntrada.cantidad_entrada;

                    try
                    {
                        // Actualizar cantidad del detalle
                        mde.ActualizarCantidadDetalle(FrmEntradasDatos.detalleEntrada.id_detalleEntrada, nuevaCantidad);

                        // Actualizar stock del producto con la diferencia
                        me.ActualizarStockProducto(idProductoActual, cantidadAnterior, nuevaCantidad);

                        MessageBox.Show("Cantidad y stock actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar detalle o stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cantidad no válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return; // Salimos porque ya se procesó la edición
            }

            // Si estamos agregando nuevos detalles
            if (DtgListaR.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos agregados.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1️⃣ Crear la entrada principal solo una vez
                Entradas entrada = new Entradas(
                    0,
                    DtpFecha.Value.ToString("yyyy-MM-dd"),
                    idUsuario,
                    idProveedorSeleccionado
                );

                int idEntrada = me.GuardarEntrada(entrada);
                if (idEntrada == 0)
                {
                    MessageBox.Show("No se pudo guardar la entrada principal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // 2️⃣ Recorrer cada fila del DataGridView y guardar detalle + actualizar stock
                foreach (DataGridViewRow fila in DtgListaR.Rows)
                {
                    if (fila.IsNewRow) continue;

                    // Obtener datos de cada fila
                    int idProducto = Convert.ToInt32(fila.Cells["id_producto"].Value);
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    double precio = Convert.ToDouble(fila.Cells["Costo"].Value);

                    // Crear detalle
                    DetalleEntradas detalle = new DetalleEntradas(
                        mde.ObtenerSiguienteIdDetalle(idProducto),
                        precio,
                        cantidad,
                        idProducto,
                        idEntrada
                    );

                    // Guardar detalle
                    mde.GuardarDetalle(new List<DetalleEntradas> { detalle });

                    // Actualizar stock individualmente
                    me.ActualizarStockProductoSP(idProducto, cantidad);
                }

                MessageBox.Show("Todos los detalles se guardaron correctamente y el stock se actualizó.",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar lista temporal y DataGridView
                listaTemporal.Clear();
                DtgListaR.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
