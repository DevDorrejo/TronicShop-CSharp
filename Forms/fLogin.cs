using System.Windows.Forms;
using TronicShop.Forms;
using TronicShop.Methods;
using TronicShop.Repositories;

namespace TronicShop
{
    public partial class fLogin : Form
    {
        private readonly UsuarioRepository _repo = new();
        private void LoadLogo()
        {
            try
            {
                var configRepo = new Configuraci�nRepository();
                byte[] logoBytes = configRepo.GetLogo();

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

        public fLogin()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
            LoadLogo();
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
                string contrase�a = txtContrase�a.Text;

                if (string.IsNullOrWhiteSpace(usuario))
                {
                    TtHelper.Mostrar(txtUsuario, "Por favor ingrese usuario.");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(contrase�a))
                {
                    TtHelper.Mostrar(txtContrase�a, "Por favor ingrese contrase�a.");
                    return;
                }
                var elusuario = _repo.Login(usuario, contrase�a);

                if (elusuario == null)
                {
                    TtHelper.Mostrar(txtUsuario,"Credenciales incorrectas.");
                    return;
                }

                // Ir al formulario principal
                var main = new fMain(elusuario);
                main.Show();
                this.Hide();
            }
            catch (Npgsql.NpgsqlException ex) when (ex.InnerException is TimeoutException || ex.Message.Contains("timeout"))
            {
                MessageBox.Show("No se pudo conectar con la base de datos. Verifica tu conexi�n.", "Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurri� un error inesperado:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}