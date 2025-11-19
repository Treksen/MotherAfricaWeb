using System.ComponentModel.DataAnnotations;

namespace web.Models.Admin
{

    public class ManageJobsModel
    {
        public int JobId { get; set; }

        [Required(ErrorMessage = "Job title is required.")]
        public string? JobTitle { get; set; }

        [Required(ErrorMessage = "Company name is required.")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Job description is required.")]
        public string? JobDescription { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string? Location { get; set; }
        public string? Country { get; set; }
        public string? County { get; set; }
        public string? Town { get; set; }

        public DateTime PostedDate { get; set; }

        public bool IsOpen { get; set; } // Indicates if the job is still open
        // Constructor to initialize default values
        public ManageJobsModel() { }

        // Method to add a new job
        public static ManageJobsModel AddNewJob(string jobTitle)
        {
            return new ManageJobsModel
            {
                JobTitle = jobTitle,
                PostedDate = DateTime.Now, // Current date
                IsOpen = true // Mark as open
            };
        }

        internal static void AddNewJob(ManageJobsModel newJob)
        {
            throw new NotImplementedException();
        }
    }
}
