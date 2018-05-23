using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NlogTest
{
    class Program
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            //日志消息也可以被参数化 - 你可以使用字符串格式，就像你在Console.WriteLine()和String.Format()中一样.但应尽量避免，说明：https://blog.csdn.net/Toshiya14/article/details/52098088
            //string log = string.Format("说明：LMS-Cloud事件订阅 处理接收消息执行异常<br/><br/>异常：{0}<br/><br/>详细：{1}<br/><br/>数据：{2}", ex.Message, ex.StackTrace, e?.Data);
            string log1 = string.Format("This is a Trace message");
            string log2 = string.Format("This is a Error message");
            string log3 = string.Format("This is a Fatal error message");
            //因为只设置了一条路由规则，minlevel="Debug"，所以下面的logger.Trace(log)是不会记录的
            logger.Trace(log1);
            logger.Error(log2);
            //logger.Fatal(log3);
            //Console.WriteLine(log);
            Console.ReadKey();
        }
    }
}
