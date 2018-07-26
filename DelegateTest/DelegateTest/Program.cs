using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateTest
{
    //https://blog.csdn.net/fdsa123456/article/details/3877678

    //新建的GreetingManager类
    public class GreetingManager
    {
        //定义委托，它定义了可以代表的方法的类型
        public delegate void GreetingDelegate(string name);
        ////在GreetingManager类的内部声明delegate1变量
        //public GreetingDelegate delegate1;
        //这一次我们在这里声明一个事件
        public event GreetingDelegate MakeGreet;
        public void GreetPeople(string name, GreetingDelegate MakeGreeting)
        {
            MakeGreeting(name);
        }
        public void Greet(string name)
        {
            //if (MakeGreet != null)
            // {       //如果有对象注册
            //    MakeGreet(name);       //调用所有注册对象的方法
            // }
            MakeGreet?.Invoke(name);//简化上面的写法
        }
    }
    class Program
    {

        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }

        //注意此方法，它接受一个GreetingDelegate类型的方法作为参数
        //private static void GreetPeople(string name, GreetingDelegate MakeGreeting)
        //{
        //    MakeGreeting(name);
        //}
        static void Main(string[] args)
        {
            GreetingManager gm = new GreetingManager();
            gm.MakeGreet += EnglishGreeting;
            gm.MakeGreet += ChineseGreeting;
            //gm.MakeGreet("Jimmy Zhang");//这样会出错，原因文中有详细解释：这次，你会得到编译错误：事件“Delegate.GreetingManager.MakeGreet”只能出现在 += 或 -= 的左边(从类型“Delegate.GreetingManager”中使用时除外)……
            gm.Greet("Jimmy Zhang");
            Console.ReadKey();
        }
    }
    //// 热水器
    //public class Heater
    //{
    //    private int temperature;
    //    public delegate void BoilHandler(int param);       //声明委托
    //    public event BoilHandler BoilEvent;                     //声明事件 

    //    // 烧水
    //    public void BoilWater()
    //    {
    //        for (int i = 0; i <= 100; i++)
    //        {
    //            temperature = i;

    //                        if (temperature > 95)
    //            {
    //                if (BoilEvent != null)
    //                {       //如果有对象注册
    //                    BoilEvent(temperature);       //调用所有注册对象的方法
    //                }
    //            }
    //        }
    //    }
    //}
    //// 警报器
    //public class Alarm
    //{
    //    public void MakeAlert(int param)
    //    {
    //        Console.WriteLine("Alarm：嘀嘀嘀，水已经 {0}度了：", param);
    //    }
    //}

    //// 显示器
    //public class Display
    //{
    //    public static void ShowMsg(int param)
    //    {       //静态方法
    //        Console.WriteLine("Display：水快烧开了，当前温度：{0}度。", param);
    //    }
    //}

    //class Program
    //{
    //    static void Main()
    //    {
    //        Heater heater = new Heater();
    //        Alarm alarm = new Alarm();
    //        heater.BoilEvent += alarm.MakeAlert;       //注册方法
    //        heater.BoilEvent += (new Alarm()).MakeAlert;       //给匿名对象注册方法
    //        heater.BoilEvent += Display.ShowMsg;              //注册静态方法 .

    //        heater.BoilWater();       //烧水，会自动调用注册过对象的方法
    //        Console.ReadKey();
    //    }
    //}
}
