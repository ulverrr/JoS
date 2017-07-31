using JoS.App_Start;
using Microsoft.Owin;
using NLog.Owin.Logging;
using Owin;

[assembly: OwinStartupAttribute(typeof(JoS.Startup))]
namespace JoS
{
    public partial class Startup
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        public void Configuration(IAppBuilder app)
        {
            Logger.Info("Application Start");
            app.UseNLog();
            ConfigureAuth(app);
            HangfireInitializer.ConfigureHangfire(app);

            HangfireInitializer.InitializeJobs();
        }

        public void Init()
        {
            Logger.Info("Application Init");
        }

        public void Dispose()
        {
            Logger.Info("Application Dispose");
        }

        protected void Application_Error()
        {
            Logger.Info("Application Error");
        }


        protected void Application_End()
        {
            Logger.Info("Application End");
        }
    }
}
