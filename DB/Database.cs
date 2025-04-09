using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.DB
{
    public static class Database
    {
        public static NpgsqlConnection? GetConnection()
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["pgsql-dbConn"].ConnectionString;
                return new NpgsqlConnection(connString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
