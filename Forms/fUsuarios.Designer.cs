namespace TronicShop.Forms
{
    partial class fUsuarios
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
            components = new System.ComponentModel.Container();
            lbNombre = new Label();
            lbUsuario = new Label();
            lbContraseña = new Label();
            lbRol = new Label();
            lbEstado = new Label();
            txNombre = new TextBox();
            txUsuario = new TextBox();
            txContraseña = new TextBox();
            cbRol = new ComboBox();
            chkEstado = new CheckBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            dgvUsuarios = new DataGridView();
            toolTip = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.Font = new Font("Fira Sans", 12F);
            lbNombre.Location = new Point(20, 17);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(76, 19);
            lbNombre.TabIndex = 0;
            lbNombre.Text = "Nombre: ";
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Font = new Font("Fira Sans", 12F);
            lbUsuario.Location = new Point(20, 57);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(65, 19);
            lbUsuario.TabIndex = 1;
            lbUsuario.Text = "Usuario";
            // 
            // lbContraseña
            // 
            lbContraseña.AutoSize = true;
            lbContraseña.Font = new Font("Fira Sans", 12F);
            lbContraseña.Location = new Point(20, 97);
            lbContraseña.Name = "lbContraseña";
            lbContraseña.Size = new Size(90, 19);
            lbContraseña.TabIndex = 2;
            lbContraseña.Text = "Contraseña";
            // 
            // lbRol
            // 
            lbRol.AutoSize = true;
            lbRol.Font = new Font("Fira Sans", 12F);
            lbRol.Location = new Point(406, 17);
            lbRol.Name = "lbRol";
            lbRol.Size = new Size(33, 19);
            lbRol.TabIndex = 3;
            lbRol.Text = "Rol";
            // 
            // lbEstado
            // 
            lbEstado.AutoSize = true;
            lbEstado.Font = new Font("Fira Sans", 12F);
            lbEstado.Location = new Point(406, 57);
            lbEstado.Name = "lbEstado";
            lbEstado.Size = new Size(59, 19);
            lbEstado.TabIndex = 4;
            lbEstado.Text = "Estado";
            // 
            // txNombre
            // 
            txNombre.Font = new Font("Fira Sans", 12F);
            txNombre.Location = new Point(120, 14);
            txNombre.Name = "txNombre";
            txNombre.Size = new Size(225, 27);
            txNombre.TabIndex = 5;
            // 
            // txUsuario
            // 
            txUsuario.Font = new Font("Fira Sans", 12F);
            txUsuario.Location = new Point(120, 54);
            txUsuario.Name = "txUsuario";
            txUsuario.Size = new Size(225, 27);
            txUsuario.TabIndex = 6;
            // 
            // txContraseña
            // 
            txContraseña.Font = new Font("Fira Sans", 12F);
            txContraseña.Location = new Point(120, 94);
            txContraseña.Name = "txContraseña";
            txContraseña.PasswordChar = '*';
            txContraseña.Size = new Size(225, 27);
            txContraseña.TabIndex = 7;
            // 
            // cbRol
            // 
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.Font = new Font("Fira Sans", 12F);
            cbRol.FormattingEnabled = true;
            cbRol.Items.AddRange(new object[] { "admin", "vendedor" });
            cbRol.Location = new Point(445, 14);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(225, 27);
            cbRol.TabIndex = 8;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Checked = true;
            chkEstado.CheckState = CheckState.Checked;
            chkEstado.Font = new Font("Fira Sans", 12F);
            chkEstado.Location = new Point(471, 56);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(73, 23);
            chkEstado.TabIndex = 9;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Fira Sans", 12F);
            btnGuardar.Location = new Point(752, 463);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Fira Sans", 12F);
            btnEliminar.Location = new Point(560, 463);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Fira Sans", 12F);
            btnNuevo.Location = new Point(656, 463);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.TabIndex = 12;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(12, 127);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(826, 330);
            dgvUsuarios.TabIndex = 13;
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
            // 
            // fUsuarios
            // 
            ClientSize = new Size(850, 500);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnNuevo);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(chkEstado);
            Controls.Add(cbRol);
            Controls.Add(txContraseña);
            Controls.Add(txUsuario);
            Controls.Add(txNombre);
            Controls.Add(lbEstado);
            Controls.Add(lbRol);
            Controls.Add(lbContraseña);
            Controls.Add(lbUsuario);
            Controls.Add(lbNombre);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fUsuarios";
            Text = "Administración de Usuario";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNombre;
        private Label lbUsuario;
        private Label lbContraseña;
        private Label lbRol;
        private Label lbEstado;
        private TextBox txNombre;
        private TextBox txUsuario;
        private TextBox txContraseña;
        private ComboBox cbRol;
        private CheckBox chkEstado;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnNuevo;
        private DataGridView dgvUsuarios;
        private ToolTip toolTip;
    }
}