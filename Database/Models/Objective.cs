namespace GoalTrackingAPI.Database.Models
{
    using MongoDB.Bson.Serialization.Attributes;
    using MongoDB.Bson;

    public class Objective
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("userId")]
        public int? UserID { get; set; }

        [BsonElement("title")]
        public string Title { get; set; } = string.Empty;
        
        [BsonElement("description")]
        public bool Description { get; set; }

        [BsonElement("occurence")]
        public string Occurence { get; set; }
    }
}
