using CardGameEngine.Decks;
using Microsoft.Extensions.DependencyInjection;

namespace CardGameEngine.Configuration
{
    public static class ConfigurationExtensions
    {
        public static void ConfigureCardGameEngineDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IDeckGenerator, StandardDeckGenerator>();
            serviceCollection.AddTransient<IDeckGenerator, ExtendedDeckGenerator>();
            serviceCollection.AddTransient<IDeckFactory, DeckFactory>();
        }
    }
}
