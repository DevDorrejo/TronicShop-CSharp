using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Methods
{
    public static class bindEvents
    {
        // Asigna eventos de validación y formato automáticamente
        public static void AsignarEventos(Control.ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is TextBox txt)
                {
                    string nombre = txt.Name.ToLower();

                    if (nombre.Contains("teléfono") || nombre.Contains("whatsapp"))
                    {
                        txt.TextChanged += (s, e) => Validaciones.FormatearTeléfono(txt);
                        txt.KeyPress += (s, e) => Validaciones.SoloNumeros(e);
                    }
                    else if (nombre.Contains("cédula"))
                    {
                        txt.TextChanged += (s, e) => Validaciones.FormatearCédula(txt);
                        txt.KeyPress += (s, e) => Validaciones.SoloNumeros(e);
                    }
                    else if (nombre.Contains("rnc"))
                    {
                        txt.TextChanged += (s, e) => Validaciones.FormatearRNC(txt);
                        txt.KeyPress += (s, e) => Validaciones.SoloNumeros(e);
                    }
                    else if (nombre.Contains("correo") || nombre.Contains("email"))
                    {
                        txt.Leave += (s, e) =>
                        {
                            if (!Validaciones.EsCorreoValido(txt.Text))
                                TtHelper.Mostrar(txt, "Correo inválido");
                        };
                    }
                    else if (nombre.Contains("precio"))
                    {
                        txt.KeyPress += (s, e) => Validaciones.SoloNumerosConUnPunto(txt, e);
                    }
                    else if (nombre.Contains("stock"))
                    {
                        txt.KeyPress += (s, e) => Validaciones.SoloEnteros(e);
                    }
                }

                // Recurse si el control tiene hijos
                if (control.HasChildren)
                {
                    AsignarEventos(control.Controls);
                }
            }
        }
    }
}

