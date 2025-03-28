namespace GoalTrackingAPI.Domain.Models.Users
{
    using System;

    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public User(string firstName, string lastName, string email, string password, string username, bool isAdmin = false)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = username;
            Password = password;
            IsAdmin = isAdmin;
            UpdatedDate = DateTime.UtcNow;
            CreatedDate = DateTime.UtcNow;
        }

        public User(Guid id, string firstName, string lastName, string email,
            string password, string username, bool isAdmin, DateTime createdDate, DateTime updatedDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = username;
            Password = password;
            IsAdmin = isAdmin;
            CreatedDate = createdDate;
            UpdatedDate = updatedDate;
        }
    }
}
