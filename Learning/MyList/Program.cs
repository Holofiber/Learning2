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
            List<int> list = new List<int>() { 1, 2, 3, 4, 5 };
            var t = list.IndexOf(3);

            string[] sArray = new string[10];

            List<string> stringList = new List<string>() { "a", "sad0", "sa" };
            stringList.CopyTo(sArray);

            foreach (string s in sArray)
            {
                Console.WriteLine(s);
            }

            new Run().AddToList();
        }
    }
}
