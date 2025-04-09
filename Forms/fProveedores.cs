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

namespace TronicShop.Forms
{
    public partial class fProveedores : Form
    {
        private readonly ProveedorRepository _repo = new();
        private int? proveedorIdSeleccionado = null;
        private void LoadProveedores()
        {
            var lista = _repo.GetAll();
            loadData.dgvLoad(dgvProveedores, lista, ["Id", "FechaCreado", "FechaActualizado"]);
        }
        private void LimpiarCampos()
        {
            proveedorIdSeleccionado = null;
            txCompañía.Clear();
            txNombreContacto.Clear();
            txTeléfono1.Clear();
            txTeléfono2.Clear();
            txWhatsapp.Clear();
            txCorreo.Clear();
            txDirección.Clear();
            txRnc.Clear();
            chkEstado.Checked = true;
        }
        public fProveedores()
        {
            InitializeComponent();
            LoadProveedores();
            bindEvents.AsignarEventos(this.Controls);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txCompañía.Text))
            {
                TtHelper.Mostrar(txCompañía, "Ingrese el nombre de la compañía.");
                return;
            }

            if (!Validaciones.ValidarTexto(txNombreContacto.Text, 3))
            {
                TtHelper.Mostrar(txNombreContacto, "Nombre del contacto obligatorio.");
                return;
            }

            if (!Validaciones.ValidarTeléfono(txTeléfono1.Text))
            {
                TtHelper.Mostrar(txTeléfono1, "Teléfono inválido.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txTeléfono2.Text) && !Validaciones.ValidarTeléfono(txTeléfono2.Text))
            {
                TtHelper.Mostrar(txTeléfono2, "Teléfono 2 inválido.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txWhatsapp.Text) && !Validaciones.ValidarTeléfono(txWhatsapp.Text))
            {
                TtHelper.Mostrar(txWhatsapp, "Número de WhatsApp inválido.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txCorreo.Text) && !Validaciones.EsCorreoValido(txCorreo.Text))
            {
                TtHelper.Mostrar(txCorreo, "Correo inválido.");
                return;
            }

            if (!Validaciones.ValidarTexto(txDirección.Text, 5))
            {
                TtHelper.Mostrar(txDirección, "Dirección es obligatoria.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(txRnc.Text) && !Validaciones.ValidarRNC(txRnc.Text))
            {
                TtHelper.Mostrar(txRnc, "RNC inválido (9 dígitos).");
                return;
            }

            var proveedor = new Proveedor
            {
                Id = proveedorIdSeleccionado ?? 0,
                Compañía = txCompañía.Text.Trim(),
                NombreContacto = txNombreContacto.Text.Trim(),
                Teléfono = txTeléfono1.Text.Trim(),
                Teléfono2 = txTeléfono2.Text.Trim(),
                Whatsapp = txWhatsapp.Text.Trim(),
                Correo = txCorreo.Text.Trim(),
                Dirección = txDirección.Text.Trim(),
                RNC = txRnc.Text.Trim(),
                Estado = chkEstado.Checked
            };

            bool ok = proveedorIdSeleccionado == null
                ? _repo.Insert(proveedor)
                : _repo.Update(proveedor);

            if (ok)
            {
                MessageBox.Show("Proveedor guardado correctamente.", "Éxito");
                LoadProveedores();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar el proveedor.", "Error");
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (proveedorIdSeleccionado == null)
                return;

            var confirmar = MessageBox.Show("¿Deseas eliminar este proveedor?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            if (_repo.Delete(proveedorIdSeleccionado.Value))
            {
                MessageBox.Show("Proveedor eliminado.");
                LoadProveedores();
                LimpiarCampos();
            }
        }
        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvProveedores.Rows[e.RowIndex];
            var proveedor = (Proveedor)fila.DataBoundItem;

            proveedorIdSeleccionado = proveedor.Id;
            txCompañía.Text = proveedor.Compañía;
            txNombreContacto.Text = proveedor.NombreContacto;
            txTeléfono1.Text = proveedor.Teléfono;
            txTeléfono2.Text = proveedor.Teléfono2;
            txWhatsapp.Text = proveedor.Whatsapp;
            txCorreo.Text = proveedor.Correo;
            txDirección.Text = proveedor.Dirección;
            txRnc.Text = proveedor.RNC;
            chkEstado.Checked = proveedor.Estado;
        }
        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            chkEstado.Text = chkEstado.Checked ? "Activo" : "Inactivo";
        }
    }
}
