using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace IServiceCollectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection()
                 .AddSingleton<IFoobar, Foo>()
                 .AddSingleton<IFoobar, Bar>();
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            Console.WriteLine("serviceProvider.GetService<IFoobar>(): {0}", serviceProvider.GetService<IFoobar>());

            IEnumerable<IFoobar> services = serviceProvider.GetServices<IFoobar>();
            int index = 1;
            Console.WriteLine("serviceProvider.GetServices<IFoobar>():");
            foreach (IFoobar foobar in services)
            {
                Console.WriteLine("{0}: {1}", index++, foobar);
            }
            Console.ReadKey();
        }
        public interface IFoobar { }
        public class Foo : IFoobar { }
        public class Bar : IFoobar { }
    }
}
