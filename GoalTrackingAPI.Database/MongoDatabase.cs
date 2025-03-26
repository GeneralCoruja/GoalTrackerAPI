namespace GoalTrackingAPI.Database
{
    using Microsoft.Extensions.Options;
    using Models;
    using MongoDB.Driver;
    using GoalTrackingAPI.Database.Clients;

    public class MongoDatabase
    {
        public UserClient Users { get; set; }
        public ObjectiveClient Objectives { get; set; }
        
        public MongoDatabase(IOptions<DatabaseSettings> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
            DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(DatabaseSettings.Value.DatabaseName);

            InitializeClients(DatabaseSettings, mongoDatabase);
        }

        private void InitializeClients(IOptions<DatabaseSettings> settings, IMongoDatabase database) {
            Users = new UserClient(database.GetCollection<User>(settings.Value.UsersCollection));
            Objectives = new ObjectiveClient(database.GetCollection<Objective>(settings.Value.ObjectivesCollection));
        }

    }
}
