using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronicShop.DB;
using TronicShop.Models;

namespace TronicShop.Repositories
{
    internal class ClienteRepository : IRepository<Cliente>
    {
        public List<Cliente> GetAll()
        {
            var lista = new List<Cliente>();
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, nombre, telefono, correo, direccion, identificacion, estado, fecha_creado
                           FROM clientes
                           ORDER BY id";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Cliente
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Teléfono = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Correo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Dirección = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Identificación = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Estado = reader.GetBoolean(6),
                    FechaCreado = reader.GetDateTime(7)
                });
            }
            return lista;
        }

        public Cliente? GetByID(int id)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, nombre, telefono, correo, direccion, identificacion, estado, fecha_creado
                           FROM clientes
                           WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Cliente
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Teléfono = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Correo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Dirección = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Identificación = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Estado = reader.GetBoolean(6),
                    FechaCreado = reader.GetDateTime(7)
                };
            }
            return null;
        }

        public bool Insert(Cliente c)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"INSERT INTO clientes(nombre, telefono, correo, direccion, identificacion, estado)
                           VALUES (@nombre, @telefono, @correo, @direccion, @identificacion, @estado)";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@telefono", string.IsNullOrEmpty(c.Teléfono) ? DBNull.Value : c.Teléfono);
            cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(c.Correo) ? DBNull.Value : c.Correo);
            cmd.Parameters.AddWithValue("@direccion", string.IsNullOrEmpty(c.Dirección) ? DBNull.Value : c.Dirección);
            cmd.Parameters.AddWithValue("@identificacion", string.IsNullOrEmpty(c.Identificación) ? DBNull.Value : c.Identificación);
            cmd.Parameters.AddWithValue("@estado", c.Estado);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Cliente c)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"UPDATE clientes
                           SET nombre = @nombre,
                               telefono = @telefono,
                               correo = @correo,
                               direccion = @direccion,
                               identificacion = @identificacion,
                               estado = @estado
                           WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@nombre", c.Nombre);
            cmd.Parameters.AddWithValue("@telefono", string.IsNullOrEmpty(c.Teléfono) ? DBNull.Value : c.Teléfono);
            cmd.Parameters.AddWithValue("@correo", string.IsNullOrEmpty(c.Correo) ? DBNull.Value : c.Correo);
            cmd.Parameters.AddWithValue("@direccion", string.IsNullOrEmpty(c.Dirección) ? DBNull.Value : c.Dirección);
            cmd.Parameters.AddWithValue("@identificacion", string.IsNullOrEmpty(c.Identificación) ? DBNull.Value : c.Identificación);
            cmd.Parameters.AddWithValue("@estado", c.Estado);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = "DELETE FROM clientes WHERE id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public Cliente? GetByIdentificación(string identificacion)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, nombre, telefono, correo, direccion, identificacion, estado, fecha_creado
                           FROM clientes
                           WHERE identificacion = @identificacion";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@identificacion", identificacion);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Cliente
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Teléfono = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Correo = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Dirección = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Identificación = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Estado = reader.GetBoolean(6),
                    FechaCreado = reader.GetDateTime(7)
                };
            }
            return null;
        }
        public Cliente? GetByCorreoOIdentificación(string correo, string identificacion)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, nombre, telefono, direccion, correo, identificacion, estado, fecha_creado
                   FROM clientes
                   WHERE correo = @correo OR identificacion = @identificacion";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@correo", correo);
            cmd.Parameters.AddWithValue("@identificacion", identificacion);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Cliente
                {
                    Id = reader.GetInt32(0),
                    Nombre = reader.GetString(1),
                    Teléfono = reader.GetString(2),
                    Dirección = reader.GetString(3),
                    Correo = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Identificación = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Estado = reader.GetBoolean(6),
                    FechaCreado = reader.GetDateTime(7)
                };
            }

            return null;
        }
    }
}
