using System;
using System.ComponentModel.DataAnnotations;
using JoS.Models;

namespace JoS.ViewModel
{
    public class AdminUsersInfoViewModel
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
        /// Get or set user email
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Get or set user date of birthday
        /// </summary>
        [Required]
        public int? Age { get; set; }

        /// <summary>
        /// Get or set user registered date
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Get or set user start study date
        /// </summary>
        public StartStudy StartStudy { get; set; }

    }
}
