namespace GoalTrackingAPI.Identity
{
    public class JwtTokenConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int TokenLifetime { get; set; }
    }
}
