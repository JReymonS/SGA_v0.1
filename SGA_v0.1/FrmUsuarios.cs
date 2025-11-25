using Entidades;
using Manejadores;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmUsuarios : Form
    {
        ManejadorUsuarios mu;
        ManejadorDiseño md;
        public static Usuarios usuario = new Usuarios(0,"","","","","",0);
        int fila = 0, columna = 0;
        
        bool permisoModificar = false, permisoBorrar = false; //PERMISOS PARA BOTONES EN DATAGRIDVIEW


        //CONSTRUCTOR DEL FORMULARIO
        public FrmUsuarios()
        {
            InitializeComponent();
            mu = new ManejadorUsuarios();
            md = new ManejadorDiseño();
            md.EstiloPanelTexto(pNombre, lblNombre, ColorTranslator.FromHtml("#8CBFAF"));
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            md.AgregarBordeFormulario(this);
            md.EstilizarTextBox(txtBuscar);
            md.EstilosBoton(btnAgregar);
            md.EstilosBoton(btnBuscar);
        }


        //EVENTO LOAD PARA ACTIVAR / DESACTIVAR BOTONES SEGUN PERMISOS DEL ROL
        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = false;
            foreach (var permiso in FrmInicio._rolPermisosActivo.permisos)
            {
                if (permiso.fkid_modulo == 9) //MODULO DE USUARIOS
                {
                    btnAgregar.Enabled = permiso.permiso_crear == "1";
                    permisoModificar = permiso.permiso_modificar == "1";
                    permisoBorrar = permiso.permiso_borrar == "1";
                }
            }
        }


        //EVENTO CLICK PARA BUSCAR USUARIOS
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            mu.Mostrar($"SELECT * FROM v_Usuarios WHERE Nombre like '%{txtBuscar.Text.Trim('\'')}%'",dtgDatos,"v_Usuarios", permisoModificar, permisoBorrar);
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


        //EVENTOS PARA DISEÑO DE FORMULARIO
        private void btnBuscar_MouseEnter(object sender, EventArgs e)
        {
            btnBuscar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnBuscar_MouseLeave(object sender, EventArgs e)
        {
            btnBuscar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnBuscar);
        }
        

        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            btnAgregar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnAgregar);
        }
        //FIN DE EVENTOS PARA DISEÑO DE FORMULARIO


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
