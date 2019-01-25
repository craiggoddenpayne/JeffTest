using Microsoft.Extensions.DependencyInjection;
using TechTest.Services;

namespace TechTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            Ioc.Initialise(services);
            var dataAccess =  Ioc.ServiceProvider.GetService<IDataAccess>();
        }
    }
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            BuildWebHost(args).Run();
//        }
//
//        private static IWebHost BuildWebHost(string[] args) =>
//            WebHost.CreateDefaultBuilder(args)
//                .UseStartup<Startup>()
//                .UseContentRoot(Directory.GetCurrentDirectory())
//                .Build();
//    }
}