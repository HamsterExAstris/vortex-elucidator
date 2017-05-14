using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using StructureMap;

namespace ShatteredTemple.StructureMap
{
    public static class StructureMapIOptionsExtensions
    {
        public static Registry RegisterOptions<TOptions>(this Registry registry)
            where TOptions : class
        {
            if (registry == null)
            {
                throw new ArgumentNullException(nameof(registry));
            }

            registry.For<IOptionsChangeTokenSource<TOptions>>()
                .Use(e => GetOptionsChangeTokenSource<TOptions>(e))
                .Singleton();

            registry.For<IConfigureOptions<TOptions>>()
                .Use(e => GetConfigureOptions<TOptions>(e))
                .Singleton();

            return registry;
        }

        private static IConfigureOptions<TOptions> GetConfigureOptions<TOptions>(IContext context)
            where TOptions : class
        {
            var config = context.GetInstance<IConfigurationRoot>();
            return new ConfigureFromConfigurationOptions<TOptions>(config);
        }

        private static IOptionsChangeTokenSource<TOptions> GetOptionsChangeTokenSource<TOptions>(IContext context)
            where TOptions : class
        {
            var config = context.GetInstance<IConfigurationRoot>();
            return new ConfigurationChangeTokenSource<TOptions>(config);
        }
    }
}
