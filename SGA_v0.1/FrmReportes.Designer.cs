namespace SGA_v0._1
{
    partial class FrmReportes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmReportes));
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnGenerarExcel = new System.Windows.Forms.Button();
            this.dtgDatos = new System.Windows.Forms.DataGridView();
            this.lblNombre = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pNombre = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pNombre.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Font = new System.Drawing.Font("Livvic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.Image = global::SGA_v0._1.Properties.Resources.Agregar_3;
            this.btnAgregar.Location = new System.Drawing.Point(810, 125);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(87, 45);
            this.btnAgregar.TabIndex = 1;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnAgregar.MouseEnter += new System.EventHandler(this.btnAgregar_MouseEnter);
            this.btnAgregar.MouseLeave += new System.EventHandler(this.btnAgregar_MouseLeave);
            // 
            // btnGenerarExcel
            // 
            this.btnGenerarExcel.Font = new System.Drawing.Font("Livvic", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarExcel.Location = new System.Drawing.Point(939, 125);
            this.btnGenerarExcel.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerarExcel.Name = "btnGenerarExcel";
            this.btnGenerarExcel.Size = new System.Drawing.Size(172, 45);
            this.btnGenerarExcel.TabIndex = 2;
            this.btnGenerarExcel.Text = "Generar Excel";
            this.btnGenerarExcel.UseVisualStyleBackColor = true;
            this.btnGenerarExcel.Click += new System.EventHandler(this.btnGenerarExcel_Click);
            this.btnGenerarExcel.MouseEnter += new System.EventHandler(this.btnGenerarExcel_MouseEnter);
            this.btnGenerarExcel.MouseLeave += new System.EventHandler(this.btnGenerarExcel_MouseLeave);
            // 
            // dtgDatos
            // 
            this.dtgDatos.AllowUserToAddRows = false;
            this.dtgDatos.AllowUserToResizeColumns = false;
            this.dtgDatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.dtgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatos.Location = new System.Drawing.Point(38, 197);
            this.dtgDatos.Margin = new System.Windows.Forms.Padding(2);
            this.dtgDatos.Name = "dtgDatos";
            this.dtgDatos.ReadOnly = true;
            this.dtgDatos.RowHeadersWidth = 51;
            this.dtgDatos.RowTemplate.Height = 24;
            this.dtgDatos.Size = new System.Drawing.Size(1073, 483);
            this.dtgDatos.TabIndex = 3;
            this.dtgDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellClick);
            this.dtgDatos.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgDatos_CellEnter);
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Suravaram", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(-2, -12);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(971, 67);
            this.lblNombre.TabIndex = 23;
            this.lblNombre.Text = "REPORTES";
            this.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::SGA_v0._1.Properties.Resources.Reporte;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(38, 26);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(59, 66);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pNombre
            // 
            this.pNombre.Controls.Add(this.lblNombre);
            this.pNombre.Location = new System.Drawing.Point(132, 26);
            this.pNombre.Margin = new System.Windows.Forms.Padding(2);
            this.pNombre.Name = "pNombre";
            this.pNombre.Size = new System.Drawing.Size(969, 66);
            this.pNombre.TabIndex = 28;
            // 
            // FrmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 714);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pNombre);
            this.Controls.Add(this.dtgDatos);
            this.Controls.Add(this.btnGenerarExcel);
            this.Controls.Add(this.btnAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTES";
            this.Load += new System.EventHandler(this.FrmReportes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pNombre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnGenerarExcel;
        private System.Windows.Forms.DataGridView dtgDatos;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pNombre;
    }
}