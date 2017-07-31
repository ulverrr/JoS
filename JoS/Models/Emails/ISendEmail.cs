namespace JoS.Models.Emails
{
    public interface ISendEmail
    {
        void Send(string toAddress, string subject, string body, bool isBodyHtml = true);
    }
}