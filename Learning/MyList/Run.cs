using System;

namespace MyListDemo
{
    public class Run
    {
        MyList list = new MyList();

        public void AddToList()
        {


            list.Add(10);
            list.Add(11);
            list.Add(12);
            list.Add(13);

            foreach (var i in list)
            {
                Console.WriteLine(i);
            }


        }
    }


}