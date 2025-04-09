namespace TronicShop.Forms.Reportes
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
            dgvReporte = new DataGridView();
            btnPDF = new Button();
            btnEXCEL = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvReporte).BeginInit();
            SuspendLayout();
            // 
            // dgvReporte
            // 
            dgvReporte.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporte.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporte.Location = new Point(12, 12);
            dgvReporte.Name = "dgvReporte";
            dgvReporte.ReadOnly = true;
            dgvReporte.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReporte.Size = new Size(826, 440);
            dgvReporte.TabIndex = 0;
            // 
            // btnPDF
            // 
            btnPDF.Font = new Font("Fira Sans", 12F);
            btnPDF.Location = new Point(723, 458);
            btnPDF.Name = "btnPDF";
            btnPDF.Size = new Size(115, 30);
            btnPDF.TabIndex = 1;
            btnPDF.Text = "Exportar PDF";
            btnPDF.UseVisualStyleBackColor = true;
            btnPDF.Click += btnPDF_Click;
            // 
            // btnEXCEL
            // 
            btnEXCEL.Font = new Font("Fira Sans", 12F);
            btnEXCEL.Location = new Point(627, 458);
            btnEXCEL.Name = "btnEXCEL";
            btnEXCEL.Size = new Size(90, 30);
            btnEXCEL.TabIndex = 9;
            btnEXCEL.Text = "EXCEL";
            btnEXCEL.UseVisualStyleBackColor = true;
            btnEXCEL.Click += btnEXCEL_Click;
            // 
            // fProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(850, 500);
            Controls.Add(btnEXCEL);
            Controls.Add(btnPDF);
            Controls.Add(dgvReporte);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fProductos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reporte de Productos";
            ((System.ComponentModel.ISupportInitialize)dgvReporte).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReporte;
        private Button btnPDF;
        private Button btnEXCEL;
    }
}