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
    public partial class FrmDatosRolesPermisos : Form
    {
        ManejadorRoles mr;
        ManejadorPermisos mp;
        List<Permisos> ListaPermisos;
        int idLocalRol;


        //CONSTRUCTOR PARA FORMULARIO DE ROLES Y PERMISOS
        public FrmDatosRolesPermisos()
        {
            InitializeComponent();
            mr = new ManejadorRoles();
            mp = new ManejadorPermisos();
            ListaPermisos = new List<Permisos>();
            mr.LLenarModulos(cmbModulo);

            if(FrmRolesPermisos.rol.id_rol>0)
            {
                txtNombre.Text = FrmRolesPermisos.rol.nombre;
                cmbIdentificador.Text = FrmRolesPermisos.rol.identificador;
                mp.MostrarPermisosBD($"SELECT * FROM v_PermisosAgregados WHERE IdRol={FrmRolesPermisos.rol.id_rol}",dtgDatosPermisos,ListaPermisos);
            }
            else 
            {
                idLocalRol = mp.ObtenerIdRol();
                cmbIdentificador.SelectedIndex = 0;
            }
        }


        //EVENTO CLICK PARA AGREGAR PERMISOS A LA LISTA
        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            var permisos = mp.ObtenerPermisos(chkCrear, chkLeer, chkModificar,chkBorrar);
            mp.GuardarPermisos(new Permisos(0,permisos.Crear,permisos.Leer,permisos.Modificar,permisos.Borrar,idLocalRol,int.Parse(cmbModulo.SelectedValue.ToString())), ListaPermisos);
            mp.MostrarPermisos(ListaPermisos,dtgDatosPermisos); //falta VERIFICAR QUE ESTEN MINIMO EN CHECK ALGUN PERMISO Y QUE NO SE REPITAN LOS MODULOS
        }


        //EVENTO CLICK PARA GUARDAR REGISTRO ROL - PERMISOS
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (FrmRolesPermisos.rol.id_rol == 0)
            {
                mr.GuardarRol(new Roles(0, txtNombre.Text, ManejadorRoles.Codificacion(cmbIdentificador), "A"));

                foreach (var item in ListaPermisos)
                {
                    mp.GuardarPermisoBD(new Permisos(0, item.permiso_crear, item.permiso_leer, item.permiso_modificar, item.permiso_borrar, idLocalRol, item.fkid_modulo));
                }
            }
            else 
            {
                MessageBox.Show("Modificacion"); //Realizar procedimientos
                MessageBox.Show(FrmRolesPermisos.rol.id_rol.ToString());
            }
            Close();
        }


        //EVENTO CLICK PARA CERRAR REGISTRO DE ROLES Y PERMISOS
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
