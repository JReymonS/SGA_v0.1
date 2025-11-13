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
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
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
            this.LblUsuarioActivo = new System.Windows.Forms.Label();
            this.tsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.AutoSize = false;
            this.tsPrincipal.Dock = System.Windows.Forms.DockStyle.Left;
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
            this.tsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(80, 929);
            this.tsPrincipal.TabIndex = 1;
            this.tsPrincipal.Text = "toolStrip1";
            // 
            // tsbInicio
            // 
            this.tsbInicio.AutoSize = false;
            this.tsbInicio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsbInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInicio.Image = global::SGA_v0._1.Properties.Resources.Inicio;
            this.tsbInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInicio.Name = "tsbInicio";
            this.tsbInicio.Size = new System.Drawing.Size(60, 60);
            this.tsbInicio.Text = "INICIO";
            // 
            // tsbProveedores
            // 
            this.tsbProveedores.AutoSize = false;
            this.tsbProveedores.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProveedores.Image = global::SGA_v0._1.Properties.Resources.Proveedores;
            this.tsbProveedores.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProveedores.Name = "tsbProveedores";
            this.tsbProveedores.Size = new System.Drawing.Size(60, 60);
            this.tsbProveedores.Text = "PROVEEDORES";
            this.tsbProveedores.Click += new System.EventHandler(this.tsbProveedores_Click);
            // 
            // tsbCategorias
            // 
            this.tsbCategorias.AutoSize = false;
            this.tsbCategorias.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCategorias.Image = global::SGA_v0._1.Properties.Resources.Categoria;
            this.tsbCategorias.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCategorias.Name = "tsbCategorias";
            this.tsbCategorias.Size = new System.Drawing.Size(60, 60);
            this.tsbCategorias.Text = "CATEGORIA";
            this.tsbCategorias.Click += new System.EventHandler(this.tsbCategorias_Click);
            // 
            // tsbNotificaciones
            // 
            this.tsbNotificaciones.AutoSize = false;
            this.tsbNotificaciones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNotificaciones.Image = global::SGA_v0._1.Properties.Resources.Notificacion;
            this.tsbNotificaciones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNotificaciones.Name = "tsbNotificaciones";
            this.tsbNotificaciones.Size = new System.Drawing.Size(60, 60);
            this.tsbNotificaciones.Text = "NOTIFICACION";
            // 
            // tsbProductos
            // 
            this.tsbProductos.AutoSize = false;
            this.tsbProductos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbProductos.Image = global::SGA_v0._1.Properties.Resources.Producto;
            this.tsbProductos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbProductos.Name = "tsbProductos";
            this.tsbProductos.Size = new System.Drawing.Size(60, 60);
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
            this.tsbEntradas.Size = new System.Drawing.Size(60, 60);
            this.tsbEntradas.Text = "ENTRADAS";
            // 
            // tsbSalidas
            // 
            this.tsbSalidas.AutoSize = false;
            this.tsbSalidas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSalidas.Image = global::SGA_v0._1.Properties.Resources.Registro_Salida;
            this.tsbSalidas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalidas.Name = "tsbSalidas";
            this.tsbSalidas.Size = new System.Drawing.Size(60, 60);
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
            this.tsbReportes.Size = new System.Drawing.Size(60, 60);
            this.tsbReportes.Text = "REPORTES";
            // 
            // tsbRolesPermisos
            // 
            this.tsbRolesPermisos.AutoSize = false;
            this.tsbRolesPermisos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRolesPermisos.Image = global::SGA_v0._1.Properties.Resources.Rol_Permisos;
            this.tsbRolesPermisos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRolesPermisos.Name = "tsbRolesPermisos";
            this.tsbRolesPermisos.Size = new System.Drawing.Size(60, 60);
            this.tsbRolesPermisos.Text = "ROLES Y PERMISOS";
            // 
            // tsbUsuarios
            // 
            this.tsbUsuarios.AutoSize = false;
            this.tsbUsuarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUsuarios.Image = global::SGA_v0._1.Properties.Resources.Usuarios;
            this.tsbUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUsuarios.Name = "tsbUsuarios";
            this.tsbUsuarios.Size = new System.Drawing.Size(60, 60);
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
            this.tsbCerrarSesion.Size = new System.Drawing.Size(60, 60);
            this.tsbCerrarSesion.Text = "CERRAR SESION";
            this.tsbCerrarSesion.Click += new System.EventHandler(this.tsbCerrarSesion_Click);
            // 
            // LblUsuarioActivo
            // 
            this.LblUsuarioActivo.AutoSize = true;
            this.LblUsuarioActivo.Location = new System.Drawing.Point(99, 23);
            this.LblUsuarioActivo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblUsuarioActivo.Name = "LblUsuarioActivo";
            this.LblUsuarioActivo.Size = new System.Drawing.Size(87, 16);
            this.LblUsuarioActivo.TabIndex = 3;
            this.LblUsuarioActivo.Text = "Bienvenid@: ";
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 929);
            this.Controls.Add(this.LblUsuarioActivo);
            this.Controls.Add(this.tsPrincipal);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmInicio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

