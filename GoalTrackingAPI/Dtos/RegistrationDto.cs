namespace GoalTrackingAPI.Dtos
{
    public class RegistrationDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; } = String.Empty;
    }
}
