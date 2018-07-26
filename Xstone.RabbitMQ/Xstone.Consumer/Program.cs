using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xstone.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderProcessMessage order = new OrderProcessMessage();
            MQ.MyMessage msg = new MQ.MyMessage();
            //不赋值messageid试试，按道理接受消息应该只要MessageRouter就可以
            // msg.MessageID = "1";
            msg.MessageRouter = "order.notice.lisi";

            MQ.MQHelper.Subscribe(msg, order);

            Console.WriteLine("Listening for messages.");
        }
    }
}
