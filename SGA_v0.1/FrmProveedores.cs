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
    public partial class FrmProveedores : Form
    {
        ManejadorProveedores mp;
        public static Proveedores proveedor = new Proveedores(0, "", "", "", "", "", 0, "");
        int fila = 0, columna = 0;

        public FrmProveedores()
        {
            mp = new ManejadorProveedores();
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mp.Mostrar(txtBuscar.Text, DtgDatos);
        }

        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            proveedor.id_proveedor = int.Parse(DtgDatos.Rows[fila].Cells["id_proveedor"].Value.ToString());
            proveedor.nombre = DtgDatos.Rows[fila].Cells["nombre"].Value.ToString();
            proveedor.apellido_paterno = DtgDatos.Rows[fila].Cells["apellido_paterno"].Value.ToString();
            proveedor.apellido_materno = DtgDatos.Rows[fila].Cells["apellido_materno"].Value.ToString();
            proveedor.telefono = DtgDatos.Rows[fila].Cells["telefono"].Value.ToString();
            proveedor.correo = DtgDatos.Rows[fila].Cells["correo"].Value.ToString();
            proveedor.plazo_disponibilidad = int.Parse(DtgDatos.Rows[fila].Cells["plazo_disponibilidad"].Value.ToString());
            string st = DtgDatos.Rows[fila].Cells["status"].Value.ToString();
            if (st == "A")
                proveedor.status = "Activo";
            else
                proveedor.status = "Inactivo";

            switch (columna)
            {
                case 8:
                    FrmDatosProveedores fmp = new FrmDatosProveedores();
                    fmp.ShowDialog();
                    DtgDatos.Columns.Clear();
                    break;
                case 9:
                    mp.Borrar(proveedor);
                    DtgDatos.Columns.Clear();
                    break;
            }
        }

        private void DtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            proveedor.id_proveedor = 0; proveedor.nombre = ""; proveedor.apellido_paterno = ""; proveedor.apellido_materno = "";
            proveedor.telefono = ""; proveedor.correo = ""; proveedor.plazo_disponibilidad = 0; proveedor.status = "";
            FrmDatosProveedores fmp = new FrmDatosProveedores();
            fmp.ShowDialog();
            DtgDatos.Columns.Clear();
        }

    }
}
