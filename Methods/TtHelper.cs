using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Methods
{
    public static class TtHelper
    {
        private static readonly ToolTip tooltip = new();
        private static readonly HashSet<Control> tooltipsActivos = new();

        static TtHelper()
        {
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Warning;
        }

        public static void Mostrar(Control control, string mensaje)
        {
            if (tooltipsActivos.Contains(control))
                return;

            tooltipsActivos.Add(control);
            control.BackColor = Color.MistyRose;

            tooltip.Show(mensaje, control, control.Width / 3, control.Height - 80, 4000);

            Task.Delay(4000).ContinueWith(_ =>
            {
                if (!control.IsDisposed)
                {
                    control.Invoke(() =>
                    {
                        tooltip.Hide(control);
                        control.BackColor = SystemColors.Window;
                        tooltipsActivos.Remove(control);
                    });
                }
            });
        }

        public static void PrepararCampo(Control control)
        {
            control.Enter += (s, e) =>
            {
                if (tooltipsActivos.Contains(control))
                {
                    tooltip.Hide(control);
                    control.BackColor = SystemColors.Window;
                    tooltipsActivos.Remove(control);
                }
            };
        }

        public static void PrepararCampos(params Control[] controles)
        {
            foreach (var c in controles)
                PrepararCampo(c);
        }
    }
}
