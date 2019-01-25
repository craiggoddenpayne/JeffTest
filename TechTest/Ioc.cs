using Microsoft.Extensions.DependencyInjection;
using TechTest.Parsers;
using TechTest.Services;

namespace TechTest
{
    public static class Ioc
    {
        public static ServiceProvider ServiceProvider { get; set; }
        public static void Initialise(IServiceCollection services)
        {
            services
                .AddScoped<IDataAccess, DataAccess>()
                .AddScoped<IFileLoader, FileLoader>()
                .AddScoped<IMusicContractsParser, MusicContractsParser>()
                .AddScoped<IDistributionPartnerContractsParser, DistributionPartnerContractsParser>();
            
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}