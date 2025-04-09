using Npgsql;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TronicShop.DB;
using TronicShop.Models;

namespace TronicShop.Repositories
{
    internal class VentaRepository
    {
        public bool Insert(Venta venta, List<DetalleVenta> detalles)
        {
            using var conn = Database.GetConnection();
            conn.Open();
            using var tx = conn.BeginTransaction();

            try
            {
                // Insertar venta
                string ventaSql = @"INSERT INTO ventas(id_cliente, id_usuario, total, fecha, estado)
                            VALUES (@cliente, @usuario, @total, CURRENT_TIMESTAMP, @estado)
                            RETURNING id";
                using var cmdVenta = new NpgsqlCommand(ventaSql, conn);
                cmdVenta.Parameters.AddWithValue("@cliente", venta.IdCliente);
                cmdVenta.Parameters.AddWithValue("@usuario", venta.IdUsuario);
                cmdVenta.Parameters.AddWithValue("@total", venta.Total);
                cmdVenta.Parameters.AddWithValue("@estado", venta.Estado);

                int idVenta = Convert.ToInt32(cmdVenta.ExecuteScalar());

                // Insertar detalles de la venta y actualizar inventario
                foreach (var item in detalles)
                {
                    // Verificar stock antes de descontar (opcional si ya se valida en UI)
                    string stockQuery = "SELECT stock FROM productos WHERE id = @id";
                    using var stockCmd = new NpgsqlCommand(stockQuery, conn);
                    stockCmd.Parameters.AddWithValue("@id", item.IdProducto);
                    int stockDisponible = Convert.ToInt32(stockCmd.ExecuteScalar());

                    if (stockDisponible < item.Cantidad)
                        throw new Exception($"Stock insuficiente para el producto ID {item.IdProducto}.");

                    // Insertar detalle
                    string detalleSql = @"INSERT INTO detalle_ventas(id_venta, id_producto, cantidad, precio_unitario)
                                  VALUES (@venta, @producto, @cantidad, @precio)";
                    using var cmdDetalle = new NpgsqlCommand(detalleSql, conn);
                    cmdDetalle.Parameters.AddWithValue("@venta", idVenta);
                    cmdDetalle.Parameters.AddWithValue("@producto", item.IdProducto);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@precio", item.PrecioUnitario);
                    cmdDetalle.ExecuteNonQuery();

                    // Descontar stock
                    string updateStock = "UPDATE productos SET stock = stock - @cantidad WHERE id = @id";
                    using var cmdStock = new NpgsqlCommand(updateStock, conn);
                    cmdStock.Parameters.AddWithValue("@cantidad", item.Cantidad);
                    cmdStock.Parameters.AddWithValue("@id", item.IdProducto);
                    cmdStock.ExecuteNonQuery();
                }

                tx.Commit();
                return true;
            }
            catch (Exception ex)
            {
                tx.Rollback();
                MessageBox.Show($"Error al guardar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // PARA USO FUTURO
        //public List<Venta> GetAll()
        //{
        //    var lista = new List<Venta>();
        //    using var conn = Database.GetConnection();
        //    conn.Open();

        //    string sql = @"SELECT v.id, v.id_cliente, v.id_usuario, v.total, v.fecha, v.estado,
        //                          c.nombre AS cliente, u.nombre AS usuario
        //                   FROM ventas v
        //                   JOIN clientes c ON c.id = v.id_cliente
        //                   JOIN usuarios u ON u.id = v.id_usuario
        //                   ORDER BY v.id DESC";

        //    using var cmd = new NpgsqlCommand(sql, conn);
        //    using var reader = cmd.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        lista.Add(new Venta
        //        {
        //            Id = reader.GetInt32(0),
        //            IdCliente = reader.GetInt32(1),
        //            IdUsuario = reader.GetInt32(2),
        //            Total = reader.GetDecimal(3),
        //            Fecha = reader.GetDateTime(4),
        //            Estado = reader.GetBoolean(5),
        //            ClienteNombre = reader.GetString(6),
        //            UsuarioNombre = reader.GetString(7),
        //        });
        //    }

        //    return lista;
        //}
        public List<DetalleVenta> GetDetalles(int idVenta)
        {
            var lista = new List<DetalleVenta>();
            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"SELECT d.id, d.id_venta, d.id_producto, d.cantidad, d.precio_unitario, d.total_linea,
                                  p.nombre AS producto
                           FROM detalle_ventas d
                           JOIN productos p ON p.id = d.id_producto
                           WHERE id_venta = @venta";

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@venta", idVenta);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new DetalleVenta
                {
                    Id = reader.GetInt32(0),
                    IdVenta = reader.GetInt32(1),
                    IdProducto = reader.GetInt32(2),
                    Cantidad = reader.GetInt32(3),
                    PrecioUnitario = reader.GetDecimal(4),
                    TotalLinea = reader.GetDecimal(5),
                    ProductoNombre = reader.GetString(6),
                });
            }

            return lista;
        }
        public List<Venta> ReporteConDetalles(DateTime desde, DateTime hasta)
        {
            var ventas = new List<Venta>();

            using var conn = Database.GetConnection();
            conn.Open();

            string sql = @"
                SELECT 
                    v.id, v.total, v.fecha, 
                    c.nombre AS cliente_nombre,
                    u.nombre AS usuario_nombre
                FROM ventas v
                INNER JOIN clientes c ON c.id = v.id_cliente
                INNER JOIN usuarios u ON u.id = v.id_usuario
                WHERE v.fecha BETWEEN @desde AND @hasta
                ORDER BY v.fecha DESC"
            ;

            using var cmd = new NpgsqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var venta = new Venta
                {
                    Id = reader.GetInt32(0),
                    Total = reader.GetDecimal(1),
                    Fecha = reader.GetDateTime(2),
                    ClienteNombre = reader.GetString(3),
                    UsuarioNombre = reader.GetString(4),
                    Detalles = new List<DetalleVenta>()
                };
                ventas.Add(venta);
            }
            reader.Close();

            // Cargar detalles
            foreach (var venta in ventas)
            {
                venta.Detalles = GetDetallesConNombre(venta.Id, conn);
            }

            return ventas;
        }
        private List<DetalleVenta> GetDetallesConNombre(int idVenta, NpgsqlConnection con)
        {
            var detalles = new List<DetalleVenta>();
            string sql = @"
                SELECT d.id_producto, d.cantidad, d.precio_unitario, d.total_linea, p.nombre 
                FROM detalle_ventas d
                INNER JOIN productos p ON p.id = d.id_producto
                WHERE d.id_venta = @id";

            using var cmd = new NpgsqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", idVenta);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                detalles.Add(new DetalleVenta
                {
                    IdProducto = reader.GetInt32(0),
                    Cantidad = reader.GetInt32(1),
                    PrecioUnitario = reader.GetDecimal(2),
                    TotalLinea = reader.GetDecimal(3),
                    ProductoNombre = reader.GetString(4)
                });
            }

            return detalles;
        }

    }
}
