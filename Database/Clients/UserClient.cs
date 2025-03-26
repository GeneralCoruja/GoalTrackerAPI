namespace GoalTrackingAPI.Database.Clients
{
    using MongoDB.Driver;
    using GoalTrackingAPI.Database.Models;

    public class UserClient : Client<User>
    {
        public UserClient(IMongoCollection<User> userCollection)
            : base(userCollection)
        {

        }

        // get all user
        public async Task<List<User>> GetAllAsync() =>
            await _collection.Find(_ => true).ToListAsync();

        // get user by username
        public async Task<User> GetByUsernameAsync(string username) =>
            await _collection.Find(x => x.Username == username).FirstOrDefaultAsync();

        // get user by Id
        public async Task<User> GetByIdAsync(string userId)
        {
            var result = await _collection.FindAsync(x => x.Id.Equals(userId));
            return result.FirstOrDefault();
        }

        // create new user
        public async Task CreateAsync(User newUser) =>
            await _collection.InsertOneAsync(newUser);

        // delete user by username
        public async Task DeleteAsync(string username)
        {
            await _collection.DeleteOneAsync(x => x.Username.Equals(username));
        }
    }
}
