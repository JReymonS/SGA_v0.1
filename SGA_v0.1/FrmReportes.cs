using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace SGA_v0._1
{
    public partial class FrmReportes : Form
    {

        //CREACION DE OBJETOS Y CREACION DE VARIABLES 
        ManejadorReportes mr;
        int fila = 0;
        int columna = 0;
        string tipoReporteActual = "";
        bool permisoEliminar = false, permisoCrear = false;
        ManejadorDiseño md;

        //CONSTRUCTOR PARA INICIALIZAR EL FORMULARIO Y EL OBJETO DE ManejadorReportes
        public FrmReportes()
        {
            InitializeComponent();
            mr = new ManejadorReportes();     
            md = new ManejadorDiseño();
            md.EstiloPanelTexto(pNombre, lblNombre, ColorTranslator.FromHtml("#8CBFAF"));
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            md.AgregarBordeFormulario(this);
            md.EstilosBoton(btnGenerarExcel);
            md.EstilosBoton(btnAgregar);
        }


        //METODO PARA GENERAR REPORTES DESDE FrmDatosReportes
        public void GenerarReporte(string tipoReporte, DateTime fechaInicio, DateTime fechaFin, string categoria, string nombreUsuario)
        {
            try
            {
                mr.GenerarReporte(tipoReporte, dtgDatos, fechaInicio, fechaFin, categoria, nombreUsuario, permisoEliminar); 
                tipoReporteActual = tipoReporte;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //EVENTO CLICK PARA AGREGAR DATOS PARA GENERAR EL REPORTE
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmDatosReportes dr = new FrmDatosReportes();
            dr.ShowDialog();
        }


        //EVENTO CLICK PARA EXPORTAR PARA EXPORTAR LOS DATOS A EXCEL
        private void btnGenerarExcel_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tipoReporteActual))
            {
                MessageBox.Show("No hay ningun reporte generado para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreArchivo = tipoReporteActual.Replace(" ", "");
            mr.Exportar(dtgDatos, nombreArchivo);

            // LIMPIAR LA VARIABLE DEL TIPO DE REPORTE
            tipoReporteActual = "";
          
        }


        //EVENTO CLICK PARA ELIMINAR UN REGISTRO ESPECIFICO DEL dtgDatos
        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (fila < 0) return;
            if (columna == 6)
            {
               
                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar este registro del reporte?", "Confirmar Eliminacion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    try
                    {
                        dtgDatos.Rows.RemoveAt(fila);
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la fila: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        

        //EVENTO CLICK PARA OBTENER LA CELDA ESPECIFICA PARA ELIMINAR UN REGISTRO
        private void dtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            btnAgregar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnAgregar);
        }

        private void btnGenerarExcel_MouseEnter(object sender, EventArgs e)
        {
            btnGenerarExcel.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnGenerarExcel_MouseLeave(object sender, EventArgs e)
        {
            btnGenerarExcel.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnGenerarExcel);
        }

        // EVENTO PARA OBTENER LOS PERMISOS Y HABILITAR / DESHABILITAR BOTONES
        private void FrmReportes_Load(object sender, EventArgs e)
        {
            
            btnAgregar.Enabled = false;
            btnGenerarExcel.Enabled = false;
            foreach(var permiso in FrmInicio._rolPermisosActivo.permisos)
            {
                if(permiso.fkid_modulo == 7)
                {
                    btnAgregar.Enabled = permiso.permiso_crear == "1";
                    btnGenerarExcel.Enabled = permiso.permiso_crear == "1";
                    permisoEliminar = permiso.permiso_borrar == "1";

                }
            }
            
        }
    }
}