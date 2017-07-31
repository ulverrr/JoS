using Autofac;
using Autofac.Integration.Mvc;
using Hangfire;
using JoS.Models.Emails;
using Owin;
using System.Web.Mvc;

namespace JoS.App_Start
{
    public class HangfireInitializer
    {
        private const int ON_TIME = 8;

        public static void ConfigureHangfire(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacDefaultModule());

            var container = builder.Build();
            GlobalConfiguration.Configuration.UseAutofacActivator(container, false);
            JobActivator.Current = new AutofacJobActivator(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.UseSqlServerStorage("JoSConnection");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }

        public static void InitializeJobs()
        {
            RecurringJob.AddOrUpdate<SendEmailService>(job => job.SendMessageOverDay(), Cron.Daily(ON_TIME));
            RecurringJob.AddOrUpdate<SendEmailService>(job => job.SendMessageOverWeek(), Cron.Daily(ON_TIME));
            RecurringJob.AddOrUpdate<SendEmailService>(job => job.SendMessageOverMonth(), Cron.Daily(ON_TIME));
        }
    }
}