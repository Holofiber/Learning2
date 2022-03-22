using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyCoreLib.Tests
{

    internal class EqualityTests
    {


        [Test]
        public void EqualityTest1()
        {
            var pers1 = new Person(12, "Orest");
            var pers2 = new Person(12, "Orest");

            Console.WriteLine(pers2 == pers1);
            Console.WriteLine(Object.ReferenceEquals(pers1, pers2));
            Console.WriteLine(Object.Equals(pers1, pers2));

            Console.WriteLine(pers1.Equals(pers2));
            pers1.Should().Be(pers2);

        }

        [Test]
        public void EqualityTest2()
        {
            var temp1 = new DailyTemperature(11.4, 45.8, 9);
            var (_, _, g) = temp1;


        }

        [Test]
        public void EqualityTest3()
        {
            var pers1 = new Person(12, "Orest");
            var pers2 = new Person(13, "Orest");
            var hs = new HashSet<Person>();
            hs.Add(pers1);
            hs.Add(pers2);

            //var d = new Dictionary<Person, int>();

            //d.Add(pers1, 1);
            //d.Add(pers2, 2);

          

            hs.Count.Should().Be(2);
        }
    }

    public record class DailyTemperature(double HighTemp, double LowTemp, int z);
}
