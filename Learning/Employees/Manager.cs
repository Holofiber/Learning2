using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Manager : Employee
    {
        public Manager(string fullName, int age, int empId, float currPay, int numbOfOpts, string ssl)
            : base(fullName, empId, currPay, age, ssl)
        {
            StockOpptions = numbOfOpts;
        }

        public int StockOpptions { get; set; }

        public Manager()
        {

        }

        public override void GiveBonus(float amount)
        {
            base.GiveBonus(amount);
            Random r = new Random();
            StockOpptions += r.Next(500);
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine($"Number of Stock: {StockOpptions}");
        }
    }
}
