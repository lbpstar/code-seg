using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xstone.Consumer
{
    public class OrderProcessMessage : MQ.IProcessMessage
    {
        public void ProcessMsg(MQ.MyMessage msg)
        {
            Console.WriteLine(msg.MessageBody);
        }
    }
}
