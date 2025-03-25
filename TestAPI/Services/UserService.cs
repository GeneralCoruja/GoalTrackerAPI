namespace TestAPI.Services
{
    using System.Security.Cryptography;
    using System.Text;
    using TestAPI.Database;
    using TestAPI.Database.Models;
    using TestAPI.Dtos;

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
    }
}