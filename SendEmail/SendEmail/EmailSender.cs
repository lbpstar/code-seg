using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace SendEmail
{
    class EmailSender
    {
        MailMessage message = new MailMessage();
        SmtpClient smtp;
        bool m_enableSsl;

        public bool EnableSsl
        {
            set
            {
                m_enableSsl = value;
            }
        }
        public EmailSender(string host, int port, string fromMail, string pwd)
        {
            smtp = new SmtpClient(host, port);
            smtp.Credentials = new NetworkCredential(fromMail, pwd);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            message.From = new MailAddress(fromMail);
        }
        public void SendMail(string subject, string body, bool isHtml, string toMail)
        {
            message.To.Clear();
            message.To.Add(new MailAddress(toMail));
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = isHtml;
            smtp.EnableSsl = m_enableSsl;

            smtp.Send(message);
        }
    }
}
