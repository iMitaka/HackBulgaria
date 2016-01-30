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
    public class EmployeeUtility
    {
        private string connectionString;

        public EmployeeUtility()
        {
            connectionString = ConfigurationManager.ConnectionStrings["HackCompanyDb"].ConnectionString;
        }

        public Employee GetEmployeeById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "SELECT * FROM Employee WHERE Id =" + id;
                SqlCommand cmd = new SqlCommand(command, connection);
                int count = (int)cmd.ExecuteScalar();
                if (count >= 1)
                {
                    var reader = cmd.ExecuteReader();
                    string name = string.Empty;
                    string email = string.Empty;
                    int employeeId = 0;
                    int? depId = 0;
                    int? managId = 0;
                    DateTime bithDate = DateTime.Now;

                    while (reader.Read())
                    {
                        employeeId = (int)reader["Id"];
                        name = (string)reader["Name"];
                        bithDate = (DateTime)reader["DateOfBirth"];
                        if (reader["Department_Id"] == DBNull.Value)
                        {
                            depId = null;
                        }
                        else
                        {
                            depId = (int?)reader["Department_Id"];
                        }

                        if (reader["Manager_Id"] == DBNull.Value)
                        {
                            managId = null;
                        }
                        else
                        {
                            managId = (int?)reader["Manager_Id"];
                        }
                        email = (string)reader["Email"];
                    }

                    return new Employee() { Id = employeeId, Name = name, BirthDate = bithDate, ManagerId = managId, DepartmentId = depId, Email = email };
                }
                else
                {
                    return null;
                }
            }
        }

        public void AddEmployeeToDb(Employee employee)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string command = "SELECT COUNT(*) FROM Employee WHERE Employee.Id = " + employee.Id;
                SqlCommand cmd = new SqlCommand(command);
                cmd.Connection = connection;
                var count = (int)cmd.ExecuteScalar();
                if (count >= 1)
                {
                    string updateCommand = "UPDATE Employee SET Name = @name, Email = @email, DateOfBirth = @dateOfBirth, Manager_Id = @managerId, Department_Id = @departmentId WHERE Id = " + employee.Id;
                    AddOrEditEmployee(updateCommand, employee, connection);
                }
                else
                {
                    string insertCommand = "INSERT INTO Employee (Name,Email,DateOfBirth,Manager_Id,Department_Id) VALUES (@name,@email,@dateOfBirth,@managerId,@departmentId)";
                    AddOrEditEmployee(insertCommand, employee, connection);

                    SqlCommand getLastIdCmd = new SqlCommand("SELECT @@IDENTITY");
                    getLastIdCmd.Connection = connection;
                    int insertedRecordId = (int)(decimal)getLastIdCmd.ExecuteScalar();
                    employee.Id = insertedRecordId;
                }
            }
        }

        public bool DeleteFromEmployee(int id) 
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string command = "DELETE FROM Employee WHERE id =" + id;
                SqlCommand deleteCmd = new SqlCommand(command, connection);
                var rows = deleteCmd.ExecuteNonQuery();
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

        public List<Employee> GetAllEmplyees() 
        {
            List<Employee> employees = new List<Employee>();

            using (var connection = new SqlConnection(connectionString)) 
            {
                connection.Open();

                string getAllEmplyeeCmd = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(getAllEmplyeeCmd,connection);
                
                var reader = cmd.ExecuteReader();

                while (reader.Read()) 
                {
                    var employee = new Employee();
                    employee.Id = (int)reader["Id"];
                    employee.Name = (string)reader["Name"];
                    employee.BirthDate = (DateTime)reader["DateOfBirth"];
                    if (reader["Department_Id"] == DBNull.Value)
                    {
                        employee.DepartmentId = null;
                    }
                    else 
                    {
                        employee.DepartmentId = (int?)reader["Department_Id"];
                    }
                    
                    if (reader["Manager_Id"] == DBNull.Value)
                    {
                        employee.ManagerId = null;
                    }
                    else 
                    {
                        employee.ManagerId = (int?)reader["Manager_Id"];
                    }
                    employee.Email = (string)reader["Email"];

                    employees.Add(employee);
                }

                return employees.ToList();
            }
        }

        private void AddOrEditEmployee(string command, Employee employee, SqlConnection connection)
        {
            SqlCommand sqlCommand = new SqlCommand(command);
            sqlCommand.Connection = connection;

            sqlCommand.Parameters.AddWithValue("@name", employee.Name);
            SqlParameter sqlParameterEmail = new SqlParameter("@email", employee.Email);
            if (employee.Email == null)
            {
                sqlParameterEmail.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(sqlParameterEmail);
            sqlCommand.Parameters.AddWithValue("@dateOfBirth", employee.BirthDate);
            SqlParameter sqlParameterManagerId = new SqlParameter("@managerId", employee.ManagerId);
            if (employee.ManagerId == null)
            {
                sqlParameterManagerId.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(sqlParameterManagerId);
            SqlParameter sqlParameterDepartmentId = new SqlParameter("@departmentId", employee.DepartmentId);
            if (employee.DepartmentId == null)
            {
                sqlParameterDepartmentId.Value = DBNull.Value;
            }
            sqlCommand.Parameters.Add(sqlParameterDepartmentId);

            var rows = sqlCommand.ExecuteNonQuery();

            Console.WriteLine("Rows Affected: {0}", rows);
        }
    }
}
