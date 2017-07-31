using System;
using System.IO;

namespace JoS.Models.Emails
{
    public class EmailTemplate : IEmailTemplate
    {
        private readonly string _emailTemplatePath;

        public EmailTemplate()
        {
            _emailTemplatePath = $"{AppDomain.CurrentDomain.BaseDirectory}Views\\Emails";
        }

        /// <summary>
        /// Get email template
        /// </summary>
        /// <param name="tempName">template file name without file type</param>
        /// <returns></returns>
        public string GetTemplate(string tempName)
        {
            var pathToView = $"{_emailTemplatePath}\\{tempName}.cshtml";

            return File.ReadAllText(pathToView);
        }
    }
}
