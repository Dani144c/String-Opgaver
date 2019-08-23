using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sqlconnection
{
    class Program
    {
        public static string Sql = @"Data Source=DESKTOP-UE671U5\H1SQLSERVER;Initial Catalog=gorm;User=Dani;Password=Passw0rd";

        static void Main(string[] args)
        {
            SqlConnection SqlConn = new SqlConnection(Sql);
            try
            {
                SqlConn.Open();
                Console.WriteLine("Succes");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            SqlDataAdapter SqlData = new SqlDataAdapter("Person", SqlConn);
            DataTable TablePerson = new DataTable();

            SqlCommand command = new SqlCommand("Select * Person");
            
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    Console.WriteLine(String.Format("{0}", reader["id"]));
                }
            }

            Console.ReadKey();
            SqlConn.Close();
        }
    }
}