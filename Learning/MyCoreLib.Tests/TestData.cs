namespace MyCoreLib.Tests
{
    public static class TestData
    {
        public static MyList<int> ListSet1 { get 
            {
                var myList = new MyList<int>();
                myList.Add(1);
                myList.Add(7);
                myList.Add(21);
                myList.Add(4);
                myList.Add(0);
                myList.Add(7);
                myList.Add(11);
                myList.Add(4577);
                myList.Add(67);
                myList.Add(34);
                return myList;
            } }  
    }
}