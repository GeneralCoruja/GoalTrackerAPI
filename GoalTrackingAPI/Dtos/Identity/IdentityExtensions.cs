namespace GoalTrackingAPI.Dtos.Identity
{
    using Domain = Domain.Models.Identity;

    public static class IdentityExtensions
    {
        public static Domain.UserRegistrationData ToDomain(this RegistrationDto dto)
        {
            return new Domain.UserRegistrationData(
                dto.Firstname,
                dto.Lastname,
                dto.Username,
                dto.Email,
                dto.Password);
        }
    }
}
