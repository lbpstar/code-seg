using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutoFacDemo2
{
    //原文：http://www.cnblogs.com/kissdodog/p/3611447.html
    //http://www.cnblogs.com/kissdodog/p/3611799.html
    class Program
    {
        static void Main(string[] args)
        {
            ContainerBuilder builder = new ContainerBuilder();
            //类型创建RegisterType
            //builder.RegisterType<AutoFacManager>();
            //实例创建
            // builder.RegisterInstance<AutoFacManager>(new AutoFacManager(new Worker()));
            //Lambda表达式创建
            //builder.Register(c => new AutoFacManager(c.Resolve<IPerson>()));
            //程序集创建
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()); //在当前正在运行的程序集中找
            builder.RegisterType<Worker>().As<IPerson>();//as用来处理接口和类的映射
            //builder.RegisterType<Student>().As<IPerson>();//as用来处理接口和类的映射
            using (IContainer container = builder.Build())
            {
                AutoFacManager manager = container.Resolve<AutoFacManager>();
                manager.Say();
            }

            Console.ReadKey();
        }
        public interface IPerson
        {
            void Say();
        }

        public class Worker : IPerson
        {
            public void Say()
            {
                Console.WriteLine("我是一个工人！");
            }
        }

        public class Student : IPerson
        {
            public void Say()
            {
                Console.WriteLine("我是一个学生！");
            }
        }

        public class AutoFacManager
        {
            IPerson person;

            public AutoFacManager(IPerson MyPerson)
            {
                person = MyPerson;
            }

            public void Say()
            {
                person.Say();
            }
        }
    }
}
