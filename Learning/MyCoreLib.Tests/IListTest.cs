using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyCoreLib.Tests
{
    internal class IListTest
    {

        [Test]
        public void IndexOf_Test()
        {
            IList<int> list = TestData.ListSet1;

            list.IndexOf(21).Should().Be(2);

            list.IndexOf(99).Should().Be(-1);
        }


        [Test]
        [TestCaseSource(nameof(IList_Ctor_Test_TestCases))]
        public void IList_Ctor_Test(ICollection<int> list, int expectedCount)
        {
            list.Count.Should().Be(expectedCount);
        }


        private static IEnumerable<object[]> IList_Ctor_Test_TestCases()
        {
            //List<ICollection<int>> emptyCollections = new List<ICollection<int>> {
            //   new List<int>(),
            //   new MyList<int>(),
            //   new LinkedList<int>()
            //};

            List<Type> collectionsTypes = new List<Type> {
               typeof(List<int>),
               typeof(MyList<int>),
               typeof(LinkedList<int>)
            };

            List<int[]> dataSets = new List<int[]>
            {
                TestData.ListSorted_Count5_Set,
                TestData.ListUnsorted_Count8_Set,
                TestData.ListEmpty_Set,
                TestData.ListRandoms_Lemon
            };
         

            foreach (var data in dataSets)
                foreach (var type in collectionsTypes)
                {                   
                   var collection = Activator.CreateInstance(type, data) as ICollection<int>;
                    yield return new object[] { collection, data.Length };
                }
            
        }



        [Test]
        public void IndexOf_NoData_Test()
        {
            var list = TestData.ListSet1;

            list.IndexOf(99).Should().Be(-1);
        }

        [Test]
        public void Insert_Test()
        {
            var list = TestData.ListSet1;

            list.IndexOf(7).Should().Be(1);

            list.Insert(1, 5);

            list.IndexOf(5).Should().Be(1);
        }

        [Test]
        public void Remove_Test()
        {
            var list = TestData.ListSet1;

            list.IndexOf(21).Should().Be(2);

            list.Remove(21);

            list.IndexOf(21).Should().Be(-1);
        }

        [Test]
        public void RemoveAt()
        {
            var list = TestData.ListSet1;

            list.IndexOf(11).Should().Be(6);

            list.RemoveAt(6);

            list.IndexOf(11).Should().Be(-1);
        }

        [Test]
        public void simpletest()
        {

        }

        /* public void Clear()
         {
             throw new NotImplementedException();
         }

         public bool Contains(T item)
         {
             throw new NotImplementedException();
         }

         public void CopyTo(T[] array, int arrayIndex)
         {
             throw new NotImplementedException();
         }

         bool ICollection<T>.Remove(T item)
         {
             throw new NotImplementedException();
         }

         public IEnumerator<T> GetEnumerator()
         {
             throw new NotImplementedException();
         }

         IEnumerator IEnumerable.GetEnumerator()
         {
             throw new NotImplementedException();
         }*/
    }
}
