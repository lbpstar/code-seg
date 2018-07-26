using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLinq
{
    class Program
    {
        //原文:https://www.cnblogs.com/dotnet261010/p/8278793.html
        static void Main(string[] args)
        {
            //// 查询出数组中的奇数并排序
            //int[] ints = { 5, 2, 0, 66, 4, 32, 7, 1 };
            ////本人注：下面的写法根本不是linq表达式，而是点标记，具体区别参考https://www.cnblogs.com/zhaopei/p/5746414.html
            //// 使用LINQ和Lambda表达式查询数组中的偶数
            //int[] intEvens = ints.Where(p => p % 2 == 0).ToArray();
            //// 使用LINQ和Lambda表达式查询数组中的奇数
            //int[] intOdds = ints.Where(p => p % 2 != 0).ToArray();

            //// 输出
            //Console.WriteLine("偶数：" + string.Join(",", intEvens));
            //Console.WriteLine("奇数：" + string.Join(",", intOdds));

            //Console.ReadKey();

            //本人注：改写成linq
            // 查询出数组中的奇数并排序
            int[] ints = { 5, 2, 0, 66, 4, 32, 7, 1 };
            // 使用LINQ和Lambda表达式查询数组中的偶数

            var i = from s in ints
                    where  s % 2 == 0
                    select s;

            // 输出
            Console.WriteLine("偶数：" + string.Join(",", i.ToArray()));
            Console.ReadKey();

        }
    }
}
