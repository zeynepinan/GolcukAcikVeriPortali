using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace acikveriportal.Models.Entity
{
    public class Mail
    {
        public static void MailSender(string body)
        {
            var fromAddress = new MailAddress("zeynp.inan3269@gmail.com");
            var toAddress = new MailAddress("zeynp.inan3269@gmail.com");
            const string subject = "GÖLCÜK| Sitenizden Gelen İletişim Formu";
            using (var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "zeynep3269")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
                {
                    smtp.Send(message);
                }
            }
        }
    }
}