using Manejadores;
using System;
using System.Windows.Forms;

namespace SGA_v0._1
{
    public partial class FrmAlerta : Form
    {

        ManejadorAlerta manejador = new ManejadorAlerta();
        ManejadorDiseño md;


        //CONSTRUCTOR
        public FrmAlerta()
        {
            InitializeComponent();
            md = new ManejadorDiseño();
            md.EstilosBoton(BtnOk);
        }

       
        //EVENTO LOAD PARA MOSTRAR LOS PRODUCTOS CON BAJO STOCK
        private void FrmAlerta_Load(object sender, EventArgs e)
        {
            var resultado = manejador.ObtenerProductosBajoStock();

           RTxtAlertas.Text = resultado.lista;

            
        }


        //EVENTO CLICK PARA CERRAR EL FORMULARIO
        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
