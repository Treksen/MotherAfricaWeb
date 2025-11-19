namespace web.Models.Application
{
    public class ProfileViewModel
    {
        // Initialize string properties to empty strings
        public string Firstname { get; set; } = string.Empty;
        public string Secondname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Emailaddress { get; set; } = string.Empty;
        public string Phonenumber { get; set; } = string.Empty;
        public string NationalId { get; set; } = string.Empty;

        // Initialize DateTime property to the minimum value
        public DateTime Dob { get; set; } = DateTime.MinValue;

        // Optional parameterized constructor for custom initialization
        public ProfileViewModel(
            string firstname, string secondname, string lastname,
            string emailaddress, string phonenumber, string nationalId, DateTime dob)
        {
            Firstname = firstname;
            Secondname = secondname;
            Lastname = lastname;
            Emailaddress = emailaddress;
            Phonenumber = phonenumber;
            NationalId = nationalId;
            Dob = dob;
        }

        // Default constructor
        public ProfileViewModel() { }
    }

}
