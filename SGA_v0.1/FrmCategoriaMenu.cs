using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmCategoriaMenu : Form
    {
        ManejadorCategorias mc;
        ManejadorDiseño md;


        //CONSTRUCTOR PARA FORMULARIO
        public FrmCategoriaMenu()
        {
            InitializeComponent();
            mc = new ManejadorCategorias();
            md = new ManejadorDiseño();
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

            md.AgregarBordeFormulario(this);
            md.EstiloPanelTexto(pCategorias, lblCategorias, ColorTranslator.FromHtml("#8CBFAF"));
            md.EstilosBoton(BtnCancelar);
            md.EstilosBoton(BtnGuardar);
            md.EstilizarTextBox(TxtNombre);
            md.EstilizarComboBox(CmbStatus);
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
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


        //EVENTOS PARA DISEÑO DE FORMULARIO
        private void BtnGuardar_MouseEnter(object sender, EventArgs e)
        {
            BtnGuardar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void BtnGuardar_MouseLeave(object sender, EventArgs e)
        {
            BtnGuardar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(BtnGuardar);
        }

        private void BtnCancelar_MouseEnter(object sender, EventArgs e)
        {
            BtnCancelar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void BtnCancelar_MouseLeave(object sender, EventArgs e)
        {
            BtnCancelar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(BtnCancelar);
        }
        // FIN DE EVENTOS PARA DISEÑO DE FORMULARIO
    }
}


