using System;
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
    public partial class FrmUsuarios : Form
    {
        ManejadorUsuarios mu;
        public static Usuarios usuario = new Usuarios(0,"","","","","",0);
        int fila = 0, columna = 0;
        public FrmUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
        }

        //EVENTO CLICK PARA BUSCAR USUARIOS
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mu.Mostrar($"SELECT * FROM v_Usuarios WHERE Nombre like '%{txtBuscar.Text}%'",dtgDatos,"v_Usuarios");
        }


        //EVENTO CLICK PARA REGISTRAR NUEVOS USUARIOS
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            usuario.id_usuario = 0;
            usuario.nombre = "";
            usuario.apellido_paterno = "";
            usuario.apellido_materno = "";
            usuario.clave = "";
            usuario.status = "";
            usuario.fkid_rol = 0;
            FrmDatosUsuario du = new FrmDatosUsuario();
            du.ShowDialog();
            dtgDatos.Columns.Clear();
        }


        //EVENTO CELL ENTER PARA OBTENER FILAS Y COLUMNAS
        private void dtgDatos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
            columna = e.ColumnIndex;
        }


        //EVENTO CLICK PARA MODIFICAR O ELIMINAR REGISTROS
        private void dtgDatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            usuario.id_usuario = int.Parse(dtgDatos.Rows[fila].Cells[0].Value.ToString());
            usuario.nombre = dtgDatos.Rows[fila].Cells["Nombre"].Value.ToString();
            usuario.apellido_paterno = dtgDatos.Rows[fila].Cells["Apellido Paterno"].Value.ToString();
            usuario.apellido_materno = dtgDatos.Rows[fila].Cells["Apellido Materno"].Value.ToString();
            usuario.status = dtgDatos.Rows[fila].Cells["Estatus"].Value.ToString();
            usuario.fkid_rol = int.Parse(dtgDatos.Rows[fila].Cells["IdRol"].Value.ToString());

            switch (columna) 
            {
                case 8:
                    {
                        FrmDatosUsuario du = new FrmDatosUsuario();
                        du.ShowDialog();
                        dtgDatos.Columns.Clear();
                    } break;
                case 9: 
                    {
                        mu.Borrar(usuario);
                        dtgDatos.Columns.Clear();
                    } break;
            }
        }
    }
}
