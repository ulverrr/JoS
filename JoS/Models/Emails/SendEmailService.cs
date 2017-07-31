using JoS.Models.EmailModels;
using JoS.Repository;

namespace JoS.Models.Emails
{
    internal enum DaysLeft
    {
        Day = 1,
        Week = 7,
        Month = 30
    }

    public class SendEmailService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IEmailTemplate _template;
        private readonly ICompiler _compiler;
        private readonly ISendEmail _sendEmail;

        private const string REMINDER_MAIL_VIEW = "Reminder";
        private const string SUBJECT_RECURRINGJOB = "Reminder for the beginning of training";

        public SendEmailService(IUserInfoRepository userInfoRepository, ISendEmail sendEmail, ICompiler compiler, IEmailTemplate template)
        {
            _userInfoRepository = userInfoRepository;
            _sendEmail = sendEmail;
            _compiler = compiler;
            _template = template;
        }


        public void SendMessageOverDay()
        {
            SendReminderMail((int)DaysLeft.Day);
        }
        public void SendMessageOverWeek()
        {
            SendReminderMail((int)DaysLeft.Week);
        }
        public void SendMessageOverMonth()
        {
            SendReminderMail((int)DaysLeft.Month);
        }

        private void SendReminderMail(int countDays)
        {
            var model = _userInfoRepository.GetDataFromUsersByConcreteDay(countDays);

            var template = _template.GetTemplate(REMINDER_MAIL_VIEW);

            foreach (var user in model)
            {
                var body = _compiler.Compile(template, REMINDER_MAIL_VIEW, new UserEmail
                {
                    Name = user.Name,
                    LeftDays = countDays
                });
                _sendEmail.Send(user.To, SUBJECT_RECURRINGJOB, body);
            }
        }
    }
}