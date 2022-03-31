using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyCoreLib.Tests
{
    public static class TestData
    {
        public static MyList<int> ListSet1
        {
            get
            {
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(7);
                myList.Add(21);
                myList.Add(4);
                myList.Add(0);
                myList.Add(7);
                myList.Add(11);
                myList.Add(4577);
                myList.Add(67);
                myList.Add(34);
                return myList;
            }
        }

        public static int[] ListSorted_Count5_Set => new int[] { 1, 2, 3, 4, 5 };

        public static int[] ListUnsorted_Count8_Set => new int[] { 4, 8, 3, 7, 9, 34, 8, 3345 };

        public static int[] ListEmpty_Set => new int[] {};

        public static int[] ListRandoms_Lemon => GetRandom(1_000_000);

        public static IEnumerable<Trader> GetTraders(int count)
        {
            var testTradersFaker = new Faker<Trader>()
                .RuleFor(n => n.Name, f => f.Name.FullName())
                .RuleFor(b => b.Balance, f => f.Random.Double(10, 1000))
                .RuleFor(c => c.Country, f => f.Address.Country());

             return testTradersFaker.Generate(count);                          
        }

        private static int[] GetRandom(int count)
        {
            var random = new Random();
            int [] randomNumbers = Enumerable.Repeat(0, count)
                .ToList()
                .Select(_=> random.Next())
                .ToArray();

            return randomNumbers;
        }
    }
}