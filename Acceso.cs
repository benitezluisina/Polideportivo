using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace polideportivo
{
    public class Acceso
    {
        SqlConnection conexion = new SqlConnection();

        public void Abrir()
        {
            conexion.ConnectionString = "Initial Catalog=polideportivo; Data Source=LUISINABENITEZ\\SQLEXPRESS; Integrated Security=SSPI; ";
            conexion.Open();
        }
        public void Cerrar()
        {
            conexion.Close();
        }

        public SqlDataReader Leer(string sql)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;

            return comando.ExecuteReader();
        }

        public void Escribir(string sql)
        {
            SqlCommand comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
            comando.CommandText = sql;

            try
            {
                comando.ExecuteNonQuery();
            }
            catch
            {

            }


        }
    }
}