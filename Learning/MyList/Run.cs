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
            list.Add(13.5);

            double[] zzz = new double[3];
            
            list.CopyTo(zzz, zzz.Length);

            List<int> www = new List<int>(){1,2,3,4};

            foreach (int i in www)
            {
                
            }
            

            foreach (double node in list)
            {
                Console.WriteLine(node);
            }

           
        }
    }


}