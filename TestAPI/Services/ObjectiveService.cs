namespace TestAPI.Services
{
    using TestAPI.Database;
    using TestAPI.Database.Models;

    public class ObjectiveService
    {
        private MongoDatabase _database;
        public ObjectiveService(MongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Objective>> GetAllAsync()
        {
            return await _database.Objectives.GetAllAsync();
        }
    }
}
