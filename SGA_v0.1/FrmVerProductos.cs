using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmVerProductos : Form
    {
        ManejadorProductos mp;
        public static Productos producto = new Productos(0, "", "", "", 0.0, 0, 0, "", 0);
        int fila = 0;
        int columna = 0;
        bool permisoModificar = false, permisoEliminar = false, permisoCrear = false;

        public FrmVerProductos()
        {
            InitializeComponent();
            mp = new ManejadorProductos();
        }


        //EVENTO CLICK PARA BUSCAR REGISTROS
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mp.Mostrar($"CALL p_BuscarProducto('{txtNombre.Text}')", dtgDatos, "productos", permisoModificar, permisoEliminar);
        }


        //EVENTO CLICK PARA AGREGAR UN NUEVO PRODUCTO
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


        //EVENTO CELL ENTER PARA OBTERNER LAS COLUMNAS Y SUS FILAS
        private void dtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;

        }

        private void FrmVerProductos_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            foreach (var permiso in FrmInicio._rolPermisosActivo.permisos)
            {
                if(permiso.fkid_modulo == 4)
                {
                    btnAgregar.Enabled = permiso.permiso_crear == "1";
                    permisoModificar = permiso.permiso_modificar == "1";
                    permisoEliminar = permiso.permiso_borrar == "1";
                }
            }
        }


        //EVENTO CELL CLICK PARA OBTENER COLUMNA DE MODIFICAR Y ELIMINAR
        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            producto.id_producto = int.Parse(dtgDatos.Rows[fila].Cells[0].Value.ToString());
            producto.nombre = dtgDatos.Rows[fila].Cells["Nombre"].Value.ToString();
            producto.descripcion = dtgDatos.Rows[fila].Cells["Descripcion"].Value.ToString();
            producto.unidad = dtgDatos.Rows[fila].Cells["Unidad"].Value.ToString();
            producto.precio_salida = double.Parse(dtgDatos.Rows[fila].Cells["Costo"].Value.ToString());
            producto.stock = int.Parse(dtgDatos.Rows[fila].Cells["Stock"].Value.ToString());
            producto.fkid_categoria = int.Parse(dtgDatos.Rows[fila].Cells["id_categoria"].Value.ToString());
            producto.stock_minimo = int.Parse(dtgDatos.Rows[fila].Cells["Stock Minimo"].Value.ToString());
            producto.status = dtgDatos.Rows[fila].Cells["Estatus"].Value.ToString();
            

            switch (columna)
            {
                case 10:
                    {
                        FrmAgregarProductos p = new FrmAgregarProductos();
                        p.ShowDialog();
                        dtgDatos.Columns.Clear();

                    }
                    break;
                case 11:
                    {
                        mp.CambiarEstatusInactivo(producto.id_producto);
                        dtgDatos.Columns.Clear();

                    }
                    break;
            }
        } 
    }
}
