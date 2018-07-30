using System;
using System.Collections.Generic;
using System.Text;

namespace Employee
{
    class Person
    {
        public Person(int age, string name)
        {
            this.age = age;
            Name = name;
        }
        private int age;
        

        public string Name { get; set; }

        public int Age
        {
            get => age;
            set
            {
                int oldage = age;
                age = value;

                if (oldage != value)
                {
                    RaiseOnAgeChanged(value);
                }
            }
        }

        public event EventHandler<int> OnAgeChanged;

        private void RaiseOnAgeChanged (int age)
        {
            OnAgeChanged?.Invoke(this, age);
        }
    }
}
