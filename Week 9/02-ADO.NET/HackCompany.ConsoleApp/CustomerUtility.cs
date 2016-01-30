using HackCompany.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace HackCompany.ConsoleApp
{
    public class CustomerUtility
    {
        private string connectionString;

        public CustomerUtility()
        {
            connectionString = ConfigurationManager.ConnectionStrings["HackCompanyDb"].ConnectionString;
        }

        public void AddCustomerToDb(Customer customer) 
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                string countCommand = "SELECT COUNT(*) FROM Customer WHERE id=" + customer.Id;
                SqlCommand sqlCountCommand = new SqlCommand(countCommand, connection);
                var count = (int)sqlCountCommand.ExecuteScalar();
                if (count >= 1)
                {
                    string updateCommand = "UDAPTE Customer SET Name=@name,Email=@email,Adress=@adress,Discount=@discount WHERE id=" + customer.Id;
                    AddOrEditCustomer(updateCommand, customer, connection);
                }
                else 
                {
                    string addCommand = "INSERT INTO Customer (Name,Email,Adress,Discount) VALUES (@name,@email,@adress,@discount)";
                    AddOrEditCustomer(addCommand, customer, connection);

                    SqlCommand getLastIdCmd = new SqlCommand("SELECT @@IDENTITY", connection);
                    int insertedRecordId = (int)(decimal)getLastIdCmd.ExecuteScalar();
                    customer.Id = insertedRecordId;
                }
            }
        }

        public bool DeleteFromCustomer(int id) 
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                string deleteCommand = "DELETE FROM Customer WHERE Id=" + id;
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

        public List<Customer> GetAllCustomers() 
        {
            var customersList = new List<Customer>();

            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                string command = "SELECT * FROM Customer";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var customer = new Customer();
                    customer.Id = (int)reader["Id"];
                    customer.Name = (string)reader["Name"];
                    customer.Email = (string)reader["Email"];
                    customer.Address = (string)reader["Adress"];
                    if (reader["Discount"] == DBNull.Value)
                    {
                        customer.Discount = null;
                    }
                    else 
                    {
                        customer.Discount = (int)reader["Discount"];
                    }

                    customersList.Add(customer);
                }

                return customersList.ToList();
            }
        }

        public Customer GetCustomerById(int id) 
        {
            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                string command = "SELECT * FROM Customer WHERE id=" + id;
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                var count = (int)sqlCommand.ExecuteScalar();
                if (count >= 1)
                {
                    var reader = sqlCommand.ExecuteReader();

                    int customerId = 0;
                    string name = string.Empty;
                    string email = string.Empty;
                    string adress = string.Empty;
                    int? discount = 0;

                    while (reader.Read())
                    {
                        customerId = (int)reader["Id"];
                        name = (string)reader["Name"];
                        email = (string)reader["Email"];
                        adress = (string)reader["Adress"];
                        if (reader["Discount"] == DBNull.Value)
                        {
                            discount = null;
                        }
                        else
                        {
                            discount = (int)reader["Discount"];
                        }
                    }

                    return new Customer() { Address = adress, Discount = discount, Email = email, Name = name, Id = id };
                }
                else 
                {
                    return null;
                }
            }
        }

        private void AddOrEditCustomer(string command, Customer customer, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            sqlCommand.Parameters.AddWithValue("@name", customer.Name);
            SqlParameter emailParameter = new SqlParameter("@email", customer.Email);
            if (customer.Email == null)
            {
                emailParameter.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(emailParameter);
            sqlCommand.Parameters.AddWithValue("@adress", customer.Address);
            SqlParameter discountParameter = new SqlParameter("@discout", customer.Discount);
            if (customer.Discount == null)
            {
                discountParameter.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(discountParameter);

            var rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: {0}", rows);
        }
    }
}
