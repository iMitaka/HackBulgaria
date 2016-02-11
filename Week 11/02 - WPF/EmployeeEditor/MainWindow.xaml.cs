using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmployeeEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IList<Employee> employees = new List<Employee>();

        public MainWindow()
        {
            InitializeComponent();

            var connectionString = ConfigurationManager.ConnectionStrings["HackCompanyDb"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string getAllEmplyeeCmd = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(getAllEmplyeeCmd, connection);

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
            }

            this.header.Content = string.Format("{0,-20} {1,30} {2,30} {3,20} {4,10}", "Name", "Email", "Date Of Birth", "ManagerID", "DepID");


            foreach (var emplyee in employees)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Tag = emplyee;
                itm.Content = string.Format("{0,-20} {1,30} {2,30} {3,20} {4,10}", emplyee.Name, emplyee.Email, emplyee.BirthDate.ToShortDateString(), emplyee.ManagerId, emplyee.DepartmentId);

                this.employeeListBox.Items.Add(itm);
            }
         
        }

        private void employeeListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (ListBoxItem)this.employeeListBox.SelectedItem;
            var employee = (Employee)item.Tag;

            var editEmployeeWindows = new EditEmployeeWindow();
            editEmployeeWindows.employee = employee;
            editEmployeeWindows.OnStartup();
            editEmployeeWindows.Show();
        }
    }
}