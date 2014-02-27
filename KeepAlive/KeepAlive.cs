using System;
using System.IO;
using System.Net;
using Quartz;
using Quartz.Impl;

namespace KeepAlive
{
    /// <summary>
    /// Class KeepAlive.
    /// </summary>
    public class KeepAlive
    {
        private readonly string _websiteUrl;
        private readonly int _intervalInMinutes;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeepAlive"/> class.
        /// </summary>
        /// <param name="websiteUrl">The website URL.</param>
        /// <param name="intervalInMinutes">The interval in minutes.</param>
        public KeepAlive(string websiteUrl, int intervalInMinutes)
        {
            _websiteUrl = websiteUrl;
            _intervalInMinutes = intervalInMinutes;
        }

        /// <summary>
        /// Starts keeping alive.
        /// </summary>
        public void Start()
        {
            var keepAliveJob = JobBuilder.Create<KeepAliveJob>()
               .UsingJobData("website", _websiteUrl)
               .Build();
            var keepAliveTrigger = TriggerBuilder.Create()
                            .WithSimpleSchedule(x => x.WithIntervalInMinutes(_intervalInMinutes).RepeatForever())
                            .Build();
            // construct a scheduler            
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            scheduler.ScheduleJob(keepAliveJob, keepAliveTrigger);
            scheduler.Start();   
        }
    }
}
