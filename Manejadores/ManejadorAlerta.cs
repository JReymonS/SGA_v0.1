using System;
using System.Data;
using AccesoDatos;

namespace Manejadores
{
    public class ManejadorAlerta
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen", 3310);

        public (string lista, int cantidad) ObtenerProductosBajoStock()
        {
            string consulta = "SELECT nombre FROM v_vistas_tock_bajo;";
            DataSet ds = b.Consulta(consulta, "stock");

            if (ds.Tables["stock"].Rows.Count > 0)
            {
                string productos = "";
                int cantidad = ds.Tables["stock"].Rows.Count;

                foreach (DataRow row in ds.Tables["stock"].Rows)
                {
                    productos += row["nombre"].ToString() + Environment.NewLine;
                }

                return (productos, cantidad);
            }
            else
            {
                return ("No hay productos con stock bajo.", 0);
            }
        }


    }
}
