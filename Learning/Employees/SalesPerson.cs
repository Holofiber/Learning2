using System;

namespace Employees
{
    class SalesPerson : Employee
    {
        public int SalesNumber { get; set; }

        public SalesPerson(string fullName, int age, int empId, float currPay, int numbOfOpts, string ssl)
            : base(fullName, empId, currPay, age, ssl)
        {
            SalesNumber = numbOfOpts;
        }

        public SalesPerson()
        {

        }

        public sealed override void GiveBonus(float amount)
        {
            int salesBonus = 0;
            if (SalesNumber >= 0 && SalesNumber <= 100)
            {
                salesBonus = 10;
            }
            else
            {
                if (SalesNumber >= 101 && SalesNumber <= 200)
                {
                    salesBonus = 15;
                }
                else
                {
                    salesBonus = 20;
                }
            }
        }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine($"Number of Stock: {SalesNumber}");
        }

        
    }
}
