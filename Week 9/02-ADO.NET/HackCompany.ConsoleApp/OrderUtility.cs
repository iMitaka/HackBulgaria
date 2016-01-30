using HackCompany.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackCompany.ConsoleApp
{
    public class OrderUtility
    {
        private string connectionString;

        public OrderUtility()
        {
            connectionString = ConfigurationManager.ConnectionStrings["HackCompanyDb"].ConnectionString;
        }

        public void AddCustomerToDb(Order order)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string countCommand = "SELECT COUNT(*) FROM Order WHERE id=" + order.Id;
                SqlCommand sqlCountCommand = new SqlCommand(countCommand, connection);
                var count = (int)sqlCountCommand.ExecuteScalar();
                if (count >= 1)
                {
                    string updateCommand = "UPDATE Order SET Date=@date,Customer_Id=@customerId,TotalPrice = @totalPrice WHERE Id=" + order.Id;
                    AddOrEditOrders(updateCommand, order, connection);
                }
                else
                {
                    string addCommand = "INSERT INTO Order (Date,Customer_Id,TotalPrice) VALUES (@date,@customerId,@totalPrice)";
                    AddOrEditOrders(addCommand, order, connection);

                    SqlCommand getLastIdCmd = new SqlCommand("SELECT @@IDENTITY", connection);
                    int insertedRecordId = (int)(decimal)getLastIdCmd.ExecuteScalar();
                    order.Id = insertedRecordId;
                }
            }
        }

        public bool DeleteFromOrder(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteCommand = "DELETE FROM Order WHERE Id=" + id;
                SqlCommand sqlDeleteCommand = new SqlCommand(deleteCommand, connection);
                var rows = sqlDeleteCommand.ExecuteNonQuery();
                if (rows >= 1)
                {
                    Console.WriteLine("Rows Affected: {0}", rows);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public List<Order> GetAllOrders()
        {
            var ordersList = new List<Order>();

            using (var connaction = new SqlConnection(connectionString))
            {
                connaction.Open();

                string command = "SELECT * FROM Order";
                SqlCommand sqlCommand = new SqlCommand(command, connaction);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var order = new Order();

                    order.Id = (int)reader["Id"];
                    order.TotalPrice = (decimal)reader["TotalPrice"];
                    order.Date = (DateTime)reader["Date"];
                    order.CustomerId = (int)reader["Customer_Id"];

                    ordersList.Add(order);
                }
            }
            return ordersList.ToList();
        }

        public Order GetOrderById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "SELECT * FROM Order WHERE Id=" + id;
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                var count = (int)sqlCommand.ExecuteScalar();
                if (count >= 1)
                {
                    var reader = sqlCommand.ExecuteReader();

                    int orderId = 0;
                    DateTime date = DateTime.Now;
                    decimal totalPrice = 0m;
                    int customerId = 0;

                    while (reader.Read())
                    {
                        orderId = (int)reader["Id"];
                        date = (DateTime)reader["Date"];
                        totalPrice = (decimal)reader["TotalPrice"];
                        customerId = (int)reader["Customer_Id"];
                    }

                    return new Order() { CustomerId = customerId, Date = date, TotalPrice = totalPrice, Id = orderId };
                }
                else
                {
                    return null;
                }
            }
        }

        private void AddOrEditOrders(string command, Order order, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            sqlCommand.Parameters.AddWithValue("@date", order.Date);
            sqlCommand.Parameters.AddWithValue("@customerId", order.CustomerId);
            sqlCommand.Parameters.AddWithValue("@totalPrice", order.TotalPrice);

            var rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: {0}", rows);
        }
    }
}
