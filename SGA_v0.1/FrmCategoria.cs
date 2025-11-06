using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Manejadores;
using Entidades;

namespace SGA_v0._1
{
    public partial class FrmCategoria : Form
    {
        ManejadorCategorias mc;
        int fila = 0, columna = 0;
        public static Categorias categoria = new Categorias(0, "", "");

        public FrmCategoria()
        {
            InitializeComponent();
            mc = new ManejadorCategorias();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                columna = e.ColumnIndex;

                FrmCategoria.categoria.id_categoria = int.Parse(DtgDatos.Rows[fila].Cells["id_categoria"].Value.ToString());
                FrmCategoria.categoria.nombre = DtgDatos.Rows[fila].Cells["nombre"].Value.ToString();
                FrmCategoria.categoria.status = DtgDatos.Rows[fila].Cells["status"].Value.ToString();

                switch (columna)
                {
                    case 3: 
                        {
                            FrmCategoriaMenu frmDatos = new FrmCategoriaMenu();
                            frmDatos.FormClosed += (s, args) =>
                            {
                                LimpiarTabla(); 
                            };
                            frmDatos.ShowDialog();
                        }
                        break;

                    case 4: 
                        {
                            mc.Borrar(FrmCategoria.categoria);
                            LimpiarTabla();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmCategoria.categoria = new Categorias(0, "", "");
            FrmCategoriaMenu frmMenu = new FrmCategoriaMenu();
            frmMenu.FormClosed += (s, args) =>
            {
                LimpiarTabla(); 
            };
            frmMenu.ShowDialog();
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            mc.Mostrar(TxtBuscar.Text, DtgDatos);
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }

        public void LimpiarTabla()
        {
            DtgDatos.DataSource = null;
            DtgDatos.Rows.Clear();
            DtgDatos.Columns.Clear();
            DtgDatos.Refresh();
        }
    }
}
