using System;
using System.Windows.Forms;
using Entidades;
using Manejadores;

namespace SGA_v0._1
{
    public partial class FrmCategoriaMenu : Form
    {
        ManejadorCategorias mc;


        //CONSTRUCTOR PARA FORMULARIO
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


        //EVENTO CLICK PARA GUARDAR UN REGISTRO
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría no puede estar vacío.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(TxtNombre.Text.Length > 100) 
            {
                MessageBox.Show("Ingrese un nombre de categoría válido (máximo 100 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TxtNombre.Clear();
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
                }
                else
                {
                    mc.Modificar(categoria);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar o modificar: {ex.Message}",
                                "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //EVENTO CLICK PARA CANCELAR EL REGISTRO
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}


