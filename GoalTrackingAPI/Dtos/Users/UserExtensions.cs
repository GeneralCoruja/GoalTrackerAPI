using GoalTrackingAPI.Database.Models;

namespace GoalTrackingAPI.Dtos.Users
{
    public static class UserExtensions
    {
        public static UserDto ToDTO(this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = $"{user.Firstname} {user.Lastname}",
                Username = user.Username,
            };
        }
    }
}
