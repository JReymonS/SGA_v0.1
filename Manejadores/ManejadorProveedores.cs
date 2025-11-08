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
            var rs = MessageBox.Show($"¿Esta seguro de desactivar a {proveedor.nombre}?",
                "ATENCIÓN!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                b.Comando($"CALL p_DesactivarProveedor({proveedor.id_proveedor})");
            }
        }

        //METODO PARA MOSTRAR PROVEEDORES
        public void Mostrar(string consulta, DataGridView tabla)
        {

            tabla.Columns.Clear();
            tabla.DataSource = b.Consulta($"select * from v_Proveedores where (Nombre like '%{consulta.Trim('\'')}%')", "proveedores").Tables[0];
            tabla.Columns["id_proveedor"].Visible = false;
            tabla.Columns.Insert(8, Boton("Modificar", Color.Green));
            tabla.Columns.Insert(9, Boton("Eliminar", Color.Red));
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
                MessageBox.Show("Ingrese correctamente el nombre porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if( txtApPa.Text.Length > 25)
            {
                MessageBox.Show("Ingrese correctamente el apellido paterno porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if (txtApMa.Text.Length > 25)
            {
                MessageBox.Show("Ingrese correctamente el apellido materno porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if (txtTelefono.Text.Length > 12)
            {
                MessageBox.Show("Ingrese correctamente el telefono porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if(txtCorreo.Text.Length > 100) 
            {
                MessageBox.Show("Ingrese correctamente el correo porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                valido = false;
                return;
            }

            if (int.TryParse(txtPlazo.Text, out int rs0))
            {
                if (rs0 < 0)
                {
                    MessageBox.Show("El plazo de disponibilidad no puede ser negativo.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    valido = false;
                    return;
                }
            }
            else if(!int.TryParse(txtPlazo.Text, out int rs1))
            {
                MessageBox.Show("Ingrese correctamente el plazo de disponibilidad porfavor.", "¡ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
