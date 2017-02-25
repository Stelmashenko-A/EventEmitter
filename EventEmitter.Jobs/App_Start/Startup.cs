using System;
using EventEmitter.Jobs;
using EventEmitter.Jobs.Infrastructure;
using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace EventEmitter.Jobs
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("Jobs");
            app.UseHangfireDashboard("");
            app.UseHangfireServer();
            var t = new JobInitializer();
            t.Initialize();
            var c = new CronJobInitializer();
            c.Initialize();
            RecurringJob.AddOrUpdate("some-id", () => Console.WriteLine(), Cron.Minutely);
        }
    }
}