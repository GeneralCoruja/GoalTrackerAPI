namespace GoalTrackingAPI.Domain.Services
{
    using GoalTrackingAPI.Database;
    using GoalTrackingAPI.Domain.Models.Users;

    public class UserService
    {
        private MongoDatabase _database;
        public UserService(MongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<User>> GetAllAsync() {
            return _database.Users.GetAllAsync().Result.Select(x => x.ToDomain());
        }

        public async Task<User> GetById(string userId) {
            return _database.Users.GetByIdAsync(userId).Result.ToDomain();
        }

        public async Task<User> GetByUsername(string username) {
            return _database.Users.GetByUsernameAsync(username).Result.ToDomain();
        }

        public async Task DeleteByUsername(string username) {
            await _database.Users.DeleteAsync(username);
        }
    }
}