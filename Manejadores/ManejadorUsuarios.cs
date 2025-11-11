using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorUsuarios
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");
        public bool valido = true;

        //METODO PARA GUARDAR USUARIOS
        public void Guardar(Usuarios usuario) 
        {
            b.Comando($"CALL p_InsertarUsuario('{usuario.nombre}','{usuario.apellido_paterno}','{usuario.apellido_materno}','{ManejadorLogin.Sha1(usuario.clave)}','{usuario.status}',{usuario.fkid_rol})");
        }

        //METODO PARA MODIFICAR USUARIOS
        public void Modificar(Usuarios usuario, bool estado) 
        {
            if (estado)
            {
                b.Comando($"CALL p_ModificarUsuario({usuario.id_usuario},'{usuario.nombre}','{usuario.apellido_paterno}','{usuario.apellido_materno}','{ManejadorLogin.Sha1(usuario.clave)}','{usuario.status}',{usuario.fkid_rol},1)");
            }
            else 
            {
                b.Comando($"CALL p_ModificarUsuario({usuario.id_usuario},'{usuario.nombre}','{usuario.apellido_paterno}','{usuario.apellido_materno}','{ManejadorLogin.Sha1(usuario.clave)}','{usuario.status}',{usuario.fkid_rol},0)");
            }
        }

        //METODO PARA BORRAR USUARIOS
        public void Borrar(Usuarios usuario)
        {
            var rs = MessageBox.Show($"¿Estas seguro de eliminar a {usuario.nombre}?","¡ATENCIÓN!",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_DesactivarUsuario({usuario.id_usuario})");
            }
        }

        //METOODO PARA MOSTRAR USUARIOS
        public void Mostrar(string consulta, DataGridView tabla, string datos) 
        {
            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta(consulta, datos).Tables[datos];
            tabla.Columns["IdUsuario"].Visible = false;
            tabla.Columns["IdRol"].Visible = false;
            tabla.Columns["Clave"].Visible=false;
            tabla.Columns.Insert(8, Boton("MODIFICAR", Color.Green));
            tabla.Columns.Insert(9, Boton("ELIMINAR", Color.Red));
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
                MessageBox.Show("Ingrese correctamente el nombre porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido =false; 
                return;
            }

            if (txtApellidoPaterno.Text.Length > 25)
            {
                MessageBox.Show("Ingrese correctamente el apellido paterno porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if (txtApellidoMaterno.Text.Length >25)
            {
                MessageBox.Show("Ingrese correctamente el apellido materno porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if (txtClave.Text.Length > 255)
            {
                MessageBox.Show("Ingrese correctamente la contraseña porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if(estado)
            {
                if (string.IsNullOrWhiteSpace(txtClave.Text)) 
                {
                    MessageBox.Show("Se requiere de una contraseña porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
