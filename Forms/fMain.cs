using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TronicShop.Models;
using Timer = System.Windows.Forms.Timer;

namespace TronicShop.Forms
{
    public partial class fMain : Form
    {
        private readonly Usuario _usuario;

        // ========================== //
        //    Sección de funciones    //
        // ========================== //
        private void AplicarPermisos()
        {
            // Asegúrate de cambiar los nombres de controles si son diferentes en tu formulario
            if (_usuario.Rol.ToLower() != "admin")
            {
                // Ocultar secciones exclusivas del Admin
                menuUsuarios.Visible = false;
                menuConfiguración.Visible = false;
                menuReportes.Visible = false;
                archivoSeparator1.Visible = false;
            }
        }

        // Versión mejorada del método AbrirUnicoFormulario
        private void AbrirUnicoFormulario<T>(Func<Form> crearFormulario) where T : Form
        {
            // Cerrar todos los formularios hijos abiertos
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            // Crear y mostrar nuevo formulario
            var form = crearFormulario();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }

        // Versión para formularios con constructor sin parámetros
        private void AbrirUnicoFormulario<T>() where T : Form, new()
        {
            AbrirUnicoFormulario<T>(() => new T());
        }

        public fMain(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            AplicarPermisos();

            lbUsuario.Text = $"Usuario: {_usuario.Nombre}";
            lbRol.Text = $"Rol: {_usuario.Rol}";
            lbHora.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");

            var tiempo = new Timer();
            tiempo.Interval = 1000;
            tiempo.Tick += (s, e) => lbHora.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            tiempo.Start();

        }
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        private void menuCerrarSesión_Click(object sender, EventArgs e)
        {
            this.Hide();
            var login = new fLogin();
            login.Show();
        }
        private void menuSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            Text = "TronicShop - Usuarios";
            AbrirUnicoFormulario<fUsuarios>();
        }
        private void menuProductos_Click(object sender, EventArgs e)
        {
            Text = "TronicShop - Productos";
            AbrirUnicoFormulario<fProductos>();
        }
        private void reporteProductos_Click(object sender, EventArgs e)
        {
            Text = "TronicShop - Reporte de Productos";
            AbrirUnicoFormulario<Reportes.fProductos>();
        }
        private void menuClientes_Click(object sender, EventArgs e)
        {
            Text = "TronicShop - Clientes";
            AbrirUnicoFormulario<fClientes>();

        }
        private void menuVentas_Click(object sender, EventArgs e)
        {
            Text = "TronicShop - Ventas";
            AbrirUnicoFormulario<fVentas>(() => new fVentas(_usuario));
        }
        private void reporteVentas_Click(object sender, EventArgs e)
        {
            Text = "TronicShop - Clientes";
            AbrirUnicoFormulario<Reportes.fVentas>();

        }
        private void menuConfiguración_Click(object sender, EventArgs e)
        {
            Text = "TronicShop - Configuración";
            AbrirUnicoFormulario<fConfiguración>();
        }
        private void menuProveedores_Click(object sender, EventArgs e)
        {
            Text = "TronicShop - Proveedores";
            AbrirUnicoFormulario<fProveedores>();
        }
    }
}
