using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoS.Models.EmailModels
{
    /// <summary>
    /// Represents class that contains users data getting from DB
    /// </summary>
    public class UserEmail
    {
        /// <summary>
        /// Gets or sets users email
        /// </summary>
        public string To { get; set; }

        /// <summary>
        /// Gets or sets users full name and surname
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets users left days to start study
        /// </summary>
        public int LeftDays { get; set; }
    }
}
