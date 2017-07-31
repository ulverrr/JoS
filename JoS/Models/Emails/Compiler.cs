using RazorEngine;
using RazorEngine.Templating;

namespace JoS.Models.Emails
{
    public class Compiler : ICompiler
    {
        public string Compile<T>(string template, string templateKey, T model)
        {
            var result = Engine.Razor.IsTemplateCached(templateKey, typeof(T))
                ? Engine.Razor.Run(templateKey, typeof(T), model)
                : Engine.Razor.RunCompile(template, templateKey, typeof(T), model);

            return result;
        }
    }
}
