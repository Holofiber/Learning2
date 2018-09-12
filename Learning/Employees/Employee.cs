using System;

namespace Employees
{
    abstract partial class Employee
    {
        public virtual void GiveBonus(float amount)
        {
            currPay += amount;
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine($"Name: {empName}");
            Console.WriteLine($"ID: {empID}");
            Console.WriteLine($"Pay: {currPay}");
            Console.WriteLine($"Age: {Age}");
        }

        public class BenefitPackage
        {
            public double ComputePayDeduction()
            {
                return 125.0;
            }

            public enum BenefitPackageLevel
            {
                Standart,
                Gold,
                Platinum
            }
        }
    }
}
