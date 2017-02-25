using System;

namespace EventEmitter.Jobs
{
    public interface ICronJob
    {
        void Execute();
        string Cron { get; set; }
    }

    class CronJob1 : ICronJob
    {
        public void Execute()
        {
            Console.Write(1);
        }

        public string Cron { get; set; } = Hangfire.Cron.Hourly();
    }
    class CronJob2 : ICronJob
    {
        public void Execute()
        {
            Console.Write(1);
        }

        public string Cron { get; set; } = Hangfire.Cron.Minutely();
    }
}