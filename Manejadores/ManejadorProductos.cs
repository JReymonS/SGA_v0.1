using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorProductos
    {
        // Objeto de la clase base para usar los metodos de conexion a la case de datos
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");

        // Metodo para realizar registros en la base de datos
        public void Guardar(Productos producto)
        {
            b.Comando($"CALL InsertarProducto('{producto.nombre}', '{producto.descripcion}', '{producto.unidad}', {producto.precio_salida}, {producto.stock}, {producto.stock_minimo}, '{producto.status}', {producto.fkid_categoria})");
        }

        // Metodo para eliminar registros en la base de datos
        public void Borrar(Productos producto)
        {
            var rs = MessageBox.Show($"Esta seguro de Eliminar el Producto {producto.nombre}", 
                "ATENCION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"delete from productos where id_producto = {producto.id_producto}");
            }
        }

        // Metodo para modificar registros en la base de datos
        public void Modificar(Productos producto)
        {
            b.Comando($"update productos set nombre = '{producto.nombre}', descripcion = '{producto.descripcion}', unidad = '{producto.unidad}', precio_salida = '{producto.precio_salida}', stock = '{producto.stock}', stock_minimo = '{producto.stock_minimo}', status = '{producto.status}', fkid_categoria = {producto.fkid_categoria} where id_producto = {producto.id_producto} ");
        }

        // Metodo para crear botones en tiempo de ejecucion
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


        // Metodo para mostrar los datos de productos en el Dtg
        public void Mostrar(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta(consulta, datos).Tables[datos];
            tabla.Columns["id_producto"].Visible = false;
            tabla.Columns["fkid_categoria"].Visible = false;
            tabla.Columns.Insert(10, Boton("Modificar", Color.Green));
            tabla.Columns.Insert(11, Boton("Eliminar", Color.Red));
            

        }

        // Metodo para llenar los combo box de tipo ENUM

        public void LlenarComboBox(ComboBox caja, string campo, string tabla)
        {
            DataTable dt = b.Consulta($"show columns from {tabla} like '{campo}'", $"{tabla}").Tables[0];
            string enumString = dt.Rows[0]["Type"].ToString();
            enumString = enumString.Replace("enum(", "").Replace(")", "").Replace("'", "");
            string[] valores = enumString.Split(',');
            caja.DataSource = valores.ToList(); 
        }

        // Metodo para llenar un combo box con datos de una tabla 
        public void LlenarCategorias(ComboBox caja)
        {
            caja.DataSource = b.Consulta($"select id_categoria, nombre from categorias", $"categorias").Tables[0];
            caja.DisplayMember = $"nombre";
            caja.ValueMember = $"Id_categoria";
        }

    }
}
