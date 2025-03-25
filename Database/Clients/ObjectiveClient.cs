namespace TestAPI.Database.Clients
{
    using MongoDB.Driver;
    using TestAPI.Database.Models;

    public class ObjectiveClient : Client<Objective>
    {
        public ObjectiveClient(IMongoCollection<Objective> objectiveCollection)
            : base(objectiveCollection)
        {
        }

        // get all objectives
        public async Task<List<Objective>> GetAllAsync() =>
        await _collection.Find(_ => true).ToListAsync();

        // create new objectives
        public async Task CreateAsync(Objective newObjective) =>
        await _collection.InsertOneAsync(newObjective);
    }
}
