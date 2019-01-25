using System;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
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
            
            Console.WriteLine("Enter a delivery partner...");
            var deliveryPartner = Console.ReadLine();
            
            Console.WriteLine("Enter an effective date year...");
            var year = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter an effective date month...");
            var month = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Enter an effective date day...");
            var day = int.Parse(Console.ReadLine());

            var result = dataAccess.Query(deliveryPartner, new DateTime(year, month, day));
            
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.ReadKey();
        }
    }
}