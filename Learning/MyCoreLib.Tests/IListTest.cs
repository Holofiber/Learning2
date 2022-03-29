using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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
               typeof(LinkedList<int>),
               typeof(DLinkedList<int>),
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

        private static IEnumerable<object> IList_1to5_Test_TestCases()
        {
            //List<ICollection<int>> emptyCollections = new List<ICollection<int>> {
            //   new List<int>(),
            //   new MyList<int>(),
            //   new LinkedList<int>()
            //};

            List<Type> collectionsTypes = new List<Type> {
               typeof(List<int>),
               typeof(MyList<int>),               
               typeof(DLinkedList<int>),
            };

            List<int[]> dataSets = new List<int[]>
            {
                TestData.ListSorted_Count5_Set,                
            };


            foreach (var data in dataSets)
                foreach (var type in collectionsTypes)
                {
                    var collection = Activator.CreateInstance(type, data) as ICollection<int>;
                    yield return collection;
                }

        }



        [Test]
        public void Linq_MoreThan5_Test()
        {
            var list = TestData.ListSet1;

           var morethan5List = list.Where(x => x < 5).ToList();
        }

        [Test]
        public void EmptyList_Foreach_Test()
        {
            var emptyList = new MyList<int>();

            foreach (var item in emptyList)
            {
                Assert.Fail();
            }            
        }

        [Test]
        public void CheckOne_Foreach_Test()
        {
            var eList = new MyList<int> { 99};            

            foreach (var item in eList)
            {
                item.Should().Be(99);
            }
        }

        [Test]
        public void CheckLast_Foreach_Test()
        {
            var fList = new MyList<int> { 99, 77, 55, 44 , 8, 88};          

            fList.Last().Should().Be(88);
            fList.ToList().Count().Should().Be(6);

            int counter = 0;

            foreach (var item in fList)
            {                
                counter++;

                if (counter == fList.Count)
                {
                    item.Should().Be(88);
                }
            }
        }

        [Test]
        public void Enumerator_Test()
        {
            var list = TestData.ListSet1;

            var enumer =  list.GetEnumerator();
            
            enumer.MoveNext();
            enumer.Current.Should().Be(1);
            enumer.MoveNext();
            enumer.Current.Should().Be(7);
            enumer.MoveNext();
            enumer.Current.Should().Be(21);
            enumer.MoveNext();

            int i = enumer.Current;

            
        }

        [Test]        
        public void Reverse_Test()
        {
            var list = TestData.ListSet1;

            foreach (var item in list.GetReverse())
            {
                Console.WriteLine(item);
            }
        }


        [Test]
        [TestCaseSource(nameof(IList_1to5_Test_TestCases))]
        public void IndexOf_NoData_Test(IList<int> list)
        {
            list = TestData.ListSet1;            

            list.IndexOf(99).Should().Be(-1);
        }

        [Test]
        [TestCaseSource(nameof(IList_1to5_Test_TestCases))]
        public void Insert_Test(IList<int> list)
        {
            list.IndexOf(3).Should().Be(2);

            list.Insert(1, 5);

            list.IndexOf(5).Should().Be(1);
        }

        [Test]
        [TestCaseSource(nameof(IList_1to5_Test_TestCases))]
        public void Remove_Test(IList<int> list)
        {           

            list.IndexOf(3).Should().Be(2);

            list.Remove(3);

            list.IndexOf(3).Should().Be(-1);
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
            var dlist = new DLinkedList<int>();
            dlist.Add(1);
            dlist.Add(-1);
            dlist.Add(2);
            
            int counter = 0;

            foreach (var item in dlist.Reverse())
            {
                counter++;
                Console.WriteLine($"foreach {item}");
            }

            counter.Should().Be(dlist.Count);            
        }
        
        [Test]
        public void Remove_DList_Test()
        {
            var dlist = new DLinkedList<int>();
            dlist.Add(4);
            dlist.Add(1);
            dlist.Add(-1);
            dlist.Add(2);            ;

            dlist.Remove(1);

            dlist.Count().Should().Be(3);

            foreach (var item in dlist)
            {                
                Console.WriteLine(item);
            }
        }

        [Test]
        public void IndexOf_DList_Test()
        {
            var dlist = new DLinkedList<int>();           

            dlist.Add(4);
            dlist.Add(1);
            dlist.Add(-1);
            dlist.Add(2);            

            dlist.IndexOf(-1).Should().Be(2);
        }

        [Test]
        public void CopyTo_DList_Test()
        {
            int[] arr = new int[20] ;

            var list = new DLinkedList<int>() { 7, 8, 9, 10};

            list.CopyTo(arr, 5);
            
            arr[5].Should().Be(7);
        }

        [Test]
        public void Contains_DList_Test()
        {
            var list = new DLinkedList<int> { 1, 2, 3, };

            list.Contains(2).Should().Be(true);
        }

        [Test]
        public void t()
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
