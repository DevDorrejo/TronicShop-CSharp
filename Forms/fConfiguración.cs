using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TronicShop.Methods;
using TronicShop.Models;
using TronicShop.Repositories;

namespace TronicShop.Forms
{
    public partial class fConfiguración : Form
    {
        private readonly ConfiguraciónRepository _repo = new();
        private Configuración? _configActual;
        private readonly ToolTip _tooltip = new ToolTip();
        private void LoadConfiguracion()
        {
            _configActual = _repo.GetAll();

            if (_configActual == null)
                return;

            txNombreEmpresa.Text = _configActual.NombreEmpresa;
            txRNC.Text = _configActual.RNC;
            txDirección.Text = _configActual.Direccion;
            txTeléfono.Text = _configActual.Telefono;
            txCorreo.Text = _configActual.Correo;
            nudImpuesto.Value = (decimal)(_configActual.Impuesto * 100m);

            if (_configActual.Logo != null && _configActual.Logo.Length > 0)
            {
                using var ms = new MemoryStream(_configActual.Logo);
                pbLogo.Image = Image.FromStream(ms);
            }
        }
        public fConfiguración()
        {
            InitializeComponent();
            LoadConfiguracion();
            bindEvents.AsignarEventos(this.Controls);
        }
        private void btnCargarLogo_Click(object sender, EventArgs e)
        {
            using OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Imágenes (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg",
                Title = "Seleccionar logo"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbLogo.Image = Image.FromFile(ofd.FileName);
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txNombreEmpresa.Text.Trim();
            string rnc = txRNC.Text.Trim();
            string dirección = txDirección.Text.Trim();
            string teléfono = txTeléfono.Text.Trim();
            string correo = txCorreo.Text.Trim();
            decimal impuesto = nudImpuesto.Value / 100m;

            // Validaciones mínimas
            if (!Validaciones.ValidarTexto(nombre, 3))
            {
                TtHelper.Mostrar(txNombreEmpresa, "El nombre de la empresa es obligatorio");
                return;
            }

            if (!Validaciones.ValidarTexto(dirección, 5))
            {
                TtHelper.Mostrar(txDirección, "La dirección es obligatoria");
                return;
            }

            if (!Validaciones.ValidarTeléfono(teléfono))
            {
                TtHelper.Mostrar(txTeléfono, "El teléfono es obligatorio");
                return;
            }
            if (!string.IsNullOrWhiteSpace(correo) && !Validaciones.EsCorreoValido(correo))
            {
                TtHelper.Mostrar(txCorreo, "Correo inválido.");
                return;
            }
            byte[]? logoBytes = null;
            if (pbLogo.Image != null)
            {
                using var ms = new MemoryStream();
                pbLogo.Image.Save(ms, ImageFormat.Png);
                logoBytes = ms.ToArray();
            }

            var config = new Configuración
            {
                Id = _configActual?.Id ?? 0,
                NombreEmpresa = nombre,
                RNC = rnc,
                Direccion = dirección,
                Telefono = teléfono,
                Correo = correo,
                Impuesto = impuesto,
                Logo = logoBytes
            };

            bool exito = _repo.Guardar(config);
            if (exito)
            {
                MessageBox.Show("Configuración guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadConfiguracion();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar la configuración.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
