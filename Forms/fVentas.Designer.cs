namespace TronicShop.Forms
{
    partial class fVentas
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
            cbCliente = new ComboBox();
            cbProducto = new ComboBox();
            nudCantidad = new NumericUpDown();
            lbSubTotal = new Label();
            lbTotal = new Label();
            lbUsuario = new Label();
            lbFecha = new Label();
            btnGuardar = new Button();
            btnEliminar = new Button();
            btnAgregar = new Button();
            dgvCarrito = new DataGridView();
            lbCliente = new Label();
            lbProducto = new Label();
            lbCantidad = new Label();
            lbITBIS = new Label();
            btnCancelarVenta = new Button();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // cbCliente
            // 
            cbCliente.Font = new Font("Fira Sans", 12F);
            cbCliente.FormattingEnabled = true;
            cbCliente.Location = new Point(93, 17);
            cbCliente.Name = "cbCliente";
            cbCliente.Size = new Size(250, 27);
            cbCliente.TabIndex = 0;
            // 
            // cbProducto
            // 
            cbProducto.Font = new Font("Fira Sans", 12F);
            cbProducto.FormattingEnabled = true;
            cbProducto.Location = new Point(93, 56);
            cbProducto.Name = "cbProducto";
            cbProducto.Size = new Size(250, 27);
            cbProducto.TabIndex = 1;
            // 
            // nudCantidad
            // 
            nudCantidad.Font = new Font("Fira Sans", 12F);
            nudCantidad.Location = new Point(374, 56);
            nudCantidad.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(100, 27);
            nudCantidad.TabIndex = 2;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lbSubTotal
            // 
            lbSubTotal.AutoSize = true;
            lbSubTotal.Font = new Font("Fira Sans", 12F);
            lbSubTotal.Location = new Point(21, 458);
            lbSubTotal.Name = "lbSubTotal";
            lbSubTotal.Size = new Size(143, 19);
            lbSubTotal.TabIndex = 4;
            lbSubTotal.Text = "Subtotal: RD$ 0.00";
            // 
            // lbTotal
            // 
            lbTotal.AutoSize = true;
            lbTotal.Font = new Font("Fira Sans", 12F);
            lbTotal.Location = new Point(374, 458);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(116, 19);
            lbTotal.TabIndex = 5;
            lbTotal.Text = "Total: RD$ 0.00";
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Font = new Font("Fira Sans", 12F);
            lbUsuario.Location = new Point(646, 19);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(135, 19);
            lbUsuario.TabIndex = 6;
            lbUsuario.Text = "Vendedor: Admin";
            // 
            // lbFecha
            // 
            lbFecha.AutoSize = true;
            lbFecha.Font = new Font("Fira Sans", 12F);
            lbFecha.Location = new Point(646, 44);
            lbFecha.Name = "lbFecha";
            lbFecha.Size = new Size(155, 19);
            lbFecha.TabIndex = 7;
            lbFecha.Text = "02/04/2025 11:07 PM";
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Fira Sans", 12F);
            btnGuardar.Location = new Point(688, 458);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 30);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar Venta";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Fira Sans", 12F);
            btnEliminar.Location = new Point(500, 60);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(140, 27);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Eliminar Producto";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Fira Sans", 12F);
            btnAgregar.Location = new Point(520, 27);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(100, 27);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // dgvCarrito
            // 
            dgvCarrito.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Location = new Point(12, 93);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.ReadOnly = true;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(826, 359);
            dgvCarrito.TabIndex = 11;
            // 
            // lbCliente
            // 
            lbCliente.AutoSize = true;
            lbCliente.Font = new Font("Fira Sans", 12F);
            lbCliente.Location = new Point(12, 20);
            lbCliente.Name = "lbCliente";
            lbCliente.Size = new Size(61, 19);
            lbCliente.TabIndex = 12;
            lbCliente.Text = "Cliente";
            // 
            // lbProducto
            // 
            lbProducto.AutoSize = true;
            lbProducto.Font = new Font("Fira Sans", 12F);
            lbProducto.Location = new Point(12, 59);
            lbProducto.Name = "lbProducto";
            lbProducto.Size = new Size(75, 19);
            lbProducto.TabIndex = 13;
            lbProducto.Text = "Producto";
            // 
            // lbCantidad
            // 
            lbCantidad.AutoSize = true;
            lbCantidad.Font = new Font("Fira Sans", 12F);
            lbCantidad.Location = new Point(374, 34);
            lbCantidad.Name = "lbCantidad";
            lbCantidad.Size = new Size(76, 19);
            lbCantidad.TabIndex = 14;
            lbCantidad.Text = "Cantidad";
            // 
            // lbITBIS
            // 
            lbITBIS.AutoSize = true;
            lbITBIS.Font = new Font("Fira Sans", 12F);
            lbITBIS.Location = new Point(170, 458);
            lbITBIS.Name = "lbITBIS";
            lbITBIS.Size = new Size(107, 19);
            lbITBIS.TabIndex = 15;
            lbITBIS.Text = "ITBIS: 00.00%";
            // 
            // btnCancelarVenta
            // 
            btnCancelarVenta.Font = new Font("Fira Sans", 12F);
            btnCancelarVenta.Location = new Point(550, 458);
            btnCancelarVenta.Name = "btnCancelarVenta";
            btnCancelarVenta.Size = new Size(132, 30);
            btnCancelarVenta.TabIndex = 16;
            btnCancelarVenta.Text = "Cancelar Venta";
            btnCancelarVenta.UseVisualStyleBackColor = true;
            btnCancelarVenta.Click += btnCancelarVenta_Click;
            // 
            // fVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 500);
            Controls.Add(btnCancelarVenta);
            Controls.Add(lbITBIS);
            Controls.Add(lbCantidad);
            Controls.Add(lbProducto);
            Controls.Add(lbCliente);
            Controls.Add(dgvCarrito);
            Controls.Add(btnAgregar);
            Controls.Add(btnEliminar);
            Controls.Add(btnGuardar);
            Controls.Add(lbFecha);
            Controls.Add(lbUsuario);
            Controls.Add(lbTotal);
            Controls.Add(lbSubTotal);
            Controls.Add(nudCantidad);
            Controls.Add(cbProducto);
            Controls.Add(cbCliente);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fVentas";
            Text = "fVentas";
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbCliente;
        private ComboBox cbProducto;
        private NumericUpDown nudCantidad;
        private Label lbSubTotal;
        private Label lbTotal;
        private Label lbUsuario;
        private Label lbFecha;
        private Button btnGuardar;
        private Button btnEliminar;
        private Button btnAgregar;
        private DataGridView dgvCarrito;
        private Label lbCliente;
        private Label lbProducto;
        private Label lbCantidad;
        private Label lbITBIS;
        private Button btnCancelarVenta;
    }
}