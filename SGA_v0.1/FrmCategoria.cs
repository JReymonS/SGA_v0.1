using System;
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

        bool permisoModificar = false, permisoBorrar = false; //PERMISOS PARA BOTONES EN DATAGRIDVIEW


        //CONSTRUCTOR PARA FORMULARIO
        public FrmCategoria()
        {
            InitializeComponent();
            mc = new ManejadorCategorias();
        }


        //EVENTO LOAD PARA ACTIVAR / DESACTIVAR BOTONES SEGUN PERMISOS DEL ROL
        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            BtnAgregar.Enabled = false;
            foreach(var permiso in FrmInicio._rolPermisosActivo.permisos) 
            {
                if (permiso.fkid_modulo == 2) //MODULO DE CATEGORIAS
                {
                    BtnAgregar.Enabled = permiso.permiso_crear == "1";
                    permisoModificar = permiso.permiso_modificar == "1";
                    permisoBorrar = permiso.permiso_borrar == "1";
                }
            }
        }
        

        //EVENTO CLICK PARA BUSCAR CATERGORIAS
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            mc.Mostrar(TxtBuscar.Text, DtgDatos,permisoModificar, permisoBorrar);
        }


        //EVENTO CLICK PARA AGREAGAR CATEGORIAS
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


        //EVENTO CELL ENTER PARA OBTENER CELDA DE MODIFICAR O ELIMINAR
        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }


        //EVENTO CELL CONTENENT CLICK PARA MODIFICAR O ELIMINAR UNA CATEGORIA
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                fila = e.RowIndex;
                columna = e.ColumnIndex;

                FrmCategoria.categoria.id_categoria = int.Parse(DtgDatos.Rows[fila].Cells["id_categoria"].Value.ToString());
                FrmCategoria.categoria.nombre = DtgDatos.Rows[fila].Cells["Nombre"].Value.ToString();
                FrmCategoria.categoria.status = DtgDatos.Rows[fila].Cells["status"].Value.ToString(); 

                switch (columna)
                {
                    case 4: 
                        FrmCategoriaMenu frmDatos = new FrmCategoriaMenu();
                        frmDatos.FormClosed += (s, args) => LimpiarTabla();
                        frmDatos.ShowDialog();
                        break;

                    case 5: 
                        mc.Borrar(FrmCategoria.categoria);
                        LimpiarTabla();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al seleccionar fila: {ex.Message}", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        //METODO PARA LIMPIAR CONTENEDOR
        public void LimpiarTabla()
        {
            DtgDatos.DataSource = null;
            DtgDatos.Rows.Clear();
            DtgDatos.Columns.Clear();
            DtgDatos.Refresh();
        }


        //EVENTO CLICK PARA SALIR DEL FORMULARIO
        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
