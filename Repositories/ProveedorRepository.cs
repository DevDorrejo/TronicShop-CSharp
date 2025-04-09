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
    internal class ProveedorRepository : IRepository<Proveedor>
    {
        public List<Proveedor> GetAll()
        {
            var lista = new List<Proveedor>();
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, compañía, nombre_contacto, telefono, telefono2, whatsapp, correo, 
                                  direccion, rnc, estado, fecha_creado, fecha_actualizado 
                           FROM proveedores 
                           ORDER BY id";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Proveedor
                {
                    Id = reader.GetInt32(0),
                    Compañía = reader.GetString(1),
                    NombreContacto = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Teléfono = reader.GetString(3),
                    Teléfono2 = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Whatsapp = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Correo = reader.IsDBNull(6) ? "" : reader.GetString(6),
                    Dirección = reader.GetString(7),
                    RNC = reader.IsDBNull(8) ? "" : reader.GetString(8),
                    Estado = reader.GetBoolean(9),
                    FechaCreado = reader.GetDateTime(10),
                    FechaActualizado = reader.GetDateTime(11)
                });
            }

            return lista;
        }

        public Proveedor? GetByID(int id)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, tipo, compañía, nombre_contacto, telefono, telefono2, whatsapp, correo, 
                                  direccion, rnc, cedula, estado, fecha_creado, fecha_actualizado 
                           FROM proveedores 
                           WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Proveedor
                {
                    Id = reader.GetInt32(0),
                    Compañía = reader.GetString(2),
                    NombreContacto = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Teléfono = reader.GetString(4),
                    Teléfono2 = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Whatsapp = reader.IsDBNull(6) ? "" : reader.GetString(6),
                    Correo = reader.IsDBNull(7) ? "" : reader.GetString(7),
                    Dirección = reader.GetString(8),
                    RNC = reader.IsDBNull(9) ? "" : reader.GetString(9),
                    Estado = reader.GetBoolean(11),
                    FechaCreado = reader.GetDateTime(12),
                    FechaActualizado = reader.GetDateTime(13)
                };
            }

            return null;
        }

        public bool Insert(Proveedor p)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"INSERT INTO proveedores (
                                compañía, nombre_contacto, telefono, telefono2, whatsapp, correo, 
                                direccion, rnc, estado, fecha_actualizado)
                           VALUES (
                                @compañía, @nombre_contacto, @telefono, @telefono2, @whatsapp, @correo, 
                                @direccion, @rnc, @estado, CURRENT_TIMESTAMP)";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@compañía", p.Compañía);
            cmd.Parameters.AddWithValue("@nombre_contacto", string.IsNullOrWhiteSpace(p.NombreContacto) ? DBNull.Value : p.NombreContacto);
            cmd.Parameters.AddWithValue("@telefono", p.Teléfono);
            cmd.Parameters.AddWithValue("@telefono2", string.IsNullOrWhiteSpace(p.Teléfono2) ? DBNull.Value : p.Teléfono2);
            cmd.Parameters.AddWithValue("@whatsapp", string.IsNullOrWhiteSpace(p.Whatsapp) ? DBNull.Value : p.Whatsapp);
            cmd.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(p.Correo) ? DBNull.Value : p.Correo);
            cmd.Parameters.AddWithValue("@direccion", p.Dirección);
            cmd.Parameters.AddWithValue("@rnc", string.IsNullOrWhiteSpace(p.RNC) ? DBNull.Value : p.RNC);
            cmd.Parameters.AddWithValue("@estado", p.Estado);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Proveedor p)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"UPDATE proveedores SET
                                compañía = @compañía,
                                nombre_contacto = @nombre_contacto,
                                telefono = @telefono,
                                telefono2 = @telefono2,
                                whatsapp = @whatsapp,
                                correo = @correo,
                                direccion = @direccion,
                                rnc = @rnc,
                                estado = @estado,
                                fecha_actualizado = CURRENT_TIMESTAMP
                           WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@compañía", p.Compañía);
            cmd.Parameters.AddWithValue("@nombre_contacto", string.IsNullOrWhiteSpace(p.NombreContacto) ? DBNull.Value : p.NombreContacto);
            cmd.Parameters.AddWithValue("@telefono", p.Teléfono);
            cmd.Parameters.AddWithValue("@telefono2", string.IsNullOrWhiteSpace(p.Teléfono2) ? DBNull.Value : p.Teléfono2);
            cmd.Parameters.AddWithValue("@whatsapp", string.IsNullOrWhiteSpace(p.Whatsapp) ? DBNull.Value : p.Whatsapp);
            cmd.Parameters.AddWithValue("@correo", string.IsNullOrWhiteSpace(p.Correo) ? DBNull.Value : p.Correo);
            cmd.Parameters.AddWithValue("@direccion", p.Dirección);
            cmd.Parameters.AddWithValue("@rnc", string.IsNullOrWhiteSpace(p.RNC) ? DBNull.Value : p.RNC);
            cmd.Parameters.AddWithValue("@estado", p.Estado);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = "DELETE FROM proveedores WHERE id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public Proveedor? GetByCompañía(string compañía)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sql = @"SELECT id, compañía, nombre_contacto, telefono, telefono2, whatsapp, correo, 
                                  direccion, rnc, estado, fecha_creado, fecha_actualizado 
                           FROM proveedores
                           WHERE LOWER(compañía) = LOWER(@compañía)";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@compañía", compañía);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Proveedor
                {
                    Id = reader.GetInt32(0),
                    Compañía = reader.GetString(1),
                    NombreContacto = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Teléfono = reader.GetString(3),
                    Teléfono2 = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Whatsapp = reader.IsDBNull(5) ? "" : reader.GetString(5),
                    Correo = reader.IsDBNull(6) ? "" : reader.GetString(6),
                    Dirección = reader.GetString(7),
                    RNC = reader.IsDBNull(8) ? "" : reader.GetString(8),
                    Estado = reader.GetBoolean(9),
                    FechaCreado = reader.GetDateTime(10),
                    FechaActualizado = reader.GetDateTime(11)
                };
            }

            return null;
        }
    }
}
