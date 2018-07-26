using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskDemo
{
    //http://www.cnblogs.com/sorex/archive/2010/09/18/1830130.html
    class Program
    {
        static void Main(string[] args)
        {
            Demo7();
        }
        /// <summary>
        /// Task简单使用
        /// </summary>
        private static void Demo1()
        {
            int i = 0;
            Random r = new Random(DateTime.Now.Second);
            Task t = new Task(() =>
            {
                for (int v = 0; v < 100; v++)
                    i += r.Next(100);
            });
            t.Start();
            t.Wait();
            Console.WriteLine("这是执行Task1后等待完成：" + i.ToString());
            Console.ReadLine();
        }
        /// <summary>
        /// Task带返回值
        /// </summary>
        private static void Demo2()
        {
            Random r = new Random(DateTime.Now.Second);
            Task<int> t = new Task<int>(() =>
            {
                int i = 0;
                for (int v = 0; v < 100; v++)
                    i += r.Next(100);
                return i;
            });
            t.Start();
            Console.WriteLine("这是执行Task1获取返回值：" + t.Result.ToString());
            Console.ReadLine();
        }
        /// <summary>
        /// Task 执行完毕后调用另一个Task
        /// </summary>
        private static void Demo3()
        {
            Random r = new Random(DateTime.Now.Second);
            Task<int> t = new Task<int>(() =>
            {
                int i = 0;
                for (int v = 0; v < 100; v++)
                    i += r.Next(100);
                return i;
            });
            t.ContinueWith((Task<int> task) =>   //这里task传递的是上一个task实例
            {
                Console.WriteLine("这是执行完毕Task1后继续调用Task2：" + task.Result.ToString());
            });
            t.Start();
            Console.ReadLine();
        }
        /// <summary>
        /// Task 执行完毕后调用另一个Task(链式写法)
        /// </summary>
        private static void Demo4()
        {
            Random r = new Random(DateTime.Now.Second);
            Task<int> t = new Task<int>(() =>
            {
                int i = 0;
                for (int v = 0; v < 100; v++)
                    i += r.Next(100);
                return i;
            });

            Task t2 = t.ContinueWith((Task<int> task) =>
            {
                Console.WriteLine(task.Result.ToString());
            });

            t2.ContinueWith(task =>
            {
                Console.WriteLine("这是执行完毕Task1后继续调用Task2，Task2后调用Task3。");
            });
            t.Start();
            Console.ReadLine();
        }
        /// <summary>
        /// 带有父子关系的Task集合，[TaskCreationOptions.AttachedToParent]
        ///
        /// 值                说明
        /// None              默认值，此Task会被排入Local Queue中等待执行，采用LIFO模式。
        /// AttachedToParent  建立的Task必须是外围的Task的子Task，也是放入Local Queue，採LIFO模式。
        /// LongRunning       建立的Task不受Thread Pool所管理，直接新增一个Thread来执行此Task，无等待、无排程。
        /// PreferFairness    建立的Task直接放入Global Queue中，採FIFO模式。(比上面的优先级低)
        /// </summary>
        private static void Demo5()
        {
            Task<int> t = new Task<int>(() =>
            {
                Task<int> t1 = new Task<int>(() =>
                {
                    int i = 0;
                    Random r = new Random(DateTime.Now.Second);
                    for (int v = 0; v < 100; v++)
                        i += r.Next(100);
                    return i;
                }, TaskCreationOptions.AttachedToParent);

                Task<int> t2 = new Task<int>(() =>
                {
                    int i = 0;
                    Random r = new Random(DateTime.Now.Second);
                    for (int v = 0; v < 100; v++)
                        i += r.Next(100);
                    return i;
                }, TaskCreationOptions.AttachedToParent);
                Task<int> t3 = new Task<int>(() =>
                {
                    int i = 0;
                    Random r = new Random(DateTime.Now.Second);
                    for (int v = 0; v < 100; v++)
                        i += r.Next(100);
                    return i;
                }, TaskCreationOptions.AttachedToParent);
                t1.Start();
                t2.Start();
                t3.Start();
                return t1.Result + t2.Result + t3.Result;
            });

            t.Start();
            t.Wait();

            Console.WriteLine("这是带有父子关系的Task集合：" + t.Result.ToString());
            Console.ReadLine();
        }
        /// <summary>
        /// 中途取消Task执行，Token
        ///
        /// 一是正常结束、二是产生例外、三是透过Cancel机制，这三种情况都会反映在Task.Status属性上
        /// 值                              说明
        /// Created                         Task已经建立，但未呼叫Start。
        /// WaitingForActivation            Task已排入排程，但尚未执行(一般我们建立的Task不会有此状态，只有ContinueWith所产生的Task才会有此状态)。
        /// WaitingToRun                    Task已排入排程，等待执行中。
        /// Running                         Task执行中。
        /// WaitingForChildrenToComplete    Task正等待子Task結束。
        /// RanToCompletion                 Task已经正常执行完毕。
        /// Canceled                        Task已被取消。
        /// Faulted                         Task执行中发生未预期例外。
        ///
        /// 除了Status属性外，Task还提供了另外三个属性来判定Task状态。
        /// 属性            说明
        /// IsCompleted     Task已经正常执行完毕。
        /// IsFaulted       Task执行中法生未预期例外。
        /// IsCanceled      Task已被取消。
        /// </summary>
        private static void Demo6()
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            var ctoken = cts.Token;
            Task t1 = new Task(() =>
            {
                for (int v = 0; v < 10; v++)
                {
                    if (ctoken.IsCancellationRequested)
                    {
                        //第一种写法
                        //这个会抛出异常
                        ctoken.ThrowIfCancellationRequested();
                        //另一种写法
                        //这个不会返回异常，但是获取不到是否是中断还是执行完毕。
                        //return;
                    }
                    Thread.Sleep(1000);
                    Console.WriteLine(v);
                }
            }, ctoken);
            t1.Start();
            Thread.Sleep(2000);
            cts.Cancel();
            try
            {
                t1.Wait();
            }
            catch
            {
                if (t1.IsCanceled)
                    Console.WriteLine("cancel");
            }
            Console.ReadLine();
            cts.Dispose();
        }
        /// <summary>
        /// Task.Factory
        /// ContinueWhenAny和ContinueWhenAll
        /// ContinueWhenAll所指定的函式会在传入的所有Tasks结束时执行，只会执行一次。
        /// ContinueWhenAny所指定的函式会在传入的Tasks中有任何一个结束时执行，且与ContinueWhenAll相同，只会执行一次。
        /// </summary>
        private static void Demo7()
        {
            Task<int> t1 = Task.Factory.StartNew<int>(() =>
            {
                int total = 0;
                for (int i = 0; i < 10; i++)
                    total += i;
                Thread.Sleep(9000);
                return total;
            });
            Task<int> t2 = Task.Factory.StartNew<int>(() =>
            {
                int total = 0;
                for (int i = 10; i < 20; i++)
                    total += i;
                Thread.Sleep(10000);
                return total;
            });
            Task tfinal = Task.Factory.ContinueWhenAny<int>(
                         new Task<int>[] { t1, t2 }, (Task<int> task) =>//这里参数task应该是先完成执行的task
                         {
                             if (task.Status == TaskStatus.RanToCompletion)
                             {
                                 Console.WriteLine(task.Result);
                             }
                         });
            Console.ReadLine();
        }
    }
}
