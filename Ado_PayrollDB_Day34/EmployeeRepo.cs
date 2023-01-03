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
        SqlConnection connection ;
        public void CheckConnection()    //UC1 Verifying the Connectivity status with the db.
        {
            connection = new SqlConnection(connectionString);
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
            connection = new SqlConnection(connectionString);
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
                            employeeModel.Basic_pay = dr.GetDouble(8);
                            employeeModel.Deductions = dr.GetDouble(9);
                            employeeModel.Taxable_Pay = dr.GetDouble(10);
                            employeeModel.Income_Tax = dr.GetDouble(11);
                            employeeModel.Net_Pay = dr.GetDouble(12);
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
        public void AddEmployee(EmployeeModel employeeModel)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand("spAddEmployeeDetails", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", employeeModel.Name);
                    command.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    command.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    command.Parameters.AddWithValue("@Gender", employeeModel.Gender);                    
                    command.Parameters.AddWithValue("@MobileNo", employeeModel.MobileNo);
                    command.Parameters.AddWithValue("@Department", employeeModel.Department);
                    command.Parameters.AddWithValue("@Address", employeeModel.Address);
                    command.Parameters.AddWithValue("@Deductions", employeeModel.Deductions);
                    command.Parameters.AddWithValue("@Basic_pay", employeeModel.Basic_pay);
                    command.Parameters.AddWithValue("@Taxable_Pay", employeeModel.Taxable_Pay);
                    command.Parameters.AddWithValue("@Income_Tax", employeeModel.Income_Tax);              
                    command.Parameters.AddWithValue("@Net_Pay", employeeModel.Net_Pay);                   
                    var result = command.ExecuteNonQuery();
                    if (result != 0)
                        Console.WriteLine("Adding employee is successfully");
                    else
                        Console.WriteLine("Insert Query failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}