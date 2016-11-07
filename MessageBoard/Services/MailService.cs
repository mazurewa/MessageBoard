using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace MessageBoard.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {
            try
            {
                var message = new MailMessage(from, to, subject, body);

                var client = new SmtpClient();
                client.Send(message);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}