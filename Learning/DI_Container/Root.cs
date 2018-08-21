using System.Diagnostics;
using System.Reflection;
using Autofac;

namespace DI_Container
{
    public class Root
    {
        private readonly MainBusinessLogic businessLogic;
        private readonly Executor executor;
        private ILogger logger;



        public Root(MainBusinessLogic businessLogic, Executor executor, ILogger logger)
        {

            this.businessLogic = businessLogic;
            this.executor = executor;
            this.logger = logger;

            Debug.WriteLine("Root created");
        }

        public void Run()
        {
            businessLogic.Start();
            executor.Start();
        }
    }
}