using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_PayrollDB_Day34
{
    internal class EmployeeRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection connection = new SqlConnection(connectionString);
        public void CheckConnection()    //UC1 Verifying the Connectivity status with the db.
        {
           
            try
            {
                connection.Open();
                Console.WriteLine("Connection with database has been established.");
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Source connection. " + ex.Message);
            }
        }
        public void GetAllEmployee()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                using (this.connection)
                {
                    this.connection.Open();
                    string query = "select * from EmployeePayRoll";
                    SqlCommand cmd = new SqlCommand(query, this.connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            employeeModel.EmployeeId = dr.GetInt32(0);
                            employeeModel.Name = dr.GetString(1);
                            employeeModel.Salary = dr.GetDouble(2);
                            employeeModel.StartDate = dr.GetDateTime(3);
                            employeeModel.Gender = dr.GetString(4);
                            employeeModel.MobileNo = dr.GetInt64(5);
                            employeeModel.Department = dr.GetString(6);
                            employeeModel.Address = dr.GetString(7);
                            employeeModel.Deductions = dr.GetDouble(8);
                            employeeModel.Taxable_Pay = dr.GetDouble(9);
                            employeeModel.Income_Tax = dr.GetDouble(10);
                            employeeModel.Net_Pay = dr.GetDouble(11);
                            Console.WriteLine($"{employeeModel.EmployeeId}, {employeeModel.Name}, {employeeModel.Salary}, {employeeModel.StartDate}, {employeeModel.Gender},{employeeModel.MobileNo}");

                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}