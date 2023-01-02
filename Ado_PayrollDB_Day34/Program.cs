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

        }
    }
}