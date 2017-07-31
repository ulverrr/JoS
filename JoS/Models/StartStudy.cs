using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JoS.Models
{
    /// <summary>
    /// Entity for start study
    /// </summary>
    public class StartStudy
    {
        /// <summary>
        /// Get or set user id
        /// </summary>
        [Key, ForeignKey("UserInfo")]
        public int Id { get; set; }

        /// <summary>
        /// Get or set user study date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime StudyDate { get; set; }

        /// <summary>
        /// Gets or sets user info
        /// </summary>
        public UserInfo UserInfo { get; set; }
    }
}
