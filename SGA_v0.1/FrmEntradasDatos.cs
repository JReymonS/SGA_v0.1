using Entidades;
using Manejadores;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmEntradasDatos : Form
    {
        private ManejadorEntradas manejador;
        public static DetalleEntradas detalleEntrada = new DetalleEntradas(0, 0.0, 0, 0, 0);
        private int fila = 0, columna = 0;

        bool permisoModificar = false, permisoCrear = false;
        public FrmEntradasDatos()
        {
            InitializeComponent();
            manejador = new ManejadorEntradas();
        }


        //EVENTO CLICK PARA BUSCAR DETALLES DE ENTRADAS
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            MostrarDetalles();
        }


        //METODO PARA AGREGAR UNA NUEVA ENTRADA
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmEntradas frm = new FrmEntradas();

            frm.FormClosed += (s, args) =>
            {
                LimpiarTabla();
            };

            frm.ShowDialog();
        }


        //EVENTO CELL ENTER PARA OBTENER COLUMNAS
        private void DtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }


        //METODO PARA MOSTRAR LOS DETALLES DE ENTRADAS
        private void MostrarDetalles()
        {
            DateTime fechaSeleccionada = DtpEntradas.Value.Date;
            DataTable datos = manejador.BuscarDetalleEntradasPorFecha(fechaSeleccionada);

            if (datos != null && datos.Rows.Count > 0)
            {
                DtgDatos.Columns.Clear();
                DtgDatos.DataSource = datos;

                if (permisoModificar)
                {
                    DtgDatos.Columns.Insert(DtgDatos.Columns.Count,
                        ManejadorEntradas.Boton("Modificar", Color.Green));
                }

                DtgDatos.AutoResizeColumns();
                DtgDatos.AutoResizeRows();
            }
            else
            {
                DtgDatos.DataSource = null;
                MessageBox.Show("No se encontraron detalles de entrada para la fecha seleccionada.",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Ocultar columnas que no quieres mostrar
            if (DtgDatos.Columns.Contains("ID Detalle"))
                DtgDatos.Columns["ID Detalle"].Visible = false;

            if (DtgDatos.Columns.Contains("ID Producto"))
                DtgDatos.Columns["ID Producto"].Visible = false;

            // Opcional: también puedes ocultar ID Entrada si no quieres que se vea
            if (DtgDatos.Columns.Contains("ID Entrada"))
                DtgDatos.Columns["ID Entrada"].Visible = false;

        }


        //METODO PARA LIMPIAR CONTENEDOR DE DETALLES ENTRADAS
        public void LimpiarTabla()
        {
            DtgDatos.DataSource = null;
            DtgDatos.Rows.Clear();
            DtgDatos.Columns.Clear();
            DtgDatos.Refresh();
        }

        private void FrmEntradasDatos_Load(object sender, EventArgs e)
        {
            BtnAgregar.Enabled = false;
            foreach (var permiso in FrmInicio._rolPermisosActivo.permisos)
            {
                if (permiso.fkid_modulo == 5)
                {
                    BtnAgregar.Enabled = permiso.permiso_crear == "1";
                    permisoModificar = permiso.permiso_modificar == "1";
                }
            }
        }


        // EVENTO CELL CONTENT CLICK PARA MODIFICAR
        private void DtgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string nombreColumna = DtgDatos.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "Modificar")
            {
                if (!permisoModificar)
                {
                    
                    return;
                }
                try
                {

                    // Obtiene los valores obligatorios
                    detalleEntrada.id_detalleEntrada = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["ID Detalle"].Value);
                    detalleEntrada.precio_entrada = Convert.ToDouble(DtgDatos.Rows[e.RowIndex].Cells["Precio Unitario"].Value);
                    detalleEntrada.cantidad_entrada = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["Cantidad"].Value);

                    // Intenta obtener el ID del producto
                    if (DtgDatos.Columns.Contains("ID Producto"))
                        detalleEntrada.fkid_producto = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["ID Producto"].Value);

                    else if (DtgDatos.Columns.Contains("id_producto"))
                        detalleEntrada.fkid_producto = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["id_producto"].Value);

                    else
                    {
                        MessageBox.Show("No se encontró la columna del producto (ID Producto).",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Intenta obtener el ID de entrada
                    if (DtgDatos.Columns.Contains("ID Entrada"))
                        detalleEntrada.fkid_entrada = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["ID Entrada"].Value);

                    else if (DtgDatos.Columns.Contains("id_entrada"))
                        detalleEntrada.fkid_entrada = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["id_entrada"].Value);

                    else
                        detalleEntrada.fkid_entrada = 0;

                    // Abre el formulario de edición
                    int idProducto = Convert.ToInt32(DtgDatos.Rows[e.RowIndex].Cells["ID Producto"].Value);

                    FrmEntradas frmEdit = new FrmEntradas(idProducto); // se lo pasamos al constructor
                    frmEdit.ShowDialog();


                    // Limpiar el DataGridView al cerrar el form
                    LimpiarTabla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar los datos para modificar: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
