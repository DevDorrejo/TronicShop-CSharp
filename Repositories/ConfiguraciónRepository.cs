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
    internal class ConfiguraciónRepository
    {
        public Configuración? GetAll()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = "SELECT id, nombre_empresa, rnc, direccion, telefono, correo, impuesto, logo, fecha_creado, fecha_actualizado FROM configuracion LIMIT 1";
            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Configuración
                {
                    Id = reader.GetInt32(0),
                    NombreEmpresa = reader.GetString(1),
                    RNC = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Direccion = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Telefono = reader.IsDBNull(4) ? null : reader.GetString(4),
                    Correo = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Impuesto = reader.GetDecimal(6),
                    Logo = reader.IsDBNull(7) ? null : (byte[])reader["logo"],
                    FechaCreado = reader.GetDateTime(8),
                    FechaActualizado = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                };
            }

            return null;
        }

        public Configuración? GetPrimera()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"SELECT id, nombre_empresa, rnc, direccion, telefono, correo, impuesto, logo, 
                          fecha_creado, fecha_actualizado 
                   FROM configuracion 
                   LIMIT 1";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Configuración
                {
                    Id = reader.GetInt32(0),
                    NombreEmpresa = reader.GetString(1),
                    RNC = reader.IsDBNull(2) ? null : reader.GetString(2),
                    Direccion = reader.IsDBNull(3) ? null : reader.GetString(3),
                    Telefono = reader.IsDBNull(4) ? null : reader.GetString(4),
                    Correo = reader.IsDBNull(5) ? null : reader.GetString(5),
                    Impuesto = reader.GetDecimal(6),
                    Logo = reader.IsDBNull(7) ? null : (byte[])reader["logo"],
                    FechaCreado = reader.GetDateTime(8),
                    FechaActualizado = reader.IsDBNull(9) ? null : reader.GetDateTime(9)
                };
            }

            return null;
        }

        public bool Guardar(Configuración config)
        {
            using var conn = Database.GetConnection()!;
            conn.Open();

            string sqlExistente = "SELECT COUNT(*) FROM configuracion";
            using var cmdExistente = new NpgsqlCommand(sqlExistente, conn);
            long cantidad = Convert.ToInt64(cmdExistente.ExecuteScalar() ?? 0);

            if (cantidad == 0)
            {
                string insertSql = @"
                    INSERT INTO configuracion(nombre_empresa, rnc, direccion, telefono, correo, impuesto, logo)
                    VALUES (@nombre, @rnc, @direccion, @telefono, @correo, @impuesto, @logo)";
                using var insertCmd = new NpgsqlCommand(insertSql, conn);
                insertCmd.Parameters.AddWithValue("@nombre", config.NombreEmpresa);
                insertCmd.Parameters.AddWithValue("@rnc", (object?)config.RNC ?? DBNull.Value);
                insertCmd.Parameters.AddWithValue("@direccion", (object?)config.Direccion ?? DBNull.Value);
                insertCmd.Parameters.AddWithValue("@telefono", (object?)config.Telefono ?? DBNull.Value);
                insertCmd.Parameters.AddWithValue("@correo", (object?)config.Correo ?? DBNull.Value);
                insertCmd.Parameters.AddWithValue("@impuesto", config.Impuesto);
                insertCmd.Parameters.AddWithValue("@logo", (object?)config.Logo ?? DBNull.Value);

                return insertCmd.ExecuteNonQuery() > 0;
            }
            else
            {
                string updateSql = @"
                    UPDATE configuracion SET
                        nombre_empresa = @nombre,
                        rnc = @rnc,
                        direccion = @direccion,
                        telefono = @telefono,
                        correo = @correo,
                        impuesto = @impuesto,
                        logo = @logo,
                        fecha_actualizado = CURRENT_TIMESTAMP WHERE id = @id";
                using var updateCmd = new NpgsqlCommand(updateSql, conn);
                updateCmd.Parameters.AddWithValue("@id", config.Id);
                updateCmd.Parameters.AddWithValue("@nombre", config.NombreEmpresa);
                updateCmd.Parameters.AddWithValue("@rnc", (object?)config.RNC ?? DBNull.Value);
                updateCmd.Parameters.AddWithValue("@direccion", (object?)config.Direccion ?? DBNull.Value);
                updateCmd.Parameters.AddWithValue("@telefono", (object?)config.Telefono ?? DBNull.Value);
                updateCmd.Parameters.AddWithValue("@correo", (object?)config.Correo ?? DBNull.Value);
                updateCmd.Parameters.AddWithValue("@impuesto", config.Impuesto);
                updateCmd.Parameters.AddWithValue("@logo", (object?)config.Logo ?? DBNull.Value);


                return updateCmd.ExecuteNonQuery() > 0;
            }
        }
        public decimal GetITBIS()
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = "SELECT impuesto FROM configuracion LIMIT 1";
            using var cmd = new NpgsqlCommand(sql, conn);
            var result = cmd.ExecuteScalar();

            if (result != null && decimal.TryParse(result.ToString(), out decimal itbis))
                return itbis;

            return 0; // Retorna 0 si hay error o no está configurado
        }

        public byte[] GetLogo()
        {
            using var conn = Database.GetConnection();
            conn.Open();
            string sql = "SELECT logo FROM configuracion LIMIT 1";
            using var cmd = new NpgsqlCommand(sql, conn);
            var result = cmd.ExecuteScalar();
            return result == DBNull.Value ? null : (byte[])result;
        }
    }
}
