namespace TestAPI.Database.Models
{
    public class DatabaseSettings
    {
        public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string UsersCollection { get; set; } = null!;

        public string ObjectivesCollection { get; set; } = null!;
    }
}
