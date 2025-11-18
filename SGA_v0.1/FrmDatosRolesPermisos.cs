using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        List<Permisos> ListaPermisosEliminados;
        int idLocalRol;
        int fila = -1;


        //CONSTRUCTOR PARA FORMULARIO DE ROLES Y PERMISOS
        public FrmDatosRolesPermisos()
        {
            InitializeComponent();
            mr = new ManejadorRoles();
            mp = new ManejadorPermisos();
            ListaPermisos = new List<Permisos>();
            ListaPermisosEliminados = new List<Permisos>();
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
            cmbModulo.SelectedIndexChanged += CmbModulo_SelectedIndexChanged;
        }


        //EVENTO PARA ACTIVAR O DESACTIVAR CHECKBOX´s
        private void CmbModulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mp.VerificarModulo(chkCrear,chkLeer,chkModificar,chkBorrar,cmbModulo);
        }


        //EVENTO CLICK PARA AGREGAR PERMISOS A LA LISTA
        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            mp.ValidarPermisos(chkCrear, chkLeer, chkModificar, chkBorrar, cmbModulo, ListaPermisos);

            if (!mp.ValidacionPermisos) 
            {
                return;
            }

            else 
            {
                var permisos = mp.ObtenerPermisos(chkCrear, chkLeer, chkModificar, chkBorrar);
                mp.GuardarPermisos(new Permisos(0, permisos.Crear, permisos.Leer, permisos.Modificar, permisos.Borrar, idLocalRol, int.Parse(cmbModulo.SelectedValue.ToString())), ListaPermisos);
                mp.MostrarPermisos(ListaPermisos, dtgDatosPermisos);
            }
        }


        //EVENTO CELL ENTER PARA DETECTAR FILA Y COLUMNA
        private void dtgDatosPermisos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            fila = e.RowIndex;
        }


        //METODO PARA ELIMINAR PERMISOS
        private void btnEliminarPermiso_Click(object sender, EventArgs e)
        {
            if(fila<0 || fila>=ListaPermisos.Count) 
            {
                MessageBox.Show("Seleccione un registro primero","¡ATENCIÓN!",MessageBoxButtons.OK, MessageBoxIcon.Warning); return;
            }
           
            var permisoSeleccionado = ListaPermisos[fila];

            var rs = MessageBox.Show("¿Desea eliminar el permiso seleccionado?","¡ATENCIÓN!",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes) 
            {
             
                if (FrmRolesPermisos.rol.id_rol > 0) 
                {
                    ListaPermisosEliminados.Add(permisoSeleccionado);
                }

                mp.EliminarPermisos(ListaPermisos, fila);
                mp.MostrarPermisos(ListaPermisos, dtgDatosPermisos);
                fila = -1;
            }
        }


        //EVENTO CLICK PARA GUARDAR REGISTRO ROL - PERMISOS
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            mr.ValidarRolPermisos(txtNombre,ListaPermisos);

            if (!mr.ValidacionRolesPermisos)
            {
                return;
            }

            else
            {
                if (FrmRolesPermisos.rol.id_rol == 0)
                {
                    mr.GuardarRol(new Roles(0, txtNombre.Text, ManejadorRoles.Codificacion(cmbIdentificador), "A"));
                    if (mr.ValidacionRolesPermisos)
                    {

                        foreach (var item in ListaPermisos)
                        {
                            mp.GuardarPermisoBD(new Permisos(0, item.permiso_crear, item.permiso_leer, item.permiso_modificar, item.permiso_borrar, idLocalRol, item.fkid_modulo));
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    mr.ModificarRol(new Roles(FrmRolesPermisos.rol.id_rol, txtNombre.Text, ManejadorRoles.Codificacion(cmbIdentificador), "A"));

                    if (mr.ValidacionRolesPermisos)
                    {
                        //ELIMINA PERMISOS SOLO SI ESTAN PRESENTES EN LA LISTA

                        if (ListaPermisosEliminados.Count > 0)
                        {
                            foreach (var item in ListaPermisosEliminados)
                            {
                                mp.EliminarPermisosBD(item);
                            }
                        }

                        //REGISTRA EXCLUSIVAMENTE NUEVOS PEMRISOS

                        var nuevosRegistros = ListaPermisos.Where(x => x.id_permiso == 0).ToList();

                        foreach (var item in nuevosRegistros)
                        {
                            item.fkid_rol = FrmRolesPermisos.rol.id_rol;
                            mp.GuardarPermisoBD(item);
                        }
                    }
                    else 
                    {
                        return;
                    }
                }
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
