using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace DI_Container
{
    class Program
    {
        static IContainer container;

        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<ConsoleLogger>().As<ILogger>().SingleInstance();
            builder.RegisterType<DateValidator>().As<IValidator>().SingleInstance();

            builder.RegisterType<Root>().SingleInstance();
            builder.RegisterType<Executor>().SingleInstance();
            builder.RegisterType<AccountManager>().SingleInstance();
            builder.RegisterType<MainBusinessLogic>().SingleInstance();
            builder.RegisterType<AccountFactory>().SingleInstance();
            builder.RegisterType<InternalAccountChecker>().SingleInstance();


            builder.RegisterType<Account>();
            builder.RegisterType<InternalAccountChecker>();


            container = builder.Build();


            Root myApplication = container.Resolve<Root>();


            //-----------------------------------------------

            myApplication.Run();

            Console.ReadLine();
        }
    }
}