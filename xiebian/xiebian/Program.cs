using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//http://www.cnblogs.com/dennys/archive/2013/11/03/3405359.html
//https://www.cnblogs.com/HopeGi/p/3536587.html
namespace xiebian
{
    class Father { }
    class Son : Father { }
    class Program
    {
        public delegate void mydelege1(Father f);

        public delegate void mydelege2(Son s);

        static void fun1(Father s)

        { }

        static void fun2(Son s)

        { }
        static void Main(string[] args)
        {
            Father f = new Father();

            Son s = new Son();

            f = s;//ok，儿子可以赋值给父亲
            s = f;//父亲不可以赋值给儿子

            mydelege1 md1 = fun2;//error,输入参数不支持协变，儿子类型的方法不能赋值给父亲类型的委托

            mydelege2 md2 = fun1;//ok，父亲类型的方法可以赋值给儿子类型的委托，逆变了。      
        }
    }
}
