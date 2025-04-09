using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronicShop.Models;
using TronicShop.Repositories;
using TronicShop.Utils;

namespace TronicShop.DB
{
    internal class Seeder
    {
        public static void Exec()
        {
            var repo = new UsuarioRepository();
            var configRepo = new ConfiguraciónRepository();

            // ========== CREAR ADMIN ========== //
            var adminExistente = repo.GetByUser("admin");
            if (adminExistente == null)
            {
                var admin = new Usuario
                {
                    Nombre = "Administrador",
                    Username = "admin",
                    Contraseña = CryptoPass.Encrypt("123456"),
                    Rol = "admin",
                    Estado = true
                };

                bool creado = repo.Insert(admin);
                Console.WriteLine(creado ? "Usuario administrador creado correctamente." : "Error al crear administrador.");
            }
            else
            {
                Console.WriteLine("Usuario administrador ya existe.");
            }

            // ========== CREAR USUARIO NORMAL ========== //
            var usuarioExistente = repo.GetByUser("usuario");
            if (usuarioExistente == null)
            {
                var user = new Usuario
                {
                    Nombre = "Juan Pérez",
                    Username = "usuario",
                    Contraseña = CryptoPass.Encrypt("123456"),
                    Rol = "usuario",
                    Estado = true
                };

                bool creado = repo.Insert(user);
                Console.WriteLine(creado ? "Usuario estándar creado correctamente." : "Error al crear usuario.");
            }
            else
            {
                Console.WriteLine("Usuario estándar ya existe.");
            }

            // ========== CONFIGURACIÓN ITBIS ========== //
            var configuracion = configRepo.GetPrimera();
            if (configuracion == null)
            {
                var itbisDefault = new Configuración
                {
                    NombreEmpresa = "Mi Empresa",
                    RNC = "",
                    Direccion = "",
                    Telefono = "",
                    Correo = "",
                    Impuesto = 18,
                    FechaCreado = DateTime.Now,
                    FechaActualizado = DateTime.Now
                };

                bool insertado = configRepo.Guardar(itbisDefault);
                Console.WriteLine(insertado ? "Configuración ITBIS insertada correctamente." : "Error al insertar configuración ITBIS.");
            }
            else
            {
                Console.WriteLine("Configuración ITBIS ya existe.");
            }
        }
    }
}
