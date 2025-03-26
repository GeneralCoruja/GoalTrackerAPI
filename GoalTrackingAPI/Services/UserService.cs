namespace GoalTrackingAPI.Services
{
    using GoalTrackingAPI.Database;
    using GoalTrackingAPI.Database.Models;

    public class UserService
    {
        private MongoDatabase _database;
        public UserService(MongoDatabase database)
        {
            _database = database;
        }

        public async Task<IEnumerable<User>> GetAllAsync() {
            return await _database.Users.GetAllAsync();
        }

        public async Task<User> GetById(string userId) {
            return await _database.Users.GetByIdAsync(userId);
        }

        public async Task<User> GetByUsername(string username) {
            return await _database.Users.GetByUsernameAsync(username);
        }

        public async Task DeleteByUsername(string username) {
            await _database.Users.DeleteAsync(username);
        }
    }
}