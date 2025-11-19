namespace web.Models.Admin
{
    public class IndexModel
    {
        public string? WelcomeMessage { get; set; }
        public int JobCount { get; set; }
        public int TotalUsersRegistered { get; set; }
        public int TotalApplications { get; set; }

        // New properties for gender distribution
        public int? TotalMaleApplicants { get; set; }
        public int? TotalFemaleApplicants { get; set; }

        public int AgeGroup18To25 { get; set; }
        public int AgeGroup26To35 { get; set; }
        public int AgeGroup36To45 { get; set; }
        public int AgeGroup46To55 { get; set; }
        public int AgeGroup56Plus { get; set; }

    }
}
