using System.Diagnostics;

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
        public ConsoleLogger()
        {
            Debug.WriteLine("ConsoleLogger Created");
        }
        public void Log(string msg)
        {

        }
    }

}