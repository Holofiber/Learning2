namespace DI_Container
{
    public interface ILogger
    {
        void Log(string msg);
    }

    public class FileLogger : ILogger
    {
        public void Log(string msg)
        {

        }
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string msg)
        {

        }
    }

}