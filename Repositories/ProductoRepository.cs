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
    internal class ProductoRepository : IRepository<Producto>
    {
        public List<Producto> GetAll()
        {
            var lista = new List<Producto>();
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"SELECT p.id, p.codigo_barra, p.nombre, p.descripcion, p.categoria, p.precio, p.stock, p.estado,
                            p.id_proveedor, pr.compañía AS nombre_proveedor,
                            p.fecha_creado, p.fecha_actualizado
                            FROM productos p
                            LEFT JOIN proveedores pr ON pr.id = p.id_proveedor
                            ORDER BY p.id;";

            using var cmd = new NpgsqlCommand(sql, conn);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Producto
                {
                    Id = reader.GetInt32(0),
                    CódigoBarra = reader.IsDBNull(1) ? "" : reader.GetString(1),
                    Nombre = reader.IsDBNull(2) ? "" : reader.GetString(2),
                    Descripción = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Categoría = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Precio = reader.GetDecimal(5),
                    Stock = reader.GetInt32(6),
                    Estado = reader.GetBoolean(7),
                    IdProveedor = reader.GetInt32(8),
                    NombreProveedor = reader.IsDBNull(9) ? "" : reader.GetString(9),
                    FechaCreado = reader.GetDateTime(10),
                    FechaActualizado = reader.GetDateTime(11)
                });
            }

            return lista;
        }

        public Producto? GetByID(int id)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"SELECT id, codigo_barra, nombre, descripcion, categoria, precio, stock, estado,
                                  id_proveedor, fecha_creado, fecha_actualizado
                           FROM productos WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return new Producto
                {
                    Id = reader.GetInt32(0),
                    CódigoBarra = reader.IsDBNull(1) ? "" : reader.GetString(1),
                    Nombre = reader.GetString(2),
                    Descripción = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Categoría = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Precio = reader.GetDecimal(5),
                    Stock = reader.GetInt32(6),
                    Estado = reader.GetBoolean(7),
                    IdProveedor = reader.IsDBNull(8) ? null : reader.GetInt32(8),
                    FechaCreado = reader.GetDateTime(9),
                    FechaActualizado = reader.GetDateTime(10)
                };
            }

            return null;
        }

        public bool Insert(Producto p)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"INSERT INTO productos (codigo_barra, nombre, descripcion, categoria, precio, stock,
                                                  estado, id_proveedor, fecha_actualizado)
                           VALUES (@codigo_barra, @nombre, @descripcion, @categoria, @precio, @stock,
                                   @estado, @id_proveedor, CURRENT_TIMESTAMP)";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@codigo_barra", string.IsNullOrWhiteSpace(p.CódigoBarra) ? DBNull.Value : p.CódigoBarra);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(p.Descripción) ? DBNull.Value : p.Descripción);
            cmd.Parameters.AddWithValue("@categoria", string.IsNullOrWhiteSpace(p.Categoría) ? DBNull.Value : p.Categoría);
            cmd.Parameters.AddWithValue("@precio", p.Precio);
            cmd.Parameters.AddWithValue("@stock", p.Stock);
            cmd.Parameters.AddWithValue("@estado", p.Estado);
            cmd.Parameters.AddWithValue("@id_proveedor", p.IdProveedor.HasValue ? p.IdProveedor.Value : DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Update(Producto p)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"UPDATE productos SET 
                                codigo_barra = @codigo_barra,
                                nombre = @nombre,
                                descripcion = @descripcion,
                                categoria = @categoria,
                                precio = @precio,
                                stock = @stock,
                                estado = @estado,
                                id_proveedor = @id_proveedor,
                                fecha_actualizado = CURRENT_TIMESTAMP
                           WHERE id = @id";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@codigo_barra", string.IsNullOrWhiteSpace(p.CódigoBarra) ? DBNull.Value : p.CódigoBarra);
            cmd.Parameters.AddWithValue("@nombre", p.Nombre);
            cmd.Parameters.AddWithValue("@descripcion", string.IsNullOrWhiteSpace(p.Descripción) ? DBNull.Value : p.Descripción);
            cmd.Parameters.AddWithValue("@categoria", string.IsNullOrWhiteSpace(p.Categoría) ? DBNull.Value : p.Categoría);
            cmd.Parameters.AddWithValue("@precio", p.Precio);
            cmd.Parameters.AddWithValue("@stock", p.Stock);
            cmd.Parameters.AddWithValue("@estado", p.Estado);
            cmd.Parameters.AddWithValue("@id_proveedor", p.IdProveedor.HasValue ? p.IdProveedor.Value : DBNull.Value);

            return cmd.ExecuteNonQuery() > 0;
        }

        public bool Delete(int id)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = "DELETE FROM productos WHERE id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);

            return cmd.ExecuteNonQuery() > 0;
        }

        public Producto? GetByCódigoBarra(string codigo)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"SELECT id, codigo_barra, nombre, descripcion, categoria, precio, stock, estado,
                                  id_proveedor, fecha_creado, fecha_actualizado
                           FROM productos
                           WHERE codigo_barra = @codigo";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@codigo", codigo);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Producto
                {
                    Id = reader.GetInt32(0),
                    CódigoBarra = reader.IsDBNull(1) ? "" : reader.GetString(1),
                    Nombre = reader.GetString(2),
                    Descripción = reader.IsDBNull(3) ? "" : reader.GetString(3),
                    Categoría = reader.IsDBNull(4) ? "" : reader.GetString(4),
                    Precio = reader.GetDecimal(5),
                    Stock = reader.GetInt32(6),
                    Estado = reader.GetBoolean(7),
                    IdProveedor = reader.IsDBNull(8) ? null : reader.GetInt32(8),
                    FechaCreado = reader.GetDateTime(9),
                    FechaActualizado = reader.GetDateTime(10)
                };
            }

            return null;
        }
        public void RestaurarStock(int idProducto, int cantidad)
        {
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = "UPDATE productos SET stock = stock + @cantidad WHERE id = @id";
            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@id", idProducto);
            cmd.ExecuteNonQuery();
        }
    }
}
