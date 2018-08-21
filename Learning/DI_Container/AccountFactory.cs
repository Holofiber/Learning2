using System.Diagnostics;
using Autofac;
using Autofac.Core;

namespace DI_Container
{
    public class AccountFactory
    {
        private readonly ILogger logger;
        private readonly IValidator validator;
        private readonly ILifetimeScope scope;



        public AccountFactory(ILogger logger, IValidator validator, ILifetimeScope scope)
        {
            this.logger = logger;
            this.validator = validator;
            this.scope = scope;

            Debug.WriteLine($"{nameof(AccountFactory)} created");
        }


        public Account Create()
        {

            return scope.Resolve<Account>();
        }
    }
}