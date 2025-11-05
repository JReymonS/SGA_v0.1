using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Manejadores;


namespace SGA_v0._1
{
    public partial class FrmVerProductos : Form
    {
        ManejadorProductos mp;
        public static Productos producto = new Productos(0, "", "", "", 0.0, 0, 0, "", 0);
        int fila = 0;
        int columna = 0;
        public FrmVerProductos()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
        }

        // Boton para buscar un registro en la base de datos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mp.Mostrar($"CALL BuscarProductos('{txtNombre.Text}')", dtgDatos, "productos");
            txtNombre.Text = "";
        }


        // Boton para abrir el formulario de registro de productos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            producto.id_producto = 0; producto.nombre = "";
            producto.descripcion = ""; producto.unidad = "";
            producto.precio_salida = 0.0; producto.stock = 0;
            producto.stock_minimo = 0; producto.status = "";
            producto.fkid_categoria = 0;
            FrmAgregarProductos p = new FrmAgregarProductos();
            p.ShowDialog();
            dtgDatos.Columns.Clear();
        }

        // Dtg para mostrar los resultados de la busqueda de productos
        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            producto.id_producto = int.Parse(dtgDatos.Rows[fila].Cells[0].Value.ToString());
            producto.nombre = dtgDatos.Rows[fila].Cells["Nombre"].Value.ToString();
            producto.descripcion = dtgDatos.Rows[fila].Cells["Descripcion"].Value.ToString();
            producto.unidad = dtgDatos.Rows[fila].Cells["Unidad"].Value.ToString();
            producto.precio_salida = double.Parse(dtgDatos.Rows[fila].Cells["Precio"].Value.ToString());
            producto.stock = int.Parse(dtgDatos.Rows[fila].Cells["Stock"].Value.ToString());
            producto.stock_minimo = int.Parse(dtgDatos.Rows[fila].Cells["Stock Minimo"].Value.ToString());
            producto.status = dtgDatos.Rows[fila].Cells["Estatus"].Value.ToString();
            producto.fkid_categoria = int.Parse(dtgDatos.Rows[fila].Cells["id_categoria"].Value.ToString());

            switch(columna)
            {
                case 10:
                    {
                        FrmAgregarProductos p = new FrmAgregarProductos();
                        p.ShowDialog();
                        dtgDatos.Columns.Clear();

                    }break;
            }
        }

        // Permite obtener las ccordenas de las filas y columnas del dtg
        private void dtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }
    }
}
