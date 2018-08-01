using System;
using System.Collections.Generic;
using MyList;

namespace MyListDemo
{
    public class Run
    {
        MyList<int> list = new MyList<int>();

        public void AddToList()
        {


            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);

            

            foreach (int node in list)
            {
                Console.WriteLine(node);
            }

           
        }
    }


}