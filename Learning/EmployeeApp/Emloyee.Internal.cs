﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp
{
    partial class Employee
    {
        private string empName;
        private int empID;
        private float currPay;

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
        public int ID { get; }
        public float Pay { get; set; }


        public Employee() { }

        public Employee(string name, int id, float pay)
        {
            empName = name;
            empID = id;
            currPay = pay;
        }
    }
}
