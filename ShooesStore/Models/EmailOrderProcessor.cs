using ShooesStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace ShooesStore.Models
{
    public class EmailSettings
    {
        public string MailToAdress = "orders@example.com";
        public string MailFromAdress = "bookstore@example.com";
        public bool UseSsl = true;
        public string UserName = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = true;
        public string FileLocation = @"c:\book_store_emails";

    }

    public class EmailOrderProcessor : IOrderProcessor
    {
        private EmailSettings emailSettings;
        public EmailOrderProcessor(EmailSettings settings)
        {
            emailSettings = settings;
        }

        public void ProcessOrder(Cart cart, ShippingDetails shipingDetails)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailSettings.UseSsl;
                smtpClient.Host = emailSettings.ServerName;
                smtpClient.Port = emailSettings.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(emailSettings.UserName, emailSettings.Password);
                if (emailSettings.WriteAsFile)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailSettings.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder()
                    .AppendLine("Новый заказ обработан")
                    .AppendLine("---")
                    .AppendLine("Товары:");

                foreach (var line in cart.Lines)
                {
                    var subTotal = line.Shoes.Price * line.Quantity;
                    body.AppendFormat("{0} x {1} (итого: {2:c})", line.Quantity, line.Shoes.NameShoes, subTotal);

                }

                body.AppendFormat("Общая стоимость: {0:c}", cart.ComputeTotalValue())
                    .AppendLine("---")
                    .AppendLine("Доствка:")
                    .AppendLine(shipingDetails.Name)
                    .AppendLine(shipingDetails.Line1)
                    .AppendLine(shipingDetails.Line2 ?? "")
                    .AppendLine(shipingDetails.Line2 ?? "")
                    .AppendLine(shipingDetails.City)
                    .AppendLine(shipingDetails.Country)
                    .AppendLine("---");

                MailMessage mailMessage = new MailMessage(
                    emailSettings.MailFromAdress,
                    emailSettings.MailToAdress,
                    "Новый заказ отправлен!", body.ToString()
                    );
                if (emailSettings.WriteAsFile)
                {
                    mailMessage.BodyEncoding = Encoding.UTF8;

                }
                smtpClient.Send(mailMessage);

            }

        }
    }
}