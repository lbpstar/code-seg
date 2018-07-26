using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

//原文：https://www.jianshu.com/p/34d1a775acf3
//这篇不错：https://www.cnblogs.com/caoshiqing/p/6094693.html
namespace AutoFacDemo
{

        public interface IOutput
        {
            void Write(string content);
        }

        public class ConsoleOutput : IOutput
        {
            public void Write(string content)
            {
                Console.WriteLine(content);
            }
        }
        public interface IDateWriter
        {
            void WriteDate();
        }

        public class TodayWriter : IDateWriter
        {
            private IOutput _output;
            public TodayWriter(IOutput output)
            {
                this._output = output;
            }

            public void WriteDate()
            {
                this._output.Write(DateTime.Today.ToShortDateString());
            }
        }
        class Program
        {
            private static IContainer Container { get; set; }
            public static void WriteDate()
            {
                using (var scope = Container.BeginLifetimeScope())
                {
                    var writer = scope.Resolve<IDateWriter>();
                    writer.WriteDate();
                }
            }
            static void Main(string[] args)
            {

                var config = new ConfigurationBuilder();
                //autofac.json位置
                System.IO.DirectoryInfo topDir = System.IO.Directory.GetParent(System.Environment.CurrentDirectory);
                config.SetBasePath(topDir.Parent.FullName);
                config.AddJsonFile("autofac.json");
                // Register the ConfigurationModule with Autofac.
                var module = new ConfigurationModule(config.Build());

                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                Container = builder.Build();
                WriteDate();
                Console.Read();
            }
        }
    }
