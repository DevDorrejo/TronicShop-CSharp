namespace TronicShop.Forms
{
    partial class fProductos
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
            lbCódigoBarra = new Label();
            lbNombre = new Label();
            lbDescripción = new Label();
            lbCategoría = new Label();
            lbPrecio = new Label();
            lbStock = new Label();
            lbProveedor = new Label();
            lbEstado = new Label();
            txCódigoBarra = new TextBox();
            txNombre = new TextBox();
            txDescripción = new TextBox();
            txCategoría = new TextBox();
            txPrecio = new TextBox();
            txStock = new TextBox();
            cbProveedor = new ComboBox();
            chkEstado = new CheckBox();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnNuevo = new Button();
            dgvProductos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // lbCódigoBarra
            // 
            lbCódigoBarra.AutoSize = true;
            lbCódigoBarra.Font = new Font("Fira Sans", 12F);
            lbCódigoBarra.Location = new Point(20, 20);
            lbCódigoBarra.Name = "lbCódigoBarra";
            lbCódigoBarra.Size = new Size(125, 19);
            lbCódigoBarra.TabIndex = 0;
            lbCódigoBarra.Text = "Código de Barra";
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.Font = new Font("Fira Sans", 12F);
            lbNombre.Location = new Point(20, 60);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(68, 19);
            lbNombre.TabIndex = 1;
            lbNombre.Text = "Nombre";
            // 
            // lbDescripción
            // 
            lbDescripción.AutoSize = true;
            lbDescripción.Font = new Font("Fira Sans", 12F);
            lbDescripción.Location = new Point(20, 100);
            lbDescripción.Name = "lbDescripción";
            lbDescripción.Size = new Size(95, 19);
            lbDescripción.TabIndex = 2;
            lbDescripción.Text = "Descripción";
            // 
            // lbCategoría
            // 
            lbCategoría.AutoSize = true;
            lbCategoría.Font = new Font("Fira Sans", 12F);
            lbCategoría.Location = new Point(20, 140);
            lbCategoría.Name = "lbCategoría";
            lbCategoría.Size = new Size(79, 19);
            lbCategoría.TabIndex = 3;
            lbCategoría.Text = "Categoría";
            // 
            // lbPrecio
            // 
            lbPrecio.AutoSize = true;
            lbPrecio.Font = new Font("Fira Sans", 12F);
            lbPrecio.Location = new Point(412, 20);
            lbPrecio.Name = "lbPrecio";
            lbPrecio.Size = new Size(55, 19);
            lbPrecio.TabIndex = 4;
            lbPrecio.Text = "Precio";
            // 
            // lbStock
            // 
            lbStock.AutoSize = true;
            lbStock.Font = new Font("Fira Sans", 12F);
            lbStock.Location = new Point(418, 60);
            lbStock.Name = "lbStock";
            lbStock.Size = new Size(49, 19);
            lbStock.TabIndex = 5;
            lbStock.Text = "Stock";
            // 
            // lbProveedor
            // 
            lbProveedor.AutoSize = true;
            lbProveedor.Font = new Font("Fira Sans", 12F);
            lbProveedor.Location = new Point(418, 103);
            lbProveedor.Name = "lbProveedor";
            lbProveedor.Size = new Size(84, 19);
            lbProveedor.TabIndex = 6;
            lbProveedor.Text = "Proveedor";
            // 
            // lbEstado
            // 
            lbEstado.AutoSize = true;
            lbEstado.Font = new Font("Fira Sans", 12F);
            lbEstado.Location = new Point(418, 143);
            lbEstado.Name = "lbEstado";
            lbEstado.Size = new Size(59, 19);
            lbEstado.TabIndex = 7;
            lbEstado.Text = "Estado";
            // 
            // txCódigoBarra
            // 
            txCódigoBarra.Font = new Font("Fira Sans", 12F);
            txCódigoBarra.Location = new Point(150, 17);
            txCódigoBarra.Name = "txCódigoBarra";
            txCódigoBarra.Size = new Size(240, 27);
            txCódigoBarra.TabIndex = 8;
            // 
            // txNombre
            // 
            txNombre.Font = new Font("Fira Sans", 12F);
            txNombre.Location = new Point(150, 57);
            txNombre.Name = "txNombre";
            txNombre.Size = new Size(240, 27);
            txNombre.TabIndex = 9;
            // 
            // txDescripción
            // 
            txDescripción.Font = new Font("Fira Sans", 12F);
            txDescripción.Location = new Point(150, 97);
            txDescripción.Name = "txDescripción";
            txDescripción.Size = new Size(240, 27);
            txDescripción.TabIndex = 10;
            // 
            // txCategoría
            // 
            txCategoría.Font = new Font("Fira Sans", 12F);
            txCategoría.Location = new Point(150, 137);
            txCategoría.Name = "txCategoría";
            txCategoría.Size = new Size(240, 27);
            txCategoría.TabIndex = 11;
            // 
            // txPrecio
            // 
            txPrecio.Font = new Font("Fira Sans", 12F);
            txPrecio.Location = new Point(528, 17);
            txPrecio.Name = "txPrecio";
            txPrecio.Size = new Size(240, 27);
            txPrecio.TabIndex = 12;
            // 
            // txStock
            // 
            txStock.Font = new Font("Fira Sans", 12F);
            txStock.Location = new Point(528, 57);
            txStock.Name = "txStock";
            txStock.Size = new Size(240, 27);
            txStock.TabIndex = 13;
            // 
            // cbProveedor
            // 
            cbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbProveedor.Font = new Font("Fira Sans", 12F);
            cbProveedor.FormattingEnabled = true;
            cbProveedor.Location = new Point(528, 100);
            cbProveedor.Name = "cbProveedor";
            cbProveedor.Size = new Size(260, 27);
            cbProveedor.TabIndex = 14;
            // 
            // chkEstado
            // 
            chkEstado.Checked = true;
            chkEstado.CheckState = CheckState.Checked;
            chkEstado.Font = new Font("Fira Sans", 12F);
            chkEstado.Location = new Point(528, 140);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(121, 27);
            chkEstado.TabIndex = 15;
            chkEstado.Text = "Activo";
            chkEstado.CheckedChanged += chkEstado_CheckedChanged;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Fira Sans", 12F);
            btnGuardar.Location = new Point(748, 458);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(90, 30);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Fira Sans", 12F);
            btnEliminar.Location = new Point(558, 458);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(90, 30);
            btnEliminar.TabIndex = 17;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Fira Sans", 12F);
            btnNuevo.Location = new Point(653, 458);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(90, 30);
            btnNuevo.TabIndex = 18;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(12, 173);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.Size = new Size(826, 279);
            dgvProductos.TabIndex = 19;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // fProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 500);
            Controls.Add(dgvProductos);
            Controls.Add(btnNuevo);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(chkEstado);
            Controls.Add(cbProveedor);
            Controls.Add(txStock);
            Controls.Add(txPrecio);
            Controls.Add(txCategoría);
            Controls.Add(txDescripción);
            Controls.Add(txNombre);
            Controls.Add(txCódigoBarra);
            Controls.Add(lbEstado);
            Controls.Add(lbProveedor);
            Controls.Add(lbStock);
            Controls.Add(lbPrecio);
            Controls.Add(lbCategoría);
            Controls.Add(lbDescripción);
            Controls.Add(lbNombre);
            Controls.Add(lbCódigoBarra);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Administración de Productos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbCódigoBarra;
        private Label lbNombre;
        private Label lbDescripción;
        private Label lbCategoría;
        private Label lbPrecio;
        private Label lbStock;
        private Label lbProveedor;
        private Label lbEstado;
        private TextBox txCódigoBarra;
        private TextBox txNombre;
        private TextBox txDescripción;
        private TextBox txCategoría;
        private TextBox txPrecio;
        private TextBox txStock;
        private ComboBox cbProveedor;
        private CheckBox chkEstado;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnNuevo;
        private DataGridView dgvProductos;
    }
}