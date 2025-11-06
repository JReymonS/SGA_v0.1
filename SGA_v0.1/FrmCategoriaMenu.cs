using System;
using System.Windows.Forms;
using Entidades;
using Manejadores;

namespace SGA_v0._1
{
    public partial class FrmCategoriaMenu : Form
    {
        ManejadorCategorias mc;

        public FrmCategoriaMenu()
        {
            InitializeComponent();
            mc = new ManejadorCategorias();

            CmbStatus.Items.Add("Activo");
            CmbStatus.Items.Add("Inactivo");

            if (FrmCategoria.categoria.id_categoria > 0)
            {
                TxtNombre.Text = FrmCategoria.categoria.nombre;
                CmbStatus.SelectedItem = FrmCategoria.categoria.status == "A" ? "Activo" : "Inactivo";
            }
            else
            {
                CmbStatus.SelectedIndex = 0;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string statusSeleccionado = CmbStatus.SelectedItem.ToString() == "Activo" ? "A" : "I";

            Categorias categoria = new Categorias(
                FrmCategoria.categoria.id_categoria,
                TxtNombre.Text.Trim(),
                statusSeleccionado
            );

            try
            {
                if (categoria.id_categoria == 0)
                {
                    mc.Guardar(categoria);
                    MessageBox.Show("Se guardó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    mc.Modificar(categoria);
                    MessageBox.Show("Se modificó correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar o modificar: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

