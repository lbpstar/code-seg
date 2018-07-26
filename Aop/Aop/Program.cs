using Castle.Core.Interceptor;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyGenerator generator = new ProxyGenerator();
            var test = generator.CreateClassProxy<TestA>(new TestInterceptor());
            Console.WriteLine($"GetResult:{test.GetResult(Console.ReadLine())}");//在控制台键入参数
            Console.ReadKey();
        }
    }

    public class TestInterceptor : StandardInterceptor
    {

        protected override void PreProceed(IInvocation invocation)
        {
            Console.WriteLine(invocation.Method.Name + "执行前,入参：" + string.Join(",", invocation.Arguments));
        }

        protected override void PerformProceed(IInvocation invocation)
        {
            Console.WriteLine(invocation.Method.Name + "执行中");

                base.PerformProceed(invocation);
        }

        protected override void PostProceed(IInvocation invocation)
        {
            Console.WriteLine(invocation.Method.Name + "执行后，返回值：" + invocation.ReturnValue);
        }

    }

    public class TestA
    {
        public virtual string GetResult(string msg)
        {
            string str = $"{DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss")}---{msg}";
            return str;
        }
    }
}
