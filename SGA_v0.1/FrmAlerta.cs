using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Manejadores;

namespace SGA_v0._1
{
    public partial class FrmAlerta : Form
    {

        ManejadorAlerta manejador = new ManejadorAlerta();
        public FrmAlerta()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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



    }
}
