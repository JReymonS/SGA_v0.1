using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorProveedores
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");
        public void Guardar(Proveedores proveedor)
        {
            b.Comando($"CALL p_AgregarProveedor('{proveedor.nombre}','{proveedor.apellido_paterno}','{proveedor.apellido_materno}','{proveedor.telefono}','{proveedor.correo}',{proveedor.plazo_disponibilidad},'{proveedor.status}')");
        }

        public void Borrar(Proveedores proveedor)
        {
            var rs = MessageBox.Show($"Esta seguro de desactivar a {proveedor.nombre}",
                "ATENCIÓN!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_DesactivarProveedor({proveedor.id_proveedor})");
            }
        }

        public void Modificar(Proveedores proveedor)
        {
            b.Comando($"CALL p_ModificarProveedor ('{proveedor.id_proveedor}','{proveedor.nombre}','{proveedor.apellido_paterno}','{proveedor.apellido_materno}'," +
                $"'{proveedor.telefono}','{proveedor.correo}',{proveedor.plazo_disponibilidad},'{proveedor.status}')");

        }

        public void Mostrar(string consulta, DataGridView tabla)
        {

            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta($"select * from v_Proveedores where (Nombre like '%{consulta}%') AND Estatus = 'A'", "proveedores").Tables[0];
            tabla.Columns["id_proveedor"].Visible = false;
            tabla.Columns.Insert(8, Boton("Modificar", Color.Green));
            tabla.Columns.Insert(9, Boton("Borrar", Color.Red));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }

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
    }
}
