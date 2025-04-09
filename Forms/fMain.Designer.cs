namespace TronicShop.Forms
{
    partial class fMain
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
            menuStrip = new MenuStrip();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            menuUsuarios = new ToolStripMenuItem();
            menuConfiguración = new ToolStripMenuItem();
            archivoSeparator1 = new ToolStripSeparator();
            menuCerrarSesión = new ToolStripMenuItem();
            menuSalir = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            proveedoresToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            menuReportes = new ToolStripMenuItem();
            productosToolStripMenuItem1 = new ToolStripMenuItem();
            ventasToolStripMenuItem1 = new ToolStripMenuItem();
            statusStrip = new StatusStrip();
            lbHora = new ToolStripStatusLabel();
            lbRol = new ToolStripStatusLabel();
            lbUsuario = new ToolStripStatusLabel();
            archivoSeparator2 = new ToolStripSeparator();
            menuStrip.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.Font = new Font("Fira Sans", 9F);
            menuStrip.Items.AddRange(new ToolStripItem[] { archivoToolStripMenuItem, clientesToolStripMenuItem, proveedoresToolStripMenuItem, productosToolStripMenuItem, ventasToolStripMenuItem, menuReportes });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(854, 24);
            menuStrip.TabIndex = 1;
            menuStrip.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menuUsuarios, menuConfiguración, archivoSeparator1, menuCerrarSesión, archivoSeparator2, menuSalir });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // menuUsuarios
            // 
            menuUsuarios.Name = "menuUsuarios";
            menuUsuarios.Size = new Size(180, 22);
            menuUsuarios.Text = "Usuarios";
            menuUsuarios.Click += menuUsuarios_Click;
            // 
            // menuConfiguración
            // 
            menuConfiguración.Name = "menuConfiguración";
            menuConfiguración.Size = new Size(180, 22);
            menuConfiguración.Text = "Configuración";
            menuConfiguración.Click += menuConfiguración_Click;
            // 
            // archivoSeparator1
            // 
            archivoSeparator1.Name = "archivoSeparator1";
            archivoSeparator1.Size = new Size(177, 6);
            // 
            // menuCerrarSesión
            // 
            menuCerrarSesión.Name = "menuCerrarSesión";
            menuCerrarSesión.Size = new Size(180, 22);
            menuCerrarSesión.Text = "Cerrar Sesión";
            menuCerrarSesión.Click += menuCerrarSesión_Click;
            // 
            // menuSalir
            // 
            menuSalir.Name = "menuSalir";
            menuSalir.Size = new Size(180, 22);
            menuSalir.Text = "Salir";
            menuSalir.Click += menuSalir_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(64, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += menuClientes_Click;
            // 
            // proveedoresToolStripMenuItem
            // 
            proveedoresToolStripMenuItem.Name = "proveedoresToolStripMenuItem";
            proveedoresToolStripMenuItem.Size = new Size(90, 20);
            proveedoresToolStripMenuItem.Text = "Proveedores";
            proveedoresToolStripMenuItem.Click += menuProveedores_Click;
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(75, 20);
            productosToolStripMenuItem.Text = "Productos";
            productosToolStripMenuItem.Click += menuProductos_Click;
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(57, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            ventasToolStripMenuItem.Click += menuVentas_Click;
            // 
            // menuReportes
            // 
            menuReportes.DropDownItems.AddRange(new ToolStripItem[] { productosToolStripMenuItem1, ventasToolStripMenuItem1 });
            menuReportes.Name = "menuReportes";
            menuReportes.Size = new Size(69, 20);
            menuReportes.Text = "Reportes";
            // 
            // productosToolStripMenuItem1
            // 
            productosToolStripMenuItem1.Name = "productosToolStripMenuItem1";
            productosToolStripMenuItem1.Size = new Size(130, 22);
            productosToolStripMenuItem1.Text = "Productos";
            productosToolStripMenuItem1.Click += reporteProductos_Click;
            // 
            // ventasToolStripMenuItem1
            // 
            ventasToolStripMenuItem1.Name = "ventasToolStripMenuItem1";
            ventasToolStripMenuItem1.Size = new Size(130, 22);
            ventasToolStripMenuItem1.Text = "Ventas";
            ventasToolStripMenuItem1.Click += reporteVentas_Click;
            // 
            // statusStrip
            // 
            statusStrip.Font = new Font("Fira Sans", 9F);
            statusStrip.Items.AddRange(new ToolStripItem[] { lbHora, lbRol, lbUsuario });
            statusStrip.Location = new Point(0, 528);
            statusStrip.Name = "statusStrip";
            statusStrip.RightToLeft = RightToLeft.Yes;
            statusStrip.Size = new Size(854, 22);
            statusStrip.TabIndex = 7;
            statusStrip.Text = "statusStrip1";
            // 
            // lbHora
            // 
            lbHora.Name = "lbHora";
            lbHora.Size = new Size(34, 17);
            lbHora.Text = "Hora";
            // 
            // lbRol
            // 
            lbRol.Name = "lbRol";
            lbRol.Size = new Size(25, 17);
            lbRol.Text = "Rol";
            // 
            // lbUsuario
            // 
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(50, 17);
            lbUsuario.Text = "Usuario";
            // 
            // archivoSeparator2
            // 
            archivoSeparator2.Name = "archivoSeparator2";
            archivoSeparator2.Size = new Size(177, 6);
            // 
            // fMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(854, 550);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip;
            MaximizeBox = false;
            Name = "fMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TronicShop - Panel Principal";
            FormClosing += fMain_FormClosing;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem menuReportes;
        private ToolStripMenuItem menuCerrarSesión;
        private ToolStripMenuItem menuSalir;
        private ToolStripMenuItem menuUsuarios;
        private ToolStripSeparator archivoSeparator1;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel lbUsuario;
        private ToolStripStatusLabel lbRol;
        private ToolStripStatusLabel lbHora;
        private ToolStripMenuItem productosToolStripMenuItem1;
        private ToolStripMenuItem ventasToolStripMenuItem1;
        private ToolStripMenuItem menuConfiguración;
        private ToolStripMenuItem proveedoresToolStripMenuItem;
        private ToolStripSeparator archivoSeparator2;
    }
}