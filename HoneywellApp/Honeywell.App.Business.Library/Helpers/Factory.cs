using Autofac;
using Honeywell.App.Business.Library.Implementations;
using Honeywell.App.Business.Library.Interfaces;

namespace Honeywell.App.Business.Library.Helpers
{
    public static class Factory
    {
        public static IContainer ConfigureApp() 
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<TimeConverter>().As<ITimeConverter>();
            builder.RegisterType<StringChecker>().As<IStringChecker>();

            return builder.Build();
        }
    }
}
