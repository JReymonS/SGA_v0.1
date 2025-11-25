namespace SGA_v0._1
{
    partial class FrmInicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.LblUsuarioActivo = new System.Windows.Forms.Label();
            this.pSuperior = new System.Windows.Forms.Panel();
            this.tsbInicio = new System.Windows.Forms.ToolStripButton();
            this.tsbProveedores = new System.Windows.Forms.ToolStripButton();
            this.tsbCategorias = new System.Windows.Forms.ToolStripButton();
            this.tsbNotificaciones = new System.Windows.Forms.ToolStripButton();
            this.tsbProductos = new System.Windows.Forms.ToolStripButton();
            this.tsbEntradas = new System.Windows.Forms.ToolStripButton();
            this.tsbSalidas = new System.Windows.Forms.ToolStripButton();
            this.tsbReportes = new System.Windows.Forms.ToolStripButton();
            this.tsbRolesPermisos = new System.Windows.Forms.ToolStripButton();
            this.tsbUsuarios = new System.Windows.Forms.ToolStripButton();
            this.tsbCerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnOcultarVentana = new System.Windows.Forms.Button();
            this.pbUsuario = new System.Windows.Forms.PictureBox();
            this.tsPrincipal.SuspendLayout();
            this.pSuperior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
            this.tsPrincipal.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbInicio,
            this.tsbProveedores,
            this.tsbCategorias,
            this.tsbNotificaciones,
            this.tsbProductos,
            this.tsbEntradas,
            this.tsbSalidas,
            this.tsbReportes,
            this.tsbRolesPermisos,
            this.tsbUsuarios,
            this.tsbCerrarSesion});
            this.tsPrincipal.Location = new System.Drawing.Point(0, 81);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Padding = new System.Windows.Forms.Padding(0);
            this.tsPrincipal.Size = new System.Drawing.Size(85, 674);
            this.tsPrincipal.TabIndex = 1;
            this.tsPrincipal.Text = "MENU";
            // 
            // LblUsuarioActivo
            // 
            this.LblUsuarioActivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUsuarioActivo.AutoSize = true;
            this.LblUsuarioActivo.Font = new System.Drawing.Font("Livvic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblUsuarioActivo.Location = new System.Drawing.Point(1026, 28);
            this.LblUsuarioActivo.Name = "LblUsuarioActivo";
            this.LblUsuarioActivo.Size = new System.Drawing.Size(69, 24);
            this.LblUsuarioActivo.TabIndex = 3;
            this.LblUsuarioActivo.Text = "Usuario.";
            // 
            // pSuperior
            // 
            this.pSuperior.Controls.Add(this.pictureBox1);
            this.pSuperior.Controls.Add(this.btnCerrar);
            this.pSuperior.Controls.Add(this.btnOcultarVentana);
            this.pSuperior.Controls.Add(this.LblUsuarioActivo);
            this.pSuperior.Controls.Add(this.pbUsuario);
            this.pSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSuperior.Location = new System.Drawing.Point(0, 0);
            this.pSuperior.Margin = new System.Windows.Forms.Padding(2);
            this.pSuperior.Name = "pSuperior";
            this.pSuperior.Size = new System.Drawing.Size(1443, 81);
            this.pSuperior.TabIndex = 8;
            // 
            // tsbInicio
            // 
            this.tsbInicio.AutoSize = false;
            this.tsbInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInicio.Image = global::SGA_v0._1.Properties.Resources.Inicio;
            this.tsbInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInicio.Name = "tsbInicio";
            this.tsbInicio.Size = new System.Drawing.Size(85, 60);
            this.tsbInicio.Text = "INICIO";
            this.tsbInicio.Click += new System.EventHandler(this.tsbInicio_Click);
            // 
            // tsbProveedores
            // 
            this.tsbProveedores.AutoSize = false;
            this.tsbProveedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbProveedores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProveedores.Image = global::SGA_v0._1.Properties.Resources.Proveedores;
            this.tsbProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProveedores.Name = "tsbProveedores";
            this.tsbProveedores.Size = new System.Drawing.Size(85, 60);
            this.tsbProveedores.Text = "PROVEEDORES";
            this.tsbProveedores.Click += new System.EventHandler(this.tsbProveedores_Click);
            // 
            // tsbCategorias
            // 
            this.tsbCategorias.AutoSize = false;
            this.tsbCategorias.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tsbCategorias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCategorias.Image = global::SGA_v0._1.Properties.Resources.Categoria;
            this.tsbCategorias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCategorias.Name = "tsbCategorias";
            this.tsbCategorias.Size = new System.Drawing.Size(85, 60);
            this.tsbCategorias.Text = "CATEGORÍAS";
            this.tsbCategorias.Click += new System.EventHandler(this.tsbCategorias_Click);
            // 
            // tsbNotificaciones
            // 
            this.tsbNotificaciones.AutoSize = false;
            this.tsbNotificaciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNotificaciones.Image = global::SGA_v0._1.Properties.Resources.Notificacion;
            this.tsbNotificaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNotificaciones.Name = "tsbNotificaciones";
            this.tsbNotificaciones.Size = new System.Drawing.Size(85, 60);
            this.tsbNotificaciones.Text = "ALERTAS";
            this.tsbNotificaciones.Click += new System.EventHandler(this.tsbNotificaciones_Click);
            // 
            // tsbProductos
            // 
            this.tsbProductos.AutoSize = false;
            this.tsbProductos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProductos.Image = global::SGA_v0._1.Properties.Resources.Producto;
            this.tsbProductos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProductos.Name = "tsbProductos";
            this.tsbProductos.Size = new System.Drawing.Size(85, 60);
            this.tsbProductos.Text = "PRODUCTOS";
            this.tsbProductos.Click += new System.EventHandler(this.tsbProductos_Click);
            // 
            // tsbEntradas
            // 
            this.tsbEntradas.AutoSize = false;
            this.tsbEntradas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEntradas.Image = global::SGA_v0._1.Properties.Resources.Registro_Entrada;
            this.tsbEntradas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEntradas.Name = "tsbEntradas";
            this.tsbEntradas.Size = new System.Drawing.Size(85, 60);
            this.tsbEntradas.Text = "ENTRADAS";
            this.tsbEntradas.Click += new System.EventHandler(this.tsbEntradas_Click);
            // 
            // tsbSalidas
            // 
            this.tsbSalidas.AutoSize = false;
            this.tsbSalidas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalidas.Image = global::SGA_v0._1.Properties.Resources.Registro_Salida;
            this.tsbSalidas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalidas.Name = "tsbSalidas";
            this.tsbSalidas.Size = new System.Drawing.Size(85, 60);
            this.tsbSalidas.Text = "SALIDAS";
            this.tsbSalidas.Click += new System.EventHandler(this.tsbSalidas_Click);
            // 
            // tsbReportes
            // 
            this.tsbReportes.AutoSize = false;
            this.tsbReportes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbReportes.Image = global::SGA_v0._1.Properties.Resources.Reporte;
            this.tsbReportes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReportes.Name = "tsbReportes";
            this.tsbReportes.Size = new System.Drawing.Size(85, 60);
            this.tsbReportes.Text = "REPORTES";
            this.tsbReportes.Click += new System.EventHandler(this.tsbReportes_Click);
            // 
            // tsbRolesPermisos
            // 
            this.tsbRolesPermisos.AutoSize = false;
            this.tsbRolesPermisos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRolesPermisos.Image = global::SGA_v0._1.Properties.Resources.Rol_Permisos;
            this.tsbRolesPermisos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRolesPermisos.Name = "tsbRolesPermisos";
            this.tsbRolesPermisos.Size = new System.Drawing.Size(85, 60);
            this.tsbRolesPermisos.Text = "ROLES Y PERMISOS";
            this.tsbRolesPermisos.Click += new System.EventHandler(this.tsbRolesPermisos_Click);
            // 
            // tsbUsuarios
            // 
            this.tsbUsuarios.AutoSize = false;
            this.tsbUsuarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUsuarios.Image = global::SGA_v0._1.Properties.Resources.Usuarios;
            this.tsbUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUsuarios.Name = "tsbUsuarios";
            this.tsbUsuarios.Size = new System.Drawing.Size(85, 60);
            this.tsbUsuarios.Text = "USUARIOS";
            this.tsbUsuarios.Click += new System.EventHandler(this.tsbUsuarios_Click);
            // 
            // tsbCerrarSesion
            // 
            this.tsbCerrarSesion.AutoSize = false;
            this.tsbCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCerrarSesion.Image = global::SGA_v0._1.Properties.Resources.Salir;
            this.tsbCerrarSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCerrarSesion.Name = "tsbCerrarSesion";
            this.tsbCerrarSesion.Size = new System.Drawing.Size(85, 60);
            this.tsbCerrarSesion.Text = "CERRAR SESION";
            this.tsbCerrarSesion.Click += new System.EventHandler(this.tsbCerrarSesion_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(85, -16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 122);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.BackgroundImage = global::SGA_v0._1.Properties.Resources.Cerrar;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Location = new System.Drawing.Point(1372, 22);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(35, 37);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            this.btnCerrar.MouseEnter += new System.EventHandler(this.btnCerrar_MouseEnter);
            this.btnCerrar.MouseLeave += new System.EventHandler(this.btnCerrar_MouseLeave);
            // 
            // btnOcultarVentana
            // 
            this.btnOcultarVentana.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOcultarVentana.BackgroundImage = global::SGA_v0._1.Properties.Resources.Max;
            this.btnOcultarVentana.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOcultarVentana.Location = new System.Drawing.Point(1312, 22);
            this.btnOcultarVentana.Margin = new System.Windows.Forms.Padding(2);
            this.btnOcultarVentana.Name = "btnOcultarVentana";
            this.btnOcultarVentana.Size = new System.Drawing.Size(35, 37);
            this.btnOcultarVentana.TabIndex = 6;
            this.btnOcultarVentana.UseVisualStyleBackColor = true;
            this.btnOcultarVentana.Click += new System.EventHandler(this.btnOcultarVentana_Click);
            this.btnOcultarVentana.MouseEnter += new System.EventHandler(this.btnOcultarVentana_MouseEnter);
            this.btnOcultarVentana.MouseLeave += new System.EventHandler(this.btnOcultarVentana_MouseLeave);
            // 
            // pbUsuario
            // 
            this.pbUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbUsuario.BackgroundImage = global::SGA_v0._1.Properties.Resources.Perfil;
            this.pbUsuario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbUsuario.Location = new System.Drawing.Point(1256, 22);
            this.pbUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.pbUsuario.Name = "pbUsuario";
            this.pbUsuario.Size = new System.Drawing.Size(35, 37);
            this.pbUsuario.TabIndex = 5;
            this.pbUsuario.TabStop = false;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 755);
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.pSuperior);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INICIO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.pSuperior.ResumeLayout(false);
            this.pSuperior.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsuario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.ToolStripButton tsbInicio;
        private System.Windows.Forms.ToolStripButton tsbProveedores;
        private System.Windows.Forms.ToolStripButton tsbCategorias;
        private System.Windows.Forms.ToolStripButton tsbNotificaciones;
        private System.Windows.Forms.ToolStripButton tsbProductos;
        private System.Windows.Forms.ToolStripButton tsbEntradas;
        private System.Windows.Forms.ToolStripButton tsbSalidas;
        private System.Windows.Forms.ToolStripButton tsbReportes;
        private System.Windows.Forms.ToolStripButton tsbRolesPermisos;
        private System.Windows.Forms.ToolStripButton tsbUsuarios;
        private System.Windows.Forms.ToolStripButton tsbCerrarSesion;
        private System.Windows.Forms.Label LblUsuarioActivo;
        private System.Windows.Forms.PictureBox pbUsuario;
        private System.Windows.Forms.Button btnOcultarVentana;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Panel pSuperior;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

