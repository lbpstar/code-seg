using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xstone.MQ
{
    public class MyMessage
    {
        public string MessageID { get; set; }

        public string MessageTitle { get; set; }

        public string MessageBody { get; set; }

        public string MessageRouter { get; set; }
    }
}
