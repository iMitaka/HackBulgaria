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
    public class DepartmentUtility
    {
        private string connectionString;

        public DepartmentUtility()
        {
            connectionString = ConfigurationManager.ConnectionStrings["HackCompanyDb"].ConnectionString;
        }

        public void AddDepartmentToDb(Department department)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string countCommand = "SELECT COUNT(*) FROM Department WHERE Id=" + department.Id;
                SqlCommand sqlCountCommand = new SqlCommand(countCommand, connection);
                var count = (int)sqlCountCommand.ExecuteScalar();
                if (count >= 1)
                {
                    string updateCommand = "UPDATE Department SET Name=@name WHERE Id=" + department.Id;
                    AddOrEditDepartment(updateCommand, department, connection);
                }
                else
                {
                    string addCommand = "INSERT INTO Department (Name) VALUES (@name)";
                    AddOrEditDepartment(addCommand, department, connection);

                    SqlCommand getLastIdCmd = new SqlCommand("SELECT @@IDENTITY", connection);
                    int insertedRecordId = (int)(decimal)getLastIdCmd.ExecuteScalar();
                    department.Id = insertedRecordId;
                }
            }
        }

        public bool DeleteFromDepartment(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteCommand = "DELETE FROM Department WHERE Id=" + id;
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

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "SELECT * FROM Order";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var order = new Order();

                    order.Date = (DateTime)reader["Date"];
                    order.Id = (int)reader["Id"];
                    order.TotalPrice = (decimal)reader["TotalPrice"];
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

                    DateTime date = DateTime.Now;
                    int orderId = 0;
                    int customerId = 0;
                    decimal totalPrice = 0m;

                    while (reader.Read())
                    {
                        date = (DateTime)reader["Date"];
                        orderId = (int)reader["Id"];
                        totalPrice = (decimal)reader["TotalPrice"];
                        customerId = (int)reader["Customer_Id"];
                    }

                    return new Order() { CustomerId = customerId, TotalPrice = totalPrice, Id = orderId, Date = date };
                }
                else
                {
                    return null;
                }
            }
        }

        private void AddOrEditDepartment(string command, Department department, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            sqlCommand.Parameters.AddWithValue("@name", department.Name);

            var rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: {0}", rows);
        }
    }
}
