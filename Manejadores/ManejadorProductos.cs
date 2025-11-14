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
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");

        //METODOS PARA GUARDAR PRODUCTOS 
        public void Guardar(Productos producto)
        {
            b.Comando($"CALL p_InsertarProducto('{producto.nombre}', '{producto.descripcion}', '{producto.unidad}', {producto.precio_salida}, {producto.stock}, {producto.stock_minimo}, '{producto.status}', {producto.fkid_categoria})");
        }


        //METODO PARA MODIFICAR PRODUCTOS
        public void Modificar(Productos producto)
        {
            b.Comando($"update productos set nombre = '{producto.nombre}', descripcion = '{producto.descripcion}', unidad = '{producto.unidad}', precio_salida = '{producto.precio_salida}', stock = '{producto.stock}', stock_minimo = '{producto.stock_minimo}', status = '{producto.status}', fkid_categoria = {producto.fkid_categoria} where id_producto = {producto.id_producto} ");
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


        //METODO PARA MOSTRAR PRODUCTOS
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


        //METODO PARA LLENAR EL COMBO BOX DE ESTATUS
        public void LlenarComboBox(ComboBox caja, string campo, string tabla)
        {
            DataTable dt = b.Consulta($"show columns from {tabla} like '{campo}'", $"{tabla}").Tables[0];
            string enumString = dt.Rows[0]["Type"].ToString();
            enumString = enumString.Replace("enum(", "").Replace(")", "").Replace("'", "");
            string[] valores = enumString.Split(',');
            caja.DataSource = valores.ToList();
        }


        //METODO PARA LLENAR EL COMBO BOX DE CATEGORIAS 
        public void LlenarCategorias(ComboBox caja)
        {
            caja.DataSource = b.Consulta($"select id_categoria, nombre from categorias", $"categorias").Tables[0];
            caja.DisplayMember = $"nombre";
            caja.ValueMember = $"Id_categoria";
        }


        //METODO PARA VALIDAR CAMPOS AL REGISTRAR PRODUCTOS
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


        //METODO PARA VALIDAR NUMEROS Y LETRAS AL ACTUALIZAR O REGISTRAR PRODUCTOS.
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


        //METODO PARA MOSTRAR ACTIVO E INACTIVO EN COMBO BOX
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


        //METODO PARA ELIMINAR PRODUCTOS (ACTIVO => INACTIVO)
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
