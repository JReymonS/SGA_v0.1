using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;


namespace Manejadores
{
    public class ManejadorReportes
    {

        // INICIALIZACION DE OBJETOS Y CRECION DE LISTAS
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");

        List <string> tiposReportes = new List<string> 
        { "Productos de Entrada","Productos de Salida","Productos en Stock Bajo","Productos mas Vendidos", "Productos Stock Actual" };

        //METODO PARA CREAR BOTONES EN TIEMO DE EJECUCION 
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


        // METODO PARA LLENAR EL COMBO BOX DE CATEGORIAS 
        public void LlenarCategorias(ComboBox caja)
        {
            caja.DataSource = b.Consulta($"select nombre from categorias", $"categorias").Tables[0];
            caja.DisplayMember = $"nombre";
            caja.ValueMember = "nombre";
        }

        // METODO PARA LLENAR EL COMBO BOX DE LOS TIPOS DE REPORTES
        public void LlenarTiposReportes(ComboBox caja)
        {
            caja.Items.Clear();
            caja.DataSource = null;
            caja.DataSource = tiposReportes;
        }

        // METODO DE REPORTES DE ENTRADAS Y SALIDAS DE PRODUCTOS
        private string ReporteEntradasSalidas(DateTime fechaInicio, DateTime fechaFin, string categoria, string tipoReporte)
        {
            string categoriaParam;

            if (string.IsNullOrEmpty(categoria))
            {
                categoriaParam = "NULL";
            }
            else
            {
                categoriaParam = $"'{categoria}'";
            }

            return $"CALL {tipoReporte}('{fechaInicio.ToString("yyyy-MM-dd HH:mm:ss")}', '{fechaFin.ToString("yyyy-MM-dd HH:mm:ss")}', {categoriaParam})";
        }

        // METODO DE REPORTES DE PRODUCTOS EN STOCK BAJO, PRODUCTOS MAS VENDIDOS Y STOCK ACTUAL
        private string ReporteStock(string categoria, string nombreUsuario, string tipoReporte)
        {
            string categoriaParam;

            if (string.IsNullOrEmpty(categoria))
            {
                categoriaParam = "NULL";
            }
            else
            {
                categoriaParam = $"'{categoria}'";
            }

            return $"CALL {tipoReporte}({categoriaParam}, '{nombreUsuario}')";
        }

        // METODO PARA PREGUNTAR SI QUIERE FILTRAR POR CATEGORÍA EN REPORTES DE STOCK
        public string PreguntarCategoria(ComboBox comboCategoria)
        {
            DialogResult resultado = MessageBox.Show("¿Desea filtrar el reporte por una categorIa especIfica?", "Filtrar por CategorIa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                return comboCategoria.SelectedItem.ToString();
            }
            else
            {
                return "";
            }
        }


        // METODO PRINCIPAL PARA GENERAR LOS DIFERENTES TIPOS DE REPORTES 
        public void GenerarReporte(string tipoReporte, DataGridView tabla, DateTime fechaInicio, DateTime fechaFin, string categoria, string nombreUsuario)
        {
            tabla.Columns.Clear();
            string consulta = "";

            switch (tipoReporte)
            {
                case "Productos de Entrada":
                    consulta = ReporteEntradasSalidas(fechaInicio, fechaFin, categoria, "p_ReporteEntradas");
                    break;

                case "Productos de Salida":
                    consulta = ReporteEntradasSalidas(fechaInicio, fechaFin, categoria, "p_ReporteSalidas");
                    break;

                case "Productos en Stock Bajo":
                    consulta = ReporteStock(categoria, nombreUsuario, "p_ReporteStockBajo");
                    break;

                case "Productos mas Vendidos":
                    consulta = ReporteStock(categoria, nombreUsuario, "p_ReporteMasVendidos");
                    break;

                case "Productos Stock Actual":
                    consulta = ReporteStock(categoria, nombreUsuario, "p_ReporteStockActual");
                    break;

                default:
                    MessageBox.Show("Tipo de reporte no valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            try
            {
                tabla.DataSource = b.Consulta(consulta, "Reporte").Tables["Reporte"];

                if (tabla.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron datos para el reporte seleccionado.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    
                    tabla.Columns.Add(Boton("ELIMINAR", Color.OrangeRed));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // METODO PARA GENERAR LOS DIFERENTES TIPOS DE REPORTES EN EXCEL  
        public void Exportar(DataGridView tabla, string nombreReporte)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook excelWorkBook = null;
            Excel.Worksheet excelWorkSheet = null;
            try
            {
                excelApp = new Excel.Application();
                excelWorkBook = excelApp.Workbooks.Add();
                excelWorkSheet = (Excel.Worksheet)excelWorkBook.Sheets[1];
                excelApp.Visible = false;

                //Exportar Encabezados de Columna (SIN LA ÚLTIMA COLUMNA)
                for (int i = 0; i < tabla.Columns.Count - 1; i++)
                {
                    excelWorkSheet.Cells[1, i + 1] = tabla.Columns[i].HeaderText;
                }

                //Exportar Filas de Datos (SIN LA ÚLTIMA COLUMNA)
                for (int i = 0; i < tabla.Rows.Count; i++)
                {
                    for (int j = 0; j < tabla.Columns.Count - 1; j++)
                    {
                        excelWorkSheet.Cells[i + 2, j + 1] = tabla.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }

                excelWorkSheet.Columns.AutoFit();

                // Generar nombres con contador y unicos para cada reporte 
                string fechaActual = DateTime.Now.ToString("yyyyMMdd");
                string rutaBase = @"C:\Users\valer\Desktop\"; //Aqui Modificar la ruta de descarga
                string nombreBase = $"{nombreReporte}_{fechaActual}";
                string filePath = $"{rutaBase}{nombreBase}.xlsx";

                int contador = 1;
                while (System.IO.File.Exists(filePath))
                {
                    filePath = $"{rutaBase}{nombreBase}_{contador}.xlsx";
                    contador++;
                }

                excelWorkBook.SaveAs(filePath);

                MessageBox.Show($"El Archivo Excel se ha guardado en:\n{filePath}", "Exportación Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // LIMPIAR EL DATAGRIDVIEW DESPUÉS DE EXPORTAR
                tabla.DataSource = null;
                tabla.Columns.Clear();
                tabla.Rows.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Exportar a Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (excelWorkBook != null) excelWorkBook.Close(false);
                if (excelApp != null) excelApp.Quit();
                
                Marshal.ReleaseComObject(excelWorkSheet);
                Marshal.ReleaseComObject(excelWorkBook);
                Marshal.ReleaseComObject(excelApp);
            }
        }

    }
}
