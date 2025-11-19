namespace web.Helpers
{
    public static class FakeUserStore
    {
        public static List<User> Users = new List<User>
    {
        new User { Username = "user1", Password = "password1" },
        new User { Username = "user2", Password = "password2" }
    };
    }

    public class User
    {
        // Initialize properties to avoid nullable warning
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Parameterized constructor to initialize with values
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        // Default constructor for scenarios where properties are set later
        public User() { }
    }

}
