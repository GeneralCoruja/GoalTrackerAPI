namespace TestAPI.Database.Clients
{
    using MongoDB.Driver;
    using TestAPI.Database.Models;

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

        // create new user
        public async Task CreateAsync(User newUser) =>
        await _collection.InsertOneAsync(newUser);
    }
}
