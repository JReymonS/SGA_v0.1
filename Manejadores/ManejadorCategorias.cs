using System;
using System.Drawing;
using System.Windows.Forms;
using AccesoDatos;
using Entidades;

namespace Manejadores
{
    public class ManejadorCategorias
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen", 3310);

        public void Guardar(Categorias categoria)
        {
            try
            {
                string query = $"CALL InsertarCategoria('{categoria.nombre}', '{categoria.status}')";
                b.Comando(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la categoría: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Modificar(Categorias categoria)
        {
            try
            {
                string query = $"CALL ModificarCategoria({categoria.id_categoria}, '{categoria.nombre}', '{categoria.status}')";
                b.Comando(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la categoría: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Borrar(Categorias categoria)
        {
            var rs = MessageBox.Show($"¿Estás seguro de eliminar la categoría '{categoria.nombre}'?",
                                     "¡Atención!",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                try
                {
                    b.Comando($"DELETE FROM categorias WHERE id_categoria = {categoria.id_categoria}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al borrar la categoría: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void Mostrar(string nombre, DataGridView tabla)
        {
            try
            {
                tabla.Columns.Clear();

                tabla.DataSource = b.Consulta(
                    $"SELECT id_categoria, nombre, status FROM categorias WHERE nombre LIKE '%{nombre}%' OR status LIKE '%{nombre}%'",
                    "categorias").Tables[0];

                if (tabla.Columns.Contains("id_categoria"))
                    tabla.Columns["id_categoria"].Visible = false;

                tabla.Columns.Insert(tabla.Columns.Count, Boton("Modificar", Color.Blue));
                tabla.Columns.Insert(tabla.Columns.Count, Boton("Borrar", Color.Red));

                tabla.AutoResizeColumns();
                tabla.AutoResizeRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar categorías: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
