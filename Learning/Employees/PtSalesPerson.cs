using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class PtSalesPerson : SalesPerson
    {
        public PtSalesPerson(string fullName, int age, int empID, float currPay, string ssn, int numbOfSales):
            base (fullName, age, empID, currPay, numbOfSales, ssn)
        {
            
        }
    }
}
