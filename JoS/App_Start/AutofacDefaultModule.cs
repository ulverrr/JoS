using Autofac;
using Autofac.Integration.Mvc;
using Hangfire;
using JoS.Models;
using JoS.Models.Emails;
using JoS.Repository;
using Microsoft.AspNet.Identity.Owin;
using System.Web;

namespace JoS
{
    public class AutofacDefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule<AutofacWebTypesModule>();
            builder.Register(c => new ApplicationDbContext());
            builder.Register(c => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>())
                   .AsSelf()
                   .InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>())
                   .AsSelf()
                   .InstancePerRequest();

            builder.RegisterType<UserInfoRepository>().As<IUserInfoRepository>();
            builder.RegisterType<StartStudyRepository>().As<IStartStudyRepository>();

            builder.RegisterType<SmtpEmail>().As<ISendEmail>().InstancePerBackgroundJob();
            builder.RegisterType<Compiler>().As<ICompiler>();
            builder.RegisterType<EmailTemplate>().As<IEmailTemplate>();
            builder.RegisterType<SendEmailService>();
        }
    }
}