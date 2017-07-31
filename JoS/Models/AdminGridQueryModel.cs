using System;

namespace JoS.Models
{
    public class AdminGridQueryModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        public DateTime? RegisteredDateFrom { get; set; }

        public DateTime? RegisteredDateTo { get; set; }

        public DateTime? StudyDateFrom { get; set; }

        public DateTime? StudyDateTo { get; set; }

        public string SortField { get; set; }

        public string SortOrder { get; set; }
    }
}
