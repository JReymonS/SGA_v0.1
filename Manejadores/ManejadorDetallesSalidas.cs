using AccesoDatos;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorDetallesSalidas
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");
        ManejadorDiseño md = new ManejadorDiseño();
        public DataTable dtTempSalida { get; private set; }


        //CONSTRUCTOR QUE INICIALIZA EL PROCEDIMIENTO Y LAS COLUMNAS CREADAS 
        public ManejadorDetallesSalidas()
        {
            b.Comando("CALL p_CrearTablaTemporal()");
            dtTempSalida = new DataTable();
            dtTempSalida.Columns.Add("id_producto");
            dtTempSalida.Columns.Add("Nombre");
            dtTempSalida.Columns.Add("Descripcion");
            dtTempSalida.Columns.Add("Cantidad");
            dtTempSalida.Columns.Add("Costo");  
        }


        //METODO PARA CREAR BOTONES EN TIEMPO DE EJECUCION
        public static DataGridViewButtonColumn Boton(string titulo, Color fondo)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = titulo;
            btn.UseColumnTextForButtonValue = true;
            btn.FlatStyle = FlatStyle.Popup;
            btn.DefaultCellStyle.BackColor = fondo;
            btn.DefaultCellStyle.ForeColor = Color.White;
            return btn;
        }
       

        //METODO QUE PERMITE MOSTRAR LOS PRODUCTOS EN EL DATAGRIDVIEW 
        public void MostrarProductos(string consulta, DataGridView tabla, string datos)
        {
            
            var color = ColorTranslator.FromHtml("#545454");
            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta(consulta, datos).Tables[datos];
            tabla.Columns["id_producto"].Visible = false;
            tabla.Columns.Insert(0, Boton("Seleccionar", color));
        
        }


        //METODO QUE PERMITE MOSTRAR LOS PRODUCTOS SELECCIONADOS PARA MODIFIFCAR O REGISTRAR COMO SALIDA
        public void MostrarProductosTemporales(DataGridView tabla)
        {
            DataSet ds = b.Consulta("CALL p_ObtenerProductosTemporales()", "temp");
            dtTempSalida = ds.Tables["temp"];

            tabla.DataSource = dtTempSalida;

            if (tabla.Columns.Contains("id_producto"))
                tabla.Columns["id_producto"].Visible = false;

         
            if (!tabla.Columns.Contains("btnEliminar"))
            {
                DataGridViewButtonColumn btn = Boton("Eliminar", Color.Orange);
                btn.Name = "btnEliminar";
                btn.HeaderText = "";
                tabla.Columns.Insert(0, btn);
            }
            md.EstilizarData(tabla);
        }



        //METODO PARA AGREGAR UN PRODUCTO A LA TABLA TEMPORAL
        public void AgregarProductoTemporal(string id_producto, string nombre, string descripcion, string cantidad, string costo)
        {
            b.Comando($"CALL p_AgregarProductoTemporal({id_producto}, '{nombre}', '{descripcion}', {cantidad}, {costo})");
        }


        //METODO PARA ELIMINAR PRODUCTOS DE LA TABLA TEMPORAL
        public void EliminarProductoTemporal(string idProducto)
        {
            b.Comando($"CALL p_EliminarProductoTemporal({idProducto})");
        }


        //METODO QUE PERMITE GUARDAR CADA PRODUCTO DE LA TABLA TEMPORAL COMO REGISTROS INDIVIDUALES
        public void GuardarDetalleSalidas(int id_salida)
        {
            
            b.Comando($"CALL p_GuardarDesdeTemporales({id_salida})");
        }
        

        //PERMITE LIMPIAR LA TABLA TEMPORAL (destruye la tabla)
        public void LimpiarProductosTemporales()
        {
            b.Comando("CALL p_LimpiarProductosTemporales()");
        }


        //PERMITE MODIFICAR UN REGISTRO PREVIO 
        public void ModificarDetalleSalida(int idDetalleSalida, int idSalida)
        {
            DataSet ds = b.Consulta("CALL p_ObtenerProductosTemporales()", "temp");

            if (ds.Tables["temp"].Rows.Count == 0)
            {
                throw new Exception("No hay productos para modificar");
            }

            DataRow row = ds.Tables["temp"].Rows[0];
            int idProducto = int.Parse(row["id_producto"].ToString());
            int cantidad = int.Parse(row["Cantidad"].ToString());
            double precio = double.Parse(row["Costo"].ToString());

            b.Comando($"CALL p_ModificarDetalleSalida({idDetalleSalida}, {idProducto}, {cantidad}, {precio})");
        }


        //METODO PARA OBTENER EL STOCK ACTUAL
        public int ObtenerStockActual(int idProducto)
        {
            string consulta = $"SELECT stock FROM productos WHERE id_producto = {idProducto}";
            DataTable dt = b.Consulta(consulta, "productos").Tables["productos"];

            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["stock"]);
            else
                return 0;
        }
    }
}
