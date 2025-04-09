using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class fProductos : Form
    {
        private readonly ProductoRepository _repo = new();
        private readonly ProveedorRepository _repoProveedor = new();
        private int? productoIdSeleccionado = null;

        // ========================== //
        //    Sección de funciones    //
        // ========================== //
        private void LoadProveedores()
        {
            cbProveedor.DataSource = _repoProveedor.GetAll(); // o lista de proveedores
            cbProveedor.DisplayMember = "Compañía";
            cbProveedor.ValueMember = "Id";
            cbProveedor.SelectedIndex = -1;
        }
        private void LoadProductos()
        {
            loadData.dgvLoad(dgvProductos, _repo.GetAll(), ["Id", "FechaCreado", "FechaActualizado", "IdProveedor"]);
            dgvProductos.Columns["NombreProveedor"].HeaderText = "Proveedor";
        }
        private void LimpiarCampos()
        {
            productoIdSeleccionado = null;
            txCódigoBarra.Clear();
            txNombre.Clear();
            txDescripción.Clear();
            txCategoría.Clear();
            txPrecio.Text = "0";
            txStock.Text = "0";
            cbProveedor.SelectedIndex = -1;
            chkEstado.Checked = true;
        }
        public fProductos()
        {
            InitializeComponent();
            LoadProveedores();
            LoadProductos();
            bindEvents.AsignarEventos(this.Controls);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbProveedor.SelectedIndex == -1)
            {
                TtHelper.Mostrar(cbProveedor, "Debe seleccionar un proveedor.");
                return;
            }
            if (string.IsNullOrWhiteSpace(txNombre.Text))
            {
                TtHelper.Mostrar(txNombre, "Debe ingresar un nombre.");
                return;
            }
            if (cbProveedor.SelectedValue == null || !int.TryParse(cbProveedor.SelectedValue.ToString(), out _))
            {
                TtHelper.Mostrar(cbProveedor, "Proveedor inválido o no seleccionado.");
                return;
            }
            if (!decimal.TryParse(txPrecio.Text.Trim(), out decimal precio) || precio <= 0)
            {
                TtHelper.Mostrar(txPrecio, "Precio inválido.");
                return;
            }
            if (!int.TryParse(txStock.Text.Trim(), out int stock) || stock < 0)
            {
                TtHelper.Mostrar(txStock, "Stock inválido.");
                return;
            }
            var producto = new Producto
            {
                Id = productoIdSeleccionado ?? 0,
                CódigoBarra = txCódigoBarra.Text.Trim(),
                Nombre = txNombre.Text.Trim(),
                Descripción = txDescripción.Text.Trim(),
                Categoría = txCategoría.Text.Trim(),
                Precio = precio,
                Stock = stock,
                Estado = chkEstado.Checked,
                IdProveedor = cbProveedor.SelectedValue as int?
            };
            bool ok = productoIdSeleccionado == null
                ? _repo.Insert(producto)
                : _repo.Update(producto);

            if (ok)
            {
                MessageBox.Show("Producto guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadProductos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar el producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (productoIdSeleccionado == null)
                return;

            var confirmar = MessageBox.Show("¿Deseas eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes)
                return;

            if (_repo.Delete(productoIdSeleccionado.Value))
            {
                MessageBox.Show("Producto eliminado.", "Éxito");
                LoadProductos();
                LimpiarCampos();
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var fila = dgvProductos.Rows[e.RowIndex];
            var producto = (Producto)fila.DataBoundItem;

            productoIdSeleccionado = producto.Id;
            txCódigoBarra.Text = producto.CódigoBarra;
            txNombre.Text = producto.Nombre;
            txDescripción.Text = producto.Descripción;
            txCategoría.Text = producto.Categoría;
            txPrecio.Text = producto.Precio.ToString("0.00");
            txStock.Text = producto.Stock.ToString();
            chkEstado.Checked = producto.Estado;
            cbProveedor.SelectedValue = Convert.ToInt32(producto.IdProveedor);
        }
        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {
            chkEstado.Text = chkEstado.Checked ? "Activo" : "Inactivo";
        }
    }
}

