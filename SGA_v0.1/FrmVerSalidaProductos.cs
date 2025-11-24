using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace SGA_v0._1
{
    public partial class FrmVerSalidaProductos : Form
    {
         // CREACION DE OBJETOS Y VARIABLES
        ManejadorSalidas ms;
        ManejadorDiseño md;
        public static Salidas salida = new Salidas(0, "", 0);
        public static Productos producto = new Productos(0, "", "", "", 0.0, 0, 0, "", 0);
        public static DetalleSalidas detalleSalida = new DetalleSalidas(0, 0.0, 0, 0, 0);
        int fila = 0;
        int columna = 0;
        bool permisoModificar = false, permisoCrear;
        

        //CONSTRUCTOR CON LA INICIALIZACION DEl OBJETO DEL MANEJADOR SALIDAS
        public FrmVerSalidaProductos()
        {
            InitializeComponent();
            ms = new ManejadorSalidas();
            md = new ManejadorDiseño();
            md.EstiloPanelTexto(pProveedores, lblNombre, ColorTranslator.FromHtml("#8CBFAF"));
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            md.AgregarBordeFormulario(this);
            md.EstilizarDTP(dtpFecha);
            md.EstilosBoton(btnAgregar);
            md.EstilosBoton(btnBuscar);
           

        }


        //EVENTO CLICK PARA MOSTRAR LOS REGISTROS DE SALIDA FILTRADOS POR FECHA
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string fecha = dtpFecha.Value.ToString("yyyy-MM-dd");

            ms.MostrarPorBusqueda($"CALL p_BuscarDetalleSalidaPorFecha('{fecha}')", dtgDatos, "detalle_salida", permisoModificar);

        }


        //EVENTO QUE PERMITE ABRIR UN NUEVO FORMULARIO PARA REGISTRAR NUEVAS SALIDAS
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            salida = new Salidas(0, "", 0);
            producto = new Productos(0, "", "", "", 0.0, 0, 0, "", 0);
            detalleSalida = new DetalleSalidas(0, 0.0, 0, 0, 0);
            FrmAgregarSalidaProductos ms = new FrmAgregarSalidaProductos();
            ms.ShowDialog();
            dtgDatos.Columns.Clear();
        }


        //EVENTO QUE PERMITE OBTENER LA FILA Y COLUMNA ESPECIFICA PARA EL DATAGRIDVIEW
        private void dtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }

        //EVENTO QUE PERMITE MOSTRAR LAS COLUMNAS PARA IDENTIFICAR SI SE CLICKEA LA CElDA
        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            salida.id_salida = int.Parse(dtgDatos.Rows[fila].Cells["id_salida"].Value.ToString());
            salida.fecha_salida = dtgDatos.Rows[fila].Cells["Fecha"].Value.ToString();
            producto.id_producto = int.Parse(dtgDatos.Rows[fila].Cells["id_producto"].Value.ToString());
            producto.nombre = dtgDatos.Rows[fila].Cells["Producto"].Value.ToString();
            producto.descripcion = dtgDatos.Rows[fila].Cells["Descripcion"].Value.ToString();  
            producto.precio_salida = double.Parse(dtgDatos.Rows[fila].Cells["Costo"].Value.ToString());  
            detalleSalida.id_detalleSalida = int.Parse(dtgDatos.Rows[fila].Cells["id_detalleSalida"].Value.ToString());
            detalleSalida.cantidad_salida = int.Parse(dtgDatos.Rows[fila].Cells["Cantidad"].Value.ToString());
            producto.precio_salida = double.Parse(dtgDatos.Rows[fila].Cells["Costo"].Value.ToString());

            switch (columna)
            {
                case 9:
                    FrmAgregarSalidaProductos frm = new FrmAgregarSalidaProductos();
                    frm.ShowDialog();
                    
                    dtgDatos.Columns.Clear();
                    break;
            }
        }

        private void dtgDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            btnBuscar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnBuscar);
        }

        private void btnBuscar_MouseEnter(object sender, EventArgs e)
        {
            btnBuscar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnAgregar);
        }

        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            btnAgregar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

        }

        // EVENTO PARA OBTENER LOS PERMISOS Y HABILITAR / DESHABILITAR BOTONES
        private void FrmVerSalidaProductos_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            foreach(var permiso in FrmInicio._rolPermisosActivo.permisos)
            {
                if(permiso.fkid_modulo == 6)
                {
                    btnAgregar.Enabled = permiso.permiso_crear == "1";
                    permisoModificar = permiso.permiso_modificar == "1";
                }
               
            }
        }
    }
}
