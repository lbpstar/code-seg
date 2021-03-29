using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace CastleTest
{
    public class Dog
    {
        public virtual void Bark()
        {
            Console.WriteLine("wang wang wang!!!");
        }
        //注：此方法不会被拦截。因为此方法不能被重写。
        public void Eat()
        {
            Console.WriteLine("mia mia mia!!!");
        }
    }

    public class DogInterceptor : StandardInterceptor
    {
        string _arg;
        public DogInterceptor(string arg)
        {
            _arg = arg;
        }
        //protected override void PreProceed(IInvocation invocation)
        //{
        //    //Console.WriteLine("在进入拦截的方法之前调用。" + invocation.Method.Name);
        //    //base.PreProceed(invocation);
        //    if (true)
        //    {
        //        Console.WriteLine("没有权限");
        //    }
        //}

        protected override void PerformProceed(IInvocation invocation)
        {
            //Console.WriteLine("在进入拦截的方法返回时调用。" + invocation.Method.Name);
            //base.PerformProceed(invocation);
            if (_arg == "no")
            {
                Console.WriteLine("没有权限");
            }
            else
            {
                base.PerformProceed(invocation);
            }
        }

        //protected override void PostProceed(IInvocation invocation)
        //{
        //    Console.WriteLine("在进入拦截的方法运行完成后调用。" + invocation.Method.Name);
        //    base.PostProceed(invocation);
        //}

    }
    class Program
    {
        static void Main(string[] args)
        {
            ProxyGenerator generator = new ProxyGenerator();
            DogInterceptor interceptor = new DogInterceptor("yes");

            Dog dog = generator.CreateClassProxy<Dog>(interceptor);
            dog.Bark();
            Console.WriteLine();

            //dog.Eat();
            Console.ReadKey();
        }
    }
}
