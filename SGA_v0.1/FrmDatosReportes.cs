using Entidades;
using Manejadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SGA_v0._1
{
    public partial class FrmDatosReportes : Form
    {
        // INSTANCIA DE OBJETOS Y VARIABLES
        ManejadorReportes mr;
        string tipoReporteSeleccionado = "";
        bool requiereCategoria = false;


        // CONSTRUCTOR PARA INICIALIZAR EL FORMULARIO Y OBJETOS
        public FrmDatosReportes()
        {
            InitializeComponent();
            mr = new ManejadorReportes();
            mr.LlenarTiposReportes(cmbTipoAccion);

        }
       
        // BOTÓN PARA SELECCIONAR UNA TIPO DE REPORTE
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            tipoReporteSeleccionado = cmbTipoAccion.SelectedItem.ToString();

            
            DialogResult resultado = MessageBox.Show(
                "¿Desea filtrar el reporte por alguna categoria especifica?", "Filtrar por Categoria", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                requiereCategoria = true;
                mr.LlenarCategorias(cmbCategoria);
                cmbCategoria.Visible = true;
                if (lblCategoria != null) 
                    lblCategoria.Visible = true;
            }
            else
            {
                requiereCategoria = false;
                cmbCategoria.Visible = false;
                if (lblCategoria != null) 
                    lblCategoria.Visible = false;
            }

            switch (tipoReporteSeleccionado)
            {
                case "Productos de Entrada":
                case "Productos de Salida":
                    dtpFechaInicio.Visible = true;
                    dtpFechaFin.Visible = true;
                    if (lblFechaInicio != null) 
                        lblFechaInicio.Visible = true;
                    if (lblFechaFin != null) 
                        lblFechaFin.Visible = true;
                    break;

                case "Productos en Stock Bajo":
                case "Productos mas Vendidos":
                case "Productos Stock Actual":
                    dtpFechaInicio.Visible = false;
                    dtpFechaFin.Visible = false;
                    if (lblFechaInicio != null) 
                        lblFechaInicio.Visible = false;
                    if (lblFechaFin != null) 
                        lblFechaFin.Visible = false;
                    break;
            }

            btnGenerar.Visible = true;
        }

        // BOTÓN GENERAR PARA MOSTRAR EN EL dtgDatos EL RESULTADO DE LOS FILTROS PARA EL REPORTE
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            string categoria = "";
            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = DateTime.Now;

            if (requiereCategoria)
            {
                if (cmbCategoria.SelectedItem is DataRowView)
                {
                    DataRowView row = (DataRowView)cmbCategoria.SelectedItem;
                    categoria = row["nombre"].ToString().Trim();
                }
                else
                {
                    categoria = cmbCategoria.Text.Trim();
                }
            }
            
            switch (tipoReporteSeleccionado)
            {
                case "Productos de Entrada":
                case "Productos de Salida":
                    if (dtpFechaInicio.Value > dtpFechaFin.Value)
                    {
                        MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    fechaInicio = dtpFechaInicio.Value;
                    fechaFin = dtpFechaFin.Value;
                    break;
            }

            if (FrmUsuarioSesion.Usuario == null)
            {
                MessageBox.Show("No hay un usuario en sesion. Por favor inicie sesion nuevamente.", "Error de Sesion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombreUsuario = FrmUsuarioSesion.Usuario.nombre;
            FrmReportes frmReportes = null;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmReportes)
                {
                    frmReportes = (FrmReportes)form;
                    break;
                }
            }

            
            if (frmReportes == null)
            {
                frmReportes = new FrmReportes();
                frmReportes.Show();
            }
            else
            {
                
                frmReportes.Focus();
            }
            frmReportes.GenerarReporte(tipoReporteSeleccionado, fechaInicio, fechaFin, categoria, nombreUsuario);
            this.Close();
        }

        // BOTON PARA SELECCIONAR EL TIPO DE REPORTE A GENERAR

        private void btnSeleccionarCategoria_Click(object sender, EventArgs e)
        {
            tipoReporteSeleccionado = cmbTipoAccion.SelectedItem.ToString();

           
            DialogResult resultado = MessageBox.Show("¿Desea filtrar el reporte por una categoria especifica?","Filtrar por Categoria",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                requiereCategoria = true;
                mr.LlenarCategorias(cmbCategoria);
                cmbCategoria.Visible = true;
                if (lblCategoria != null) 
                    lblCategoria.Visible = true;
            }
            else
            {
                requiereCategoria = false;
                cmbCategoria.Visible = false;
                if (lblCategoria != null)
                    lblCategoria.Visible = false;
            }

            switch (tipoReporteSeleccionado)
            {
                case "Productos de Entrada":
                case "Productos de Salida":
                    dtpFechaInicio.Visible = true;
                    dtpFechaFin.Visible = true;
                    if (lblFechaInicio != null) 
                        lblFechaInicio.Visible = true;
                    if (lblFechaFin != null) 
                        lblFechaFin.Visible = true;
                    break;

                case "Productos en Stock Bajo":
                case "Productos mas Vendidos":
                case "Productos Stock Actual":
                    dtpFechaInicio.Visible = false;
                    dtpFechaFin.Visible = false;
                    if (lblFechaInicio != null) 
                        lblFechaInicio.Visible = false;
                    if (lblFechaFin != null) 
                        lblFechaFin.Visible = false;
                    break;
            }
            btnGenerar.Visible = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}