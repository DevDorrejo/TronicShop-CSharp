using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronicShop.DB;
using TronicShop.Models;
using TronicShop.Utils;

namespace TronicShop.Repositories
{
    internal class UsuarioRepository : IRepository<Usuario>
    {
        // =================== //
        //    Métodos CRUDS    //
        // =================== //
        public List<Usuario> GetAll()
        {
            var lista = new List<Usuario>();
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, nombre, usuario, clave, rol, estado, fecha_creado FROM usuarios ORDER BY id";
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Username = reader.GetString(2),
                    Contraseña = (byte[])reader["clave"],
                    Rol = reader.GetString(4),
                    Estado = reader.GetBoolean(5),
                    FechaCreado = reader.GetDateTime(6)
                });
            }
            return lista;
        }
        public Usuario? GetByID(int id)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, nombre, usuario, clave, rol, estado, fecha_creado FROM usuarios WHERE id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Username = reader.GetString(2),
                    Contraseña = (byte[])reader["clave"],
                    Rol = reader.GetString(4),
                    Estado = reader.GetBoolean(5),
                    FechaCreado = reader.GetDateTime(6)
                };
            }
            return null;
        }
        public bool Insert(Usuario usuario)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"INSERT INTO usuarios(nombre, usuario, clave, rol, estado) VALUES (@nombre, @usuario, @clave, @rol, @estado)";
            using var cmd = new NpgsqlCommand(sql, conn);

            cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@usuario", usuario.Username.ToLowerInvariant());
            cmd.Parameters.AddWithValue("@clave", usuario.Contraseña);
            cmd.Parameters.AddWithValue("@rol", usuario.Rol.ToLower());
            cmd.Parameters.AddWithValue("@estado", usuario.Estado);

            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Update(Usuario usuario)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"UPDATE usuarios
                           SET  nombre = @nombre,
                                usuario = @usuario,
                                clave = @clave,
                                rol = @rol,
                                estado = @estado
                           WHERE id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", usuario.Id);
            cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
            cmd.Parameters.AddWithValue("@usuario", usuario.Username.ToLowerInvariant());
            cmd.Parameters.AddWithValue("@clave", usuario.Contraseña);
            cmd.Parameters.AddWithValue("@rol", usuario.Rol.ToLower());
            cmd.Parameters.AddWithValue("@estado", usuario.Estado);

            return cmd.ExecuteNonQuery() > 0;
        }
        public bool Delete(int id)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = "DELETE FROM usuarios WHERE id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        // ======================== //
        //    Manejos de Usuario    //
        // ======================== //
        public Usuario? Login(string username, string contraseña)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, nombre, usuario, clave, rol, estado, fecha_creado 
                            FROM usuarios 
                            WHERE LOWER(usuario) = LOWER(@usuario)";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@usuario", username);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                var claveSaved = (byte[])reader["clave"];
                if (!CryptoPass.Verify(contraseña, claveSaved))
                    return null;

                return new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Username = reader.GetString(2),
                    Contraseña = claveSaved,
                    Rol = reader.GetString(4),
                    Estado = reader.GetBoolean(5),
                    FechaCreado = reader.GetDateTime(6)
                };
            }
            return null;
        }
        public Usuario? GetByUser(string username)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = "SELECT id, nombre, usuario, clave, rol, estado, fecha_creado FROM usuarios WHERE LOWER(usuario) = LOWER(@usuario)";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@usuario", username);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Usuario
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Username = reader.GetString(2),
                    Contraseña = (byte[])reader["clave"],
                    Rol = reader.GetString(4),
                    Estado = reader.GetBoolean(5),
                    FechaCreado = reader.GetDateTime(6)
                };
            }
            return null;
        }
    }
}
