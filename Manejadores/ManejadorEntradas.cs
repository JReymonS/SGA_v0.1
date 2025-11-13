using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejadores
{
    public class ManejadorEntradas
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen", 3310);
        public bool valido = true; // VARIABLE PARA VALIDAR CAMPOS
        public void ActualizarFechaEntrada(int idEntrada, DateTime nuevaFecha)
        {
            try
            {
                string query = $"UPDATE entradas SET fecha_entrada = '{nuevaFecha:yyyy-MM-dd}' WHERE id_entrada = {idEntrada};";
                b.Comando(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar fecha de entrada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataRow ObtenerProductoPorId(int idProducto)
        {
            try
            {
                string query = $"SELECT * FROM v_ProductosPorId WHERE id_producto = {idProducto};";
                DataTable dt = b.Consulta(query, "productos").Tables[0];

                if (dt.Rows.Count > 0)
                    return dt.Rows[0];
                else
                    return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener producto por ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        // Para actualizar stock usando procedimiento almacenado
        public void ActualizarStockProductoSP(int idProducto, int cantidad)
        {
            try
            {
                string query = $"CALL SP_ActualizarStock({idProducto}, {cantidad});";
                b.Comando(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Para modificar un producto existente, solo actualiza la diferencia
        public void ActualizarStockDiferenciaSP(int idProducto, int cantidadAnterior, int nuevaCantidad)
        {
            int diferencia = nuevaCantidad - cantidadAnterior;
            if (diferencia != 0)
            {
                ActualizarStockProductoSP(idProducto, diferencia);
            }
        }


        // MÉTODO PARA GUARDAR ENTRADA
        public int GuardarEntrada(Entradas entrada)
        {
            try
            {
                string query = $"CALL p_InsertarEntrada('{entrada.fecha_entrada}', {entrada.fkid_usuario}, {entrada.fkid_proveedor});";
                b.Comando(query);

                DataSet ds = b.Consulta("SELECT LAST_INSERT_ID() AS id;", "entradas");
                return Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la entrada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        public string ObtenerNombreProducto(int idProducto)
        {
            string query = $"SELECT nombre FROM v_ProductosPorId WHERE id_producto = {idProducto};";
            DataTable dt = b.Consulta(query, "productos").Tables[0];
            return dt.Rows.Count > 0 ? dt.Rows[0]["nombre"].ToString() : "";
        }

        public string ObtenerDescripcionProducto(int idProducto)
        {
            string query = $"SELECT descripcion FROM v_ProductosPorId WHERE id_producto = {idProducto};";
            DataTable dt = b.Consulta(query, "productos").Tables[0];
            return dt.Rows.Count > 0 ? dt.Rows[0]["descripcion"].ToString() : "";
        }





        // MÉTODO PARA OBTENER PROVEEDORES ACTIVOS
        public DataTable ObtenerProveedores()
        {
            try
            {
                string query = "SELECT id_proveedor, nombre FROM v_proveedores_activos;";
                return b.Consulta(query, "proveedores").Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



        // MÉTODO PARA MOSTRAR PRODUCTOS DISPONIBLES
        public void MostrarProductos(DateTime fecha, int idProveedor, DataGridView tabla)
        {
            try
            {
                string query = $@"
                    SELECT * 
                    FROM v_productos_disponibles;";

                tabla.Columns.Clear();
                tabla.DataSource = b.Consulta(query, "productos").Tables[0];

                if (tabla.Columns.Contains("id_producto"))
                    tabla.Columns["id_producto"].Visible = false;

                if (!tabla.Columns.Contains("Seleccionar"))
                    tabla.Columns.Add(Boton("Seleccionar", Color.DarkGreen));

                tabla.AutoResizeColumns();
                tabla.AutoResizeRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Para actualizar stock al modificar
        public void SumarStockProducto(int idProducto, int cantidad)
        {
            string query = $"CALL sp_SumarStockProducto({idProducto}, {cantidad});";
            b.Comando(query);
        }

        public void ActualizarStockProducto(int idProducto, int cantidadAnterior, int nuevaCantidad)
        {
            string query = $"CALL sp_ActualizarStockProducto({idProducto}, {cantidadAnterior}, {nuevaCantidad});";
            b.Comando(query);
        }

        public void MostrarProductosTodos(DateTime fecha, int idProveedor, DataGridView tabla)
        {
            try
            {
                string query = $@"
                    SELECT * 
                    FROM v_productos_disponibles;";

                tabla.Columns.Clear();
                tabla.DataSource = b.Consulta(query, "productos").Tables[0];

                if (tabla.Columns.Contains("id_producto"))
                    tabla.Columns["id_producto"].Visible = false;


                tabla.AutoResizeColumns();
                tabla.AutoResizeRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        // MÉTODO PARA MOSTRAR DETALLE DE ENTRADAS (Usado en FrmEntradasDatos)

        public DataTable BuscarDetalleEntradasPorFecha(DateTime fecha)
        {
            try
            {
                string query = $@"
            SELECT *
            FROM v_Buscar_Detalles_Por_Fecha
            WHERE Fecha = '{fecha:yyyy-MM-dd}';
        ";

                return b.Consulta(query, "detalle_entradas").Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener detalles de entrada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        // MÉTODO PARA CREAR BOTONES EN DATAGRIDVIEW
        public static DataGridViewButtonColumn Boton(string titulo, Color fondo)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = titulo;
            btn.UseColumnTextForButtonValue = true;
            btn.FlatStyle = FlatStyle.Popup;
            btn.DefaultCellStyle.BackColor = fondo;
            btn.DefaultCellStyle.ForeColor = Color.White;
            btn.HeaderText = titulo; 
            btn.Name = titulo;     
            return btn;
        }

    }
}
