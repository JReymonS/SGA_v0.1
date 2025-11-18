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
            LbProducto.Text = manejador.ObtenerProductoMasBajo();
        }


    }
}
