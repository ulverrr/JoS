using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JoS.Models.EmailModels;

namespace JoS.Models
{
    public class HangfireModel
    {
        /// <summary>
        /// Gets or sets all users, whom the message should be sent
        /// </summary>
        public List<UserEmail> Users { get; set; }

        /// <summary>
        /// Gets or sets the template name for view mail
        /// </summary>
        public string TemplateName { get; set; }
    }
}
