using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace data_access_application
{
    class Controller
    {
        string connection;
        SqlConnection connect = null;

        public Controller()
        {
            connection = "Server = LAPTOP-1HMCDI96\\SQLEXPRESS; " +
                          "Trusted_Connection = true;" +
                          "Database = Northwind;" +
                          "User Instance = false;" +
                          "Connection timeout = 30";
        }
        public Controller(string connect)
        {
            connection = connect;
        }

        public string getCustomerNumber()
        {
            int count = 0;
            connect = new SqlConnection(connection);
            connect.Open();

            string Query = "SELECT COUNT(*) FROM customers;";
            SqlCommand command = new SqlCommand(Query, connect);

            try
            {
                count = Convert.ToInt32(command.ExecuteScalar());
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            connect.Close();
            return count.ToString();
        }

        public string getCustomerNames()
        {
            string names = "";
            SqlDataReader reader;
            connect = new SqlConnection(connection);
            connect.Open();

            string Query = "SELECT companyname FROM customers;";
            SqlCommand command = new SqlCommand(Query, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                try
                {
                    names = names + reader.GetValue(0) + "\n";
                } catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            connect.Close();
            return names.ToString();
        }
    }
}
