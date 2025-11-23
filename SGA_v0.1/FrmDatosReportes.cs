using Manejadores;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace SGA_v0._1
{
    public partial class FrmDatosReportes : Form
    {
        //INSTANCIA DE OBJETOS Y VARIABLES
        ManejadorReportes mr;
        ManejadorDiseño md;
        string tipoReporteSeleccionado = "";
        bool requiereCategoria = false;



        //CONSTRUCTOR PARA INICIALIZAR EL FORMULARIO Y OBJETOS
        public FrmDatosReportes()
        {
            InitializeComponent();
            mr = new ManejadorReportes();
            md = new ManejadorDiseño();
            md.EstiloPanelTexto(pNombre, lblNombre, ColorTranslator.FromHtml("#8CBFAF"));
            this.BackColor = ColorTranslator.FromHtml("#EDE7D5");
            md.AgregarBordeFormulario(this);
            md.EstilizarComboBox(cmbTipoAccion);
            mr.LlenarTiposReportes(cmbTipoAccion);
        }
       

        //EVENTO CLICK PARA SELECCIONAR UNA TIPO DE REPORTE
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
                md.EstilizarComboBox(cmbCategoria);
                md.EstilizarComboBox(cmbTipoAccion);
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
                    md.EstilizarDTP(dtpFechaFin);
                    md.EstilizarDTP(dtpFechaInicio);
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


        //EVENTO CLICK PARA GENERAR PARA MOSTRAR EN EL dtgDatos EL RESULTADO DE LOS FILTROS PARA EL REPORTE
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


        //EVENTO CLICK PARA SELECCIONAR EL TIPO DE REPORTE A GENERAR
        private void btnSeleccionarCategoria_Click(object sender, EventArgs e)
        {
            tipoReporteSeleccionado = cmbTipoAccion.SelectedItem.ToString();

           
            DialogResult resultado = MessageBox.Show("¿Desea filtrar el reporte por una categoria especifica?","Filtrar por Categoria",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                requiereCategoria = true;
                mr.LlenarCategorias(cmbCategoria);
                md.EstilizarComboBox(cmbCategoria);
                md.EstilizarComboBox(cmbTipoAccion);
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
                    md.EstilizarDTP(dtpFechaFin);
                    md.EstilizarDTP(dtpFechaInicio);
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


        //EVENTO CLICK PARA CERRAR FORMULARIO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenerar_MouseLeave(object sender, EventArgs e)
        {
            btnGenerar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnGenerar);
        }

        private void btnGenerar_MouseEnter(object sender, EventArgs e)
        {
            btnGenerar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            btnCancelar.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            btnCancelar.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnCancelar);
        }

        private void btnSeleccionarReporte_MouseLeave(object sender, EventArgs e)
        {
            btnSeleccionarReporte.BackColor = ColorTranslator.FromHtml("#545454");
            md.QuitarBordesBotones(btnSeleccionarReporte);
        }

        private void btnSeleccionarReporte_MouseEnter(object sender, EventArgs e)
        {
            btnSeleccionarReporte.BackColor = ColorTranslator.FromHtml("#7B8A84");
        }

        private void FrmDatosReportes_Load(object sender, EventArgs e)
        {
            md.EstilosBoton(btnCancelar);
            md.EstilosBoton(btnGenerar);
            md.EstilosBoton(btnSeleccionarReporte);
        }
    }
}