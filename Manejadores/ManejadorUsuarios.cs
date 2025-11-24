using AccesoDatos;
using Entidades;
using System.Drawing;
using System.Web;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorUsuarios
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");
        ManejadorDiseño md = new ManejadorDiseño();
        public bool valido = true;


        //METODO PARA GUARDAR USUARIOS
        public void Guardar(Usuarios usuario) 
        {
            valido = true;
            var rs = b.Consulta($"CALL p_InsertarUsuario('{usuario.nombre}','{usuario.apellido_paterno}','{usuario.apellido_materno}','{ManejadorLogin.Sha1(usuario.clave)}','{usuario.status}',{usuario.fkid_rol})","msg");
            string mensaje = rs.Tables["msg"].Rows[0]["msg"].ToString();

            if(!mensaje.Equals("Ok")) 
            {
                valido = false;
                MessageBox.Show(mensaje, "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //METODO PARA MODIFICAR USUARIOS
        public void Modificar(Usuarios usuario, bool estado) 
        {
            valido = true;
            if (estado)
            {
                var rs = b.Consulta($"CALL p_ModificarUsuario({usuario.id_usuario},'{usuario.nombre}','{usuario.apellido_paterno}','{usuario.apellido_materno}','{ManejadorLogin.Sha1(usuario.clave)}','{usuario.status}',{usuario.fkid_rol},1)","msg");
                string mensaje = rs.Tables["msg"].Rows[0]["msg"].ToString();

                if (!mensaje.Equals("Ok")) 
                {
                    valido = false;
                    MessageBox.Show(mensaje, "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else 
            {
                var rs = b.Consulta($"CALL p_ModificarUsuario({usuario.id_usuario},'{usuario.nombre}','{usuario.apellido_paterno}','{usuario.apellido_materno}','{ManejadorLogin.Sha1(usuario.clave)}','{usuario.status}',{usuario.fkid_rol},0)", "msg");
                string mensaje = rs.Tables["msg"].Rows[0]["msg"].ToString();

                if(!mensaje.Equals("Ok")) 
                {
                    valido = false;
                    MessageBox.Show(mensaje, "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //METODO PARA BORRAR USUARIOS
        public void Borrar(Usuarios usuario)
        {
            var rs = MessageBox.Show($"¿Estas seguro de eliminar al usuario {usuario.nombre}?","¡ATENCIÓN!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_DesactivarUsuario({usuario.id_usuario})");
            }
        }


        //METOODO PARA MOSTRAR USUARIOS
        public void Mostrar(string consulta, DataGridView tabla, string datos, bool permisoModificar, bool permisoBorrar) 
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta(consulta, datos).Tables[datos];
            tabla.Columns["IdUsuario"].Visible = false;
            tabla.Columns["IdRol"].Visible = false;
            tabla.Columns["Clave"].Visible=false;
            tabla.Columns.Insert(8, Boton("MODIFICAR", Color.Green));
            tabla.Columns.Insert(9, Boton("ELIMINAR", Color.Red));
            tabla.Columns[8].Visible = permisoModificar;
            tabla.Columns[9].Visible = permisoBorrar;
            md.EstilizarData(tabla);
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }


        //METODO PARA VALIDAR CAMPOS DE REGISTRO
        public void ValidarCampos(TextBox txtNombre, TextBox txtApellidoPaterno, TextBox txtApellidoMaterno, TextBox txtClave, bool estado) 
        {
            valido = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellidoPaterno.Text) || string.IsNullOrWhiteSpace(txtApellidoMaterno.Text))
            {
                MessageBox.Show("Ingrese todos los campos porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if(txtNombre.Text.Length > 50) 
            {
                MessageBox.Show("Ingrese un nombre de usuario válido (máximo 50 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Clear();
                valido =false; 
                return;
            }

            if (txtApellidoPaterno.Text.Length > 25)
            {
                MessageBox.Show("Ingrese un apellido paterno de usuario válido (máximo 25 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidoPaterno.Clear();
                valido = false;
                return;
            }

            if (txtApellidoMaterno.Text.Length >25)
            {
                MessageBox.Show("Ingrese un apellido materno de usuario válido (máximo 25 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellidoMaterno.Clear();
                valido = false;
                return;
            }

            if (txtClave.Text.Length > 255)
            {
                MessageBox.Show("Ingrese una contraseña de usuario válida (máximo 255 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Clear();
                valido = false;
                return;
            }

            if(estado)
            {
                if (string.IsNullOrWhiteSpace(txtClave.Text)) 
                {
                    MessageBox.Show("Se requiere de una contraseña para el usuario.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    valido = false;
                    return;
                }
            }

        }


        //METODO PARA OBTENER ROLES EXISTENTES
        public void LLenarRoles(ComboBox cajaRol) 
        {
            cajaRol.DataSource = b.Consulta("SELECT * FROM v_RolesExistentes","v_RolesExistentes").Tables[0];
            cajaRol.DisplayMember = "NombreRol";
            cajaRol.ValueMember = "IdRol";
        }


        //METODO PARA CODIFICAR ESTATUS
        public string Codificacion(ComboBox cmb) 
        {
            string valor = "";
            switch (cmb.SelectedItem.ToString()) 
            {
                case "Activo": { valor = "A"; } break;
                case "Inactivo": { valor = "I"; } break; 
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
