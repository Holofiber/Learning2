using System;

namespace Employees
{
    partial class Employee
    {
        protected string empName;
        protected int empID;
        protected float currPay;
        protected int age;
        protected string SocialSecurityNumber;
        protected BenefitPackage empBenefit = new BenefitPackage();

        public double GetBenefitCost()
        {
            return empBenefit.ComputePayDeduction();
        }

        public BenefitPackage Benefits
        {
            get => empBenefit;
            set => empBenefit = value;
        }

        public string Name
        {
            get => empName;
            set
            {
                if (value.Length > 15)
                {
                    Console.WriteLine("Error");
                }
                else
                {
                    empName = value;
                }
            }
        }
        public int ID { get; set; }
        public float Pay { get; set; }
        public int Age { get; set; }


        public Employee()
        {

        }

        public Employee(string name, int id, float pay, int age, string socialSecurityNumber)
        {
            empName = name;
            empID = id;
            currPay = pay;
            Age = age;
            SocialSecurityNumber = socialSecurityNumber;
        }
    }
}
