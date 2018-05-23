using System;
using System.Configuration;
using EasyNetQ;

namespace Weiz.MQ
{
    /// <summary>
    /// ��Ϣ������������
    /// </summary>
    public class BusBuilder
    {
        public static IBus CreateMessageBus()
        {
            // ��Ϣ�����������ַ���
            // var connectionString = ConfigurationManager.ConnectionStrings["RabbitMQ"];
            string connString = "host=127.0.0.1:5672;virtualHost=Xstone;username=lbp;password=lbp";
            //string connString = "host=127.0.0.1:15672;virtualHost=Xstone;username=lbp;password=lbp";
            if (connString == null || connString == string.Empty)
            {
                throw new Exception("messageserver connection string is missing or empty");
            }
            
            return RabbitHutch.CreateBus(connString);
        }

       
    }

}