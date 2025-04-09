using iTextSharp.text;
using iTextSharp.text.pdf;
using Document = iTextSharp.text.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TronicShop.Repositories;
using TronicShop.Methods;
using TronicShop.Utils;

namespace TronicShop.Forms.Reportes
{
    public partial class fProductos : Form
    {
        private readonly ProductoRepository _repo = new();

        public fProductos()
        {
            InitializeComponent();
            loadData.dgvLoad(dgvReporte, _repo.GetAll());
            dgvReporte.Columns["Id"].Visible = false;
            dgvReporte.Columns["Estado"].Visible = false;
            dgvReporte.Columns["IdProveedor"].Visible = false;
            dgvReporte.Columns["FechaCreado"].Visible = false;
            dgvReporte.Columns["FechaActualizado"].Visible = false;
            dgvReporte.Columns["NombreProveedor"].HeaderText = "Proveedor";
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            var productos = _repo.GetAll(); // si quieres, filtra solo activos
            if (productos.Count == 0)
            {
                MessageBox.Show("No hay productos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ReporteUtils.ProductosPDF(productos);
        }

        private void btnEXCEL_Click(object sender, EventArgs e)
        {
            var productos = _repo.GetAll(); // o GetActivos() si quieres filtrar
            ReporteUtils.GenerarReporteProductosExcel(productos);
        }
    }
}
