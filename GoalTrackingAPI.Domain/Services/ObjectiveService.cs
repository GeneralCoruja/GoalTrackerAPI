namespace GoalTrackingAPI.Domain.Services
{
    using GoalTrackingAPI.Database;
    using GoalTrackingAPI.Domain.Models.Objective;

    public class ObjectiveService
    {
        private MongoDatabase _database;
        public ObjectiveService(MongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<Objective>> GetAllAsync()
        {
            return _database.Objectives.GetAllAsync().Result.Select(x => x.ToDomain());
        }

        public async Task CreateAsync(Objective objective) {
            await _database.Objectives.CreateAsync(objective.ToEntity());
        }
    }
}
