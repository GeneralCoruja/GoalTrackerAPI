namespace TestAPI.Database.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("id")]
        public int? InternalID { get; set; }

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;
        
        [BsonElement("isAdmin")]
        public bool IsAdmin { get; set; }

    }
}
