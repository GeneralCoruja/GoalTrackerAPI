namespace GoalTrackingAPI.Dtos.Users
{
    using Domain = Domain.Models.Users;

    public static class UserExtensions
    {
        public static UserDto ToDTO(this Domain.User user)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.UserName,
            };
        }
    }
}
