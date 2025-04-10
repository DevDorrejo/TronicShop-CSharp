using System.Windows.Forms;
using TronicShop.Forms;
using TronicShop.Methods;
using TronicShop.Models;
using TronicShop.Repositories;

namespace TronicShop
{
    public partial class fLogin : Form
    {
        private readonly UsuarioRepository _repo = new();
        private fMain _main;
        public Usuario? Usuario { get; private set; } = null;
        private void LoadLogo()
        {
            try
            {
                var configRepo = new ConfiguraciónRepository();
                byte[]? logoBytes = configRepo.GetLogo();

                if (logoBytes != null && logoBytes.Length > 0)
                {
                    using (var ms = new MemoryStream(logoBytes))
                    {
                        pbLogo.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Cargar una imagen por defecto con X
                    pbLogo.Image = Properties.Resources.X_Logo; // Agrega tu imagen en Resources
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el logo: " + ex.Message);
                pbLogo.Image = Properties.Resources.X_Logo;
            }
        }

        public fLogin(fMain main)
        {
            InitializeComponent();
            AcceptButton = btnLogin;
            _main = main;
            LoadLogo();

            if (MdiParent != null)
            {
                int x = (MdiParent.ClientSize.Width - Width) / 2;
                int y = (MdiParent.ClientSize.Height - Height) / 2;
                Location = new Point(x, y);
            }
        }
        private void fLogin_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string contraseña = txtContraseña.Text;

                if (string.IsNullOrWhiteSpace(usuario))
                {
                    TtHelper.Mostrar(txtUsuario, "Por favor ingrese usuario.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(contraseña))
                {
                    TtHelper.Mostrar(txtContraseña, "Por favor ingrese contraseña.");
                    return;
                }
                Usuario elusuario = _repo.Login(usuario, contraseña);

                if (elusuario != null)
                {
                    Usuario = elusuario;
                    _main.login(Usuario);
                    Close();
                }
                else
                {
                    MessageBox.Show("Credenciales inválidas.");
                }
            }
            catch (Npgsql.NpgsqlException ex) when (ex.InnerException is TimeoutException || ex.Message.Contains("timeout"))
            {
                MessageBox.Show("No se pudo conectar con la base de datos. Verifica tu conexión.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}