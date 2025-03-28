namespace GoalTrackingAPI.Database.Models
{
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid Id { get; set; }

        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;

        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;

        [BsonElement("email")]
        public string Email { get; set; } = string.Empty;

        [BsonElement("firstname")]
        public string Firstname { get; set; } = string.Empty;

        [BsonElement("lastname")]
        public string Lastname { get; set; } = string.Empty;

        [BsonElement("isAdmin")]
        public bool IsAdmin { get; set; }
        
        [BsonElement("createdDate")]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [BsonElement("updatedDate")]
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
    }
}
