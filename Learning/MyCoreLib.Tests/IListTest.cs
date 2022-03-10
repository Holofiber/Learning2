using NUnit.Framework;
using System.Collections.Generic;
using FluentAssertions;

namespace MyCoreLib.Tests
{
    internal class IListTest
    {       

        [Test]
        public void IndexOf_Test()
        {
            var list = TestData.ListSet1;

            list.IndexOf(21).Should().Be(2);

            list.IndexOf(99).Should().Be(-1);
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

        /* public void RemoveAt(int index)
         {
             throw new NotImplementedException();
         }

         public void Clear()
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
