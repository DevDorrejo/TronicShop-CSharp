using Org.BouncyCastle.Asn1.Crmf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TronicShop.Methods;
using TronicShop.Models;
using TronicShop.Repositories;
using static TronicShop.Methods.Validaciones;

namespace TronicShop.Forms
{
    public partial class fClientes : Form
    {
        private readonly ClienteRepository _repo = new();
        private int? clienteIdSeleccionado = null;

        // ========================== //
        //    Sección de funciones    //
        // ========================== //
        private void LoadClientes()
        {
            loadData.dgvLoad(dgvClientes, _repo.GetAll(), ["Id", "FechaCreado"]);
        }
        private void LimpiarCampos()
        {
            clienteIdSeleccionado = null;

            txNombre.Text = string.Empty;
            txTeléfono.Text = string.Empty;
            txCorreo.Text = string.Empty;
            txDirección.Text = string.Empty;
            txIdentificación.Text = string.Empty;
            chkEstado.Checked = true;

            txNombre.Focus();
        }
        private void AsignarEventoIdentificación()
        {
            txIdentificación.TextChanged -= txIdentificación_TextChanged;
            txIdentificación.KeyPress -= txIdentificación_KeyPress;

            txIdentificación.TextChanged += txIdentificación_TextChanged;
            txIdentificación.KeyPress += txIdentificación_KeyPress;
        }

        public fClientes()
        {
            InitializeComponent();
            LoadClientes();
            bindEvents.AsignarEventos(this.Controls);
            rbCompañía.Checked = true;
            AsignarEventoIdentificación();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txNombre.Text.Trim();
            string teléfono = txTeléfono.Text.Trim();
            string dirección = txDirección.Text.Trim();
            string correo = txCorreo.Text.Trim();
            string identificación = txIdentificación.Text.Trim();
            bool estado = chkEstado.Checked;


            if (!Validaciones.ValidarTexto(nombre, 3))
            {
                TtHelper.Mostrar(txNombre, "Nombre inválido.");
                return;
            }
            if (!Validaciones.ValidarTeléfono(teléfono))
            {
                TtHelper.Mostrar(txTeléfono, "Teléfono inválido.");
                return;
            }
            if (!Validaciones.ValidarTexto(dirección, 5))
            {
                TtHelper.Mostrar(txDirección, "Dirección obligatoria.");
                return;
            }
            if (string.IsNullOrWhiteSpace(identificación))
            {
                TtHelper.Mostrar(txIdentificación, "Este campo es obligatorio.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(correo) && !Validaciones.EsCorreoValido(correo))
            {
                TtHelper.Mostrar(txCorreo, "Correo inválido.");
                return;
            }
            // Validar tipo de identificación
            if (rbFinal.Checked)
            {
                if (!Validaciones.ValidarCedula(identificación))
                {
                    TtHelper.Mostrar(txIdentificación, "Cédula inválida. Verifica el formato.");
                    return;
                }
            }
            else if (rbCompañía.Checked)
            {
                if (!Validaciones.ValidarRNC(identificación))
                {
                    TtHelper.Mostrar(txIdentificación, "RNC inválido. Verifica el formato.");
                    return;
                }
            }

            if (!string.IsNullOrWhiteSpace(correo) || !string.IsNullOrWhiteSpace(identificación))
            {
                var existente = _repo.GetByCorreoOIdentificación(correo, identificación);
                if (existente != null && existente.Id != clienteIdSeleccionado)
                {
                    if (!string.IsNullOrWhiteSpace(correo) && existente.Correo == correo)
                    {
                        TtHelper.Mostrar(txCorreo, "Ya existe un cliente con ese correo.");
                        return;
                    }
                    if (!string.IsNullOrWhiteSpace(identificación) && existente.Identificación == identificación)
                    {
                        // Validar tipo de identificación
                        if (rbFinal.Checked)
                        {
                            TtHelper.Mostrar(txIdentificación, "Ya existe un cliente con esa cédula.");
                            return;
                        }
                        else if (rbCompañía.Checked)
                        {
                            TtHelper.Mostrar(txIdentificación, "Ya existe un cliente con ese RNC.");
                            return;
                        }
                    }
                }
            }
            var cliente = new Cliente
            {
                Id = clienteIdSeleccionado ?? 0,
                Nombre = nombre,
                Teléfono = teléfono,
                Dirección = dirección,
                Correo = correo,
                Identificación = identificación,
                Estado = estado
            };

            bool ok = clienteIdSeleccionado == null
                ? _repo.Insert(cliente)
                : _repo.Update(cliente);

            if (ok)
            {
                MessageBox.Show("Cliente guardado correctamente.", "Éxito");
                LoadClientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Error al guardar el cliente.", "Error");
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (clienteIdSeleccionado == null)
            {
                MessageBox.Show("Debe seleccionar un cliente primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("¿Está seguro que desea eliminar este cliente?", "Confirmación",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            bool eliminado = _repo.Delete(clienteIdSeleccionado.Value);

            if (eliminado)
            {
                MessageBox.Show("Cliente eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClientes();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al eliminar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvClientes.CurrentRow == null)
                return;

            
            var fila = dgvClientes.CurrentRow;

            clienteIdSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
            txNombre.Text = fila.Cells["Nombre"].Value?.ToString() ?? "";
            txTeléfono.Text = fila.Cells["Teléfono"].Value?.ToString() ?? "";
            txCorreo.Text = fila.Cells["Correo"].Value?.ToString() ?? "";
            txDirección.Text = fila.Cells["Dirección"].Value?.ToString() ?? "";
            txIdentificación.Text = fila.Cells["Identificación"].Value?.ToString() ?? "";
            chkEstado.Checked = Convert.ToBoolean(fila.Cells["Estado"].Value ?? true);
        }

        private void rbCompañia_Click(object sender, EventArgs e)
        {
            AsignarEventoIdentificación();
            if (txIdentificación.PlaceholderText == "Final" || txIdentificación.PlaceholderText == "")
                txIdentificación.PlaceholderText = "RNC";

            if (rbCompañía.Checked)
            {
                txIdentificación.Text = string.Empty;
            }
        }
        private void rbFinal_Click(object sender, EventArgs e)
        {
            AsignarEventoIdentificación();
            if (txIdentificación.PlaceholderText == "RNC" || txIdentificación.PlaceholderText == "")
                txIdentificación.PlaceholderText = "Final";
            
            if (rbFinal.Checked)
            {
                txIdentificación.Text = string.Empty;
            }
        }

        private void txIdentificación_TextChanged(object sender, EventArgs e)
        {
            if (rbCompañía.Checked)
                Validaciones.FormatearRNC(txIdentificación);
            else if (rbFinal.Checked)
                Validaciones.FormatearCédula(txIdentificación);
        }

        private void txIdentificación_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones.SoloNumeros(e);

        }
    }
}
