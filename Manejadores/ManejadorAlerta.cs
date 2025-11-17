using System;
using System.Data;
using System.Windows.Forms;
using AccesoDatos;

namespace Manejadores
{
    public class ManejadorAlerta
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen", 3310);

        public string ObtenerProductoMasBajo()
        {
            string nombreProducto = "";

            try
            {
                string consulta = "SELECT nombre FROM v_vistas_tock_bajo LIMIT 1";

                DataSet ds = b.Consulta(consulta, "Productos");

                if (ds.Tables.Count > 0 && ds.Tables["Productos"].Rows.Count > 0)
                {
                    nombreProducto = ds.Tables["Productos"].Rows[0]["nombre"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener el producto: " + ex.Message);
            }

            return nombreProducto;
        }
    }
}
