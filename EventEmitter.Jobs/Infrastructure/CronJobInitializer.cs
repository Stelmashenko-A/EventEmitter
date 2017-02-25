using System;
using System.Linq;
using System.Reflection;
using Hangfire;

namespace EventEmitter.Jobs.Infrastructure
{
    public class CronJobInitializer
    {
        public void Initialize()
        {
            var instances = from type in Assembly.GetExecutingAssembly().GetTypes()
                            where type.GetInterfaces().Contains(typeof(ICronJob))
                                  && type.GetConstructor(Type.EmptyTypes) != null
                            select Activator.CreateInstance(type) as ICronJob;
            foreach (var instance in instances)
            {
                RecurringJob.AddOrUpdate(instance.GetType().Name, () => instance.Execute(), instance.Cron);
            }
        }
    }
    
}