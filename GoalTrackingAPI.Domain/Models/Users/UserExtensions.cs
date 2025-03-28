namespace GoalTrackingAPI.Domain.Models.Users
{
    public static class UserExtensions
    {
        public static User ToDomain(this Database.Models.User user)
        {
            return new User(
                user.Id,
                user.Firstname,
                user.Lastname,
                user.Email,
                user.Password,
                user.Username,
                user.IsAdmin,
                user.CreatedDate,
                user.UpdatedDate);
        }

        public static Database.Models.User ToEntity(this User user)
        {
            return new Database.Models.User
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Username = user.UserName,
                IsAdmin = user.IsAdmin,
                CreatedDate = user.CreatedDate,
                UpdatedDate = user.UpdatedDate
            };
        }
    }
}
