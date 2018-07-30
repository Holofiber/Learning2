using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
namespace Employee
{
    delegate void ApplyRaiseDelegate(Employee emp, Decimal percent);

    public class Employee
    {
        private Decimal salary;
        public Employee(Decimal salary)
        {
            this.salary = salary;
        }

        public Decimal Salary
        {
            get { return salary; }
        }

        public void ApplyRaiseOf(Decimal percent)
        {
            salary *= (1 + percent);
        }
    }
}




