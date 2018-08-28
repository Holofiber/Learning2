using Module1.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Autofac;
using Prism.Autofac;

namespace Module1
{
    public class Module1Module : IModule
    {
        private IRegionManager _regionManager;
        private ContainerBuilder _builder;

        public Module1Module(ContainerBuilder builder, IRegionManager regionManager)
        {
            _builder = builder;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _builder.RegisterTypeForNavigation<ViewA>();
        }
    }
}