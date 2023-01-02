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
            public static void CheckConnection()    //UC1 Verifying the Connectivity status with the db.
            {
                SqlConnection connection = new SqlConnection(connectionString);
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
    }
}