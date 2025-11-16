using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorPermisos
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");


        //METODO PARA GUARDAR PERMISOS LOCALMENTE
        public void GuardarPermisos(Permisos permiso, List<Permisos> lista)
        {
            lista.Add(permiso);
        }


        //METODO PARA GUARDAR PERMISOS EN LA BD
        public void GuardarPermisoBD(Permisos permiso) 
        {
            b.Comando($"CALL p_RegistrarRolesPermisos('{permiso.permiso_crear}','{permiso.permiso_leer}','{permiso.permiso_modificar}','{permiso.permiso_borrar}',{permiso.fkid_rol},{permiso.fkid_modulo})");
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
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
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

        //FALTA ELIMINAR y Guardar nuevos permisos , verificar no duplicados 



        //METODO PARA OBTENER EL ID DEL ULTIMO REGISTRO
        public int ObtenerIdRol() 
        {
            var rs = b.Consulta("SELECT IFNULL(MAX(id_rol),0)+1 AS IdVirtual FROM roles", "roles");
            int id = Convert.ToInt32(rs.Tables[0].Rows[0]["IdVirtual"]);
            return id;
        }
    }
}
