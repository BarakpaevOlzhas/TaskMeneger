using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TaskMeneger
{
    public class TaskAction
    {
        private Task task;

        public TaskAction(Task taskTwo)
        {
            task = taskTwo;
        }

        public void SendMessages()
        {
            var fromAddress = new MailAddress("olzhas.barakpaev@gmail.com");
            var toAddress = new MailAddress("olzhas.barakpaev@gmail.com");
            const string fromPassword = "titivi032312";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            smtp.EnableSsl = true;
            using (var message = new MailMessage(fromAddress, toAddress)
            { Subject = task.HeadMessage, Body = task.BodyMessage })
            {
                smtp.Send(message);
            }
        }

        public void DownloadFile()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(task.FromDownloadPath, task.NameFile);
            }
        }

        public void MoveCaralog()
        {
            DirectoryInfo dir = new DirectoryInfo(task.Catalog);
            dir.MoveTo(task.MovePath);
        }
    }
}
