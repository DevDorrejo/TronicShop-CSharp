using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Methods
{
    public class loadData
    {
        public static void dgvLoad<T>(DataGridView dgv, List<T> datos, string[]? ocultar = null!)
        {
            dgv.DataSource = null;
            dgv.DataSource = datos;


            if (ocultar != null)
            {
                foreach (var column in ocultar)
                {
                    if (dgv.Columns.Contains(column))
                        dgv.Columns[column].Visible = false;
                }
            }

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.ReadOnly = true;
        }
    }
}