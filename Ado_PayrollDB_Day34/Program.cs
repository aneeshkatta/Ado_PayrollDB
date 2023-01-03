using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_PayrollDB_Day34
{
    internal class Program
    {
        static void Main()
        {
            EmployeeRepo objRepo = new EmployeeRepo();
            objRepo.CheckConnection();
            objRepo.GetAllEmployee();        
            EmployeeModel employeeModel = new EmployeeModel();          
            employeeModel.Name = "ravi";
            employeeModel.Salary = 30000;
            employeeModel.StartDate = DateTime.Now;
            employeeModel.Gender = "M";
            employeeModel.MobileNo = 9703718299;
            employeeModel.Department = "IT";
            employeeModel.Address = "hyderabad";
            employeeModel.Deductions = 1000;
            employeeModel.Basic_pay = 20000;
            employeeModel.Taxable_Pay = 200;
            employeeModel.Income_Tax = 100;
            employeeModel.Net_Pay = 31300;
            objRepo.AddEmployee(employeeModel);
            objRepo.GetAllEmployee();
        }
    }
}