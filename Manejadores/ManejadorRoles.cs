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
    public class ManejadorRoles
    {
        Base b = new Base("localhost", "root", "2025", "SistemaGestionAlmacen");


        //METODO PARA GUARDAR ROLES
        public void GuardarRol(Roles roles) 
        {
            b.Comando($"CALL p_RegistrarRoles('{roles.nombre}','{roles.identificador}')");
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
