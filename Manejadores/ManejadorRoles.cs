using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorRoles
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");



        //METODO PARA MOSTRAR ROLES EXISTENTES
        public void Mostrar(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta(consulta, datos).Tables[datos];
            tabla.Columns["IdRol"].Visible = false;
            //tabla.Columns.Insert()
            //tabla.Columns.Insert()
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }
    }
}
