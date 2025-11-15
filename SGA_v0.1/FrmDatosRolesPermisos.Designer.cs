namespace SGA_v0._1
{
    partial class FrmDatosRolesPermisos
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbIdentificador = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbModulo = new System.Windows.Forms.ComboBox();
            this.dtgDatosPermisos = new System.Windows.Forms.DataGridView();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAgregarPermiso = new System.Windows.Forms.Button();
            this.btnEliminarPermiso = new System.Windows.Forms.Button();
            this.chkCrear = new System.Windows.Forms.CheckBox();
            this.chkLeer = new System.Windows.Forms.CheckBox();
            this.chkModificar = new System.Windows.Forms.CheckBox();
            this.chkBorrar = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(339, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "ROLES Y PERMISOS";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(88, 79);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(429, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // cmbIdentificador
            // 
            this.cmbIdentificador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIdentificador.FormattingEnabled = true;
            this.cmbIdentificador.Location = new System.Drawing.Point(667, 77);
            this.cmbIdentificador.Name = "cmbIdentificador";
            this.cmbIdentificador.Size = new System.Drawing.Size(121, 24);
            this.cmbIdentificador.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(578, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Identificador:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(606, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Modulo:";
            // 
            // cmbModulo
            // 
            this.cmbModulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModulo.FormattingEnabled = true;
            this.cmbModulo.Location = new System.Drawing.Point(667, 129);
            this.cmbModulo.Name = "cmbModulo";
            this.cmbModulo.Size = new System.Drawing.Size(121, 24);
            this.cmbModulo.TabIndex = 6;
            // 
            // dtgDatosPermisos
            // 
            this.dtgDatosPermisos.AllowUserToAddRows = false;
            this.dtgDatosPermisos.AllowUserToResizeColumns = false;
            this.dtgDatosPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgDatosPermisos.Location = new System.Drawing.Point(12, 206);
            this.dtgDatosPermisos.Name = "dtgDatosPermisos";
            this.dtgDatosPermisos.ReadOnly = true;
            this.dtgDatosPermisos.Size = new System.Drawing.Size(505, 166);
            this.dtgDatosPermisos.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(684, 296);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(104, 34);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(684, 359);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(104, 34);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnAgregarPermiso
            // 
            this.btnAgregarPermiso.Location = new System.Drawing.Point(538, 206);
            this.btnAgregarPermiso.Name = "btnAgregarPermiso";
            this.btnAgregarPermiso.Size = new System.Drawing.Size(75, 28);
            this.btnAgregarPermiso.TabIndex = 10;
            this.btnAgregarPermiso.Text = "Agregar";
            this.btnAgregarPermiso.UseVisualStyleBackColor = true;
            // 
            // btnEliminarPermiso
            // 
            this.btnEliminarPermiso.Location = new System.Drawing.Point(538, 252);
            this.btnEliminarPermiso.Name = "btnEliminarPermiso";
            this.btnEliminarPermiso.Size = new System.Drawing.Size(75, 28);
            this.btnEliminarPermiso.TabIndex = 11;
            this.btnEliminarPermiso.Text = "Eliminar";
            this.btnEliminarPermiso.UseVisualStyleBackColor = true;
            // 
            // chkCrear
            // 
            this.chkCrear.AutoSize = true;
            this.chkCrear.Location = new System.Drawing.Point(26, 137);
            this.chkCrear.Name = "chkCrear";
            this.chkCrear.Size = new System.Drawing.Size(59, 20);
            this.chkCrear.TabIndex = 12;
            this.chkCrear.Text = "Crear";
            this.chkCrear.UseVisualStyleBackColor = true;
            // 
            // chkLeer
            // 
            this.chkLeer.AutoSize = true;
            this.chkLeer.Location = new System.Drawing.Point(147, 137);
            this.chkLeer.Name = "chkLeer";
            this.chkLeer.Size = new System.Drawing.Size(53, 20);
            this.chkLeer.TabIndex = 13;
            this.chkLeer.Text = "Leer";
            this.chkLeer.UseVisualStyleBackColor = true;
            // 
            // chkModificar
            // 
            this.chkModificar.AutoSize = true;
            this.chkModificar.Location = new System.Drawing.Point(261, 137);
            this.chkModificar.Name = "chkModificar";
            this.chkModificar.Size = new System.Drawing.Size(81, 20);
            this.chkModificar.TabIndex = 14;
            this.chkModificar.Text = "Modificar";
            this.chkModificar.UseVisualStyleBackColor = true;
            // 
            // chkBorrar
            // 
            this.chkBorrar.AutoSize = true;
            this.chkBorrar.Location = new System.Drawing.Point(399, 137);
            this.chkBorrar.Name = "chkBorrar";
            this.chkBorrar.Size = new System.Drawing.Size(63, 20);
            this.chkBorrar.TabIndex = 15;
            this.chkBorrar.Text = "Borrar";
            this.chkBorrar.UseVisualStyleBackColor = true;
            // 
            // FrmDatosRolesPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 423);
            this.Controls.Add(this.chkBorrar);
            this.Controls.Add(this.chkModificar);
            this.Controls.Add(this.chkLeer);
            this.Controls.Add(this.chkCrear);
            this.Controls.Add(this.btnEliminarPermiso);
            this.Controls.Add(this.btnAgregarPermiso);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtgDatosPermisos);
            this.Controls.Add(this.cmbModulo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbIdentificador);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDatosRolesPermisos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDatosRolesPermisos";
            ((System.ComponentModel.ISupportInitialize)(this.dtgDatosPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.ComboBox cmbIdentificador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbModulo;
        private System.Windows.Forms.DataGridView dtgDatosPermisos;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAgregarPermiso;
        private System.Windows.Forms.Button btnEliminarPermiso;
        private System.Windows.Forms.CheckBox chkCrear;
        private System.Windows.Forms.CheckBox chkLeer;
        private System.Windows.Forms.CheckBox chkModificar;
        private System.Windows.Forms.CheckBox chkBorrar;
    }
}