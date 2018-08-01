using System;
using System.Collections.Generic;
using MyList;

namespace MyListDemo
{
    public class Run
    {
        MyList<double> list = new MyList<double>();

        public void AddToList()
        {


            list.Add(10.3);
            list.Add(11.54);
            list.Add(12);
            list.Add(13.1);
            

            

            foreach (double node in list)
            {
                Console.WriteLine(node);
            }

           
        }
    }


}