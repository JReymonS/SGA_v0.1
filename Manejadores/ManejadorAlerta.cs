using System;
using System.Data;
using AccesoDatos;

namespace Manejadores
{
    public class ManejadorAlerta
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen", 3310);

        public string ObtenerProductoMasBajo()
        {
            string consulta = "SELECT nombre FROM v_vistas_tock_bajo;";

            DataSet ds = b.Consulta(consulta, "stock");

            if (ds.Tables["stock"].Rows.Count > 0)
            {
                string productos = "";

                foreach (DataRow row in ds.Tables["stock"].Rows)
                {
                    productos += row["nombre"].ToString() + Environment.NewLine;
                }

                return productos;
            }
            else
            {
                return "No hay productos con stock bajo.";
            }
        }

    }
}
