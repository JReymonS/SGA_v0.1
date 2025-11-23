namespace SGA_v0._1
{
    partial class FrmEntradas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnMostrar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.BtnCancelar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.TxtCosto = new System.Windows.Forms.TextBox();
            this.TxtProducto = new System.Windows.Forms.TextBox();
            this.CbProveedor = new System.Windows.Forms.ComboBox();
            this.DtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DtgLista = new System.Windows.Forms.DataGridView();
            this.DtgListaR = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtIdsProductosSeleccionados = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pProveedores = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DtgLista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListaR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pProveedores.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnMostrar
            // 
            this.BtnMostrar.Location = new System.Drawing.Point(871, 219);
            this.BtnMostrar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnMostrar.Name = "BtnMostrar";
            this.BtnMostrar.Size = new System.Drawing.Size(100, 28);
            this.BtnMostrar.TabIndex = 0;
            this.BtnMostrar.Text = "Mostrar";
            this.BtnMostrar.UseVisualStyleBackColor = true;
            this.BtnMostrar.Click += new System.EventHandler(this.BtnMostrar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(868, 459);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(100, 28);
            this.BtnAgregar.TabIndex = 1;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Location = new System.Drawing.Point(663, 459);
            this.BtnConfirmar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(100, 28);
            this.BtnConfirmar.TabIndex = 2;
            this.BtnConfirmar.Text = "Confirmar";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // BtnCancelar
            // 
            this.BtnCancelar.Location = new System.Drawing.Point(901, 651);
            this.BtnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnCancelar.Name = "BtnCancelar";
            this.BtnCancelar.Size = new System.Drawing.Size(100, 28);
            this.BtnCancelar.TabIndex = 3;
            this.BtnCancelar.Text = "Cancelar";
            this.BtnCancelar.UseVisualStyleBackColor = true;
            this.BtnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(649, 651);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(100, 28);
            this.BtnGuardar.TabIndex = 4;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Location = new System.Drawing.Point(649, 394);
            this.TxtCantidad.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(132, 22);
            this.TxtCantidad.TabIndex = 5;
            // 
            // TxtCosto
            // 
            this.TxtCosto.Location = new System.Drawing.Point(868, 394);
            this.TxtCosto.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCosto.Name = "TxtCosto";
            this.TxtCosto.Size = new System.Drawing.Size(132, 22);
            this.TxtCosto.TabIndex = 6;
            // 
            // TxtProducto
            // 
            this.TxtProducto.Location = new System.Drawing.Point(871, 284);
            this.TxtProducto.Margin = new System.Windows.Forms.Padding(4);
            this.TxtProducto.Name = "TxtProducto";
            this.TxtProducto.ReadOnly = true;
            this.TxtProducto.Size = new System.Drawing.Size(132, 22);
            this.TxtProducto.TabIndex = 7;
            // 
            // CbProveedor
            // 
            this.CbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbProveedor.FormattingEnabled = true;
            this.CbProveedor.Location = new System.Drawing.Point(556, 221);
            this.CbProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.CbProveedor.Name = "CbProveedor";
            this.CbProveedor.Size = new System.Drawing.Size(160, 24);
            this.CbProveedor.TabIndex = 8;
            // 
            // DtpFecha
            // 
            this.DtpFecha.Location = new System.Drawing.Point(139, 224);
            this.DtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.DtpFecha.Name = "DtpFecha";
            this.DtpFecha.Size = new System.Drawing.Size(265, 22);
            this.DtpFecha.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(645, 293);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Producto Seleccionado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(552, 397);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(799, 394);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Costo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(461, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Proveedor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 231);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Fecha";
            // 
            // DtgLista
            // 
            this.DtgLista.AllowUserToAddRows = false;
            this.DtgLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgLista.Location = new System.Drawing.Point(28, 256);
            this.DtgLista.Margin = new System.Windows.Forms.Padding(4);
            this.DtgLista.Name = "DtgLista";
            this.DtgLista.ReadOnly = true;
            this.DtgLista.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.DtgLista.RowHeadersWidth = 51;
            this.DtgLista.Size = new System.Drawing.Size(472, 185);
            this.DtgLista.TabIndex = 15;
            this.DtgLista.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgLista_CellContentClick);
            // 
            // DtgListaR
            // 
            this.DtgListaR.AllowUserToAddRows = false;
            this.DtgListaR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgListaR.Location = new System.Drawing.Point(28, 495);
            this.DtgListaR.Margin = new System.Windows.Forms.Padding(4);
            this.DtgListaR.Name = "DtgListaR";
            this.DtgListaR.ReadOnly = true;
            this.DtgListaR.RowHeadersWidth = 51;
            this.DtgListaR.Size = new System.Drawing.Size(472, 185);
            this.DtgListaR.TabIndex = 16;
            this.DtgListaR.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgListaR_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 459);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 17;
            this.label6.Text = "Lista de registro";
            // 
            // TxtIdsProductosSeleccionados
            // 
            this.TxtIdsProductosSeleccionados.Location = new System.Drawing.Point(737, 561);
            this.TxtIdsProductosSeleccionados.Margin = new System.Windows.Forms.Padding(4);
            this.TxtIdsProductosSeleccionados.Name = "TxtIdsProductosSeleccionados";
            this.TxtIdsProductosSeleccionados.Size = new System.Drawing.Size(132, 22);
            this.TxtIdsProductosSeleccionados.TabIndex = 18;
            this.TxtIdsProductosSeleccionados.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SGA_v0._1.Properties.Resources.Proveedores;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 81);
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // pProveedores
            // 
            this.pProveedores.Controls.Add(this.lblNombre);
            this.pProveedores.Location = new System.Drawing.Point(151, 12);
            this.pProveedores.Name = "pProveedores";
            this.pProveedores.Size = new System.Drawing.Size(1056, 81);
            this.pProveedores.TabIndex = 30;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Suravaram", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(331, 0);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(299, 64);
            this.lblNombre.TabIndex = 23;
            this.lblNombre.Text = "REGISTRO DE ENTRADAS";
            this.lblNombre.Click += new System.EventHandler(this.lblNombre_Click);
            // 
            // FrmEntradas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1225, 689);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pProveedores);
            this.Controls.Add(this.TxtIdsProductosSeleccionados);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.DtgListaR);
            this.Controls.Add(this.DtgLista);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtpFecha);
            this.Controls.Add(this.CbProveedor);
            this.Controls.Add(this.TxtProducto);
            this.Controls.Add(this.TxtCosto);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.BtnCancelar);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.BtnMostrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEntradas";
            this.Text = "FrmEntradas";
            this.Load += new System.EventHandler(this.FrmEntradas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgLista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DtgListaR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pProveedores.ResumeLayout(false);
            this.pProveedores.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnMostrar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnConfirmar;
        private System.Windows.Forms.Button BtnCancelar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.TextBox TxtCosto;
        private System.Windows.Forms.TextBox TxtProducto;
        private System.Windows.Forms.ComboBox CbProveedor;
        private System.Windows.Forms.DateTimePicker DtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView DtgLista;
        private System.Windows.Forms.DataGridView DtgListaR;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtIdsProductosSeleccionados;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pProveedores;
        private System.Windows.Forms.Label lblNombre;
    }
}