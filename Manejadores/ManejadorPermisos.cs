using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorPermisos
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");
        public bool ValidacionPermisos = true;


        //METODO PARA GUARDAR PERMISOS LOCALMENTE
        public void GuardarPermisos(Permisos permiso, List<Permisos> lista)
        {
            lista.Add(permiso);
        }


        //METODO PARA ELIMINAR PERMISOS LOCALMENTE
        public void EliminarPermisos(List<Permisos> lista, int fila) 
        {
            lista.RemoveAt(fila);
        }


        //METODO PARA GUARDAR PERMISOS EN LA BD
        public void GuardarPermisoBD(Permisos permiso) 
        {
            b.Comando($"CALL p_RegistrarRolesPermisos('{permiso.permiso_crear}','{permiso.permiso_leer}','{permiso.permiso_modificar}','{permiso.permiso_borrar}',{permiso.fkid_rol},{permiso.fkid_modulo})");
        }


        //METODO PARA ELIMINAR PERMISOS EN LA BD
        public void EliminarPermisosBD(Permisos permisos) 
        {
            b.Comando($"CALL p_EliminarPermisos({permisos.fkid_rol},{permisos.fkid_modulo})");
        }


        //METODO PARA OBTENER PERMISOS MARCADOR (CHECKBOX)
        public (string Crear, string Leer, string Modificar, string Borrar) ObtenerPermisos( CheckBox crear, CheckBox leer, CheckBox modificar, CheckBox borrar) 
        {
            string sCrear = crear.Checked ? "1":"0"; //Expresion Ternaria..
            string sLeer = leer.Checked? "1":"0";
            string sModificar = modificar.Checked? "1":"0";
            string sBorrar = borrar.Checked ? "1" : "0";

            return(sCrear, sLeer,  sModificar, sBorrar);
        }


        //METODO DE REGISTRO DE MODULOS (FIJO)
        private readonly Dictionary<int, string> NombreModulos = new Dictionary<int, string>()
        {
            {1,"Proveedores"},
            {2,"Categorias"},
            {3,"Notificaciones" },
            {4,"Productos" },
            {5,"Entradas" },
            {6,"Salidas" },
            {7,"Reportes" },
            {8,"Roles y permisos" },
            {9,"Usuarios" }
        };


        //METODO PARA MOSTRAR LISTA DE PERMISOS
        public void MostrarPermisos(List<Permisos> lista, DataGridView tabla) 
        {
            tabla.Columns.Clear();

            var datos = lista.Select(x => new
            {
                x.id_permiso,
                Crear = x.permiso_crear,
                Leer = x.permiso_leer,
                Modificar = x.permiso_modificar,
                Borrar = x.permiso_borrar,
                Rol = x.fkid_rol,
                Modulo = NombreModulos.ContainsKey(x.fkid_modulo)? NombreModulos[x.fkid_modulo]:"Desconocido"
            }).ToList();
            tabla.DataSource = datos;
            tabla.Columns["id_permiso"].Visible = false;
            tabla.Columns["Rol"].Visible=false;
        }


        //METODO PARA MOSTRAR REGISTROS DE PERMISOS YA EN BD
        public void MostrarPermisosBD(string consulta, DataGridView tabla, List<Permisos>lista)
        {
            tabla.Columns.Clear();
            lista.Clear();

            var rs = b.Consulta(consulta, "permisos").Tables[0];

            foreach (DataRow fila in rs.Rows)
            {

                var permiso = new Permisos(
                    Convert.ToInt32(fila["IdPermiso"]),
                    Convert.ToString(fila["Crear"]),
                    Convert.ToString(fila["Leer"]),
                    Convert.ToString(fila["Modificar"]),
                    Convert.ToString(fila["Borrar"]),
                    Convert.ToInt32(fila["IdRol"]),
                    Convert.ToInt32(fila["IdModulo"])
                );
                
                lista.Add(permiso);
            }
            MostrarPermisos(lista,tabla); //UTILZA VISTA LOCAL PARA MOSTRAR EL NOMBRE DEL MODULO
        }


        //VALIDAR EXISTENCIA DE MODULOS DUPLICADOS O SI NO HAY CHECKBOX ACTIVOS
        public void ValidarPermisos(CheckBox crear, CheckBox leer, CheckBox modificar, CheckBox borrar,ComboBox modulo, List<Permisos>PermisosAgregados)
        {
            ValidacionPermisos=true;
            if(!(crear.Checked || leer.Checked || modificar.Checked || borrar.Checked) && !modulo.Text.Equals("Notificaciones") && !modulo.Text.Equals("Entradas") && !modulo.Text.Equals("Salidas") && !modulo.Text.Equals("Reportes")) 
            {
                MessageBox.Show("Marque al menos un permiso (Crear / Leer / Modificar / Borrar).","¡ATENCIÓN!",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionPermisos = false;
                return;
            }

            if(!leer.Checked && modulo.Text.Equals("Notificaciones")) 
            {
                MessageBox.Show("Marque el permios de (Leer) para poder agregar.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionPermisos = false;
                return;
            }

            if(!(crear.Checked || leer.Checked || modificar.Checked) && (modulo.Text.Equals("Entradas") || modulo.Text.Equals("Salidas"))) 
            {
                MessageBox.Show("Marque el permios de (Crear / Leer / Modificar) para poder agregar.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionPermisos = false;
                return;
            }

            if(!(crear.Checked || leer.Checked || borrar.Checked) && modulo.Text.Equals("Reportes")) 
            {
                MessageBox.Show("Marque el permios de (Crear / Leer / Borrar) para poder agregar.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionPermisos = false;
                return;
            }

            int moduloId = int.Parse(modulo.SelectedValue.ToString());
            if (PermisosAgregados.Any(x => x.fkid_modulo == moduloId)) 
            {
                MessageBox.Show("El modulo seleccionado ya se encuentra en uso.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionPermisos = false;
                return;
            }
        }


        //METODO PARA ACTIVAR O DESACTIVAR CHECKBOX PARA MODULOS ESPECIFICOS
        public void VerificarModulo(CheckBox crear, CheckBox leer,CheckBox modificar, CheckBox borrar, ComboBox modulo) 
        {

            crear.Enabled = true;
            crear.Checked = false;
            leer.Enabled = true;
            leer.Checked = false;
            modificar.Enabled = true;
            modificar.Checked = false;
            borrar.Enabled = true;
            borrar.Checked = false;

            if (modulo.Text.Equals("Notificaciones")) 
            {
                crear.Enabled = false;
                modificar.Enabled = false;
                borrar.Enabled = false;
            }

            if (modulo.Text.Equals("Entradas") || modulo.Text.Equals("Salidas")) 
            {
                borrar.Enabled = false;
            }

            if (modulo.Text.Equals("Reportes")) 
            {
                modificar.Enabled = false;
            }
        }


        //METODO PARA OBTENER EL ID DEL ULTIMO REGISTRO
        public int ObtenerIdRol() 
        {
            var rs = b.Consulta("SELECT IFNULL(MAX(id_rol),0)+1 AS IdVirtual FROM roles", "roles");
            int id = Convert.ToInt32(rs.Tables[0].Rows[0]["IdVirtual"]);
            return id;
        }
    }
}
