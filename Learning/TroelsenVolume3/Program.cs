using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TroelsenVolume3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****  Fun  with  Class  Types  *****\n");

            Car c = new Car();
            c.PetName = "Frank";
            c.Speed = 55;
            c.Color = "Red";
            c.DisplayStats();

            Garage g = new Garage();
            g.MyAuto = c;

            Console.WriteLine($"Number of Cars: {g.NumberOfCars}");
            Console.WriteLine("Your car is named: {0}", g.MyAuto.PetName);


            Console.ReadLine();
        }
    }

    class Garage
    {
        public int NumberOfCars { get; set; }
        public Car MyAuto { get; set; }

        public Garage()
        {
            MyAuto = new Car();
            NumberOfCars = 1;
        }

        public Garage(Car car, int number)
        {
            MyAuto = car;
            NumberOfCars = number;
        }
    }

    class Car
    {
        public string PetName { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }

        public Car()
        {
            PetName = "Chuck";
            Speed = 10;
        }

        public Car(string pn)
        {
            PetName = pn;
        }

        public Car(string pn, int cs)
        {
            PetName = pn;
            Speed = cs;
        }

        public void DisplayStats()

        {

            Console.WriteLine("CarName:  {0}", PetName);

            Console.WriteLine("Speed:  {0}", Speed);

            Console.WriteLine("Color:  {0}", Color);

        }



        public void PrintState()
        {
            Console.WriteLine($"{PetName} is going {Speed} MPH");
        }

        public void SpeedUp(int delta)
        {
            Speed += delta;
        }
    }

    class Motorcycle
    {
        public int driverIntensity;
        public string name;

        public void SetDriverName(string name)
        {
            this.name = name;
        }


        public Motorcycle()
        {
            Console.WriteLine("In default ctor");
        }

        public Motorcycle(int intensity) : this(10, "")
        {
            Console.WriteLine("In ctor taking an Int");
        }

        public Motorcycle(string name) : this(0, name)
        { Console.WriteLine("In ctor taking an String"); }

        public Motorcycle(int intensity, string name)
        {
            Console.WriteLine("In master ctor");
            if (intensity > 10)
            {
                intensity = 10;
            }

            driverIntensity = intensity;
            this.name = name;
        }

        public void PopAWheely()
        {
            for (int i = 0; i <= driverIntensity; i++)
            {
                Console.WriteLine("Yeeeeeee  Haaaaaeewww!");

            }
        }
    }
}