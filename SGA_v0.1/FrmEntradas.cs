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
            ConfigurarDataGridView();

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
            ConfigurarDataGridView();

            if (FrmEntradasDatos.detalleEntrada.id_detalleEntrada != 0)
            {
                CargarDatosParaModificar();
            }

            this.FormClosed += FrmEntradas_FormClosed;
        }

        private void ConfigurarDataGridView()
        {
            // Configurar columnas iniciales
            DtgListaR.Columns.Clear();
            DtgListaR.Columns.Add("id_producto", "ID");
            DtgListaR.Columns["id_producto"].Visible = false;

            DtgListaR.Columns.Add("Producto", "Producto");
            DtgListaR.Columns.Add("Descripcion", "Descripción");
            DtgListaR.Columns.Add("Cantidad", "Cantidad");
            DtgListaR.Columns.Add("Costo", "Costo Unitario");
            DtgListaR.Columns.Add("FechaProducto", "Fecha");

            // Agregar columna de botón Eliminar
            if (!DtgListaR.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                DtgListaR.Columns.Add(btnEliminar);
            }

            DtgListaR.ReadOnly = false;
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

                // Ocultar controles innecesarios
                BtnMostrar.Visible = false;
                CbProveedor.Visible = false;
                DtpFecha.Visible = false;
                BtnAgregar.Visible = false;
                BtnConfirmar.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;

                DtgListaR.Rows.Clear();

                DataRow producto = me.ObtenerProductoPorId(detalle.fkid_producto);
                if (producto == null)
                {
                    MessageBox.Show("No se encontró el producto en la base de datos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mostrar información en los TextBox
                TxtProducto.Text = producto["nombre"].ToString();
                TxtCantidad.Text = detalle.cantidad_entrada.ToString();
                TxtCosto.Text = detalle.precio_entrada.ToString("F2");

                // Hacer solo lectura todos excepto cantidad
                TxtProducto.ReadOnly = true;
                TxtCosto.ReadOnly = true;
                // TxtCantidad queda editable

                // Agregar producto al DataGridView en modo solo lectura excepto columna "Cantidad"
                DtgListaR.Rows.Add(
                    detalle.fkid_producto,
                    producto["nombre"].ToString(),
                    producto["descripcion"].ToString(),
                    detalle.cantidad_entrada,
                    detalle.precio_entrada.ToString("F2"),
                    DateTime.Now.ToString("yyyy-MM-dd") // o la fecha que corresponda
                );

                // Bloquear edición de todas las columnas excepto "Cantidad"
                foreach (DataGridViewColumn col in DtgListaR.Columns)
                {
                    if (col.Name != "Cantidad")
                        col.ReadOnly = true;
                }

                // Opcional: ocultar botón eliminar
                if (DtgListaR.Columns.Contains("Eliminar"))
                    DtgListaR.Columns["Eliminar"].Visible = false;

                DtgListaR.AutoResizeColumns();

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

            int cantidad = int.Parse(TxtCantidad.Text);
            double costo = double.Parse(TxtCosto.Text);
            DateTime fechaProducto = DtpFecha.Value;

            // Agregar a lista temporal
            DetalleEntradas detalle = new DetalleEntradas(0, costo, cantidad, idProductoSeleccionado, 0);
            listaTemporal.Add(detalle);

            // Agregar fila al DataGridView
            DtgListaR.Rows.Add(
                idProductoSeleccionado,
                TxtProducto.Text,
                me.ObtenerDescripcionProducto(idProductoSeleccionado),
                cantidad,
                costo,
                fechaProducto.ToString("yyyy-MM-dd")
            );

            // Guardar ID en el textbox invisible
            if (string.IsNullOrEmpty(TxtIdsProductosSeleccionados.Text))
                TxtIdsProductosSeleccionados.Text = idProductoSeleccionado.ToString();
            else
                TxtIdsProductosSeleccionados.Text += "," + idProductoSeleccionado.ToString();

            LimpiarCampos();
        }

        private void DtgListaR_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtgListaR.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                int idProductoEliminado = Convert.ToInt32(DtgListaR.Rows[e.RowIndex].Cells["id_producto"].Value);

                // Eliminar del DataGridView
                DtgListaR.Rows.RemoveAt(e.RowIndex);

                // Eliminar de lista temporal
                var item = listaTemporal.FirstOrDefault(x => x.fkid_producto == idProductoEliminado);
                if (item != null) listaTemporal.Remove(item);

                // Actualizar IDs en el textbox oculto
                if (!string.IsNullOrWhiteSpace(TxtIdsProductosSeleccionados.Text))
                {
                    var ids = TxtIdsProductosSeleccionados.Text.Split(',')
                        .Where(x => !string.IsNullOrWhiteSpace(x))
                        .ToList();
                    ids.Remove(idProductoEliminado.ToString());
                    TxtIdsProductosSeleccionados.Text = string.Join(",", ids);
                }
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
                var fila = DtgListaR.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => Convert.ToInt32(r.Cells["id_producto"].Value) == detalle.fkid_producto);

                DateTime fechaProducto = DateTime.Now;
                if (fila != null)
                    fechaProducto = DateTime.Parse(fila.Cells["FechaProducto"].Value.ToString());

                Entradas entrada = new Entradas(0, fechaProducto.ToString("yyyy-MM-dd"), idUsuario, idProveedorSeleccionado);
                int idEntrada = me.GuardarEntrada(entrada);
                detalle.fkid_entrada = idEntrada;
            }

            MessageBox.Show("Se crearon entradas individuales con sus fechas.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
           

            try
            {
                // Lista de IDs procesados para actualizar stock solo una vez por producto
                List<int> idsProcesados = new List<int>();
                if (!string.IsNullOrWhiteSpace(TxtIdsProductosSeleccionados.Text))
                {
                    idsProcesados = TxtIdsProductosSeleccionados.Text
                        .Split(',')
                        .Where(id => !string.IsNullOrWhiteSpace(id))
                        .Select(id => int.Parse(id.Trim()))
                        .ToList();
                }

                foreach (DataGridViewRow fila in DtgListaR.Rows)
                {
                    if (fila.IsNewRow) continue;

                    int idProducto = Convert.ToInt32(fila.Cells["id_producto"].Value);
                    int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    double precio = Convert.ToDouble(fila.Cells["Costo"].Value);
                    DateTime fechaProducto = DateTime.Parse(fila.Cells["FechaProducto"].Value.ToString());

                    // --- MODO EDICIÓN ---
                    // Si existe detalle seleccionado para edición
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

                    // --- MODO AGREGAR NUEVO ---
                    Entradas entrada = new Entradas(
                        0,
                        fechaProducto.ToString("yyyy-MM-dd"),
                        idUsuario,
                        idProveedorSeleccionado
                    );

                    int idEntrada = me.GuardarEntrada(entrada);
                    if (idEntrada == 0)
                    {
                        MessageBox.Show($"No se pudo guardar la entrada para el producto {idProducto}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    DetalleEntradas detalle = new DetalleEntradas(
                        mde.ObtenerSiguienteIdDetalle(idProducto),
                        precio,
                        cantidad,
                        idProducto,
                        idEntrada
                    );

                    mde.GuardarDetalle(new List<DetalleEntradas> { detalle });

                    // Actualizamos stock solo si no se procesó antes
                    if (!idsProcesados.Contains(idProducto))
                    {
                        me.ActualizarStockProductoSP(idProducto, cantidad);
                        idsProcesados.Add(idProducto);
                    }
                }

                // Limpiamos listas y controles
                listaTemporal.Clear();
                DtgListaR.Rows.Clear();
                TxtIdsProductosSeleccionados.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar detalles: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimpiarCampos()
        {
            TxtProducto.Clear();
            TxtCantidad.Clear();
            TxtCosto.Clear();
            idProductoSeleccionado = 0;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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
