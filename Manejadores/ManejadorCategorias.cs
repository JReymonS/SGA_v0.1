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
            var rs = MessageBox.Show(
                $"¿Estás seguro de inactivar la categoría '{categoria.nombre}'?",
                "Confirmar inactivación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (rs == DialogResult.Yes)
            {
                try
                {
                    string query = $"CALL InactivarCategoria({categoria.id_categoria})";
                    b.Comando(query);
                    MessageBox.Show("La categoría se marcó como inactiva correctamente.",
                                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al inactivar la categoría: {ex.Message}",
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
                    $"SELECT * FROM vista_categorias " +
                    $"WHERE (nombre COLLATE utf8mb4_general_ci LIKE '%{nombre}%') " +
                    $"AND status = 'A'",
                    "categorias").Tables[0];

                if (tabla.Columns.Contains("status"))
                    tabla.Columns["status"].Visible = false;

                if (tabla.Columns.Contains("status_texto"))
                    tabla.Columns["status_texto"].HeaderText = "Estatus";

                if (tabla.Columns.Contains("nombre"))
                    tabla.Columns["nombre"].HeaderText = "Nombre";

                if (tabla.Columns.Contains("id_categoria"))
                    tabla.Columns["id_categoria"].Visible = false;

                tabla.Columns.Insert(tabla.Columns.Count, Boton("Modificar", Color.Blue));
                tabla.Columns.Insert(tabla.Columns.Count, Boton("Eliminar", Color.Red));

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
