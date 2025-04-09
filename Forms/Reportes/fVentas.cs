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
using TronicShop.Repositories;
using TronicShop.Utils;

namespace TronicShop.Forms.Reportes
{
    public partial class fVentas : Form
    {
        private readonly VentaRepository _repo = new();
        private List<Venta> _ventas = new();

        public fVentas()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime desde = dtDesde.Value.Date;
            DateTime hasta = dtHasta.Value.Date.AddDays(1).AddTicks(-1);

            _ventas = _repo.ReporteConDetalles(desde, hasta);

            dgvVentas.DataSource = null;
            dgvVentas.DataSource = _ventas;

            dgvVentas.Columns["Id"].Visible = false;
            dgvVentas.Columns["IdCliente"].Visible = false;
            dgvVentas.Columns["IdUsuario"].Visible = false;
            dgvVentas.Columns["Estado"].Visible = false;

            dgvVentas.Columns["ClienteNombre"].HeaderText = "Cliente";
            dgvVentas.Columns["UsuarioNombre"].HeaderText = "Vendedor";
            dgvVentas.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm tt";
            dgvVentas.Columns["Total"].DefaultCellStyle.Format = "RD$ #,##0.00";
        }
        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una venta.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ventaSeleccionada = dgvVentas.CurrentRow.DataBoundItem as Venta;
            if (ventaSeleccionada == null)
            {
                MessageBox.Show("Error al obtener la venta seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool? generado = ReporteUtils.GenerarFacturaDesdeVenta(ventaSeleccionada);

            if (generado == true)
            {
                MessageBox.Show("Factura generada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (generado == false)
            {
                MessageBox.Show("Error al generar la factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Guardado cancelado por el usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            if (dgvVentas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var venta = dgvVentas.CurrentRow.DataBoundItem as Venta;
            if (venta == null)
            {
                MessageBox.Show("Error al obtener los datos de la venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool? generado = ReporteUtils.GenerarFacturaExcel(venta, venta.Detalles, venta.ClienteNombre, venta.UsuarioNombre);

            if (generado == true)
            {
                MessageBox.Show("Factura Excel exportada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (generado == false)
            {
                MessageBox.Show("Error al exportar la factura Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Guardado cancelado por el usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}


