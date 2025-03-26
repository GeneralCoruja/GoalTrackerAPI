namespace GoalTrackingAPI.Services
{
    using GoalTrackingAPI.Database;
    using GoalTrackingAPI.Database.Models;

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
