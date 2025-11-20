using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmRolesPermisos : Form
    {
        ManejadorRoles mr;
        public static Roles rol = new Roles(0,"","","");
        int fila = 0, columna = 0;

        bool permisoModificar = false, permisoBorrar = false; //PERMISOS PARA BOTONES EN DATAGRIDVIEW


        //CONSTRUCTOR PARA FORMULARIO PRINCIPAL
        public FrmRolesPermisos()
        {
            InitializeComponent();
            mr= new ManejadorRoles();
        }


        // EVENTO LOAD PARA ACTIVAR / DESACTIVAR BOTONES SEGUN PERMISOS DEL ROL
        private void FrmRolesPermisos_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            foreach(var permiso in FrmInicio._rolPermisosActivo.permisos) 
            {
                if(permiso.fkid_modulo == 8) //MODULO DE ROLES Y PERMISOS
                {
                    btnAgregar.Enabled = permiso.permiso_crear == "1";
                    permisoModificar = permiso.permiso_modificar == "1";
                    permisoBorrar = permiso.permiso_borrar == "1";
                }
            }
        }


        //EVENTO CLICK PARA BUSCAR ROLES
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mr.Mostrar($"SELECT * FROM v_DatosRolesExistentes WHERE Nombre like '%{txtBuscar.Text.Trim('\'')}%'", dtgDatos, "v_DatosRolesExistentes", permisoModificar, permisoBorrar);
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
                        mr.EliminarRol(rol);
                        dtgDatos.Columns.Clear();
                    }break;
            }
        }
    }
}
