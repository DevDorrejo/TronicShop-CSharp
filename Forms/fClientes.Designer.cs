namespace TronicShop.Forms
{
    partial class fClientes
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
            lbNombre = new Label();
            lbTeléfono = new Label();
            lbCorreo = new Label();
            lbDirección = new Label();
            lbIdentificación = new Label();
            lbEstado = new Label();
            txNombre = new TextBox();
            txTeléfono = new TextBox();
            txCorreo = new TextBox();
            txDirección = new TextBox();
            txIdentificación = new TextBox();
            chkEstado = new CheckBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            dgvClientes = new DataGridView();
            rbCompañía = new RadioButton();
            rbFinal = new RadioButton();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.Font = new Font("Fira Sans", 12F);
            lbNombre.Location = new Point(23, 44);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(68, 19);
            lbNombre.TabIndex = 0;
            lbNombre.Text = "Nombre";
            // 
            // lbTeléfono
            // 
            lbTeléfono.AutoSize = true;
            lbTeléfono.Font = new Font("Fira Sans", 12F);
            lbTeléfono.Location = new Point(23, 79);
            lbTeléfono.Name = "lbTeléfono";
            lbTeléfono.Size = new Size(71, 19);
            lbTeléfono.TabIndex = 1;
            lbTeléfono.Text = "Teléfono";
            // 
            // lbCorreo
            // 
            lbCorreo.AutoSize = true;
            lbCorreo.Font = new Font("Fira Sans", 12F);
            lbCorreo.Location = new Point(23, 116);
            lbCorreo.Name = "lbCorreo";
            lbCorreo.Size = new Size(57, 19);
            lbCorreo.TabIndex = 2;
            lbCorreo.Text = "Correo";
            // 
            // lbDirección
            // 
            lbDirección.AutoSize = true;
            lbDirección.Font = new Font("Fira Sans", 12F);
            lbDirección.Location = new Point(405, 44);
            lbDirección.Name = "lbDirección";
            lbDirección.Size = new Size(78, 19);
            lbDirección.TabIndex = 3;
            lbDirección.Text = "Dirección";
            // 
            // lbIdentificación
            // 
            lbIdentificación.AutoSize = true;
            lbIdentificación.Font = new Font("Fira Sans", 12F);
            lbIdentificación.Location = new Point(405, 84);
            lbIdentificación.Name = "lbIdentificación";
            lbIdentificación.Size = new Size(110, 19);
            lbIdentificación.TabIndex = 4;
            lbIdentificación.Text = "Identificación";
            // 
            // lbEstado
            // 
            lbEstado.AutoSize = true;
            lbEstado.Font = new Font("Fira Sans", 12F);
            lbEstado.Location = new Point(405, 121);
            lbEstado.Name = "lbEstado";
            lbEstado.Size = new Size(59, 19);
            lbEstado.TabIndex = 5;
            lbEstado.Text = "Estado";
            // 
            // txNombre
            // 
            txNombre.Font = new Font("Fira Sans", 12F);
            txNombre.Location = new Point(100, 41);
            txNombre.Name = "txNombre";
            txNombre.Size = new Size(280, 27);
            txNombre.TabIndex = 6;
            // 
            // txTeléfono
            // 
            txTeléfono.Font = new Font("Fira Sans", 12F);
            txTeléfono.Location = new Point(100, 76);
            txTeléfono.Name = "txTeléfono";
            txTeléfono.Size = new Size(280, 27);
            txTeléfono.TabIndex = 7;
            // 
            // txCorreo
            // 
            txCorreo.Font = new Font("Fira Sans", 12F);
            txCorreo.Location = new Point(100, 113);
            txCorreo.Name = "txCorreo";
            txCorreo.Size = new Size(280, 27);
            txCorreo.TabIndex = 8;
            // 
            // txDirección
            // 
            txDirección.Font = new Font("Fira Sans", 12F);
            txDirección.Location = new Point(489, 41);
            txDirección.Name = "txDirección";
            txDirección.Size = new Size(232, 27);
            txDirección.TabIndex = 9;
            // 
            // txIdentificación
            // 
            txIdentificación.Font = new Font("Fira Sans", 12F);
            txIdentificación.Location = new Point(521, 81);
            txIdentificación.Name = "txIdentificación";
            txIdentificación.PlaceholderText = "RNC";
            txIdentificación.Size = new Size(200, 27);
            txIdentificación.TabIndex = 10;
            txIdentificación.TextChanged += txIdentificación_TextChanged;
            txIdentificación.KeyPress += txIdentificación_KeyPress;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Checked = true;
            chkEstado.CheckState = CheckState.Checked;
            chkEstado.Font = new Font("Fira Sans", 12F);
            chkEstado.Location = new Point(489, 120);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(73, 23);
            chkEstado.TabIndex = 11;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Fira Sans", 12F);
            btnGuardar.Location = new Point(740, 460);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Fira Sans", 12F);
            btnEliminar.Location = new Point(550, 460);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Fira Sans", 12F);
            btnNuevo.Location = new Point(645, 460);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.TabIndex = 14;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 154);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.Size = new Size(826, 300);
            dgvClientes.TabIndex = 15;
            dgvClientes.CellClick += dgvClientes_CellClick;
            // 
            // rbCompañía
            // 
            rbCompañía.AutoSize = true;
            rbCompañía.Font = new Font("Fira Sans", 12F);
            rbCompañía.Location = new Point(23, 12);
            rbCompañía.Name = "rbCompañía";
            rbCompañía.Size = new Size(101, 23);
            rbCompañía.TabIndex = 16;
            rbCompañía.TabStop = true;
            rbCompañía.Text = "Compañia";
            rbCompañía.UseVisualStyleBackColor = true;
            rbCompañía.Click += rbCompañia_Click;
            // 
            // rbFinal
            // 
            rbFinal.AutoSize = true;
            rbFinal.Font = new Font("Fira Sans", 12F);
            rbFinal.Location = new Point(130, 12);
            rbFinal.Name = "rbFinal";
            rbFinal.Size = new Size(153, 23);
            rbFinal.TabIndex = 17;
            rbFinal.TabStop = true;
            rbFinal.Text = "Consumidor Final";
            rbFinal.UseVisualStyleBackColor = true;
            rbFinal.Click += rbFinal_Click;
            // 
            // fClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 500);
            Controls.Add(rbFinal);
            Controls.Add(rbCompañía);
            Controls.Add(dgvClientes);
            Controls.Add(btnNuevo);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(chkEstado);
            Controls.Add(txIdentificación);
            Controls.Add(txDirección);
            Controls.Add(txCorreo);
            Controls.Add(txTeléfono);
            Controls.Add(txNombre);
            Controls.Add(lbEstado);
            Controls.Add(lbIdentificación);
            Controls.Add(lbDirección);
            Controls.Add(lbCorreo);
            Controls.Add(lbTeléfono);
            Controls.Add(lbNombre);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNombre;
        private Label lbTeléfono;
        private Label lbCorreo;
        private Label lbDirección;
        private Label lbIdentificación;
        private Label lbEstado;
        private TextBox txNombre;
        private TextBox txTeléfono;
        private TextBox txCorreo;
        private TextBox txDirección;
        private TextBox txIdentificación;
        private CheckBox chkEstado;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnNuevo;
        private DataGridView dgvClientes;
        private RadioButton rbCompañía;
        private RadioButton rbFinal;
    }
}