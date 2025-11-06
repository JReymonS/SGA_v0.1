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
            b.Comando($"CALL p_InsertarProducto('{producto.nombre}', '{producto.descripcion}', '{producto.unidad}', {producto.precio_salida}, {producto.stock}, {producto.stock_minimo}, '{producto.status}', {producto.fkid_categoria})");
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
            tabla.Columns["id_categoria"].Visible = false;
            tabla.Columns["Categoria"].Visible = true;
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

        // Metodo para asegurar que al registrar productos se llenen todos los campos de datos del formulario
        public bool ValidarCampos(TextBox nombre, TextBox descripcion, TextBox costo, TextBox stockActual, TextBox stockMinimo)
        {
            if (string.IsNullOrWhiteSpace(nombre.Text) || string.IsNullOrWhiteSpace(descripcion.Text) || string.IsNullOrWhiteSpace(costo.Text) || string.IsNullOrWhiteSpace(stockActual.Text) ||
                string.IsNullOrWhiteSpace(stockMinimo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos", "Registro incompleto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //Metodo para validar la entrada de los numeros para registrar o actualizar registros de productos validos, que no sean negativos, letras o numeros decimales donde deben ser enteros
        public bool ValidarNumeros(TextBox txtCosto, TextBox txtStockActual, TextBox txtStockMinimo)
        {
            if (!double.TryParse(txtCosto.Text, out double precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un numero",
                               "Precio invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtStockActual.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un numero entero", "Stock invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtStockMinimo.Text, out int stockMinimo) || stockMinimo < 0)
            {
                MessageBox.Show("El stock mínimo debe ser un numero entero", "Stock mínimo invalido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        //Metodo para mostrar Activo e Inactivo en los ComboBox
        public void LlenarComboEstatus(ComboBox caja)
        {

            var lista = new List<object>
            {
              new { Texto = "Activo", Valor = "A" },
              new { Texto = "Inactivo", Valor = "I" }
            };

            caja.DataSource = lista;
            caja.DisplayMember = "Texto";
            caja.ValueMember = "Valor";
        }

        // Método para eliminar el producto es decir, cambiar el estatus de un producto a Inactivo
        public void CambiarEstatusInactivo(int idProducto)
        {
            try
            {
                var rs = MessageBox.Show("¿Esta seguro de eliminar el Producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (rs == DialogResult.Yes)
                {
                    b.Comando($"UPDATE productos SET status = 'I' WHERE id_producto = {idProducto}");
                    MessageBox.Show("El producto ha sido marcado como Inactivo.", "Estatus actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cambiar el estatus del producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
