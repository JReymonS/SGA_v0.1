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
    public partial class FrmRolesPermisos : Form
    {
        ManejadorRoles mr;
        public static Roles rol = new Roles(0,"","","");
        int fila = 0, columna = 0;


        //CONSTRUCTOR PARA FORMULARIO PRINCIPAL
        public FrmRolesPermisos()
        {
            InitializeComponent();
            mr= new ManejadorRoles();
        }


        //EVENTO CLICK PARA BUSCAR ROLES
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mr.Mostrar($"SELECT * FROM v_DatosRolesExistentes WHERE Nombre like '%{txtBuscar.Text}%'", dtgDatos, "v_DatosRolesExistentes");
        }


        //EVENTO CLICK PARA AGREGAR REGISTROS
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            rol.id_rol = 0;
            rol.nombre = "";
            rol.identificador = "";
            FrmDatosRolesPermisos drp = new FrmDatosRolesPermisos();
            drp.ShowDialog();
            dtgDatos.Columns.Clear();
        }


        //EVENTO CELL ENTER PARA OBTENER FILAS Y COLUMNAS
        private void dtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }

        //EVENTO CELL CLICK PARA MODIFICAR O ELIMINAR
        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            rol.id_rol = int.Parse(dtgDatos.Rows[fila].Cells[0].Value.ToString());
            rol.nombre = dtgDatos.Rows[fila].Cells["Nombre"].Value.ToString();
            rol.identificador = dtgDatos.Rows[fila].Cells["Identificador"].Value.ToString();
            switch (columna)
            {
                case 4: 
                    {
                        FrmDatosRolesPermisos drp = new FrmDatosRolesPermisos();
                        drp.ShowDialog();
                        dtgDatos.Columns.Clear();
                    }break;
                case 5: 
                    {
                        //Borrado
                        dtgDatos.Columns.Clear();
                    }break;
            }
        }
    }
}
