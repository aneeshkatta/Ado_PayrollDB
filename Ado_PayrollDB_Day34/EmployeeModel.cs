using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ado_PayrollDB_Day34
{
    internal class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public double MobileNo { get; set; }
        public string Department { get; set; }
        public double Deductions { get; set; }
        public double Basic_pay { get; set; }
        public double Taxable_Pay { get; set; }
        public double Income_Tax { get; set; }
        public double Net_Pay { get; set; }
    }
}
