using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            string smtpHost = "smtp.hytera.com";
            int port = 25;
            string from = "publicpostman@hytera.com";
            string password = "publicpostman";

            string subject = "大疆接口故障";
            string body = "邮件测试";
            string to = "baoping.liu@hytera.com";

            EmailSender sender = new SendEmail.EmailSender(smtpHost, port, from, password);
            sender.SendMail(subject,body,false,to);
            Console.ReadKey();
        }
    }
}
