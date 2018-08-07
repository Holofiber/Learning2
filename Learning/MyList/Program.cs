using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> lis = new MyList<int>() { 1, 2, 3, 4, 5 };

            foreach (int li in lis)
            {
                Console.WriteLine(li);
            }

            foreach (int li in lis.GetEnumeratorReverse())
            {
                Console.WriteLine(li);
            }


            /*List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            var t = list.IndexOf(3);

            string[] sArray = new string[10];

            List<string> stringList = new List<string>() { "a", "sad0", "sa" };
            stringList.CopyTo(sArray);

            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }*/

            new Run().AddToList();
        }
    }
}
