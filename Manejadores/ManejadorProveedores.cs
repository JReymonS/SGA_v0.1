using AccesoDatos;
using Entidades;
using System.Drawing;
using System.Windows.Forms;

namespace Manejadores
{
    public class ManejadorProveedores
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");
        public bool valido = true; //VARIABLE PARA VALIDAR CAMPOS


        //METODO PARA GUARDAR PROVEEDORES
        public void Guardar(Proveedores proveedor)
        {
            b.Comando($"CALL p_AgregarProveedor('{proveedor.nombre}','{proveedor.apellido_paterno}','{proveedor.apellido_materno}','{proveedor.telefono}','{proveedor.correo}',{proveedor.plazo_disponibilidad},'{proveedor.status}')");
        }


        //METODO PARA MODIFICAR PROVEEDORES
        public void Modificar(Proveedores proveedor)
        {
            b.Comando($"CALL p_ModificarProveedor ('{proveedor.id_proveedor}','{proveedor.nombre}','{proveedor.apellido_paterno}','{proveedor.apellido_materno}'," +
                $"'{proveedor.telefono}','{proveedor.correo}',{proveedor.plazo_disponibilidad},'{proveedor.status}')");
        }


        //METODO PARA BORRAR PROVEEDORES
        public void Borrar(Proveedores proveedor)
        {
            var rs = MessageBox.Show($"¿Esta seguro de eliminar al proveedor {proveedor.nombre}?","ATENCIÓN!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_DesactivarProveedor({proveedor.id_proveedor})");
            }
        }


        //METODO PARA MOSTRAR PROVEEDORES
        public void Mostrar(string consulta, DataGridView tabla, bool permisoModificar, bool permisoBorrar)
        {

            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta($"select * from v_Proveedores where (Nombre like '%{consulta.Trim('\'')}%')", "proveedores").Tables[0];
            tabla.Columns["id_proveedor"].Visible = false;
            tabla.Columns.Insert(8, Boton("Modificar", Color.Green));
            tabla.Columns.Insert(9, Boton("Eliminar", Color.Red));
            tabla.Columns[8].Visible = permisoModificar; 
            tabla.Columns[9].Visible = permisoBorrar; 
            tabla.AutoResizeColumns();
            tabla.AutoResizeRows();
        }


        //METODO PARA VALIDAR CAMPOS DE REGISTRO
        public void ValidarCampos(TextBox txtNombre, TextBox txtApPa, TextBox txtApMa, TextBox txtTelefono, TextBox txtCorreo, TextBox txtPlazo ) 
        {
            valido = true;
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApPa.Text) || string.IsNullOrWhiteSpace(txtApMa.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtPlazo.Text))
            {
                MessageBox.Show("Ingrese todos los campos porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if (txtNombre.Text.Length > 25) 
            {
                MessageBox.Show("Ingrese un nombre de proveedor válido (máximo 25 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Clear();
                valido = false;
                return;
            }

            if( txtApPa.Text.Length > 25)
            {
                MessageBox.Show("Ingrese un apellido paterno de proveedor válido (máximo 25 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApPa.Clear();
                valido = false;
                return;
            }

            if (txtApMa.Text.Length > 25)
            {
                MessageBox.Show("Ingrese un apellido materno de proveedor válido (máximo 25 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApMa.Clear();
                valido = false;
                return;
            }

            if (txtTelefono.Text.Length > 12)
            {
                MessageBox.Show("Ingrese un telefono del proveedor válido (máximo 12 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Clear();
                valido = false;
                return;
            }

            if(txtCorreo.Text.Length > 100) 
            {
                MessageBox.Show("Ingrese un correo del proveedor válido (máximo 100 caracteres).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Clear();
                valido = false;
                return;
            }

            if (int.TryParse(txtPlazo.Text, out int rs0))
            {
                if (rs0 < 0)
                {
                    MessageBox.Show("El plazo de disponibilidad del proveedor no puede ser negativo.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPlazo.Clear();
                    valido = false;
                    return;
                }
            }
            else if(!int.TryParse(txtPlazo.Text, out int rs1))
            {
                MessageBox.Show("Ingrese un plazo de disponibilidad de proveedor válido (número entero).", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPlazo.Clear();
                valido = false;
                return;
            }
        }


        //METODO PARA CREAR BOTONES EN DATAGRIDVIEW EN TIEMPO DE EJECUCION
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
