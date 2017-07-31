namespace JoS.Models.Emails
{
    public interface ICompiler
    {
        string Compile<T>(string template, string templateKey, T model);
    }
}