using System;
using System.Linq;
using System.Reflection;
using Hangfire;

namespace EventEmitter.Jobs.Infrastructure
{
    public class JobInitializer
    {
        public void Initialize()
        {
            var instances = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.GetInterfaces().Contains(typeof (IJob))
                      && type.GetConstructor(Type.EmptyTypes) != null
                select Activator.CreateInstance(type) as IJob;
            foreach (var instance in instances)
            {
                BackgroundJob.Enqueue(() => instance.Execute());
            }
        }
    }
}