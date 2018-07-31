using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
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

/* public partial class EntryPoint
 {
     static void Main()
     {
         List<Employee> employees = new List<Employee>();
         employees.Add(new Employee(40000));
         employees.Add(new Employee(65000));
         employees.Add(new Employee(95000));

         MethodInfo mi = typeof(Employee).GetMethod("ApplyRaiseOf", BindingFlags.Public | BindingFlags.Instance);
         ApplyRaiseDelegate applyRaise = (ApplyRaiseDelegate)
             Delegate.CreateDelegate(typeof(ApplyRaiseDelegate), mi);

         foreach(Employee e in employees)
         {
             applyRaise(e, (Decimal)0.10);
             Console.WriteLine(e.Salary);
         }
     }
 }*/

