using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TronicShop.Methods
{
    public static class Validaciones
    {
        // Permitir solo números
        public static void SoloNumeros(KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Formato en tiempo real para Cédula (000-0000000-0)
        public static void FormatearCédula(TextBox txt)
        {
            string entrada = Regex.Replace(txt.Text, "[^0-9]", "");
            if (entrada.Length > 11) entrada = entrada[..11];
            if (entrada.Length >= 7)
                txt.Text = Regex.Replace(entrada, @"(\d{3})(\d{7})(\d{1})", "$1-$2-$3");
            else if (entrada.Length >= 3)
                txt.Text = Regex.Replace(entrada, @"(\d{3})(\d{1,7})", "$1-$2");
            else
                txt.Text = entrada;
            txt.SelectionStart = txt.Text.Length;
        }

        // Formato para RNC (000-00000-0)
        public static void FormatearRNC(TextBox txt)
        {
            string entrada = Regex.Replace(txt.Text, "[^0-9]", "");
            if (entrada.Length > 9) entrada = entrada[..9];
            if (entrada.Length >= 5)
                txt.Text = Regex.Replace(entrada, @"(\d{3})(\d{5})(\d{1})", "$1-$2-$3");
            else if (entrada.Length >= 3)
                txt.Text = Regex.Replace(entrada, @"(\d{3})(\d{1,5})", "$1-$2");
            else
                txt.Text = entrada;
            txt.SelectionStart = txt.Text.Length;
        }

        // Formato para Teléfonos ((809) 000-0000)
        public static void FormatearTeléfono(TextBox txt)
        {
            string entrada = Regex.Replace(txt.Text, "[^0-9]", "");
            if (entrada.Length > 10) entrada = entrada[..10];

            if (entrada.Length >= 10)
                txt.Text = Regex.Replace(entrada, @"(\d{3})(\d{3})(\d{4})", "($1) $2-$3");
            else if (entrada.Length >= 7)
                txt.Text = Regex.Replace(entrada, @"(\d{3})(\d{3})(\d{1,3})", "($1) $2-$3");
            else if (entrada.Length >= 4)
                txt.Text = Regex.Replace(entrada, @"(\d{3})(\d{1,3})", "($1) $2");
            else if (entrada.Length >= 1)
                txt.Text = "(" + entrada;
            else
                txt.Text = entrada;

            txt.SelectionStart = txt.Text.Length;
        }

        // Validar correo
        public static bool EsCorreoValido(string correo)
        {
            return Regex.IsMatch(correo, @"^[\w\.-]+@[\w\.-]+\.[a-zA-Z]{2,}$");
        }

        // Validar Teléfono en formato (809) 000-0000
        public static bool ValidarTeléfono(string tel)
        {
            var regex = new Regex(@"^\(\d{3}\)\s\d{3}-\d{4}$");
            return regex.IsMatch(tel);
        }

        // 5. Validar Cédula (básico, solo estructura)
        public static bool ValidarCedula(string cedula)
        {
            cedula = cedula.Replace("-", "").Trim();
            if (cedula.Length != 11 || !long.TryParse(cedula, out _)) return false;

            int total = 0;
            int[] multiplicador = { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            for (int i = 0; i < 10; i++)
            {
                int resultado = multiplicador[i] * int.Parse(cedula[i].ToString());
                if (resultado < 10)
                    total += resultado;
                else
                    total += resultado / 10 + resultado % 10;
            }

            int digitoVerificador = (10 - (total % 10)) % 10;
            return digitoVerificador == int.Parse(cedula[10].ToString());
        }

        public static bool ValidarRNC(string rnc)
        {
            if (string.IsNullOrWhiteSpace(rnc))
                return false;

            // Acepta formato como 131-23123-1 o sin guiones
            rnc = rnc.Replace("-", "").Trim();

            // Debe tener exactamente 9 dígitos
            return rnc.Length == 9 && long.TryParse(rnc, out _);
        }

        // 6. Validar RNC (estructura)
        public static bool ValidarTexto(string texto, int min = 2, int max = 100)
        {
            return !string.IsNullOrWhiteSpace(texto) && texto.Length >= min && texto.Length <= max;
        }

        // 7. Solo permitir números y 1 (un) solo punto.
        public static void SoloNumerosConUnPunto(TextBox txt,KeyPressEventArgs e)
        {
            // Permitir backspace
            if (char.IsControl(e.KeyChar))
                return;

            // Permitir solo dígitos o un punto
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Solo permitir un punto
            if (e.KeyChar == '.' && txt.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
        public static void SoloEnteros(KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
