using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TronicShop.Methods;
using TronicShop.Models;
using TronicShop.Repositories;
using TronicShop.Utils;

namespace TronicShop.Forms
{
    public partial class fUsuarios : Form
    {
        private readonly UsuarioRepository _repo = new();
        private int? usuarioIdSeleccionado = null;
        private readonly HashSet<Control> toolTipsActivos = new();

        // ========================== //
        //    Sección de funciones    //
        // ========================== //
        private void LoadUsuarios()
        {
            dgvUsuarios.DataSource = _repo.GetAll();
            dgvUsuarios.Columns["Contraseña"].Visible = false;
            dgvUsuarios.Columns["Id"].Visible = false;
        }
        private void LimpiarCampos()
        {
            usuarioIdSeleccionado = null;
            txNombre.Clear();
            txUsuario.Clear();
            txContraseña.Clear();
            cbRol.SelectedIndex = -1;
            chkEstado.Checked = true;
        }
        public fUsuarios()
        {
            InitializeComponent();
            cbRol.SelectedIndex = -1;
            LoadUsuarios();
            bindEvents.AsignarEventos(this.Controls);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txNombre.Text.Trim();
            string usuario = txUsuario.Text.Trim();
            string contraseña = txContraseña.Text.Trim();
            string rol = cbRol.SelectedItem?.ToString() ?? "";
            bool estado = chkEstado.Checked;

            if (!Validaciones.ValidarTexto(nombre, 3))
            {
                TtHelper.Mostrar(txNombre, "Ingrese un nombre válido.");
                return;
            }

            if (!Validaciones.ValidarTexto(usuario, 3))
            {
                TtHelper.Mostrar(txUsuario, "Usuario inválido.");
                return;
            }

            if (usuarioIdSeleccionado == null && string.IsNullOrWhiteSpace(contraseña))
            {
                TtHelper.Mostrar(txContraseña, "Debe ingresar una contraseña para el nuevo usuario.");
                return;
            }

            if (cbRol.SelectedIndex == -1)
            {
                TtHelper.Mostrar(cbRol, "Debe seleccionar un rol.");
                return;
            }

            var usuarioObj = new Usuario
            {
                Id = usuarioIdSeleccionado ?? 0,
                Nombre = nombre,
                Username = usuario,
                Contraseña = (!string.IsNullOrWhiteSpace(contraseña))
                                ? CryptoPass.Encrypt(contraseña)
                                : _repo.GetByID(usuarioIdSeleccionado ?? 0)?.Contraseña ?? Array.Empty<byte>(),
                Rol = rol.ToLower(),
                Estado = estado
            };

            bool ok = usuarioIdSeleccionado == null
                        ? _repo.Insert(usuarioObj)
                        : _repo.Update(usuarioObj);

            if (ok)
            {
                MessageBox.Show("Usuario guardado correctamente.", "Éxito");
                LoadUsuarios();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar el usuario.", "Error");
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var elusuario = (Usuario)dgvUsuarios.Rows[e.RowIndex].DataBoundItem;
                usuarioIdSeleccionado = elusuario.Id;
                txNombre.Text = elusuario.Nombre;
                txUsuario.Text = elusuario.Username;
                cbRol.SelectedItem = elusuario.Rol;
                chkEstado.Checked = elusuario.Estado;
                txContraseña.Text = ""; // no mostrar clave
                txContraseña.PlaceholderText = "Dejar en blanco para omitir.";
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (usuarioIdSeleccionado == null)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
                return;
            }
            var confirm = MessageBox.Show("¿Está seguro de eliminar este usuario?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                if (_repo.Delete(usuarioIdSeleccionado.Value))
                {
                    MessageBox.Show("Usuario eliminado.");
                    LoadUsuarios();
                    LimpiarCampos();
                }
                else
                    MessageBox.Show("No se pudo eliminar.");
            }
        }
    }
}
