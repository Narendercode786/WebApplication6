using System.Data.SqlClient;
using System.Security.Cryptography.Xml;
using WebApplication6.Models;

namespace WebApplication6.Services
{
    public class EmployeeService
    {
        private static string db_source = "appdb786.database.windows.net";
        private static string db_user = "admindb";
        private static string db_password = "test@123";
        private static string db_database = "appdb";


        private SqlConnection GetConnectionString()
        {
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }

        public List<Employee> GetEmployees()
        {
            SqlConnection sqlConnection = GetConnectionString();
            List<Employee> employees = new List<Employee>();
            string str = "select Id,Name,Address from Employee With(nolock)";
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(str, sqlConnection);
            using(SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Employee emp = new Employee();
                    emp.Id = Convert.ToInt32(reader["Id"]);
                    emp.Name = reader["Name"].ToString();
                    emp.Address = reader["Address"].ToString();
                    employees.Add(emp);
                }
            }
            sqlConnection.Close();
            return employees; 
        }
    }
}
