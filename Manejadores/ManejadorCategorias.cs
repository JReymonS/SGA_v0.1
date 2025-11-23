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
        ManejadorDiseño md = new ManejadorDiseño();

        //METODO PARA GUARDAR CATEGORIAS
        public void Guardar(Categorias categoria)
        {
            b.Comando($"CALL p_InsertarCategoria('{categoria.nombre}','{categoria.status}')");
        }


        //METODO PARA MODIFICAR CATEGORIAS
        public void Modificar(Categorias categoria)
        {
            b.Comando($"CALL p_ModificarCategoria({categoria.id_categoria},'{categoria.nombre}', '{categoria.status}')");
        }


        //METODO PARA BORRAR CATEGORIAS
        public void Borrar(Categorias categoria)
        {
            var rs = MessageBox.Show($"¿Estás seguro de eliminar la categoría {categoria.nombre}?","¡ATENCIÓN!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_InactivarCategoria({categoria.id_categoria})");
            }
        }


        //METODO PARA MOSTRAR CATEGORIAS
        public void Mostrar(string nombre, DataGridView tabla, bool permisoModificar, bool permisoBorrar)
        {
            try
            {
                tabla.Columns.Clear();

                tabla.DataSource = b.Consulta(
                    $"SELECT * FROM v_ConsultaCategoria " +
                    $"WHERE (nombre COLLATE utf8mb4_general_ci LIKE '%{nombre.Trim('\'')}%') " +
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
                tabla.Columns[4].Visible = permisoModificar;
                tabla.Columns[5].Visible = permisoBorrar;
                md.EstilizarData(tabla);
                tabla.AutoResizeColumns();
                tabla.AutoResizeRows();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar categorías: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //METODO PARA GENERAR BOTONES EN TIEMPO DE EJECUCIÓN
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
