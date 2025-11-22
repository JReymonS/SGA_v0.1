namespace SGA_v0._1
{
    partial class FrmEntradasDatos
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
            this.DtgDatos = new System.Windows.Forms.DataGridView();
            this.BtnBuscar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DtpEntradas = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // DtgDatos
            // 
            this.DtgDatos.AllowUserToAddRows = false;
            this.DtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DtgDatos.Location = new System.Drawing.Point(140, 132);
            this.DtgDatos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DtgDatos.Name = "DtgDatos";
            this.DtgDatos.RowHeadersWidth = 51;
            this.DtgDatos.Size = new System.Drawing.Size(911, 391);
            this.DtgDatos.TabIndex = 0;
            this.DtgDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgDatos_CellContentClick);
            this.DtgDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DtgDatos_CellEnter);
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Location = new System.Drawing.Point(836, 82);
            this.BtnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(100, 28);
            this.BtnBuscar.TabIndex = 2;
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.UseVisualStyleBackColor = true;
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.Location = new System.Drawing.Point(951, 82);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(100, 28);
            this.BtnAgregar.TabIndex = 3;
            this.BtnAgregar.Text = "+";
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(497, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Entradas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(136, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha";
            // 
            // DtpEntradas
            // 
            this.DtpEntradas.Location = new System.Drawing.Point(288, 89);
            this.DtpEntradas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DtpEntradas.Name = "DtpEntradas";
            this.DtpEntradas.Size = new System.Drawing.Size(291, 22);
            this.DtpEntradas.TabIndex = 6;
            // 
            // FrmEntradasDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.DtpEntradas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnAgregar);
            this.Controls.Add(this.BtnBuscar);
            this.Controls.Add(this.DtgDatos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmEntradasDatos";
            this.Text = "FrmEntradasDatos";
            this.Load += new System.EventHandler(this.FrmEntradasDatos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DtgDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DtgDatos;
        private System.Windows.Forms.Button BtnBuscar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker DtpEntradas;
    }
}