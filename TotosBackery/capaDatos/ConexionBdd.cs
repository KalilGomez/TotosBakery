using MySql.Data.MySqlClient;
using System;
namespace capaDatos
{
    public class ConexionBdd
    {
        public static void Conectar()
        {
            bool estaConectado;
            string connectionString = "server=localhost;database=totosBackery;uid=root;pwd=";
            using (MySqlConnection conexion = new MySqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    estaConectado = true;
                }
                catch (MySqlException ex)
                {
                    estaConectado= false;
                    Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                }
                finally
                {
                    if (conexion.State == System.Data.ConnectionState.Open)
                    {
                        conexion.Close();
                        Console.WriteLine("Conexión cerrada.");
                    }
                }
            }
        }

    }
}
