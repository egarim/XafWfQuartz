using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Xpo;
using Quartz;
using Quartz.Impl;
using System;
using System.Linq;
using XafWfQuartz.Module.BusinessObjects;

namespace XafWfQuartz.Web
{
    public class JobScheduler
    {
        public static void Start(IObjectSpace Osp)
        {
        
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
            scheduler.Start();

            var os=Osp;
            //TODO aqui tiene que cargar todos los schedule task
            var Tasks =  os.CreateCollection(typeof(ScheduleTask)).Cast<ScheduleTask>().ToList();

            foreach (ScheduleTask task in Tasks)
            {
                JobDataMap newJobDataMap = new JobDataMap();


                //HACK se pasa el dal para poder crear unit of work adentro del job
                newJobDataMap.Add("dal", ((XPObjectSpace)os).Session.DataLayer);
                IJobDetail job = JobBuilder.Create<EmailJob>().UsingJobData(newJobDataMap).Build();

                //ITrigger trigger = TriggerBuilder.Create()
                //    .WithDailyTimeIntervalSchedule
                //      (s =>
                //         s.WithIntervalInHours(24)
                //        .OnEveryDay()
                //        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(0, 0))
                //      )
                //    .Build();

                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity(task.Code, "group1")
                    //.WithCronSchedule("0/15 * * ? * * *")
                    .WithCronSchedule(task.CronExpression)
                    .Build();

                scheduler.ScheduleJob(job, trigger);
            }
          
        }
    }
}