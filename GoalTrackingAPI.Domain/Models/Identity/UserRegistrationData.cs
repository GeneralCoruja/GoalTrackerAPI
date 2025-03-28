namespace GoalTrackingAPI.Domain.Models.Identity
{
    using System;
    public class UserRegistrationData
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } = string.Empty;

        public UserRegistrationData(string firstName, string lastName, string username, string email, string password)
        {
            Firstname = firstName;
            Lastname = lastName;
            Username = username;
            Email = email;
            Password = password;
        }
    }
}
