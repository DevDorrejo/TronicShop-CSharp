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
using TronicShop.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TronicShop.Forms
{
    public partial class fVentas : Form
    {
        private readonly Usuario _usuario;
        private readonly ClienteRepository _clienteRepo = new();
        private readonly ProductoRepository _productoRepo = new();
        private readonly VentaRepository _ventaRepo = new();
        private readonly ConfiguraciónRepository _configRepo = new();

        private List<Producto> _productos = new();
        private List<Cliente> _clientes = new();
        private List<DetalleVenta> _carrito = new();

        public fVentas(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;

            lbUsuario.Text = $"Vendedor: {_usuario.Nombre}";
            lbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
            ActualizarVistaCarrito();
            LoadClientesYProductos();
        }

        private void LoadClientesYProductos()
        {
            _clientes = _clienteRepo.GetAll();
            _productos = _productoRepo.GetAll().Where(p => p.Estado && p.Stock > 0).ToList();

            cbCliente.DataSource = null;
            cbCliente.DataSource = _clientes;
            cbCliente.DisplayMember = "Nombre";
            cbCliente.ValueMember = "Id";
            cbCliente.SelectedIndex = -1;

            cbProducto.DataSource = null;
            cbProducto.DataSource = _productos;
            cbProducto.DisplayMember = "Nombre";
            cbProducto.ValueMember = "Id";
            cbProducto.SelectedIndex = -1;
        }

        private void ActualizarVistaCarrito()
        {
            dgvCarrito.DataSource = null;
            dgvCarrito.DataSource = _carrito.Select(x => new
            {
                Producto = x.ProductoNombre,
                Cantidad = x.Cantidad,
                Unitario = x.PrecioUnitario,
                Total = x.TotalLinea
            }).ToList();

            decimal subtotal = _carrito.Sum(x => x.TotalLinea);
            decimal itbisDecimal = _configRepo.GetITBIS();
            decimal montoITBIS = subtotal * itbisDecimal;
            decimal totalFinal = subtotal + montoITBIS;

            lbSubTotal.Text = $"Subtotal: {subtotal:C}";
            lbITBIS.Text = $"ITBIS ({(itbisDecimal * 100):F2}%): {montoITBIS:C}";
            lbTotal.Text = $"Total: {totalFinal:C}";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedItem is not Producto producto) return;

            int cantidad = (int)nudCantidad.Value;

            if (cantidad <= 0)
            {
                TtHelper.Mostrar(cbProducto, "Cantidad inválida");
                return;
            }

            if (cantidad > producto.Stock)
            {
                TtHelper.Mostrar(cbProducto, "Stock insuficiente");
                return;
            }

            var existente = _carrito.FirstOrDefault(p => p.IdProducto == producto.Id);
            if (existente != null)
            {
                if (existente.Cantidad + cantidad > producto.Stock)
                {
                    TtHelper.Mostrar(cbProducto, "Stock insuficiente");
                    return;
                }
                existente.Cantidad += cantidad;
                existente.TotalLinea = existente.Cantidad * existente.PrecioUnitario;
            }
            else
            {
                _carrito.Add(new DetalleVenta
                {
                    IdProducto = producto.Id,
                    ProductoNombre = producto.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio,
                    TotalLinea = cantidad * producto.Precio
                });
            }
            cbCliente.Enabled = false;
            ActualizarVistaCarrito();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvCarrito.SelectedRows.Count == 0) return;

            var index = dgvCarrito.SelectedRows[0].Index;
            _carrito.RemoveAt(index);
            ActualizarVistaCarrito();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            cbCliente.Enabled = true;
            if (_carrito.Count == 0)
            {
                MessageBox.Show("No hay productos en el carrito", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbCliente.SelectedItem is not Cliente cliente)
            {
                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal subtotal = _carrito.Sum(p => p.TotalLinea);
            decimal impuesto = _configRepo.GetITBIS();
            decimal total = subtotal + (subtotal * impuesto);

            var venta = new Venta
            {
                IdCliente = cliente.Id,
                IdUsuario = _usuario.Id,
                Total = total,
                Estado = true
            };

            bool ok = _ventaRepo.Insert(venta, _carrito);
            if (ok)
            {
                MessageBox.Show("Venta guardada correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReporteUtils.GenerarFacturaPDF(venta, _carrito, cliente.Nombre, _usuario.Nombre);
                _carrito.Clear();
                ActualizarVistaCarrito();
            }
            else
            {
                MessageBox.Show("Error al guardar la venta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarVenta_Click(object sender, EventArgs e)
        {
            if (_carrito.Count > 0)
            {
                foreach (var item in _carrito)
                {
                    _productoRepo.RestaurarStock(item.IdProducto, item.Cantidad);
                }
            }

            _carrito.Clear();
            dgvCarrito.DataSource = null;
            cbCliente.Enabled = true;
            ActualizarVistaCarrito();
        }
    }
}
