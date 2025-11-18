using Manejadores;
using System;
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

        //CONSTRUCTOR PARA INICIALIZAR EL FORMULARIO Y EL OBJETO DE ManejadorReportes
        public FrmReportes()
        {
            InitializeComponent();
            mr = new ManejadorReportes();     
        }


        //METODO PARA GENERAR REPORTES DESDE FrmDatosReportes
        public void GenerarReporte(string tipoReporte, DateTime fechaInicio, DateTime fechaFin, string categoria, string nombreUsuario)
        {
            try
            {
                mr.GenerarReporte(tipoReporte, dtgDatos, fechaInicio, fechaFin, categoria, nombreUsuario); 
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
                        MessageBox.Show("Fila eliminada del reporte correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}