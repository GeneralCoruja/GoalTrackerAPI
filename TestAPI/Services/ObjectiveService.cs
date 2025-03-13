using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestAPI.Database.Models;

namespace TestAPI.Services
{
    public class ObjectiveService
    {
        const string DATABASE_NAME = "objectives";
        private readonly IMongoCollection<Objective> _objectiveCollection;

        public ObjectiveService(
            IOptions<DatabaseSettings> DatabaseSettings)
        {
            var mongoClient = new MongoClient(
                DatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(DATABASE_NAME);

            _objectiveCollection = mongoDatabase.GetCollection<Objective>(
                DatabaseSettings.Value.UsersCollection);
        }

        public async Task<List<Objective>> GetAsync() =>
        await _objectiveCollection.Find(_ => true).ToListAsync();

        public async Task CreateAsync(Objective newBook) =>
        await _objectiveCollection.InsertOneAsync(newBook);
    }
}
