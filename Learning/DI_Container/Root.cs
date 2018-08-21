using System.Reflection;
using Autofac;

namespace DI_Container
{
    public class Root
    {
        private readonly MainBusinessLogic businessLogic;
        private readonly Executor executor;
        private ILogger logger;

        public ContainerBuilder builder = new ContainerBuilder();

        public Root()
        {
            logger = new ConsoleLogger();

            builder.RegisterInstance(new DateValidator()).As<IValidator>();
            builder.RegisterInstance(logger).As<ILogger>();


           /* builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(Root)))
                .Where(t => t.Name.EndsWith("Account")).AsImplementedInterfaces();*/

            var container = builder.Build();

            IValidator validator = new DateValidator();
            this.businessLogic = new MainBusinessLogic(logger);

            var accountFactory = new AccountFactory();

            var accountManager = new AccountManager(logger, accountFactory);

            this.executor = new Executor(logger, accountManager);
        }

        public void Run()
        {
            businessLogic.Start();
            executor.Start();
        }
    }
}