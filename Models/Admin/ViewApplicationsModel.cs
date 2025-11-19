using System.ComponentModel.DataAnnotations;

namespace web.Models.Admin
{
    public class ViewApplicationsModel
    {
        public int ApplicationId { get; set; }

        public int JobId { get; set; }
        public string? JobTitle { get; set; }

        public int UserId { get; set; }
        public string? ApplicantName { get; set; }

        [Required(ErrorMessage = "Application status is required.")]
        public string? ApplicationStatus { get; set; } // Example: Pending, Approved, Rejected

        public DateTime DateApplied { get; set; }

        public string? ResumeUrl { get; set; } // URL to the applicant's resume

        // New property to hold the file path of the submitted document
        public string? DocumentPath { get; set; }
    }

}
