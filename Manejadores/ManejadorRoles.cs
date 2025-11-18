using AccesoDatos;
using Entidades;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorRoles
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");
        public bool ValidacionRolesPermisos = true;


        //METODO PARA GUARDAR ROLES
        public void GuardarRol(Roles roles) 
        {
            ValidacionRolesPermisos = true;
            var rs = b.Consulta($"CALL p_RegistrarRoles('{roles.nombre}','{roles.identificador}')", "msg");
            string mensaje = rs.Tables["msg"].Rows[0]["msg"].ToString();

            if (!mensaje.Equals("Ok"))
            {
                ValidacionRolesPermisos = false;
                MessageBox.Show(mensaje, "¡ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //METODO PARA MODIFICAR ROLES
        public void ModificarRol(Roles roles) 
        {
            ValidacionRolesPermisos = true;
            var rs = b.Consulta($"CALL p_ModificarRoles({roles.id_rol},'{roles.nombre}','{roles.identificador}')", "msg");
            string mensaje = rs.Tables["msg"].Rows[0]["msg"].ToString();

            if (!mensaje.Equals("Ok")) 
            {
                ValidacionRolesPermisos= false;
                MessageBox.Show(mensaje,"¡ATENCIÓN!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //METODO PARA ELIMINAR ROLES (CAMBIO ESTATUS)
        public void EliminarRol(Roles roles) 
        {
            var rs = MessageBox.Show($"¿Estas seguro de eliminar el registro: {roles.nombre}?", "¡ATENCIÓN!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes) 
            {
                b.Comando($"CALL p_DesactivarRoles({roles.id_rol})");
            }
        }


        //METODO PARA MOSTRAR ROLES EXISTENTES
        public void Mostrar(string consulta, DataGridView tabla, string datos)
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta(consulta, datos).Tables[datos];
            tabla.Columns["IdRol"].Visible = false;
            tabla.Columns.Insert(4, Boton("MODIFICAR", Color.Green));
            tabla.Columns.Insert(5, Boton("ELIMINAR", Color.Red));
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }


        //METODO PARA VALIDAR SI EXISTEN PERMISOS Y SI EL NOMBRE ES VALIDO
        public void ValidarRolPermisos (TextBox CajaNombre, List<Permisos> PermisosAgregados) 
        {
            ValidacionRolesPermisos = true;
            if (string.IsNullOrWhiteSpace(CajaNombre.Text) && PermisosAgregados.Count==0) 
            {
                MessageBox.Show("Complete los campos requeridos.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionRolesPermisos = false;
                return;
            }

            if(string.IsNullOrWhiteSpace(CajaNombre.Text)) 
            {
                MessageBox.Show("El nombre no puede esta vacio.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionRolesPermisos = false;
                return;
            }

            if (CajaNombre.Text.Length > 50) 
            {
                MessageBox.Show("Introduzca un nombre valido.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionRolesPermisos = false;
                return;
            }

            if(PermisosAgregados.Count == 0) 
            {
                MessageBox.Show("Se requiere registrar al menos un permiso.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ValidacionRolesPermisos = false;
                return;
            }
        }


        //METODO PARA LLENAR COMBO BOX DE MODULOS
        public void LLenarModulos(ComboBox CajaModulos) 
        {
            CajaModulos.DataSource = b.Consulta("SELECT * FROM v_ModulosExistentes", "v_ModulosExistentes").Tables[0];
            CajaModulos.DisplayMember = "NombreModulo";
            CajaModulos.ValueMember = "IdModulo";
        }


        //METODO PARA CODIFICAR EL IDENTIFICADOR
        public static string Codificacion(ComboBox cmb) 
        {
            string valor = "";
            switch (cmb.SelectedItem.ToString()) 
            {
                case "Administrador": { valor = "A"; } break;
                case "Empleado": { valor = "E"; } break;
                case "Admin. Sistema": { valor = "AS"; } break;
                case "Cliente": { valor = "C"; } break;
            }
            return valor;
        }


        //METODO PARA CREAR BOTONES EN TIEMPO DE EJECUCION
        public static DataGridViewButtonColumn Boton(string titulo, Color fondo) 
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Text = titulo;
            btn.UseColumnTextForButtonValue = true;
            btn.FlatStyle = FlatStyle.Popup;
            btn.DefaultCellStyle.BackColor = fondo;
            btn.DefaultCellStyle.ForeColor = Color.White;
            return btn;
        }
    }
}
