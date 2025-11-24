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
using Manejadores;

namespace SGA_v0._1
{
    public partial class FrmInicio : Form
    {
        // CREACION DE OBJETOS Y VARIABLES
        ManejadorDiseño md;
        public static Usuarios _usuarioActivo;
        public static Roles _rolPermisosActivo;
        private ToolStripButton botonActivoActual = null;

        // CONSTRUCTOR DEL FORMULARIO
        public FrmInicio(Usuarios user, Roles rolPermisosActivo)
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            foreach (Control ctrl in this.Controls)
            {
                ctrl.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            }
            md = new ManejadorDiseño();
            _usuarioActivo = user;
            _rolPermisosActivo = rolPermisosActivo;
            tsPrincipal.BackColor = ColorTranslator.FromHtml("#B7CC18");
            tsPrincipal.ForeColor = ColorTranslator.FromHtml("#B7CC18");
            pSuperior.BackColor = ColorTranslator.FromHtml("#B7CC18");
            LblUsuarioActivo.ForeColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnCerrar);
            md.QuitarBordesBotones(btnOcultarVentana);
        }

        // EVENTO LOAD DEL FORMULARIO
        private void FrmInicio_Load(object sender, EventArgs e)
        {
            //HABILITAR O DESHABILITAR BOTONES SEGUN PERMISOS DEL ROL
            LblUsuarioActivo.Text = $"Bienvenid@: {_usuarioActivo.nombre}";
            tsbProveedores.Enabled = false;
            tsbCategorias.Enabled = false;
            tsbNotificaciones.Enabled = false;
            tsbProductos.Enabled = false;
            tsbEntradas.Enabled = false;
            tsbSalidas.Enabled = false;
            tsbReportes.Enabled = false;
            tsbRolesPermisos.Enabled = false;
            tsbUsuarios.Enabled = false;

            foreach (var permiso in _rolPermisosActivo.permisos)
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
            tsbInicio.PerformClick();
        }

        // EVENTO CLICK PARA VOLVER AL INICIO
        private void tsbInicio_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
        }


        //EVENTO CLICK PARA ABRIR FORMULARIO DE PROVEEDORES
        private void tsbProveedores_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmProveedores frmProveedores = new FrmProveedores();
            frmProveedores.MdiParent = this;
            frmProveedores.Show();

        }

        //EVENTO CLICK PAARA ABRIR FORMULARIO DE CATEGORIAS
        private void tsbCategorias_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmCategoria frmCategoria = new FrmCategoria();
            frmCategoria.MdiParent = this;
            frmCategoria.Show();
        }

        //EVENTO CLICK PARA ABRIR FORMULARIO DE PRODUCTOS
        private void tsbProductos_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmVerProductos frmVerProductos = new FrmVerProductos();
            frmVerProductos.MdiParent = this;
            frmVerProductos.Show();
        }

        //EVENTO CLICK PARA ABRIR FORMULARIO DE SALIDAS
        private void tsbSalidas_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmVerSalidaProductos frmVerSalida = new FrmVerSalidaProductos();
            frmVerSalida.MdiParent = this;
            frmVerSalida.Show();
        }

        //EVENTO CLICK PARA ABRIR FORMULARIO DE ENTRADAS
        private void tsbEntradas_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmEntradasDatos frmEntradasDatos = new FrmEntradasDatos();
            frmEntradasDatos.MdiParent = this;
            frmEntradasDatos.Show();
        }

        //EVENTO CLICK PARA ABRIR FORMULARIO DE USUARIOS
        private void tsbUsuarios_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            frmUsuarios.MdiParent = this;
            frmUsuarios.Show();
        }

        //EVENTO CLICK PARA ROLES Y PERMISOS
        private void tsbRolesPermisos_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmRolesPermisos frmRolesPermisos = new FrmRolesPermisos();
            frmRolesPermisos.MdiParent = this;
            frmRolesPermisos.Show();
        }

        //EVENTO CLICK PARA RECIBIR NOTIFICACION DE STOCK BAJO
        private void tsbNotificaciones_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmAlerta frmAlerta = new FrmAlerta();
            frmAlerta.MdiParent = this;
            frmAlerta.Show();
        }

        //EVENTO CLICK PARA GENERAR REPORTES
        private void tsbReportes_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            md.CerrarFormulariosActivos(this);
            FrmReportes fr = new FrmReportes();
            fr.MdiParent = this;
            fr.Show();
        }

        //EVENTO CLICK PARA CERRAR SESION
        private void tsbCerrarSesion_Click(object sender, EventArgs e)
        {
            md.Boton(sender, tsPrincipal, botonActivoActual);
            Application.Restart();
        }

        //EVENTO CLICK PARA CERRAR LA APLICACION
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // EVENTOS PARA DISEÑO DE INTERFAZ
        private void btnCerrar_MouseEnter(object sender, EventArgs e)
        {
            btnCerrar.BackColor = ColorTranslator.FromHtml("#8CBFAF");
        }

        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = ColorTranslator.FromHtml("#B7CC18");
        }

        private void btnOcultarVentana_MouseLeave(object sender, EventArgs e)
        {
            btnOcultarVentana.BackColor = ColorTranslator.FromHtml("#B7CC18");
        }

        private void btnOcultarVentana_MouseEnter(object sender, EventArgs e)
        {
            btnOcultarVentana.BackColor = ColorTranslator.FromHtml("#8CBFAF");
        }

        private void btnOcultarVentana_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        // FIN DE EVENTOS PARA DISEÑO DE INTERFAZ
    }
}
