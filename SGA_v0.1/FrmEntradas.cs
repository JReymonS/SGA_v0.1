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
        ManejadorDiseño md;

        List<DetalleEntradas> listaTemporal = new List<DetalleEntradas>();
        int idProductoSeleccionado = 0;
        int idProveedorSeleccionado = 0;
        int idUsuario = FrmInicio._usuarioActivo.id_usuario;
        private int idProductoActual = 0;

      


        //CONSTRUCTOR SIN PARAMETROS
        public FrmEntradas()
        {
            InitializeComponent();
            CargarProveedores();
            ConfigurarDataGridView();
            md = new ManejadorDiseño();
            md.EstiloPanelTexto(pRegistro, lblNombre, ColorTranslator.FromHtml("#8CBFAF"));
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            md.AgregarBordeFormulario(this);
            md.EstilizarComboBox(CbProveedor);
            md.EstilizarTextBox(TxtCantidad);
            md.EstilizarTextBox(TxtCosto);
            md.EstilizarTextBox(TxtProducto);
            md.EstilizarDTP(DtpFecha);
            md.EstilosBoton(BtnAgregar);
            md.EstilosBoton(BtnCancelar);
            md.EstilosBoton(BtnConfirmar);
            md.EstilosBoton(BtnGuardar);
            md.EstilosBoton(BtnMostrar);
            

            if (FrmEntradasDatos.detalleEntrada.id_detalleEntrada != 0)
            {
                CargarDatosParaModificar();
            }

            this.FormClosed += FrmEntradas_FormClosed;
        }


        //CONSTRUCTOR CON PARAMETROS
        public FrmEntradas(int idProducto)
        {
            InitializeComponent();
            md = new ManejadorDiseño();
            md.EstiloPanelTexto(pRegistro, lblNombre, ColorTranslator.FromHtml("#8CBFAF"));
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            md.AgregarBordeFormulario(this);
            md.EstilizarTextBox(TxtCantidad);
            md.EstilizarTextBox(TxtCosto);
            md.EstilizarTextBox(TxtProducto);
            md.EstilosBoton(BtnAgregar);
            md.EstilosBoton(BtnCancelar);
            md.EstilosBoton(BtnConfirmar);
            md.EstilosBoton(BtnGuardar);
            CargarProveedores();
            idProductoActual = idProducto;
            ConfigurarDataGridView();

            if (FrmEntradasDatos.detalleEntrada.id_detalleEntrada != 0)
            {
                CargarDatosParaModificar();
            }

            this.FormClosed += FrmEntradas_FormClosed;
        }


        //METODO PARA CONFIGURAR EL DATAGRIDVIEW
        private void ConfigurarDataGridView()
        {

            var color = ColorTranslator.FromHtml("#545454");
            var color2 = ColorTranslator.FromHtml("#EDE7D5");
            // Configurar columnas iniciales
            DtgListaR.Columns.Clear();
            DtgListaR.Columns.Add("id_producto", "ID");
            DtgListaR.Columns["id_producto"].Visible = false;

            DtgListaR.Columns.Add("Producto", "Producto");
            DtgListaR.Columns.Add("Descripcion", "Descripción");
            DtgListaR.Columns.Add("Cantidad", "Cantidad");
            DtgListaR.Columns.Add("Costo", "Costo Unitario");
            DtgListaR.Columns.Add("FechaProducto", "Fecha de Registro");

            // Agregar columna de botón Eliminar
            if (!DtgListaR.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.FlatStyle = FlatStyle.Popup;
                btnEliminar.DefaultCellStyle.BackColor = color;
                btnEliminar.DefaultCellStyle.ForeColor = color2;
                DtgListaR.Columns.Add(btnEliminar);
              
            }

            DtgListaR.ReadOnly = false;
            
        }


        //METODO PARA CARGAR DATOS DE ENTRADAS A MODIFICAR
        private void CargarDatosParaModificar()
        {
            try
            {

                me.MostrarProductos(DtpFecha.Value, idProveedorSeleccionado, DtgLista);

                var detalle = FrmEntradasDatos.detalleEntrada;

                if (detalle.id_detalleEntrada == 0)
                {
                    MessageBox.Show("No hay un detalle válido para modificar.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show("No se encontró el producto en la base de datos.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mostrar información en los TextBox
                TxtProducto.Text = producto["nombre"].ToString();
                TxtCantidad.Text = detalle.cantidad_entrada.ToString();
                TxtCosto.Text = detalle.precio_entrada.ToString("F2");

                // Hacer solo lectura todos excepto cantidad
                TxtProducto.ReadOnly = true;
               
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

                if (DtgLista.Columns.Contains("Seleccionar"))
                    DtgLista.Columns["Seleccionar"].Visible = false;

                
                DtgListaR.AutoResizeColumns();
                md.EstilizarData(DtgListaR);

                idProductoActual = detalle.fkid_producto;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos para modificar: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //METODO PARA CARGAR LOS PROVEERODRES
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


        //EVENTO CLICK PARA MOSTRAR LOS PRODUCTOS
        private void BtnMostrar_Click(object sender, EventArgs e)
        {

            idProveedorSeleccionado = Convert.ToInt32(CbProveedor.SelectedValue);
            me.MostrarProductos(DtpFecha.Value, idProveedorSeleccionado, DtgLista);
            md.EstilizarData(DtgLista);
            md.EstilizarData(DtgListaR);
        }


        //EVENTO CLICK PARA SELECCIONAR DATOS DE UN REGISTRO Y SU RECUPERACIÓN
        private void DtgLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DtgLista.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                idProductoSeleccionado = Convert.ToInt32(DtgLista.Rows[e.RowIndex].Cells["id_producto"].Value);
                TxtProducto.Text = DtgLista.Rows[e.RowIndex].Cells["Producto"].Value.ToString();
                TxtCantidad.Clear();
                TxtCantidad.Focus();
            }
        }


        //EVENTO CLICK PARA AGREGAR UN PRODUCTO EXISTENTE Y REGISTRAR SU ENTRADA
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (idProductoSeleccionado == 0)
            {
                MessageBox.Show("Selecciona un producto primero.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(TxtCantidad.Text))
            {
                MessageBox.Show("Debes ingresar una cantidad.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int cantidad;
            double costo;
            DateTime fechaProducto = DtpFecha.Value;

            if (!int.TryParse(TxtCantidad.Text,out cantidad)||cantidad<=0) 
            {
                MessageBox.Show("La cantidad a ingresar, deberá ser un número entero no negativo.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!double.TryParse(TxtCosto.Text,out costo) || costo < 0) 
            {
                MessageBox.Show("El costo debe ser un número válido y no negativo.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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


        //EVENTO CLICK PARA ELIMINAR UN REGISTRO EN LA LISTA DE DETALLES
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


        //EVENTO CLICK PARA CONFIRMAR LA LISTA DE DETALLES
        private void BtnConfirmar_Click(object sender, EventArgs e)
        {

            if (listaTemporal.Count == 0)
            {
                MessageBox.Show("No hay productos para guardar.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            MessageBox.Show("Se crearon entradas de productos individuales.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //EVENTO CLICK PARA GUARDAR REGISTRO EN TABLAS ENTRADAS Y DETALLEENTRADAS
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
                        if (int.TryParse(TxtCantidad.Text, out int nuevaCantidad) && nuevaCantidad>0 &&
                           double.TryParse(TxtCosto.Text, out double nuevoCosto) && nuevoCosto>0)
                        {
                            int cantidadAnterior = FrmEntradasDatos.detalleEntrada.cantidad_entrada;

                            try
                            {
                                // Actualizar cantidad y costo del detalle
                                mde.ActualizarCantidadDetalle(FrmEntradasDatos.detalleEntrada.id_detalleEntrada, nuevaCantidad);
                                mde.ActualizarCostoDetalle(FrmEntradasDatos.detalleEntrada.id_detalleEntrada, nuevoCosto);

                                // Actualizar stock del producto con la diferencia
                                me.ActualizarStockProducto(idProductoActual, cantidadAnterior, nuevaCantidad);

                                MessageBox.Show("Cantidad, costo y stock actualizados correctamente.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al actualizar detalle, costo o stock: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Cantidad o costo no válidos.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        return;
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
                        MessageBox.Show($"No se pudo guardar la entrada para el producto {idProducto}.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    this.Close();
                    // Actualizamos stock solo si no se procesó antes
                    if (!idsProcesados.Contains(idProducto))
                    {
                        me.ActualizarStockProductoSP(idProducto, cantidad);
                        idsProcesados.Add(idProducto);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar detalles: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //METODO PARA LIMPIAR CAMPOS
        private void LimpiarCampos()
        {
            TxtProducto.Clear();
            TxtCantidad.Clear();
            TxtCosto.Clear();
            idProductoSeleccionado = 0;
        }

        //EVENTO CLICK PARA CANCELAR EL REGISTRO
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmEntradas_Load(object sender, EventArgs e)
        {
            md.EstilizarData(DtgLista);
            md.EstilizarData(DtgListaR);
        }


        //EVENTO CERRADO DE FORMULARIO PARA LIMPIAR LISTA DE DETALLES
        private void FrmEntradas_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmEntradasDatos.detalleEntrada = new DetalleEntradas(0, 0.0, 0, 0, 0);
        }


        //EVENTO PARA DISEÑO DE FOMULARIO
        private void BtnMostrar_MouseLeave(object sender, EventArgs e)
        {
            BtnMostrar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(BtnMostrar);
        }

        private void BtnMostrar_MouseEnter(object sender, EventArgs e)
        {
            BtnMostrar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void BtnAgregar_MouseEnter(object sender, EventArgs e)
        {
            BtnAgregar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void BtnAgregar_MouseLeave(object sender, EventArgs e)
        {
            BtnAgregar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(BtnAgregar);
        }

        private void BtnConfirmar_MouseEnter(object sender, EventArgs e)
        {
            BtnConfirmar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void BtnConfirmar_MouseLeave(object sender, EventArgs e)
        {
            BtnConfirmar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(BtnConfirmar);
        }

        private void BtnGuardar_MouseEnter(object sender, EventArgs e)
        {
            BtnGuardar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void BtnGuardar_MouseLeave(object sender, EventArgs e)
        {
            BtnGuardar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(BtnGuardar);
        }

        private void BtnCancelar_MouseEnter(object sender, EventArgs e)
        {
            BtnCancelar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void BtnCancelar_MouseLeave(object sender, EventArgs e)
        {
            BtnCancelar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(BtnCancelar);
        }
        // FIN DE EVENTOS PARA DISEÑO DE FORMULARIO
    }
}
