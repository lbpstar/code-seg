using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFunction
{
    //测试泛型方法https://www.cnblogs.com/rinack/p/5676285.html
    class Program
    {
        static void Swap<T>(ref T lhs, ref T rhs)
        {
            T temp;
            temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public static void TestSwap()
        {
            int a = 1;
            int b = 2;

            Swap<int>(ref a, ref b);
            System.Console.WriteLine(a + " " + b);
        }
        //可以去掉where T : IComparable看看，则t只能使用object相关的方法
        static int Compare<T>(T i,  T j) where T : IComparable
        {
            return i.CompareTo(j);
        }
        //和下面的myclass一起测试泛型委托
        public static void GenericMethodDemo()
        {
            MyClass<int> obj = new MyClass<int>();
            MyClass<int>.GenericDelegate del;
            del = new MyClass<int>.GenericDelegate(obj.SomeMethod);
            del(3);
        }
        static void Main(string[] args)
        {
            TestSwap();
            System.Console.WriteLine(Compare(2, 2));//测试where约束
            GenericMethodDemo();//测试泛型委托
            Console.ReadKey();
        }
    }
    //泛型委托
    public class MyClass<T>
    {
        public delegate void GenericDelegate(T t);
        public void SomeMethod(T t)
        {
            System.Console.WriteLine(t);
        }
    }
    
}
