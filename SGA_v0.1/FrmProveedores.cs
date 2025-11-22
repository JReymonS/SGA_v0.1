using Entidades;
using Manejadores;
using System;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmProveedores : Form
    {
        ManejadorProveedores mp;
        public static Proveedores proveedor = new Proveedores(0, "", "", "", "", "", 0, "");
        int fila = 0, columna = 0;

        bool permisoModificar = false, permisoBorrar = false; //PERMISOS PARA BOTONES EN DATAGRIDVIEW


        //CONSTRUCTOR DEL FORMULARIO
        public FrmProveedores()
        {
            mp = new ManejadorProveedores();
            InitializeComponent();
        }


        //EVENTO LOAD PARA ACTIVAR / DESACTIVAR BOTONES SEGUN PERMISOS DEL ROL
        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            foreach(var permiso in FrmInicio._rolPermisosActivo.permisos)
            {
                if (permiso.fkid_modulo == 1) //MODULO DE PROVEEDORES
                {
                    btnAgregar.Enabled = permiso.permiso_crear == "1";
                    permisoModificar = permiso.permiso_modificar == "1";
                    permisoBorrar = permiso.permiso_borrar == "1";
                }
            }
        }


        //METODO PARA BUSCAR PROVEEDORES
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mp.Mostrar(txtBuscar.Text, DtgDatos,permisoModificar,permisoBorrar);
        }


        //METODO PARA AGREGAR PROVEEDORES
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            proveedor.id_proveedor = 0; proveedor.nombre = ""; proveedor.apellido_paterno = ""; proveedor.apellido_materno = "";
            proveedor.telefono = ""; proveedor.correo = ""; proveedor.plazo_disponibilidad = 0; proveedor.status = "";

            this.Hide();

            FrmDatosProveedores fmp = new FrmDatosProveedores();
            fmp.FormClosed += (s, args) => this.Show();
            fmp.ShowDialog();
            
            DtgDatos.Columns.Clear();
        }


        //METODO PARA CAPTURAR LA FILA Y COLUMNA SELECCIONADA
        private void DtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex; columna = e.ColumnIndex;
        }


        //METODO PARA CAPTURAR EL EVENTO DE CLIC EN LOS BOTONES DE MODIFICAR Y BORRAR
        private void DtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            proveedor.id_proveedor = int.Parse(DtgDatos.Rows[fila].Cells["id_proveedor"].Value.ToString());
            proveedor.nombre = DtgDatos.Rows[fila].Cells["Nombre"].Value.ToString();
            proveedor.apellido_paterno = DtgDatos.Rows[fila].Cells["Apellido Paterno"].Value.ToString();
            proveedor.apellido_materno = DtgDatos.Rows[fila].Cells["Apellido Materno"].Value.ToString();
            proveedor.telefono = DtgDatos.Rows[fila].Cells["Telefono"].Value.ToString();
            proveedor.correo = DtgDatos.Rows[fila].Cells["Correo"].Value.ToString();
            proveedor.plazo_disponibilidad = int.Parse(DtgDatos.Rows[fila].Cells["Plazo de Disponibilidad"].Value.ToString());
            string st = DtgDatos.Rows[fila].Cells["Estatus"].Value.ToString();
            if (st == "Activo")
                proveedor.status = "Activo";
            else
                proveedor.status = "Inactivo";

            switch (columna)
            {
                case 8:
                    FrmDatosProveedores fmp1 = new FrmDatosProveedores();

                    this.Hide();
                    fmp1.FormClosed += (s, args) => this.Show();
                    fmp1.ShowDialog();

                    DtgDatos.Columns.Clear();
                    break;
                case 9:
                    mp.Borrar(proveedor);
                    DtgDatos.Columns.Clear();
                    break;
            }
        }
    }
}
