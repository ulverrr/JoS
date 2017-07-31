namespace JoS.Models.Emails
{
    public interface IEmailTemplate
    {
        string GetTemplate(string tempName);
    }
}