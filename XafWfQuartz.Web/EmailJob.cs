using DevExpress.Xpo;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using XafWfQuartz.Module.BusinessObjects;

namespace XafWfQuartz.Web
{
    public class EmailJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var Dal= context.JobDetail.JobDataMap["dal"] as IDataLayer;
            var UoW = new UnitOfWork(Dal);
            var ScheduleTasks = UoW.Query<ScheduleTask>().ToArray();
            Debug.WriteLine("Email Sent");
            //using (var message = new MailMessage("user@gmail.com", "user@live.co.uk"))
            //{
            //    message.Subject = "Test";
            //    message.Body = "Test at " + DateTime.Now;
            //    using (SmtpClient client = new SmtpClient
            //    {
            //        EnableSsl = true,
            //        Host = "smtp.gmail.com",
            //        Port = 587,
            //        Credentials = new NetworkCredential("user@gmail.com", "password")
            //    })
            //    {
            //        client.Send(message);
            //    }
            //}
        }

        Task IJob.Execute(IJobExecutionContext context)
        {
            var Dal = context.JobDetail.JobDataMap["dal"] as IDataLayer;
            var UoW = new UnitOfWork(Dal);
            var ScheduleTasks = UoW.Query<ScheduleTask>().ToArray();
            Debug.WriteLine("Email Sent");
            Debug.WriteLine("Email Sent");
            return null;
           
            //throw new NotImplementedException();
        }
    }
}