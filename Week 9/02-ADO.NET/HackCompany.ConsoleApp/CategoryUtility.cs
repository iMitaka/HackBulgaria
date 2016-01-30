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
    public class CategoryUtility
    {
        private string connectionString;

        public CategoryUtility()
        {
            connectionString = ConfigurationManager.ConnectionStrings["HackCompanyDb"].ConnectionString;
        }

        public void AddCategoryToDb(Category category)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string countCommad = "SELECT COUNT(*) FROM Category WHERE id=" + category.Id;
                SqlCommand sqlCountCommand = new SqlCommand(countCommad, connection);
                var count = (int)sqlCountCommand.ExecuteScalar();
                if (count >= 1)
                {
                    string updateCommand = "UPDATE Category SET Name=@name,Code=@code WHERE id=" + category.Id;
                    AddOrEditCategory(updateCommand, category, connection);
                }
                else
                {
                    string addCommand = "INSERT INT Category (Name,Code) VALUES (@name,@code)";
                    AddOrEditCategory(addCommand, category, connection);

                    SqlCommand getLastIdCmd = new SqlCommand("SELECT @@IDENTITY", connection);
                    int insertedRecordId = (int)(decimal)getLastIdCmd.ExecuteScalar();
                    category.Id = insertedRecordId;
                }
            }
        }

        public bool DeleteFromCategory(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string deleteCommand = "DELETE FROM Category WHERE Id = " + id;
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

        public List<Category> GetAllCategorys()
        {
            var listCategory = new List<Category>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string command = "SELECT * FROM Category";
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                var reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    var category = new Category();

                    category.Id = (int)reader["Id"];
                    category.Name = (string)reader["Name"];
                    category.Code = (string)reader["Code"];

                    listCategory.Add(category);
                }

                return listCategory.ToList();
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "SELECT * FROM Category WHERE id=" + id;
                SqlCommand sqlCommand = new SqlCommand(command, connection);
                var rows = sqlCommand.ExecuteNonQuery();
                if (rows >= 1)
                {
                    var reader = sqlCommand.ExecuteReader();

                    int categoryId = 0;
                    string name = string.Empty;
                    string code = string.Empty;

                    while (reader.Read())
                    {
                        categoryId = (int)reader["Id"];
                        name = (string)reader["Name"];
                        code = (string)reader["Code"];
                    }

                    return new Category() { Code = code, Name = name, Id = categoryId };
                }
                else 
                {
                    return null;
                }
            }
        }

        private void AddOrEditCategory(string command, Category category, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(command, connection);
            sqlCommand.Parameters.AddWithValue("@name", category.Name);
            sqlCommand.Parameters.AddWithValue("@code", category.Code);

            var rows = sqlCommand.ExecuteNonQuery();
            Console.WriteLine("Rows Affected: {0}", rows);
        }

    }
}
