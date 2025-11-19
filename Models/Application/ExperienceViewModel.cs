namespace web.Models.Application
{
    public class ExperienceViewModel
    {
        // Initialize string properties to empty strings
        public string Company { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;

        // Initialize DateTime properties to the minimum value
        public DateTime StartDateRole { get; set; } = DateTime.MinValue;
        public DateTime EndDateRole { get; set; } = DateTime.MinValue;

        // Parameterized constructor to initialize with values
        public ExperienceViewModel(string company, string jobTitle, DateTime startDateRole, DateTime endDateRole)
        {
            Company = company;
            JobTitle = jobTitle;
            StartDateRole = startDateRole;
            EndDateRole = endDateRole;
        }

        // Default constructor
        public ExperienceViewModel() { }
    }

}
