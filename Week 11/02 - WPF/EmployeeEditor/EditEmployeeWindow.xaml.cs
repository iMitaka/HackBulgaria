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
using System.Windows.Shapes;

namespace EmployeeEditor
{
    /// <summary>
    /// Interaction logic for EditEmployeeWindow.xaml
    /// </summary>
    public partial class EditEmployeeWindow : Window
    {
        public EditEmployeeWindow()
        {
            InitializeComponent();
            this.employeeDate.DisplayDateStart = new DateTime(1950, 1, 1);
            this.employeeDate.DisplayDateEnd = new DateTime(1998, 1, 1);
        }

        public void OnStartup()
        {
            this.Title = string.Format("Edit Employee ID:{0}", employee.Id, employee.Name);

            this.employeeName.Text = employee.Name;
            this.employeeEmail.Text = employee.Email;
            this.employeeDate.SelectedDate = employee.BirthDate;
        }

        public Employee employee { get; set; }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var name = this.employeeName.Text;

            if (name.Length < 2)
            {
                this.nameErrorLabel.Content = "Name length must be minimum 2.";
                return;
            }
            else
            {
                this.nameErrorLabel.Content = string.Empty;
            }

            var email = this.employeeEmail.Text;
            
            if (!email.Contains("@") && !email.Contains('.'))
            {
                this.emailErrorLabel.Content = "Email is not vaid.";
                return;
            }
            else
            {
                this.emailErrorLabel.Content = string.Empty;
            }

            var date = this.employeeDate.SelectedDate.Value;


            var connectionString = ConfigurationManager.ConnectionStrings["HackCompanyDb"].ConnectionString;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateCommand = "UPDATE Employee SET Name = @name, Email = @email, DateOfBirth = @dateOfBirth WHERE Id = " + employee.Id;
                SqlCommand command = new SqlCommand(updateCommand, connection);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@dateOfBirth", date);
                command.ExecuteNonQuery();
            }

            System.Windows.Forms.Application.Restart();
            System.Windows.Application.Current.Shutdown();
        }


    }
}
