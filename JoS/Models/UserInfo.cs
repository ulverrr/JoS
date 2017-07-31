using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JoS.Models
{
    /// <summary>
    /// User information entity
    /// </summary>
    [Table("UserInfo")]
    public class UserInfo
    {
        /// <summary>
        /// Get or set user Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Get or set user name
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Get or set user last name
        /// </summary>
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// Get or set user date of birthday
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirthday { get; set; }

        /// <summary>
        /// Get or set user registered date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Get or sets start study
        /// </summary>
        public StartStudy StartStudy { get; set; }
    }
}