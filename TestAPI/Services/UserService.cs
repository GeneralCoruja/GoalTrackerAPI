namespace TestAPI.Services;

using Microsoft.Extensions.Options;
using MongoDB.Driver;
using TestAPI.Database.Models;

public class UserService
{
    const string DATABASE_NAME = "users";
    private readonly IMongoCollection<User> _userCollection;

    public UserService(
        IOptions<DatabaseSettings> DatabaseSettings)
    {
        var mongoClient = new MongoClient(
            DatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(DATABASE_NAME);

        _userCollection = mongoDatabase.GetCollection<User>(
            DatabaseSettings.Value.UsersCollection);
    }

    public async Task<List<User>> GetAsync() =>
        await _userCollection.Find(_ => true).ToListAsync();

    public async Task<User?> GetAsync(string id) =>
        await _userCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(User newBook) =>
        await _userCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, User updatedBook) =>
        await _userCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _userCollection.DeleteOneAsync(x => x.Id == id);
}