using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Employee
{
    public class Example1
    {
        public static void Run()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee(40000));
            employees.Add(new Employee(65000));
            employees.Add(new Employee(95000));

            MethodInfo mi = typeof(Employee).GetMethod("ApplyRaiseOf", BindingFlags.Public | BindingFlags.Instance);
            ApplyRaiseDelegate applyRaise = (ApplyRaiseDelegate)
                Delegate.CreateDelegate(typeof(ApplyRaiseDelegate), mi);

            foreach (Employee e in employees)
            {
                applyRaise(e, (Decimal)0.10);
                Console.WriteLine(e.Salary);
            }
        }
    }
}
