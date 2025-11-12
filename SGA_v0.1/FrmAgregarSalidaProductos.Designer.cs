namespace SGA_v0._1
{
    partial class FrmAgregarSalidaProductos
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.dtgMostrarProductos = new System.Windows.Forms.DataGridView();
            this.dtgListaProductos = new System.Windows.Forms.DataGridView();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMostrarProductos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(425, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "REGISTROS DE SALIDA";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1014, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cantidad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(955, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Producto Seleccionado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(1130, 264);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 22);
            this.txtCantidad.TabIndex = 5;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(1130, 203);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.ReadOnly = true;
            this.txtProducto.Size = new System.Drawing.Size(248, 22);
            this.txtProducto.TabIndex = 6;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(757, 610);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(579, 610);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1017, 331);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // dtgMostrarProductos
            // 
            this.dtgMostrarProductos.AllowUserToAddRows = false;
            this.dtgMostrarProductos.AllowUserToResizeColumns = false;
            this.dtgMostrarProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMostrarProductos.Location = new System.Drawing.Point(96, 191);
            this.dtgMostrarProductos.Name = "dtgMostrarProductos";
            this.dtgMostrarProductos.ReadOnly = true;
            this.dtgMostrarProductos.RowHeadersWidth = 51;
            this.dtgMostrarProductos.RowTemplate.Height = 24;
            this.dtgMostrarProductos.Size = new System.Drawing.Size(708, 150);
            this.dtgMostrarProductos.TabIndex = 12;
            this.dtgMostrarProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMostrarProductos_CellClick);
            this.dtgMostrarProductos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMostrarProductos_CellContentClick);
            this.dtgMostrarProductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgMostrarProductos_CellEnter);
            // 
            // dtgListaProductos
            // 
            this.dtgListaProductos.AllowUserToAddRows = false;
            this.dtgListaProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgListaProductos.Location = new System.Drawing.Point(96, 430);
            this.dtgListaProductos.Name = "dtgListaProductos";
            this.dtgListaProductos.ReadOnly = true;
            this.dtgListaProductos.RowHeadersWidth = 51;
            this.dtgListaProductos.RowTemplate.Height = 24;
            this.dtgListaProductos.Size = new System.Drawing.Size(708, 150);
            this.dtgListaProductos.TabIndex = 12;
            this.dtgListaProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaProductos_CellClick);
            this.dtgListaProductos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgListaProductos_CellEnter);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(828, 499);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmar.TabIndex = 13;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Lista de Productos";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(96, 124);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(200, 22);
            this.dtpFecha.TabIndex = 15;
            // 
            // FrmAgregarSalidaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1566, 693);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.dtgListaProductos);
            this.Controls.Add(this.dtgMostrarProductos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtProducto);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmAgregarSalidaProductos";
            this.Text = "FrmAgregarSalidaProductos";
            ((System.ComponentModel.ISupportInitialize)(this.dtgMostrarProductos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgListaProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.DataGridView dtgMostrarProductos;
        private System.Windows.Forms.DataGridView dtgListaProductos;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpFecha;
    }
}