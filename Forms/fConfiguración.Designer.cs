namespace TronicShop.Forms
{
    partial class fConfiguración
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
            lbNombreEmpresa = new Label();
            lbRNC = new Label();
            lbDirección = new Label();
            lbTeléfono = new Label();
            lbCorreo = new Label();
            lbImpuesto = new Label();
            lbLogo = new Label();
            txNombreEmpresa = new TextBox();
            txRNC = new TextBox();
            txDirección = new TextBox();
            txTeléfono = new TextBox();
            txCorreo = new TextBox();
            nudImpuesto = new NumericUpDown();
            pbLogo = new PictureBox();
            btnCargarLogo = new Button();
            btnGuardar = new Button();
            ((System.ComponentModel.ISupportInitialize)nudImpuesto).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // lbNombreEmpresa
            // 
            lbNombreEmpresa.AutoSize = true;
            lbNombreEmpresa.Location = new Point(20, 20);
            lbNombreEmpresa.Name = "lbNombreEmpresa";
            lbNombreEmpresa.Size = new Size(99, 15);
            lbNombreEmpresa.TabIndex = 0;
            lbNombreEmpresa.Text = "Nombre Empresa";
            // 
            // lbRNC
            // 
            lbRNC.AutoSize = true;
            lbRNC.Location = new Point(20, 60);
            lbRNC.Name = "lbRNC";
            lbRNC.Size = new Size(31, 15);
            lbRNC.TabIndex = 1;
            lbRNC.Text = "RNC";
            // 
            // lbDirección
            // 
            lbDirección.AutoSize = true;
            lbDirección.Location = new Point(20, 100);
            lbDirección.Name = "lbDirección";
            lbDirección.Size = new Size(57, 15);
            lbDirección.TabIndex = 2;
            lbDirección.Text = "Dirección";
            // 
            // lbTeléfono
            // 
            lbTeléfono.AutoSize = true;
            lbTeléfono.Location = new Point(20, 180);
            lbTeléfono.Name = "lbTeléfono";
            lbTeléfono.Size = new Size(53, 15);
            lbTeléfono.TabIndex = 3;
            lbTeléfono.Text = "Teléfono";
            // 
            // lbCorreo
            // 
            lbCorreo.AutoSize = true;
            lbCorreo.Location = new Point(20, 220);
            lbCorreo.Name = "lbCorreo";
            lbCorreo.Size = new Size(43, 15);
            lbCorreo.TabIndex = 4;
            lbCorreo.Text = "Correo";
            // 
            // lbImpuesto
            // 
            lbImpuesto.AutoSize = true;
            lbImpuesto.Location = new Point(20, 260);
            lbImpuesto.Name = "lbImpuesto";
            lbImpuesto.Size = new Size(78, 15);
            lbImpuesto.TabIndex = 5;
            lbImpuesto.Text = "Impuesto (%)";
            // 
            // lbLogo
            // 
            lbLogo.AutoSize = true;
            lbLogo.Location = new Point(500, 20);
            lbLogo.Name = "lbLogo";
            lbLogo.Size = new Size(34, 15);
            lbLogo.TabIndex = 6;
            lbLogo.Text = "Logo";
            // 
            // txNombreEmpresa
            // 
            txNombreEmpresa.Location = new Point(150, 20);
            txNombreEmpresa.Name = "txNombreEmpresa";
            txNombreEmpresa.Size = new Size(300, 23);
            txNombreEmpresa.TabIndex = 7;
            // 
            // txRNC
            // 
            txRNC.Location = new Point(150, 60);
            txRNC.Name = "txRNC";
            txRNC.Size = new Size(300, 23);
            txRNC.TabIndex = 8;
            // 
            // txDirección
            // 
            txDirección.Location = new Point(150, 100);
            txDirección.Name = "txDirección";
            txDirección.Size = new Size(300, 23);
            txDirección.TabIndex = 9;
            // 
            // txTeléfono
            // 
            txTeléfono.Location = new Point(150, 180);
            txTeléfono.Name = "txTeléfono";
            txTeléfono.Size = new Size(300, 23);
            txTeléfono.TabIndex = 10;
            // 
            // txCorreo
            // 
            txCorreo.Location = new Point(150, 220);
            txCorreo.Name = "txCorreo";
            txCorreo.Size = new Size(300, 23);
            txCorreo.TabIndex = 11;
            // 
            // nudImpuesto
            // 
            nudImpuesto.DecimalPlaces = 2;
            nudImpuesto.Location = new Point(150, 260);
            nudImpuesto.Name = "nudImpuesto";
            nudImpuesto.Size = new Size(120, 23);
            nudImpuesto.TabIndex = 12;
            // 
            // pbLogo
            // 
            pbLogo.BorderStyle = BorderStyle.FixedSingle;
            pbLogo.Location = new Point(500, 50);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(250, 150);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 13;
            pbLogo.TabStop = false;
            // 
            // btnCargarLogo
            // 
            btnCargarLogo.Location = new Point(500, 210);
            btnCargarLogo.Name = "btnCargarLogo";
            btnCargarLogo.Size = new Size(75, 23);
            btnCargarLogo.TabIndex = 14;
            btnCargarLogo.Text = "Cargar Logo";
            btnCargarLogo.UseVisualStyleBackColor = true;
            btnCargarLogo.Click += btnCargarLogo_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(330, 310);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(120, 35);
            btnGuardar.TabIndex = 15;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // fConfiguración
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 500);
            Controls.Add(btnGuardar);
            Controls.Add(btnCargarLogo);
            Controls.Add(pbLogo);
            Controls.Add(nudImpuesto);
            Controls.Add(txCorreo);
            Controls.Add(txTeléfono);
            Controls.Add(txDirección);
            Controls.Add(txRNC);
            Controls.Add(txNombreEmpresa);
            Controls.Add(lbLogo);
            Controls.Add(lbImpuesto);
            Controls.Add(lbCorreo);
            Controls.Add(lbTeléfono);
            Controls.Add(lbDirección);
            Controls.Add(lbRNC);
            Controls.Add(lbNombreEmpresa);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fConfiguración";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Configuración de la Empresa";
            ((System.ComponentModel.ISupportInitialize)nudImpuesto).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbNombreEmpresa;
        private Label lbRNC;
        private Label lbDirección;
        private Label lbTeléfono;
        private Label lbCorreo;
        private Label lbImpuesto;
        private Label lbLogo;
        private TextBox txNombreEmpresa;
        private TextBox txRNC;
        private TextBox txDirección;
        private TextBox txTeléfono;
        private TextBox txCorreo;
        private NumericUpDown nudImpuesto;
        private PictureBox pbLogo;
        private Button btnCargarLogo;
        private Button btnGuardar;
    }
}