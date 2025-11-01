using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmInicio : Form
    {
        private Usuarios _usuarioActivo;
        private Roles _rolPermisosActivo;
        public FrmInicio(Usuarios user, Roles rolPermisosActivo)
        {
            InitializeComponent();
            _usuarioActivo = user;
            _rolPermisosActivo = rolPermisosActivo;
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            //HABILITAR O DESHABILITAR BOTONES SEGUN PERMISOS DEL ROL
            tsbProveedores.Enabled = false;
            tsbCategorias.Enabled = false;
            tsbNotificaciones.Enabled = false;
            tsbProductos.Enabled= false;
            tsbEntradas.Enabled= false;
            tsbSalidas.Enabled= false;
            tsbReportes.Enabled= false;
            tsbRolesPermisos.Enabled= false;
            tsbUsuarios.Enabled= false;

            foreach(var permiso in _rolPermisosActivo.permisos) 
            {
                switch (permiso.fkid_modulo) 
                {
                    case 1:
                        tsbProveedores.Enabled = permiso.permiso_leer == "1";
                        break;
                    case 2:
                        tsbCategorias.Enabled = permiso.permiso_leer == "1";
                        break;
                    case 3: 
                        tsbNotificaciones.Enabled = permiso.permiso_leer == "1";
                        break;
                    case 4:
                        tsbProductos.Enabled = permiso.permiso_leer == "1";
                        break;
                    case 5:
                        tsbEntradas.Enabled = permiso.permiso_leer == "1";
                        break;
                    case 6:
                        tsbSalidas.Enabled = permiso.permiso_leer == "1";
                        break;
                    case 7:
                        tsbReportes.Enabled = permiso.permiso_leer == "1";
                        break;
                    case 8:
                        tsbRolesPermisos.Enabled = permiso.permiso_leer == "1";
                        break;
                    case 9:
                        tsbUsuarios.Enabled = permiso.permiso_leer == "1";
                        break;
                }
            }
        }
    }
}
