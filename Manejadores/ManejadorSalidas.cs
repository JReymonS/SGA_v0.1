using AccesoDatos;
using Entidades;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorSalidas
    {
        //INSTANCIA DE UN NUEVO OBJETO DE ACCESO DATOS
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");


        // PERMITE CREAR BOTONES EN TIEMPO DE EJECUCION
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


        // PERMITE REGISTRAR UNA NUEVA SALIDA
        public void GuardarSalidas(Salidas salida)
        {
            b.Comando($"CALL p_RegistrarSalidas({salida.fkid_usuario}, '{salida.fecha_salida}')");
        }


        // PERMITE REGISTRAR UNA NUEVA SALIDA OBTENIENDO EL ID PARA DESPUES HACER REGISTROS DE DETALLESALIDAS
        public int GuardarSalidaObtenerId(Salidas salida)
        {
            b.Comando($"CALL p_RegistrarSalidas({salida.fkid_usuario}, '{salida.fecha_salida}')");

            int idSalida = int.Parse(b.Consulta("SELECT LAST_INSERT_ID() AS id_salida", "Salida")
                                     .Tables["Salida"].Rows[0]["id_salida"].ToString());
            return idSalida;
        }


        //PERMITE MOSTRAR LOS REGISTROS DE SALIDA FILTRADO POR BUSQUEDA
        public void MostrarPorBusqueda(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta(consulta, datos).Tables[datos];
            tabla.Columns["id_salida"].Visible = false;
            tabla.Columns["id_detalleSalida"].Visible = false;
            tabla.Columns["id_producto"].Visible = false;
            tabla.Columns.Insert(9, Boton("Modificar", Color.Orange));
        }


        //ELIMINA EL REGISTRO DE SALIDA EN CASO DE NO COMPLETAR EL REGISTRO COMPLETO DE UNA SALIDA
        public void EliminarSalida(int id_salida)
        {
            
            b.Comando($"DELETE FROM salidas WHERE id_salida = {id_salida}");
        }   
    }
}

