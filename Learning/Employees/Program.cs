using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****  The  Employee  Class  Hierarchy  *****\n");


            //  Предоставить  каждому  сотруднику  бонус?

            Manager chucky = new Manager("Chucky", 50, 92, 100000, 9000, "333-23-2322");

            chucky.GiveBonus(300);

            chucky.DisplayStats();

            Console.WriteLine();

            SalesPerson fran = new SalesPerson("Fran", 43, 93, 3000, 31, "932-32-3232");

            fran.GiveBonus(200);

            fran.DisplayStats();


            Console.ReadLine();
        }

        static void GivePromotion(Employee emp)
        {
            Console.WriteLine($"{emp.Name} was promoted!");

            if (emp is SalesPerson salesPerson)
            {
                Console.WriteLine($"{salesPerson.Name} made {salesPerson.SalesNumber} sale(s)!");
                Console.WriteLine();
            }

            if (emp is Manager manager)
            {
                Console.WriteLine($"{emp.Name} had {manager.StockOpptions} stock options...");
                Console.WriteLine();
            }

        }

        static void CastingExamples()
        {
            object frank = new Manager("Frank Zapppa", 9, 3000, 40000, 5, "111-11-1111");
            GivePromotion((Manager)frank);

            Employee moonUnit = new Manager("MoonUnit Zappa", 2, 3001, 20000, 1, "101-11-1321");
            GivePromotion(moonUnit);

            SalesPerson jill = new PtSalesPerson("Jill", 834, 3002, 100000, "111-12-1119", 90);
            GivePromotion(jill);
        }

    }
}
