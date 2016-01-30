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
    public class ProductUtility
    {
        private string connectionString;

        public ProductUtility()
        {
            connectionString = ConfigurationManager.ConnectionStrings["HackCompanyDb"].ConnectionString;
        }

        public void AddProductToDb(Product product)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string cmd = "SELECT COUNT(*) FROM Product WHERE Id=" + product.Id;
                SqlCommand countProductsCmd = new SqlCommand(cmd, connection);
                int count = (int)countProductsCmd.ExecuteScalar();
                if (count >= 1)
                {
                    string updateCommand = "UPDATE Product SET Name = @name, Price = @price, Category_Id = @categoryId WHERE Id=" + product.Id;
                    AddOrEdintProduct(product, updateCommand, connection);
                }
                else
                {
                    string addCommand = "INSERT INTO Product (Name,Price,Category_Id) VALUES (@name,@price,@categoryId)";
                    AddOrEdintProduct(product, addCommand, connection);

                    SqlCommand getLastIdCmd = new SqlCommand("SELECT @@IDENTITY", connection);
                    int insertedRecordId = (int)(decimal)getLastIdCmd.ExecuteScalar();
                    product.Id = insertedRecordId;
                }
            }
        }

        public bool DeleteFromProducts(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteCommand = "DELETE FROM Product WHERE Id=" + id;
                SqlCommand command = new SqlCommand(deleteCommand, connection);
                int rows = command.ExecuteNonQuery();
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

        public List<Product> GetAllProducts() 
        {
            var listProducts = new List<Product>();

            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                string command = "SELECT * FROM Products";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    var product = new Product();

                    product.Id = (int)reader["Id"];
                    product.Name = (string)reader["Name"];
                    product.Price = (decimal)reader["Price"];
                    product.CategoryId = (int)reader["Category_Id"];

                    listProducts.Add(product);
                }

                return listProducts.ToList();
            }
        }

        public Product GetProductById(int id) 
        {
            string name = string.Empty;
            int productId = 0;
            decimal price = 0m;
            int categoriId = 0;

            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                string command = "SELECT FROM Product WHERE id=" + id;
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                var count = (int)sqlCommand.ExecuteScalar();
                if (count >= 1)
                {                   
                    var reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        productId = (int)reader["Id"];
                        name = (string)reader["Name"];
                        price = (decimal)reader["Price"];
                        categoriId = (int)reader["Category_Id"];
                    }

                    return new Product() { Name = name, CategoryId = categoriId, Price = price, Id = productId };
                }
                else 
                {
                    return null;
                }
            }
        }

        public void AddOrEdintProduct(Product product, string command, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            sqlCommand.Parameters.AddWithValue("@name", product.Name);
            sqlCommand.Parameters.AddWithValue("@price", product.Price);
            sqlCommand.Parameters.AddWithValue("@categoryId", product.CategoryId);

            var rows = sqlCommand.ExecuteNonQuery();

            Console.WriteLine("Rows Affected: {0}", rows);
        }
    }
}
