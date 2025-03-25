namespace TestAPI.Database.Clients
{
    using MongoDB.Driver;

    public abstract class Client<T>
    {
        protected IMongoCollection<T> _collection;
        public Client(IMongoCollection<T> collection)
        {
            _collection = collection;
        }
    }
}
