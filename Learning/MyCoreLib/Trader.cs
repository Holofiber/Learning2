namespace MyCoreLib
{
    public class Trader
    {
        public string Name { get; set; }

        public double Balance { get; set; }

        public string Country { get; set; }

        public Dictionary<string, SubscriptionType> Subscriptions { get; set; }

         
    }

    

    [Flags]
    public enum SubscriptionType
    {
        Trades,
        Historical,
        LevelTwo
    }

    public class Subscription
    {

    }

    public class Name
    {

    }
    public class Balance
    {

    }
}