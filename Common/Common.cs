﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace WebBanHang.Common
{
    public class Common
    {
        private static string password = ConfigurationManager.AppSettings["Password"];
        private static string Email = ConfigurationManager.AppSettings["Email"];

        public static bool SendMail( string name, string subject, string content, string toMail)
        {
            bool rs = false;
            try
            {
                MailMessage message = new MailMessage();
                var smtp = new System.Net.Mail.SmtpClient();
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(Email, password);
                    smtp.Timeout = 20000;
                }
                MailAddress fromAddress = new MailAddress(Email, name);
                message.From = fromAddress;
                message.To.Add(toMail);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = content;

                smtp.Send(message);
                rs = true;
            }
            catch(Exception)
            {
                rs = false;
            }
            return rs;

             
        }
        //public static string FormatNumber(object value, int SoSauDauPhay = 2)
        //{

        //}
    }
}