using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enumeraots
{
    class Program
    {
        static void Main(string[] args)
        {
            var parking = new Parking();

            parking.Add(new Car("BMW"), 2, 0);
            parking.Add(new Car("Lada"), 1, 1);
            parking.Add(new Car("Audi"), 3, 0);
            parking.Add(new Car("Mers"), 4, 1);



            foreach (Car car in parking)
            {
                Console.WriteLine(car.carName);
            }

            Console.ReadLine();

            /*MyColl<int> integers = new MyColl<int>(new[] { 1, 2, 3, 4 });
            foreach (int i in integers)
            {
                Console.WriteLine(i);
            }*/
        }
    }
}
