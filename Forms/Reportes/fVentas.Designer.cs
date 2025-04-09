namespace TronicShop.Forms.Reportes
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
            lbDesde = new Label();
            lbHasta = new Label();
            dtDesde = new DateTimePicker();
            dtHasta = new DateTimePicker();
            btnBuscar = new Button();
            btnPDF = new Button();
            dgvVentas = new DataGridView();
            btnEXCEL = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // lbDesde
            // 
            lbDesde.AutoSize = true;
            lbDesde.Font = new Font("Fira Sans", 12F);
            lbDesde.Location = new Point(20, 20);
            lbDesde.Name = "lbDesde";
            lbDesde.Size = new Size(54, 19);
            lbDesde.TabIndex = 0;
            lbDesde.Text = "Desde";
            // 
            // lbHasta
            // 
            lbHasta.AutoSize = true;
            lbHasta.Font = new Font("Fira Sans", 12F);
            lbHasta.Location = new Point(300, 20);
            lbHasta.Name = "lbHasta";
            lbHasta.Size = new Size(51, 19);
            lbHasta.TabIndex = 1;
            lbHasta.Text = "Hasta";
            // 
            // dtDesde
            // 
            dtDesde.Font = new Font("Fira Sans", 12F);
            dtDesde.Location = new Point(80, 16);
            dtDesde.Name = "dtDesde";
            dtDesde.Size = new Size(200, 27);
            dtDesde.TabIndex = 2;
            // 
            // dtHasta
            // 
            dtHasta.Font = new Font("Fira Sans", 12F);
            dtHasta.Location = new Point(360, 16);
            dtHasta.Name = "dtHasta";
            dtHasta.Size = new Size(200, 27);
            dtHasta.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Font = new Font("Fira Sans", 12F);
            btnBuscar.Location = new Point(580, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 27);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnPDF
            // 
            btnPDF.Font = new Font("Fira Sans", 12F);
            btnPDF.Location = new Point(748, 458);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(90, 30);
            btnPDF.TabIndex = 5;
            btnPDF.Text = "PDF";
            btnPDF.UseVisualStyleBackColor = true;
            btnPDF.Click += btnReporte_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(12, 49);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(826, 403);
            dgvVentas.TabIndex = 7;
            // 
            // btnEXCEL
            // 
            btnEXCEL.Font = new Font("Fira Sans", 12F);
            btnEXCEL.Location = new Point(652, 458);
            btnEXCEL.Name = "btnEXCEL";
            btnEXCEL.Size = new Size(90, 30);
            btnEXCEL.TabIndex = 8;
            btnEXCEL.Text = "EXCEL";
            btnEXCEL.UseVisualStyleBackColor = true;
            btnEXCEL.Click += btnEXCEL_Click;
            // 
            // fVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 500);
            Controls.Add(btnEXCEL);
            Controls.Add(dgvVentas);
            Controls.Add(btnPDF);
            Controls.Add(btnBuscar);
            Controls.Add(dtHasta);
            Controls.Add(dtDesde);
            Controls.Add(lbHasta);
            Controls.Add(lbDesde);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fVentas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ventas";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbDesde;
        private Label lbHasta;
        private DateTimePicker dtDesde;
        private DateTimePicker dtHasta;
        private Button btnBuscar;
        private Button btnPDF;
        private DataGridView dgvVentas;
        private Button btnEXCEL;
    }
}