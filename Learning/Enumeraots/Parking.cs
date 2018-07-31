using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Enumeraots
{
    public class Parking : IEnumerable
    {
        private readonly List<Car> firstRow = new List<Car>(5);
        private readonly List<Car> secondRow = new List<Car>(5);
        private int state = 0;
        public Parking()
        {
            for (int i = 0; i < 5; i++)
            {
               
                firstRow.Add(null);
                secondRow.Add(null);
            }
        }

        public void Add(Car car, int slot, int row)
        {

            if (row == 0)
            {
                firstRow[slot] = car;
            }
            else if (row == 1)
            {
                secondRow[slot] = car;
            }
        }


        public IEnumerator GetEnumerator()
        {
            Debug.WriteLine("before");
            int i = 0;
            int y = 0;
            
            switch (state)
            {
                case 0:
                    state = 1;

                    yield return firstRow[0];
                    break;
                case 1:
                    state = 2;
                    yield return firstRow[1];
                    break;
                case 2:
                    state = 3;
                    yield return firstRow[2];
                    break;
                case 3:
                    state = 4;
                    yield return firstRow[3];
                    break;
            }


           /* foreach (var car in firstRow)
            {
                Debug.WriteLine($"count {i++}");
                if (car != null)
                {
                    Debug.WriteLine(car.carName);
                    yield return car;
                }
                else
                {
                    Debug.WriteLine("car is null");
                }
            }*/

            Debug.WriteLine("end first foreach");

            foreach (var car in secondRow)
            {
                Debug.WriteLine($"count2 {y++}");
                if (car != null)
                {
                    Debug.WriteLine(car.carName);
                    yield return car;
                }
                else
                {
                    Debug.WriteLine("car is null");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }



    public class Car
    {

        public string carName;

        public Car(string carName)
        {
            this.carName = carName;
        }

        public override string ToString()
        {
            return carName;
        }
    }
}
