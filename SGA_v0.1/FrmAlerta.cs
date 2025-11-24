using Manejadores;
using System;
using System.Drawing;
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
            md.EstiloPanelTexto(pNombre, lblAlerta, ColorTranslator.FromHtml("#8CBFAF"));
        }

       
        //EVENTO LOAD PARA MOSTRAR LOS PRODUCTOS CON BAJO STOCK
        private void FrmAlerta_Load(object sender, EventArgs e)
        {
            var resultado = manejador.ObtenerProductosBajoStock();

            LbProducto.Text = resultado.lista;

            // Si hay más de 5 productos, aumentar el tamaño del form
            if (resultado.cantidad > 5)
            {
                // Por cada producto adicional, agrandar un poco
                int extra = (resultado.cantidad - 5) * 17;

                this.Height += extra;

                // mover el botón OK hacia abajo
                BtnOk.Top += extra;
            }
        }


        //EVENTO CLICK PARA CERRAR EL FORMULARIO
        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
