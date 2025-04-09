namespace TronicShop
{
    partial class fLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLogin));
            pbLogo = new PictureBox();
            lbUsuario = new Label();
            lbContraseña = new Label();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            btnLogin = new Button();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.BorderStyle = BorderStyle.FixedSingle;
            pbLogo.ErrorImage = (Image)resources.GetObject("pbLogo.ErrorImage");
            pbLogo.Image = Properties.Resources.X_Logo;
            pbLogo.Location = new Point(15, 15);
            pbLogo.Margin = new Padding(5);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(128, 128);
            pbLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.Font = new Font("Microsoft Sans Serif", 12F);
            lbUsuario.Location = new Point(151, 17);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Padding = new Padding(5);
            lbUsuario.Size = new Size(74, 30);
            lbUsuario.TabIndex = 100;
            lbUsuario.Text = "Usuario";
            // 
            // lbContraseña
            // 
            lbContraseña.AutoSize = true;
            lbContraseña.Font = new Font("Microsoft Sans Serif", 12F);
            lbContraseña.Location = new Point(151, 60);
            lbContraseña.Name = "lbContraseña";
            lbContraseña.Padding = new Padding(5);
            lbContraseña.Size = new Size(102, 30);
            lbContraseña.TabIndex = 100;
            lbContraseña.Text = "Contraseña";
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Microsoft Sans Serif", 12F);
            txtContraseña.Location = new Point(257, 62);
            txtContraseña.MaxLength = 32;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.PlaceholderText = "Contraseña";
            txtContraseña.Size = new Size(217, 26);
            txtContraseña.TabIndex = 1;
            // 
            // txtUsuario
            // 
            txtUsuario.Font = new Font("Microsoft Sans Serif", 12F);
            txtUsuario.Location = new Point(232, 19);
            txtUsuario.MaxLength = 50;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.PlaceholderText = "Usuario";
            txtUsuario.Size = new Size(242, 26);
            txtUsuario.TabIndex = 0;
            // 
            // btnLogin
            // 
            btnLogin.AutoSize = true;
            btnLogin.Font = new Font("Microsoft Sans Serif", 12F);
            btnLogin.Location = new Point(356, 104);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(118, 30);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Iniciar Sesión";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnCerrar
            // 
            btnCerrar.AutoSize = true;
            btnCerrar.Font = new Font("Microsoft Sans Serif", 12F);
            btnCerrar.Location = new Point(265, 104);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(76, 30);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // fLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(487, 154);
            Controls.Add(btnCerrar);
            Controls.Add(btnLogin);
            Controls.Add(txtUsuario);
            Controls.Add(txtContraseña);
            Controls.Add(lbContraseña);
            Controls.Add(lbUsuario);
            Controls.Add(pbLogo);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fLogin";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterScreen;
            Load += fLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbLogo;
        private Label lbUsuario;
        private Label lbContraseña;
        private TextBox txtContraseña;
        private TextBox txtUsuario;
        private Button btnLogin;
        private Button btnCerrar;
    }
}
