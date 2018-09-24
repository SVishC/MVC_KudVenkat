using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Employee> employees = new List<Employee>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(rdr["Id"]);
                        employee.Name = Convert.ToString(rdr["Name"]);
                        employee.Gender = Convert.ToString(rdr["Gender"]);
                        employee.City = Convert.ToString(rdr["City"]);
                        employee.DateOfBirth = Convert.ToDateTime(rdr["DateOfBirth"]);

                        employees.Add(employee);
                    }
                }
                    return employees;
            }
        }

        public void AddEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth ";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con?.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveEmployee(Employee employee)
        {

            string connectionString = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            //List<Employee> employees = new List<Employee>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth ";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                con?.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
