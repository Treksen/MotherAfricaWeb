namespace web.Models.Application
{
    public class EducationViewModel
    {
        // Initialize string properties to empty strings
        public string Institution { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;

        // Initialize DateTime properties to the current date/time or a specific default
        public DateTime StartDateEducation { get; set; } = DateTime.MinValue;
        public DateTime EndDateEducation { get; set; } = DateTime.MinValue;

        // Parameterized constructor to initialize with values
        public EducationViewModel(string institution, string degree, DateTime startDateEducation, DateTime endDateEducation)
        {
            Institution = institution;
            Degree = degree;
            StartDateEducation = startDateEducation;
            EndDateEducation = endDateEducation;
        }

        // Default constructor
        public EducationViewModel() { }
    }

}
