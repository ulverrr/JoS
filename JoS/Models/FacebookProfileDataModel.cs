using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoS.Models
{
    /// <summary>
    /// Facebook profile data model entity
    /// </summary>
    public class FacebookProfileDataModel
    {
        /// <summary>
        /// User first name from facebook
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User last name from facebook
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// User email from facebook
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User date of birth from facebook
        /// </summary>
        public DateTime DateOfBirthday { get; set; }
    }
}
